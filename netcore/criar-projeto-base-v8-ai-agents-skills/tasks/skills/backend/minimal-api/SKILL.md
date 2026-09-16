---
name: minimal-api
description: Criar endpoints ASP.NET Core Minimal API enxutos e alinhados a Vertical Slices.
---

# minimal-api

## Quando usar
Criar endpoints ASP.NET Core Minimal API enxutos e alinhados a Vertical Slices.

## Procedimento
- Endpoint faz binding, autorização, despacho do caso de uso e mapeamento HTTP.
- Regra de negócio não fica no endpoint.
- Usar respostas HTTP consistentes e contratos explícitos.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
