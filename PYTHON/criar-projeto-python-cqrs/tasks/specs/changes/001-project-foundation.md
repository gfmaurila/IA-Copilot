# Spec 001 - Fundação Python CQRS

## Objetivo

Criar a primeira versão funcional usando FastAPI, SQLAlchemy 2, Alembic e MySQL.

## Usuários

Campos:

- id
- name
- email
- password_hash
- active
- created_at
- updated_at

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

Relacionamentos:

```text
users <-> groups
groups <-> permissions
```

## Auth

Criar:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

## API Admin

Criar rotas:

```text
/api/admin/users
/api/admin/groups
/api/admin/permissions
```

## API Site

Criar:

```text
/api/site/profile
```

## Testes de integração

Cobrir:

- login válido
- login inválido
- refresh token
- CRUD usuários
- CRUD grupos
- vínculo usuário x grupo
- vínculo grupo x permissão
- autorização leitura
- autorização escrita
- acesso negado

## Banco de teste

Usar:

```text
meuprojeto_test
```

Fluxo:

1. aplicar migrations
2. inserir dados de cenário
3. executar teste
4. limpar dados
5. nunca usar development

## Frontend Admin

Criar:

```text
auth
dashboard
users
groups
settings
```

## Frontend Site

Criar:

```text
home
auth
profile
```

## Critérios de aceite

- backend inicia
- migrations funcionam
- CQRS aplicado
- JWT funciona
- autorização funciona
- unit tests passam
- integration tests passam
- frontend admin compila
- frontend site compila
- Docker gerado e validado
