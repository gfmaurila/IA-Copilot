---
name: vertical-slices
description: Organizar funcionalidades por caso de uso usando Vertical Slice Architecture.
---

# vertical-slices

## Quando usar
Organizar funcionalidades por caso de uso usando Vertical Slice Architecture.

## Procedimento
- Manter endpoint, request/command/query, handler e validação próximos da feature.
- Evitar pastas horizontais globais para Commands/Queries/Handlers.
- Compartilhar somente o que for realmente transversal.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
