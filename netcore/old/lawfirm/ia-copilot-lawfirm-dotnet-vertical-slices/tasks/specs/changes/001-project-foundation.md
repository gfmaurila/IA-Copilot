# Spec 001 — Fundação Vertical Slice

## Objetivo

Criar a primeira versão funcional utilizando:

- ASP.NET Core
- Minimal APIs
- Vertical Slice Architecture
- CQRS
- Domain Events
- EF Core
- JWT
- React Admin/Site

## Usuários

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

## Grupos

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

## Auth

Slices:

```text
Auth/Login
Auth/RefreshToken
Auth/Me
Auth/Logout
```

## Domain

Criar:

- User
- UserGroup
- Permission
- Email Value Object
- Domain Events

## Infrastructure

Criar:

- AppDbContext
- EF Configurations
- Migrations
- JWT service
- Refresh Token persistence

## Permissões

```text
Users.Read
Users.Write
Groups.Read
Groups.Write
```

## Minimal APIs

Não criar Controllers.

Cada Slice registra seu endpoint.

## Testes

### Unit

- Domain
- Commands
- Queries
- Handlers
- Validators

### Integration

- Minimal APIs
- JWT
- Policies
- EF Core
- CRUD Users
- CRUD Groups
- relacionamentos

## Frontend Admin

- auth
- dashboard
- users
- groups
- settings

## Frontend Site

- home
- auth
- profile

## Critérios de aceite

- organização por Vertical Slice
- Minimal APIs sem Controllers
- CQRS respeitado
- Domain isolado
- Domain Events funcionando
- build passa
- migrations passam
- testes passam
- frontends compilam
- Docker gerado e validado


## Plano detalhado do Frontend

As tarefas detalhadas de implementação tela a tela estão em:

- `tasks/frontend/README.md`
- `tasks/frontend/admin/` — 50 tarefas
- `tasks/frontend/site/` — 20 tarefas

Os agentes devem usar os mockups em `docs/screens/1. Front End` como referência visual e seguir `tasks/rules/frontend.md`.
