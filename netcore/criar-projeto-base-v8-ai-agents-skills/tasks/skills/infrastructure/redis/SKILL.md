---
name: redis
description: Usar Redis para cache, estado efêmero ou coordenação conforme arquitetura.
---

# redis

## Quando usar
Usar Redis para cache, estado efêmero ou coordenação conforme arquitetura.

## Procedimento
- Definir prefixo e TTL.
- Não tratar Redis como fonte permanente sem decisão explícita.
- Prever indisponibilidade e estratégia de fallback quando aplicável.
- Não armazenar segredo em chave sem proteção adequada.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
