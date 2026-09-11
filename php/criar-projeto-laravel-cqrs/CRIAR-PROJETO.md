# CRIAR-PROJETO - Laravel + CQRS

## Objetivo

Criar uma solução Full Stack utilizando:

- PHP
- Laravel
- MySQL
- React + TypeScript
- CQRS
- Commands
- Queries
- Handlers
- Domain Events
- Eloquent
- Form Requests
- API Resources
- Policies / Gates
- autenticação
- testes Unit
- testes Feature/Integration
- Docker
- Rules + Skills + Specs

## Princípio arquitetural

Usar Laravel de forma idiomática, mas organizar a camada de aplicação com CQRS.

Separar claramente:

```text
Write Side = Commands
Read Side  = Queries
```

Controllers devem ser finos e delegar para Commands ou Queries.

## Estrutura

```text
backend
├── app
│   ├── Application
│   │   ├── Commands
│   │   ├── Queries
│   │   ├── Handlers
│   │   │   ├── Commands
│   │   │   └── Queries
│   │   ├── DTOs
│   │   └── Contracts
│   │
│   ├── Domain
│   │   ├── Users
│   │   ├── Groups
│   │   └── Permissions
│   │
│   ├── Http
│   │   ├── Controllers
│   │   │   ├── Admin
│   │   │   └── Site
│   │   ├── Requests
│   │   └── Resources
│   │
│   ├── Infrastructure
│   │   └── Persistence
│   │
│   ├── Models
│   ├── Policies
│   ├── Events
│   ├── Listeners
│   ├── Jobs
│   └── Providers
│
├── database
│   ├── factories
│   ├── migrations
│   └── seeders
│
├── routes
│   ├── api.php
│   ├── admin.php
│   └── site.php
│
└── tests
    ├── Unit
    └── Feature
```

## CQRS

### Commands

Commands alteram estado.

Exemplos:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
AssignUserToGroupCommand
AssignPermissionToGroupCommand
```

Estrutura:

```text
app/Application/Commands/Users/CreateUserCommand.php
app/Application/Handlers/Commands/Users/CreateUserHandler.php
```

### Queries

Queries apenas consultam.

Exemplos:

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery
GetGroupByIdQuery
GetGroupsQuery
```

Estrutura:

```text
app/Application/Queries/Users/GetUserByIdQuery.php
app/Application/Handlers/Queries/Users/GetUserByIdHandler.php
```

### Regras

- Command nunca deve ser usado para consulta complexa.
- Query nunca deve alterar estado.
- Controllers não devem possuir regra de negócio.
- Handlers orquestram a operação.
- Eloquent pode ser utilizado dentro da Infrastructure ou em Query Handlers simples quando apropriado.
- Validação HTTP permanece em Form Requests.
- Autorização permanece em Policies/Gates.
- Transformação de resposta permanece em API Resources.

## Domain Events

Usar eventos para efeitos colaterais relevantes.

Exemplos:

```text
UserCreated
UserUpdated
UserDeleted
UserAssignedToGroup
```

Fluxo:

```text
Command
  ↓
Handler
  ↓
Domain change
  ↓
Event
  ↓
Listener
```

## Autenticação

Usar autenticação via token.

Preferir Laravel Sanctum para SPA/API.

JWT pode ser adotado se a Spec exigir.

## Usuários e grupos

Funcionalidades iniciais:

- CRUD de usuários
- CRUD de grupos
- permissões Read/Write
- usuário x grupo
- grupo x permissão

Permissões:

```text
users.read
users.write
groups.read
groups.write
```

## Banco

MySQL:

```text
meuprojeto_dev
meuprojeto_test
```

Toda alteração estrutural deve ser feita por Migration.

## Testes

### Unit

Testar:

- Commands
- Queries
- Handlers
- Services
- regras isoladas

### Feature/Integration

Testar:

- endpoints
- autenticação
- autorização
- banco
- fluxo Command -> Handler
- fluxo Query -> Handler

Nunca usar banco Development em testes.

## Docker

`docker-compose.yml` permanece vazio no template.

Gerar durante a execução da Spec.

Topologia padrão:

```text
frontend-admin -> api -> mysql
frontend-site  -> api -> mysql
```

## Regra para IA

Antes de implementar:

1. Ler `CRIAR-PROJETO.md`.
2. Ler `tasks/rules/`.
3. Ler a Spec atual.
4. Identificar Skills necessárias.
5. Ler somente as Skills necessárias.
6. Implementar.
7. Executar migrations.
8. Executar testes.
9. Executar build frontend.
10. Corrigir erros.
11. Arquivar a Spec somente após validação.
