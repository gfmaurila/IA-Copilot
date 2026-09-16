---
name: sqlserver
description: Implementar persistência ou scripts específicos para Microsoft SQL Server.
---

# sqlserver

## Quando usar
Implementar persistência ou scripts específicos para Microsoft SQL Server.

## Procedimento
- Usar parâmetros; nunca concatenar entrada em SQL.
- Definir índices e constraints somente com justificativa.
- Tratar transações explicitamente quando houver múltiplas escritas.
- Scripts devem ser idempotentes quando a task exigir.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
