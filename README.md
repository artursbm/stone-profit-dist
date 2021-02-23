[![.NET Build](https://github.com/artursbm/stone-profit-dist/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/artursbm/stone-profit-dist/actions/workflows/dotnet.yml)

# stone-profit-dist
Desafio Stone - Distribuição de lucros

## Arquivos do Projeto
Para acessar os arquivos do projeto, [clique aqui](./Profit-Distribution)

## Contrato API
A API foi gerada utilizando a framework NSwag, e para acessar o contrato no formato Swagger/OpenAPI, com a aplicação rodando, basta entrar no endereço `http://localhost:8080/swagger`.

## Base de dados
A base de funcionários da empresa, na qual o projeto se baseia para calcular os valores de distribuição de lucro está descrita [neste arquivo .json](./database-jsons/employees.json)

Para os cálculos de pesos por área de atuação, tempo de admissão e faixa salarial, foram criados [novos arquivos](./database-jsons) de base de dados, que serão armazenados no Firebase, facilitando assim qualquer possível modificação nos dados sem necessariamente alterar as regras de negócio baseadas nestes dados.

## Como fazer build e deploy da aplicação
Para rodar a aplicação utilizando Docker (API RESTful), clone o projeto para a máquina e siga os passos abaixo:

```sh
cd ./ProfitDistribution
```    
```sh
docker-compose up -d
```
```sh
# Depois de a aplicação iniciar, para fazer um teste usando cURL, basta digitar, por exemplo:

curl 'http://localhost:8080/api/profit-dist/employees/profit?totalAmount=500000' 

```
## Teste pelo Postman
Utiilize a collection [ProfitDistribution](./Postman/collection.json) para fazer testes no Postman.
