# Cadastro de Produtor Rural API

Esta é uma API para cadastro de produtores rurais, fazendas, culturas e gerenciamento de usuários. A API foi desenvolvida utilizando ASP.NET Core.

## Estrutura do Projeto

- **Controllers**: Contém as classes que gerenciam as requisições HTTP.
- **Models**: Contém as entidades do domínio, como `Usuario`, `ProdutorRural`, `Fazenda`, `Cultura`, e `FazendaCultura`.
- **Services**: Contém a lógica de negócios e manipulação de dados.
- **Data**: Contém a configuração do banco de dados e o contexto.

## Endpoints

### Usuário

- `POST /api/usuario/register`: Registra um novo usuário.
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

1. Clone o repositório.
2. Navegue até a pasta do projeto.
3. Execute `dotnet restore` para restaurar as dependências.
4. Execute `dotnet run` para iniciar a API.
5. Acesse `http://localhost:5000` para usar a API.

## Tecnologias Usadas

- ASP.NET Core
- Entity Framework Core
- BCrypt
- JWT

## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
