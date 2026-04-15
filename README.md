# Projeto de Software - API de Gestão de Produtos

Projeto desenvolvido para a disciplina de Programação com Acesso a Banco de Dados.

## Desenvolvedores

- Anderson Garcia
- Gabriel Lucena

## Professor

- Joao Eujacio

## Funcionalidades

- CRUD de produtos
- Gerenciamento de categorias
- Registro de vendas
- Geração de relatórios

## Tecnologias

- .NET 8 (C#)
- Entity Framework Core (MySQL)
- Swagger

## Estrutura do Projeto

A estrutura segue o padrão de camadas:

- **Controllers**: Endpoints da API.
- **Models**: Entidades do banco de dados.
- **DataContexts**: Configuração do Entity Framework Core.
- **Excecoes**: Tratamento de erros customizados.

## Banco de Dados

O projeto utiliza MySQL. A configuração da string de conexão deve ser realizada no arquivo `appsettings.json`.

A API possui interface Swagger para testes das rotas.
