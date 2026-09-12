# Criar Projeto Batch

## Objetivo
Criar Console Application para Windows em C#/.NET 10 que lê registros de uma tabela origem, processa e grava em uma tabela destino.

## Stack
- C# / .NET 10
- Console Application
- CQRS
- Mediator
- Entity Framework Core
- SQL Server
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Logging
- xUnit para testes

## Projetos
- `Batch.Console`: bootstrap, configuração, DI, logging, execução e exit code.
- `Batch.Application`: Commands, Queries, Handlers, DTOs e interfaces.
- `Batch.Infrastructure`: EF Core, DbContext, configurações e repositories.
- `Batch.Application.Tests`: testes unitários.
- `Batch.Integration.Tests`: testes de integração.

## Regras CQRS
Queries apenas leem. Commands coordenam alterações de estado. `Program.cs` não contém regra de negócio.

## Execução
`Program.cs -> Mediator -> ProcessDataCommand -> ProcessDataCommandHandler -> GetSourceDataQuery -> origem -> processamento -> destino`.

## Batch
Suportar CancellationToken, I/O assíncrono, lotes configuráveis, transação quando aplicável, idempotência, logs e resultado final.

## Exit codes
- 0: sucesso
- 1: erro
