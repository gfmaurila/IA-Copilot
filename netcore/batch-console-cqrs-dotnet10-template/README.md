# Batch Base - .NET 10

Template de projeto Batch/Console para Windows usando C#, .NET 10, CQRS, Mediator, EF Core e SQL Server.

Fluxo principal: tabela origem -> consulta CQRS -> processamento -> tabela destino.

Não utiliza Kafka, RabbitMQ, Redis, MassTransit, Domain Events, APIs ou frontend.
