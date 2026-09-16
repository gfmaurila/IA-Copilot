---
name: docker
description: Criar ou ajustar Dockerfile e Docker Compose do projeto.
---

# docker

## Quando usar
Criar ou ajustar Dockerfile e Docker Compose do projeto.

## Procedimento
- Usar variáveis de ambiente para segredos.
- Adicionar healthcheck quando necessário.
- Evitar imagens e serviços não utilizados.
- Validar com `docker compose config` e build quando disponível.

## Restrições
- Respeitar `tasks/rules/`, requisitos e `tasks/generated/ARCHITECTURE_PLAN.md`.
- Não adicionar abstrações, pacotes ou infraestrutura sem necessidade da task.
- Alterar somente arquivos relacionados ao caso de uso atual.
- Executar a validação indicada na task antes de concluir.
