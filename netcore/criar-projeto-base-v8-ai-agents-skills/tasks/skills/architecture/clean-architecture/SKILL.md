---
name: clean-architecture
description: Preservar limites, direção de dependências e independência do domínio.
---

# clean-architecture

## Quando usar
Preservar limites, direção de dependências e independência do domínio.

## Procedimento
- Domínio não depende de infraestrutura.
- Dependências apontam para dentro.
- Contratos ficam no limite que os possui.
- Evitar camada vazia ou abstração sem consumidor real.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
