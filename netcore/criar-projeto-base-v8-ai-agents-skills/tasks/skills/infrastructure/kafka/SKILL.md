---
name: kafka
description: Implementar publicação/consumo Kafka com contratos e semântica explícita.
---

# kafka

## Quando usar
Implementar publicação/consumo Kafka com contratos e semântica explícita.

## Procedimento
- Definir topic, key e consumer group.
- Consumidores devem tolerar reprocessamento.
- Definir estratégia de erro/retry.
- Evitar depender de ordem global quando apenas ordem por key é garantida.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
