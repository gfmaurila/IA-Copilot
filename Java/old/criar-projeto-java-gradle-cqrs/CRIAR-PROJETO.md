# CRIAR-PROJETO — Java + Gradle + Spring Boot + CQRS + MySQL

## Stack base

Usar versões estáveis atuais e compatíveis no momento da execução.

Baseline definido em setembro/2026:

- Java 25 LTS
- Spring Boot 4.1.x
- Gradle 9.7.x com Gradle Wrapper
- Gradle Kotlin DSL (`build.gradle.kts`)
- Spring Framework 7
- Spring Security
- Spring Data JPA / Hibernate
- MySQL
- Flyway
- Jakarta Validation
- CQRS
- Domain Events
- JWT
- Testcontainers
- JUnit 5
- Mockito
- AssertJ
- React + TypeScript + Vite

Antes de gerar o projeto, verificar se existem releases estáveis mais recentes e compatíveis.
Nunca usar snapshot, milestone ou release candidate como padrão.

## Princípio arquitetural

Seguir convenções modernas de Java/Spring.

Usar CQRS sem tentar reproduzir MediatR do .NET.

```text
Write -> Command -> CommandHandler
Read  -> Query   -> QueryHandler
```

Spring DI deve resolver os handlers.

Controllers devem ser finos.

## Estrutura

```text
backend
├── src/main/java/com/meuprojeto
│   ├── api
│   │   ├── admin
│   │   └── site
│   ├── application
│   │   ├── command
│   │   ├── query
│   │   ├── handler
│   │   │   ├── command
│   │   │   └── query
│   │   └── dto
│   ├── domain
│   │   ├── user
│   │   ├── group
│   │   ├── permission
│   │   └── event
│   ├── infrastructure
│   │   ├── persistence
│   │   └── security
│   └── config
│
├── src/main/resources
│   ├── application.yml
│   ├── application-dev.yml
│   ├── application-test.yml
│   └── db/migration
│
└── src/test/java/com/meuprojeto
    ├── unit
    └── integration
```

## CQRS

Commands alteram estado:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
ActivateUserCommand
DeactivateUserCommand
AssignUserToGroupCommand
AssignPermissionToGroupCommand
```

Queries apenas consultam:

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery
GetGroupByIdQuery
GetGroupsQuery
```

Cada Command e Query possui Handler correspondente.

## Domain Events

Usar eventos Spring ou abstração de domínio quando apropriado:

```text
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
UserAssignedToGroupEvent
```

Eventos devem ser usados para efeitos colaterais desacoplados, não para esconder fluxo principal.

## Persistência

- MySQL
- Spring Data JPA
- Hibernate
- Flyway
- migrations versionadas
- transações com `@Transactional` na camada de aplicação apropriada

Bancos:

```text
meuprojeto_dev
meuprojeto_test
```

## Segurança

Usar Spring Security.

Autenticação:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

Usar JWT access token + refresh token.

Senhas com `PasswordEncoder`, preferencialmente BCrypt ou Argon2.

Permissões:

```text
users.read
users.write
groups.read
groups.write
```

Usar Method Security:

```text
@PreAuthorize("hasAuthority('users.read')")
@PreAuthorize("hasAuthority('users.write')")
```

## API

Preferir:

- `@RestController`
- DTOs/Java records para contratos
- Jakarta Validation
- `@RestControllerAdvice` para erros
- Problem Details/RFC 9457 quando suportado pelo stack
- paginação com Spring Data

## Testes

### Unit

- JUnit 5
- Mockito
- AssertJ

Sem banco real quando possível.

### Integration

- Spring Boot Test
- MockMvc ou WebTestClient conforme stack
- Testcontainers
- MySQL container real para testes
- Flyway aplicado no banco de teste

Nunca usar `meuprojeto_dev` em testes automatizados.

## Docker

`docker-compose.yml` permanece vazio no template.

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

## Frontend

- React
- TypeScript
- Vite
- React Router
- TanStack Query
- Axios
- React Hook Form
- Zod

## Qualidade

Configurar:

- Gradle Wrapper
- Java Toolchains
- Spotless
- Checkstyle ou equivalente quando útil
- JaCoCo
- dependency locking/verificação quando apropriado

## Regra para IA

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules`.
3. Ler a Spec.
4. Ler somente Skills necessárias.
5. Verificar versões estáveis compatíveis.
6. Implementar.
7. Executar Flyway.
8. Executar `./gradlew clean test`.
9. Executar testes de integração.
10. Executar build dos frontends.
11. Corrigir erros e warnings relevantes.
12. Arquivar Spec somente após validação.
