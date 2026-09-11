# CRIAR-PROJETO - Python + FastAPI + CQRS + MySQL

## Objetivo

Criar uma solução Full Stack utilizando:

- Python
- FastAPI
- SQLAlchemy 2
- MySQL
- Alembic
- Pydantic v2
- CQRS
- Domain Events
- JWT
- React + TypeScript
- testes unitários
- testes de integração
- Docker
- Rules + Skills + Specs

## Princípio arquitetural

Seguir padrões naturais do ecossistema Python.

Não copiar mecanicamente arquitetura de C#.

Usar:

- módulos por domínio/feature
- FastAPI routers
- Pydantic para contratos e validação
- SQLAlchemy 2 para persistência
- Alembic para migrations
- Commands para escrita
- Queries para leitura
- Handlers para orquestração
- Domain Events para efeitos desacoplados
- repositories quando fizer sentido
- dependency injection nativa do FastAPI
- pytest para testes

## Estrutura

```text
backend
├── src
│   └── app
│       ├── api
│       │   ├── admin
│       │   └── site
│       ├── application
│       │   ├── commands
│       │   ├── queries
│       │   ├── handlers
│       │   │   ├── commands
│       │   │   └── queries
│       │   ├── dtos
│       │   └── contracts
│       ├── domain
│       │   ├── users
│       │   ├── groups
│       │   ├── permissions
│       │   └── events
│       ├── infrastructure
│       │   ├── database
│       │   ├── repositories
│       │   └── security
│       └── core
│
└── tests
    ├── unit
    └── integration
```

## CQRS

### Commands

Usar para alteração de estado.

Exemplos:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
AssignUserToGroupCommand
AssignPermissionToGroupCommand
```

### Queries

Usar somente para leitura.

Exemplos:

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
- Router não contém regra de negócio.
- Handler orquestra casos de uso.
- Domain concentra regras de domínio.
- Infrastructure concentra detalhes externos.

## Domain Events

Exemplos:

```text
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
UserAssignedToGroupEvent
```

Fluxo:

```text
Command
  ↓
Handler
  ↓
Domain
  ↓
Repository
  ↓
Domain Event
  ↓
Event Handler
```

## Banco

Usar MySQL.

Bancos:

```text
meuprojeto_dev
meuprojeto_test
```

Toda alteração estrutural deve usar Alembic.

## Autenticação

Usar JWT.

Endpoints:

```text
POST /api/auth/login
POST /api/auth/refresh
GET  /api/auth/me
POST /api/auth/logout
```

Senha deve usar hash seguro.

Preferir Argon2 ou bcrypt.

## Autorização

Permissões:

```text
users.read
users.write
groups.read
groups.write
```

Usuário pode pertencer a múltiplos grupos.

Usuário herda permissões dos grupos.

Autorização deve ser centralizada em dependencies/middlewares.

## Testes

### Unit

Testar:

- entidades
- value objects
- commands
- queries
- handlers
- validators
- regras isoladas

### Integration

Testar:

- endpoints
- autenticação
- autorização
- banco
- repositories
- migrations

Nunca utilizar `meuprojeto_dev` nos testes.

## Docker

`docker-compose.yml` deve permanecer vazio no template.

Gerar durante a execução da Spec.

Serviços esperados:

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

## Regra para IA

Antes de implementar:

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules/`.
3. Ler a Spec.
4. Identificar Skills necessárias.
5. Ler somente as Skills necessárias.
6. Implementar.
7. Executar migrations.
8. Executar testes.
9. Executar build backend/frontend.
10. Corrigir erros.
11. Arquivar a Spec somente após validação.
