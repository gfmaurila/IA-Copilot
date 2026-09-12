# COPILOT

Antes de executar qualquer tarefa:

1. Leia `CRIAR-PROJETO.md`.
2. Leia `tasks/rules/`.
3. Leia a Spec solicitada em `tasks/specs/changes/`.
4. Identifique e leia somente as Skills necessárias em `tasks/skills/`.
5. Para a Spec `001-project-foundation.md`, considere `TASK_USER_PERSON_DATA_MODEL.md` como fonte oficial da modelagem; não gere o modelo legado simplificado de User/UserGroup.
6. Ao iniciar o backend, configure EF Core/SQL Server, `ApplicationDbContext`, mappings e crie a migration `InitialCreate` antes de CQRS/JWT/APIs.
7. Crie `DevelopmentSeed` com os dados fake exigidos pela Spec 001 e mantenha esses dados fora de produção.
8. Valide as migrations com `dotnet ef migrations script`.
9. Implemente todos os CRUDs e o User Registration Wizard exigidos pela Spec 001.
10. Execute build e testes.
11. Corrija erros antes de concluir.

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

## Skills obrigatórias para Spec 001

Ao executar `001-project-foundation.md`, utilizar quando aplicável:

```text
tasks/skills/backend/create-ef-migration/SKILL.md
tasks/skills/backend/create-development-seed/SKILL.md
tasks/skills/backend/create-user-registration-wizard/SKILL.md
tasks/skills/frontend/create-crud/SKILL.md
tasks/skills/frontend/create-user-registration-wizard/SKILL.md
```
