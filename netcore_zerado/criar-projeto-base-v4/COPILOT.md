# COPILOT

Antes de executar qualquer tarefa:

1. Leia `CRIAR-PROJETO.md`.
2. Leia `tasks/rules/`.
3. Leia a Spec solicitada em `tasks/specs/changes/`.
4. Identifique e leia somente as Skills necessárias em `tasks/skills/`.
5. Implemente.
6. Execute build e testes.
7. Corrija erros antes de concluir.

## Docker

O `docker-compose.yml` do template fica vazio.

Ao executar uma Spec que necessite Docker:

- gere o conteúdo do `docker-compose.yml` naquele momento;
- use somente os serviços necessários;
- para SQL Server, gere a senha no padrão `Gfm@d{dia}m{mes}a{ano}`;
- use a data atual da execução;
- dia e mês devem possuir dois dígitos;
- não reutilize uma senha fixa do template.

Exemplo:

```text
11/09/2026 => Gfm@d11m09a2026
```


## Serviços obrigatórios no Docker Compose inicial

Ao gerar o `docker-compose.yml`, criar:

```text
frontend-admin
frontend-site
api-admin
api-site
sqlserver
```

Vínculos:

```text
frontend-admin -> api-admin
frontend-site  -> api-site
api-admin      -> sqlserver
api-site       -> sqlserver
```

Regras:

- Admin nunca deve apontar para API Site.
- Site nunca deve apontar para API Admin.
- URLs das APIs devem ser configuradas por variável de ambiente.
- Connection strings devem ser configuradas por variável de ambiente.
- comunicação entre containers deve usar nomes dos serviços Docker.
- `localhost` é usado somente para acesso a partir do host.
