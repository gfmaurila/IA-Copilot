# Spec 001 - Fundação Laravel CQRS

## Objetivo

Criar a fundação do projeto com Laravel, MySQL e CQRS.

## Usuários

Commands:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
ActivateUserCommand
DeactivateUserCommand
```

Queries:

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery
```

Criar respectivos Handlers.

## Grupos

Commands:

```text
CreateGroupCommand
UpdateGroupCommand
DeleteGroupCommand
AssignUserToGroupCommand
RemoveUserFromGroupCommand
AssignPermissionToGroupCommand
RemovePermissionFromGroupCommand
```

Queries:

```text
GetGroupByIdQuery
GetGroupsQuery
GetPagedGroupsQuery
GetGroupUsersQuery
GetGroupPermissionsQuery
```

## Permissões

Criar:

```text
users.read
users.write
groups.read
groups.write
```

## Autenticação

Criar:

```text
POST /api/login
POST /api/logout
GET /api/me
```

Preferir Sanctum.

## HTTP

Controllers:

- Admin/UserController
- Admin/GroupController
- AuthController

Controllers devem apenas despachar Commands/Queries.

## Banco

MySQL:

```text
meuprojeto_dev
meuprojeto_test
```

## Testes

Criar testes para:

- Commands
- Queries
- Handlers
- Policies
- Controllers
- endpoints
- autenticação
- autorização
- migrations

## Frontend Admin

Criar:

- auth
- dashboard
- users
- groups
- settings

## Frontend Site

Criar:

- home
- auth
- profile

## Critérios de aceite

- CQRS aplicado
- Commands não fazem leitura complexa
- Queries não alteram estado
- Controllers finos
- migrations funcionam
- testes passam
- frontend compila
- Docker gerado e validado
