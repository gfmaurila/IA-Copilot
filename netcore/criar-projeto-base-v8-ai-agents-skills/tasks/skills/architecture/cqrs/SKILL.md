---
name: cqrs
description: Aplicar CQRS quando a arquitetura exigir separação entre escrita e leitura.
---

# cqrs

## Quando usar
Aplicar CQRS quando a arquitetura exigir separação entre escrita e leitura.

## Procedimento
- Commands alteram estado e não servem como consultas.
- Queries não alteram estado.
- Handlers devem ter responsabilidade pequena e explícita.
- Não criar CQRS cerimonial para operações que a arquitetura não exige.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
