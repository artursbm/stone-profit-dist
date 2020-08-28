# stone-profit-dist
Desafio Stone - Distribuição de lucros

## Arquivos do Projeto
Para acessar os arquivos do projeto, [clique aqui](./Profit-Distribution)

## Contrato API
A API foi desenhada utilizando OpenAPI 3, e o contrato criado para referência pode ser acessado [aqui](./openapi.json)

## Base de dados
A base de funcionários da empresa, na qual o projeto se baseia para calcular os valores de distribuição de lucro está descrita [neste arquivo .json](./database-jsons/employees.json)

Para os cálculos de pesos por área de atuação, tempo de admissão e faixa salarial, foram criados [novos arquivos](./database-jsons) de base de dados, que serão armazenados no Firebase, facilitando assim qualquer possível modificação nos dados sem necessariamente alterar as regras de negócio baseadas nestes dados.

## Como fazer build e deploy da aplicação
`TODO`

# TODOs
- [X] Create logic to map values to weights on profit calculation
- [X] Handle errors on Web API;
- [ ] Unit Tests;
- [ ] Deploy service to container
- [ ] Create front client (react?) to consume API
- [ ] Try to parallelize profit distribution method for each employee