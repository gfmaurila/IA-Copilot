# Spec 001 - Project Foundation

## Objetivo
Gerar a fundação executável do Batch .NET 10.

## Entregáveis
1. Solution e projetos Console/Application/Infrastructure/Testes.
2. Referências entre projetos conforme arquitetura.
3. Pacote Mediator e registro no DI.
4. EF Core SQL Server e DbContext.
5. `GetSourceDataQuery` + handler.
6. `ProcessDataCommand` + handler.
7. Interfaces de origem/destino e implementações.
8. `appsettings.json` com ConnectionStrings e seção Batch.
9. ILogger e códigos de saída.
10. Testes básicos.

## Modelo de dados
A modelagem real será fornecida posteriormente. Não inventar colunas. Use placeholders claramente marcados apenas onde necessário para compilar.

## Fora de escopo
Kafka, RabbitMQ, Redis, MassTransit, Domain Events, APIs, frontend, JWT, Docker e microservices.
