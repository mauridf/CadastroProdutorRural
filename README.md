# Cadastro de Produtor Rural API

Esta � uma API para cadastro de produtores rurais, fazendas, culturas e gerenciamento de usu�rios. A API foi desenvolvida utilizando ASP.NET Core.

## Estrutura do Projeto

- **Controllers**: Cont�m as classes que gerenciam as requisi��es HTTP.
- **Models**: Cont�m as entidades do dom�nio, como `Usuario`, `ProdutorRural`, `Fazenda`, `Cultura`, e `FazendaCultura`.
- **Services**: Cont�m a l�gica de neg�cios e manipula��o de dados.
- **Data**: Cont�m a configura��o do banco de dados e o contexto.

## Endpoints

### Usu�rio

- `POST /api/usuario/register`: Registra um novo usu�rio.
- `POST /api/usuario/login`: Faz login e gera um token.

### Produtor Rural

- `POST /api/produtor`: Cadastra um produtor rural.
- `GET /api/produtor`: Busca todos os produtores rurais.
- `GET /api/produtor/{id}`: Busca um produtor rural por ID.
- `PUT /api/produtor`: Atualiza um produtor rural.
- `DELETE /api/produtor/{id}`: Deleta um produtor rural.

### Fazenda

- `POST /api/fazenda`: Cadastra uma fazenda.
- `GET /api/fazenda`: Busca todas as fazendas.
- `GET /api/fazenda/{id}`: Busca uma fazenda por ID.
- `PUT /api/fazenda`: Atualiza uma fazenda.
- `DELETE /api/fazenda/{id}`: Deleta uma fazenda.

### Cultura

- `POST /api/cultura`: Cadastra uma cultura.
- `GET /api/cultura`: Busca todas as culturas.
- `GET /api/cultura/{id}`: Busca uma cultura por ID.
- `PUT /api/cultura`: Atualiza uma cultura.
- `DELETE /api/cultura/{id}`: Deleta uma cultura.

### Dashboard

- `GET /api/dashboard/total-fazendas`: Total de fazendas cadastradas.
- `GET /api/dashboard/total-hectares`: Total de hectares de todas as fazendas.
- `GET /api/dashboard/produtores-por-estado`: Total de produtores cadastrados por estado.
- `GET /api/dashboard/culturas-plantadas`: Total de culturas plantadas separadas por cultura.
- `GET /api/dashboard/uso-solo`: Total de uso do solo.

## Como Executar

1. Clone o reposit�rio.
2. Navegue at� a pasta do projeto.
3. Execute `dotnet restore` para restaurar as depend�ncias.
4. Execute `dotnet run` para iniciar a API.
5. Acesse `http://localhost:5000` para usar a API.

## Tecnologias Usadas

- ASP.NET Core
- Entity Framework Core
- BCrypt
- JWT

## Licen�a

Este projeto est� sob a licen�a MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
