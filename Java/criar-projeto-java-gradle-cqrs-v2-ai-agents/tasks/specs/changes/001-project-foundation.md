# Spec 001 — Fundação Java

Criar a aplicação com Java, Spring Boot, Gradle Kotlin DSL, CQRS e MySQL.

## Usuários

Campos:

- id
- name
- email
- passwordHash
- active
- createdAt
- updatedAt

Commands:

- CreateUserCommand
- UpdateUserCommand
- DeleteUserCommand
- ActivateUserCommand
- DeactivateUserCommand

Queries:

- GetUserByIdQuery
- GetUsersQuery
- GetPagedUsersQuery

## Grupos

Commands:

- CreateGroupCommand
- UpdateGroupCommand
- DeleteGroupCommand
- AssignUserToGroupCommand
- RemoveUserFromGroupCommand
- AssignPermissionToGroupCommand
- RemovePermissionFromGroupCommand

Queries:

- GetGroupByIdQuery
- GetGroupsQuery
- GetPagedGroupsQuery
- GetGroupUsersQuery
- GetGroupPermissionsQuery

## Permissões

- users.read
- users.write
- groups.read
- groups.write

## Auth

Implementar JWT + Refresh Token com Spring Security.

## Banco

MySQL com Flyway:

- meuprojeto_dev
- meuprojeto_test

## Testes

Unit:
- domínio
- Commands/Queries
- Handlers
- autorização

Integration:
- login
- refresh
- CRUD users
- CRUD groups
- associações
- permissões
- endpoints protegidos
- Flyway

Usar Testcontainers MySQL.

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

## Aceite

- Gradle build passa
- migrations passam
- CQRS respeitado
- JWT funciona
- permissões funcionam
- unit tests passam
- integration tests passam
- React Admin/Site compilam
- Docker é gerado e validado
