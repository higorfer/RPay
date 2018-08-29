# RPay

Para rodar pelo visual studio, basta abrir a solution, buildar e executar.

API publicada em http://rpay.azurewebsites.net/api/lojista

Obs.: As APIs estão contemplando retornos RESTFUL

CRUD Lojista
Contratos para testes no POSTMAN:

GET
http://rpay.azurewebsites.net/api/lojista/{id}
- GET - Sem contrato
- Retorna todos os lojistas cadastrados
- Para filtro opcional da consulta, utilizar o parâmetro "id" ao final da URL

POST
http://rpay.azurewebsites.net/api/lojista
- Contrato de exemplo:
{
    "DscLojista": "Restaurante Mineiro",
    "Cnpj": "33.000.000/0002-99",
    "Email": "tutu@teste.com",
    "Telefone": "23912345678"
}

DELETE
http://rpay.azurewebsites.net/api/lojista/{id}
- DELETE - Sem Contrato
- Para especificar qual lojista deletar, utilizar o parâmetro "id" ao final da URL

PUT
http://rpay.azurewebsites.net/api/lojista/{id}
- Contrato de exemplo:
{
    "DscLojista": "Restaurante Mineiro",
    "Cnpj": "33.000.000/0002-99",
    "Email": "tutuamineira@teste.com",
    "Telefone": "22222222",
    "BlAtivo": 1
}
- Para especificar qual lojista alterar, utilizar o parâmetro "id" ao final da URL


Transações
GET
http://rpay.azurewebsites.net/api/sales/{id}
- GET - Sem contrato
- Retorna todas as transações cadastradas
- Para filtro detalhado da consulta, utilizar o parâmetro "id" ao final da URL
