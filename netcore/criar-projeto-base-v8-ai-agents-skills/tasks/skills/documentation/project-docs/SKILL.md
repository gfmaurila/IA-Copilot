---
name: project-docs
description: Atualizar documentação para refletir exatamente a entrega aprovada.
---

# project-docs

## Quando usar
Atualizar documentação para refletir exatamente a entrega aprovada.

## Procedimento
- Documentar execução, configuração, migrations e endpoints afetados.
- Não declarar feature como pronta antes dos gates.
- Preferir exemplos mínimos e copiáveis.
- Manter README como porta de entrada e detalhes extensos em `docs/`.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
