# CRIAR-PROJETO — .NET + Vertical Slice Architecture + AI Agents

> Antes de qualquer implementação, seguir `AGENTS.md`, gerar os artefatos em `tasks/generated/` e executar os Quality Gates definidos em `orchestration/gates/QUALITY_GATES.md`.

## Objetivo

Criar uma solução Full Stack utilizando:

- .NET
- ASP.NET Core
- Minimal APIs
- Vertical Slice Architecture
- CQRS
- Domain Events
- Domain Model
- EF Core
- FluentValidation
- MediatR ou abstração equivalente para Commands/Queries
- JWT + Refresh Token
- React + TypeScript
- testes unitários
- testes de integração
- Docker
- Rules + Skills + Specs

## Princípio arquitetural

A organização principal do backend deve ser por **feature/vertical slice**, e não por camada técnica.

Evitar estruturas horizontais como:

```text
Controllers/
Services/
Repositories/
Validators/
Handlers/
```

espalhadas globalmente.

Cada funcionalidade deve manter seus arquivos juntos.

Exemplo:

```text
Features/
└── Users/
    ├── Create/
    │   ├── Command.cs
    │   ├── Validator.cs
    │   ├── Handler.cs
    │   ├── Endpoint.cs
    │   └── Response.cs
    ├── Update/
    ├── Delete/
    ├── GetById/
    └── GetPaged/
```

## Estrutura principal

```text
backend
├── src
│   ├── MeuProjeto.API
│   │   ├── Features
│   │   │   ├── Auth
│   │   │   ├── Users
│   │   │   ├── Groups
│   │   │   ├── Permissions
│   │   │   └── Common
│   │   ├── Extensions
│   │   ├── Middleware
│   │   └── Program.cs
│   │
│   ├── MeuProjeto.Domain
│   │   ├── Entities
│   │   ├── ValueObjects
│   │   ├── Events
│   │   ├── Enums
│   │   └── Abstractions
│   │
│   └── MeuProjeto.Infrastructure
│       ├── Persistence
│       ├── Repositories
│       ├── Security
│       └── Messaging
│
└── tests
    ├── MeuProjeto.Domain.Tests
    ├── MeuProjeto.API.Tests
    └── MeuProjeto.IntegrationTests
```

## Minimal APIs

Não usar Controllers MVC como padrão.

Cada slice deve registrar seu próprio endpoint.

Exemplo conceitual:

```csharp
public static class Endpoint
{
    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/", HandleAsync)
             .RequireAuthorization("Users.Write");
    }
}
```

Os endpoints devem ser registrados por extensão, por exemplo:

```csharp
app.MapUserEndpoints();
app.MapGroupEndpoints();
app.MapAuthEndpoints();
```

## CQRS

### Commands

Operações de escrita:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
AssignUserToGroupCommand
AssignPermissionToGroupCommand
```

### Queries

Operações de leitura:

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery
GetGroupByIdQuery
GetGroupsQuery
```

### Regras

- Command altera estado.
- Query não altera estado.
- Cada Slice possui Command/Query + Handler.
- Validator pertence ao Slice.
- Endpoint pertence ao Slice.
- Response/DTO pertence ao Slice quando específico.
- Não criar camada Application global apenas para centralizar Handlers.
- O Domain continua isolado.

## Domain

O projeto Domain deve conter apenas regras de domínio.

Exemplos:

- User
- UserGroup
- Permission
- Email
- Domain Events
- invariantes

Domain não deve depender de:

- ASP.NET Core
- EF Core
- MediatR
- Minimal APIs
- Infrastructure

## Domain Events

Eventos iniciais:

```text
UserCreatedDomainEvent
UserUpdatedDomainEvent
UserDeletedDomainEvent
UserAssignedToGroupDomainEvent
PermissionAssignedToGroupDomainEvent
```

Os eventos devem ser publicados após mudanças relevantes de domínio.

## Infrastructure

Responsável por detalhes externos:

- EF Core
- DbContext
- Configurations
- Repositories
- JWT
- Refresh Token
- mensageria futura
- cache futuro

## Persistência

Usar EF Core.

Toda alteração estrutural deve possuir Migration.

## Auth

Endpoints:

```text
POST /api/auth/login
POST /api/auth/refresh-token
GET  /api/auth/me
POST /api/auth/logout
```

JWT deve conter claims necessárias para autorização.

Permissões:

```text
Users.Read
Users.Write
Groups.Read
Groups.Write
```

Usar Policies.

## Users

Slices:

```text
Users/Create
Users/Update
Users/Delete
Users/GetById
Users/GetPaged
Users/Activate
Users/Deactivate
```

## Groups

Slices:

```text
Groups/Create
Groups/Update
Groups/Delete
Groups/GetById
Groups/GetPaged
Groups/AssignUser
Groups/RemoveUser
Groups/AssignPermission
Groups/RemovePermission
```

## Validação

Usar FluentValidation.

Validator deve ficar no mesmo Slice do Command/Request.

## Error Handling

Usar tratamento centralizado.

Preferir ProblemDetails.

## Testes

### Domain Tests

Testar:

- entidades
- value objects
- invariantes
- domain events

### API Tests

Testar:

- slices
- handlers
- validators
- endpoints

### Integration Tests

Testar:

- API real
- EF Core
- autenticação
- autorização
- migrations
- banco de teste separado

Nunca utilizar banco Development.

## Frontend

Manter:

```text
frontend/admin
frontend/site
```

Admin:

- auth
- dashboard
- users
- groups
- settings

Site:

- home
- auth
- profile

## Docker

O `docker-compose.yml` do template permanece vazio.

Gerar na execução da Spec.

Serviços:

```text
frontend-admin
frontend-site
api
database
```

Vínculos:

```text
frontend-admin -> api
frontend-site  -> api
api            -> database
```

## Fluxo da IA

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules/`.
3. Ler a Spec.
4. Identificar Skills necessárias.
5. Ler somente Skills necessárias.
6. Implementar Slice por Slice.
7. Executar migrations.
8. Executar build.
9. Executar testes.
10. Corrigir erros.
11. Arquivar a Spec apenas após validação.