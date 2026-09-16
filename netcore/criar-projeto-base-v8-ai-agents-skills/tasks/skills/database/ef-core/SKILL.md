---
name: ef-core
description: Implementar persistência com Entity Framework Core e migrations controladas.
---

# ef-core

## Quando usar
Implementar persistência com Entity Framework Core e migrations controladas.

## Procedimento
- Configurar mappings fora das entidades quando definido.
- Evitar lazy loading implícito.
- Gerar migration apenas após alteração de modelo aprovada.
- Revisar SQL/migration antes de aplicar.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
