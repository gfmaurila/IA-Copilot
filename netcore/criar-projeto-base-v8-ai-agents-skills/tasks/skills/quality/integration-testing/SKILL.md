---
name: integration-testing
description: Criar testes de integração para banco, HTTP ou infraestrutura real de teste.
---

# integration-testing

## Quando usar
Criar testes de integração para banco, HTTP ou infraestrutura real de teste.

## Procedimento
- Isolar dados por teste.
- Preparar e limpar estado de forma previsível.
- Exercitar integração real relevante.
- Não substituir integração por mocks quando o objetivo é provar compatibilidade.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
