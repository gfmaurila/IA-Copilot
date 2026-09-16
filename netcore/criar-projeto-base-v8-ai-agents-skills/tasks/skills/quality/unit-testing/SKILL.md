---
name: unit-testing
description: Criar testes unitários rápidos para regras e handlers isoláveis.
---

# unit-testing

## Quando usar
Criar testes unitários rápidos para regras e handlers isoláveis.

## Procedimento
- Testar comportamento observável, não detalhes internos.
- Cobrir caminho feliz, bordas e falhas relevantes.
- Mockar apenas fronteiras necessárias.
- Testes devem ser determinísticos.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
