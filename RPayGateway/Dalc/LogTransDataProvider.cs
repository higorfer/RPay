using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RPayGateway.Models;

namespace RPayGateway.Dalc
{
    public class LogTransDataProvider : ILogTransDataProvider
    {
        private readonly string connectionString = "Data Source = tcp:radixpay.database.windows.net,1433; Database = RadixPay; User ID = rpay; Password = Radix1234; Encrypt = True; TrustServerCertificate = True;";

        public async Task AddLogTrans(string strReqJson, int idLojista, int idBandeira)
        {
            //Obtem as configuracoes do lojista
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLojista", idLojista);
                dynamicParameters.Add("@IdBandeira", idBandeira);
                //dynamicParameters.Add("@StrReqJson", strReqJson);
                //DtTrans insere com getdate() default
                await sqlConnection.ExecuteAsync(
                    "spGetCfgLojista",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }

            //Aqui é criada a requisição ao adquirente pegando no retorno a string do endpoint

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                //dados mockados
                var logTrans = new LogTrans();
                logTrans.IdLojistaCfg = 1;
                logTrans.IdLojistaCfgBandeira = 1;

                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLojista", idLojista);
                dynamicParameters.Add("@IdLojistaCfg", logTrans.IdLojistaCfg);
                dynamicParameters.Add("@IdLojistaCfgBandeira", logTrans.IdLojistaCfgBandeira);
                dynamicParameters.Add("@StrReqJson", strReqJson);
                //DtTrans insere com getdate() default
                await sqlConnection.ExecuteAsync(
                    "spAddLogTrans",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<LogTransDet>> GetLogTrans(int idLogTrans)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLogTrans", idLogTrans);
                return await sqlConnection.QueryAsync<LogTransDet>(
                    "spGetLogTrans",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<LogTransDet>> GetLogTrans()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<LogTransDet>(
                    "spGetLogTrans",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
        
    }
}