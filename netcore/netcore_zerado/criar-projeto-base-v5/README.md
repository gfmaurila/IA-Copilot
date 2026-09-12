# MeuProjeto - Base

Template inicial para geração de projeto Full Stack.

## Primeira entrega

- CRUD usuários
- CRUD grupos
- permissões Read/Write
- JWT
- testes unitários
- testes de integração
- SQL Server Dev/Test
- Entity Framework Core + migration inicial `InitialCreate`
- React Admin/Site

## Documentos principais

- `CRIAR-PROJETO.md`
- `tasks/specs/changes/001-project-foundation.md`
- `tasks/rules/`
- `tasks/skills/`


## Docker Compose

O arquivo `docker-compose.yml` começa vazio e deve ser gerado pelo Copilot
durante a execução da Spec.

A senha SQL Server segue o padrão:

```text
Gfm@d{dia}m{mes}a{ano}
```


## Topologia Docker inicial

```text
Browser
├── http://localhost:8081 -> frontend-admin -> api-admin -> sqlserver
└── http://localhost:8082 -> frontend-site  -> api-site  -> sqlserver
```

Portas sugeridas:

```text
Admin Frontend : 8081
Site Frontend  : 8082
Admin API      : 5001
Site API       : 5002
SQL Server     : 1433
```


## Entity Framework Core

A criação do backend deve iniciar a persistência com EF Core antes das features de aplicação.

Fluxo obrigatório:

```text
Domain entities
  -> Infrastructure
  -> ApplicationDbContext
  -> Fluent configurations
  -> InitialCreate migration
  -> validate migration script
  -> CQRS / JWT / APIs
```

A modelagem de referência está em:

```text
tasks/specs/changes/TASK_USER_PERSON_DATA_MODEL.md
```
