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
    public class LojistaDataProvider : ILojistaDataProvider
    {
        private readonly string connectionString = "Data Source = tcp:radixpay.database.windows.net,1433; Database = RadixPay; User ID = rpay; Password = Radix1234; Encrypt = True; TrustServerCertificate = True;";

        public async Task AddLojista(Lojista lojista)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DscLojista", lojista.DscLojista);
                dynamicParameters.Add("@CNPJ", lojista.Cnpj);
                dynamicParameters.Add("@Email", lojista.Email);
                dynamicParameters.Add("@Telefone", lojista.Telefone);

                await sqlConnection.ExecuteAsync(
                    "spAddLojista",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteLojista(int IdLojista)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLojista", IdLojista);
                await sqlConnection.ExecuteAsync(
                    "spDeleteLojista",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Lojista> GetLojista(int IdLojista)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLojista", IdLojista);
                return await sqlConnection.QuerySingleOrDefaultAsync<Lojista>(
                    "spGetLojista",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Lojista>> GetLojistas()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Lojista>(
                    "spGetLojistas",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateLojista(int idLojista, Lojista lojista)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdLojista", idLojista);
                dynamicParameters.Add("@DscLojista", lojista.DscLojista);
                dynamicParameters.Add("@CNPJ", lojista.Cnpj);
                dynamicParameters.Add("@Email", lojista.Email);
                dynamicParameters.Add("@Telefone", lojista.Telefone);
                dynamicParameters.Add("@BlAtivo", lojista.BlAtivo);
                await sqlConnection.ExecuteAsync(
                    "spUpdateLojista",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}