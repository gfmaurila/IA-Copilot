---
name: dapper
description: Implementar acesso a dados com Dapper com SQL explícito e parametrizado.
---

# dapper

## Quando usar
Implementar acesso a dados com Dapper com SQL explícito e parametrizado.

## Procedimento
- SQL deve ficar em local definido pela arquitetura.
- Usar parâmetros nomeados.
- Mapear retorno de forma explícita.
- Abrir/fechar conexão e transação com ciclo de vida claro.
- Não misturar Dapper e EF na mesma operação sem decisão arquitetural.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
