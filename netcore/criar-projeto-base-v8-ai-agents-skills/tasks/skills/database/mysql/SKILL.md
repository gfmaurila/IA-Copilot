---
name: mysql
description: Implementar persistência e scripts MySQL conforme versão definida.
---

# mysql

## Quando usar
Implementar persistência e scripts MySQL conforme versão definida.

## Procedimento
- Usar parâmetros e tipos adequados.
- Considerar charset/collation somente quando relevante.
- Evitar SQL dependente de versão não declarada.
- Validar migrations contra o ambiente alvo.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
