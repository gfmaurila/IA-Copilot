---
name: validation
description: Implementar validação de entrada e regras prévias do caso de uso.
---

# validation

## Quando usar
Implementar validação de entrada e regras prévias do caso de uso.

## Procedimento
- Validar formato e obrigatoriedade antes do handler.
- Invariantes de negócio permanecem no domínio.
- Retornar erros previsíveis e testáveis.
- Não duplicar a mesma validação em múltiplas camadas.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
