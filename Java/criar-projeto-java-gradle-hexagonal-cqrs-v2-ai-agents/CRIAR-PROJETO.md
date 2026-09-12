# CRIAR-PROJETO — Java + Gradle + Hexagonal + CQRS + MySQL

## Objetivo

Criar uma solução Full Stack moderna utilizando:

- Java 25 LTS
- Spring Boot 4.1.1
- Gradle 9.7.1
- Gradle Wrapper
- Gradle Kotlin DSL
- Arquitetura Hexagonal (Ports & Adapters)
- CQRS
- Domain Events
- Spring Security
- Spring Data JPA / Hibernate
- MySQL
- Flyway
- Jakarta Validation
- JWT + Refresh Token
- Testcontainers
- JUnit 5
- Mockito
- AssertJ
- React + TypeScript + Vite

Sempre verificar, no momento da execução, se existem versões estáveis mais recentes e compatíveis.
Não utilizar SNAPSHOT, Milestone ou RC como padrão.

---

# Arquitetura Hexagonal

Regra central:

```text
                  ┌─────────────────────┐
                  │      ADAPTER IN     │
                  │ REST / Controllers  │
                  └─────────┬───────────┘
                            │
                     Input Ports
                            │
                  ┌─────────▼───────────┐
                  │     APPLICATION     │
                  │ Use Cases / CQRS    │
                  └─────────┬───────────┘
                            │
                     Output Ports
                            │
                  ┌─────────▼───────────┐
                  │     ADAPTER OUT     │
                  │ JPA / MySQL / JWT   │
                  └─────────────────────┘
```

O domínio fica no centro e não conhece:

- Spring MVC
- JPA
- Hibernate
- MySQL
- JWT
- HTTP
- Docker

Dependências sempre apontam para dentro.

---

# Estrutura

```text
backend
└── src/main/java/com/meuprojeto
    │
    ├── domain
    │   ├── model
    │   ├── event
    │   └── service
    │
    ├── application
    │   ├── port
    │   │   ├── in
    │   │   └── out
    │   ├── usecase
    │   │   ├── command
    │   │   └── query
    │   └── dto
    │
    ├── adapter
    │   ├── in
    │   │   └── web
    │   │       ├── admin
    │   │       ├── site
    │   │       └── auth
    │   │
    │   └── out
    │       ├── persistence
    │       │   └── jpa
    │       │       ├── entity
    │       │       ├── repository
    │       │       └── mapper
    │       └── security
    │
    └── config
```

---

# Camadas

## Domain

Contém:

- Entities
- Value Objects
- Domain Services
- Domain Events
- regras de negócio puras

Não pode depender de Spring, JPA ou infraestrutura.

## Application

Contém:

- Input Ports
- Output Ports
- Commands
- Queries
- Use Cases
- DTOs

A camada Application depende apenas do Domain.

## Adapter In

Entradas da aplicação:

- REST Controllers
- HTTP Requests
- validação de entrada
- autenticação/autorização
- mapeamento HTTP -> Command/Query

## Adapter Out

Saídas:

- MySQL
- JPA
- JWT
- serviços externos
- mensageria futura

Adapters implementam Output Ports.

---

# CQRS

## Write Side

```text
Controller
   ↓
Input Port
   ↓
Command
   ↓
Command Use Case
   ↓
Domain
   ↓
Output Port
   ↓
Persistence Adapter
   ↓
MySQL
```

Commands iniciais:

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

## Read Side

```text
Controller
   ↓
Input Port
   ↓
Query
   ↓
Query Use Case
   ↓
Output Port
   ↓
Persistence Adapter
```

Queries:

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

Query nunca altera estado.

---

# Domain Events

Eventos iniciais:

```text
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
UserAssignedToGroupEvent
PermissionAssignedToGroupEvent
```

Fluxo:

```text
Command Use Case
   ↓
Domain
   ↓
Domain Event
   ↓
Publisher Port
   ↓
Adapter
```

---

# Persistência

Usar:

- MySQL
- Spring Data JPA
- Hibernate
- Flyway

Bancos:

```text
meuprojeto_dev
meuprojeto_test
```

Regras:

- Domain Entity != JPA Entity.
- Criar mapper entre Domain e Persistence.
- Repository JPA fica no Adapter Out.
- Domain não conhece JpaRepository.
- Output Port define contrato de persistência.

Exemplo:

```text
application/port/out/UserRepositoryPort.java
adapter/out/persistence/jpa/UserPersistenceAdapter.java
```

---

# Segurança

Usar:

- Spring Security
- JWT Access Token
- Refresh Token
- PasswordEncoder
- Method Security

Permissões:

```text
users.read
users.write
groups.read
groups.write
```

Exemplo:

```java
@PreAuthorize("hasAuthority('users.read')")
```

Endpoints:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

---

# REST

Usar:

- @RestController
- Java records para DTOs quando adequado
- Jakarta Validation
- Problem Details
- @RestControllerAdvice
- paginação Spring Data

Controllers devem ser finos.

Controller nunca acessa JpaRepository diretamente.

---

# Testes

## Unit

Testar:

- Domain Entities
- Value Objects
- Domain Services
- Commands
- Queries
- Use Cases
- Input/Output Ports quando necessário

Ferramentas:

- JUnit 5
- Mockito
- AssertJ

## Integration

Usar:

- Spring Boot Test
- Testcontainers
- MySQL real em container
- Flyway

Cobrir:

- REST
- autenticação
- autorização
- persistence adapters
- migrations
- CQRS completo

Nunca usar banco Development.

---

# Docker

O `docker-compose.yml` do template fica vazio.

Gerar durante a Spec.

Serviços:

```text
frontend-admin
frontend-site
api
mysql
```

Topologia:

```text
frontend-admin -> api -> mysql
frontend-site  -> api -> mysql
```

Containers devem se comunicar pelo nome do serviço.

---

# Frontend

Usar:

- React
- TypeScript
- Vite
- React Router
- TanStack Query
- Axios
- React Hook Form
- Zod

Apps:

```text
frontend/admin
frontend/site
```

---

# Qualidade

Configurar:

- Gradle Wrapper
- Kotlin DSL
- Java Toolchains
- Spotless
- JaCoCo
- Checkstyle ou equivalente quando útil
- dependency verification quando apropriado

---

# Fluxo da IA

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules`.
3. Ler a Spec.
4. Identificar Skills necessárias.
5. Ler somente Skills necessárias.
6. Verificar versões estáveis.
7. Implementar.
8. Executar Flyway.
9. Executar `./gradlew clean test`.
10. Executar integration tests.
11. Build frontend.
12. Corrigir erros.
13. Arquivar a Spec.

---

# Orquestração por Agentes

Antes de implementar qualquer funcionalidade, seguir `AGENTS.md` e `orchestration/workflows/PROJECT_CREATION.md`.

Artefatos obrigatórios de planejamento:
- `tasks/generated/REQUIREMENTS.md`
- `tasks/generated/ARCHITECTURE_PLAN.md`
- `tasks/generated/EXECUTION_PLAN.md`

A implementação só é concluída após Tester + Reviewer + Quality Gates aprovados.
