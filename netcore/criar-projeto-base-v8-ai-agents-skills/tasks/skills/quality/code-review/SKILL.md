---
name: code-review
description: Executar revisão independente orientada a requisitos, risco e manutenção.
---

# code-review

## Quando usar
Executar revisão independente orientada a requisitos, risco e manutenção.

## Procedimento
- Conferir critérios de aceite e diff relacionado.
- Procurar regressões, segurança, transação, concorrência e erros silenciosos.
- Classificar achados como BLOCKER/HIGH/MEDIUM/LOW/NOTE.
- Não bloquear por preferência estética sem regra ou impacto.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
