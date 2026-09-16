---
name: oracle
description: Implementar acesso e scripts para Oracle respeitando versão e schema definidos.
---

# oracle

## Quando usar
Implementar acesso e scripts para Oracle respeitando versão e schema definidos.

## Procedimento
- Qualificar schema quando necessário.
- Usar bind parameters.
- Não assumir recursos de versões mais novas que a definida.
- Preservar tipos Oracle e estratégia transacional existente.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
