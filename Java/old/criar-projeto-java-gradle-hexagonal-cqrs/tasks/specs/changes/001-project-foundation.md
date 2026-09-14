# Spec 001 — Fundação Hexagonal

## Objetivo

Criar a primeira versão funcional utilizando:

- Java 25 LTS
- Spring Boot
- Gradle Kotlin DSL
- Arquitetura Hexagonal
- CQRS
- MySQL
- JWT
- React

## Domínio

Criar:

- User
- UserGroup
- Permission

Relacionamentos conceituais:

```text
User <-> UserGroup
UserGroup <-> Permission
```

## Commands

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
ActivateUserCommand
DeactivateUserCommand

CreateGroupCommand
UpdateGroupCommand
DeleteGroupCommand

AssignUserToGroupCommand
RemoveUserFromGroupCommand
AssignPermissionToGroupCommand
RemovePermissionFromGroupCommand
```

## Queries

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery

GetGroupByIdQuery
GetGroupsQuery
GetPagedGroupsQuery
GetGroupUsersQuery
GetGroupPermissionsQuery
```

## Input Ports

Criar portas de entrada para os casos de uso.

Exemplo:

```text
CreateUserUseCase
GetUserByIdUseCase
```

## Output Ports

Criar portas de saída:

```text
UserRepositoryPort
GroupRepositoryPort
PermissionRepositoryPort
TokenProviderPort
PasswordEncoderPort
```

## Adapters In

Criar:

```text
AdminUserController
AdminGroupController
AuthController
SiteProfileController
```

## Adapters Out

Criar:

```text
UserPersistenceAdapter
GroupPersistenceAdapter
PermissionPersistenceAdapter
JwtTokenAdapter
PasswordEncoderAdapter
```

## MySQL

Criar:

```text
meuprojeto_dev
meuprojeto_test
```

Usar Flyway.

## Segurança

Permissões:

```text
users.read
users.write
groups.read
groups.write
```

JWT + Refresh Token.

## Testes

### Unit

- Domain
- Use Cases
- Commands
- Queries

### Integration

- Controllers
- Persistence Adapters
- JWT
- autorização
- Flyway
- Testcontainers MySQL

## Frontend Admin

```text
auth
dashboard
users
groups
settings
```

## Frontend Site

```text
home
auth
profile
```

## Aceite

- dependências apontam para dentro
- Domain não depende de Spring/JPA
- Persistence implementa Output Ports
- REST usa Input Ports
- CQRS respeitado
- Gradle build passa
- Flyway passa
- tests passam
- frontends compilam
- Docker gerado e validado
