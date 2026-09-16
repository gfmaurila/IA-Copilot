---
name: domain-events
description: Criar e publicar eventos de domínio para fatos relevantes do negócio.
---

# domain-events

## Quando usar
Criar e publicar eventos de domínio para fatos relevantes do negócio.

## Procedimento
- Nomear eventos no passado (Created, Updated, Approved).
- Disparar somente após invariantes válidas.
- Evitar eventos para detalhes puramente técnicos.
- Definir claramente transação e momento de publicação.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
