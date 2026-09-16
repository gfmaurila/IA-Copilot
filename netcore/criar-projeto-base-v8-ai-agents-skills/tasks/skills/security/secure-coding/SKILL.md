---
name: secure-coding
description: Aplicar checklist de segurança nas alterações de aplicação e infraestrutura.
---

# secure-coding

## Quando usar
Aplicar checklist de segurança nas alterações de aplicação e infraestrutura.

## Procedimento
- Validar autorização além de autenticação.
- Nunca registrar senha, token ou segredo.
- Parametrizar consultas.
- Validar entrada em fronteiras.
- Aplicar menor privilégio.
- Dependências novas exigem justificativa.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
