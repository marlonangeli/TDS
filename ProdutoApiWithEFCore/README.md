# ProdutoApiWithEFCore

Projeto de exemplo de uma API REST utilizando Minimal API do .NET 6.<br>
É uma API simples que permite a criação, consulta, atualização e exclusão de produtos. Utiliza persistência em banco de dados, utilizando Entity Framework Core e SQLite.

## Como executar

### Pré-requisitos

- .NET 6
- Visual Studio 2022

### Executando

1. Entre no diretório `Produtos.Data` e execute o comando `dotnet ef database update` para criar o banco de dados.
2. Abra o arquivo `ProdutoApiWithEFCore.sln` no Visual Studio 2022.
3. Execute o projeto `Produtos.Api`.

## Tecnologias utilizadas

- .NET 6
- Entity Framework Core
- SQLite
- Swagger

---

## Erro ao realizar `migration` ou `update` do banco de dados

Se houver algum erro ao realizar a `migration` ou `update` do banco de dados, execute o comando `dotnet tool install --global dotnet ef` para instalar o pacote `dotnet ef`.<br>
Em seguida, execute o comando `dotnet ef database update -s ..\Produtos.Api` sendo o parâmetro `-s` referência a `--startup-project` que é o projeto de inicialização.
