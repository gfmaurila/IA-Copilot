---
name: rabbitmq
description: Implementar mensageria RabbitMQ com contratos e tratamento de falhas.
---

# rabbitmq

## Quando usar
Implementar mensageria RabbitMQ com contratos e tratamento de falhas.

## Procedimento
- Definir exchange/queue/routing key explicitamente.
- Consumidor deve considerar idempotência.
- Definir ack/nack e retry/DLQ quando necessário.
- Versionar contratos de mensagens relevantes.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
