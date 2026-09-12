# COPILOT - Projeto Batch

Leia nesta ordem antes de gerar código:
1. `CRIAR-PROJETO.md`
2. `tasks/rules/`
3. a Spec solicitada em `tasks/specs/changes/`
4. somente as Skills necessárias em `tasks/skills/batch/`

## Restrições
Este projeto NÃO utiliza Kafka, RabbitMQ, Redis, MassTransit, Azure Service Bus, filas, tópicos, event streaming, Domain Events, microservices, API, frontend ou autenticação.

Não invente campos de tabelas que não tenham sido fornecidos. O processamento é local. `async/await` deve ser usado para I/O e `CancellationToken` deve ser propagado.
