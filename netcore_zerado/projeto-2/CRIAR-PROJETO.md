# CRIAR-PROJETO

## 1. Objetivo

Criar uma solução Full Stack contendo:

* Backend em C# / ASP.NET Core
* Frontend em React + TypeScript
* Arquitetura baseada em DDD
* CQRS
* Domain Events
* Repository Pattern
* Dependency Injection
* Validação
* Testes unitários
* Testes de integração
* Docker
* Separação entre Admin e Site

O projeto deve ser criado respeitando obrigatoriamente as regras, estrutura e Skills existentes neste repositório.

---

# 2. Nome do projeto

Usar a variável:

```text
PROJECT_NAME=MeuProjeto
```

Todo namespace, projeto `.csproj`, solution e estrutura deverá utilizar:

```text
{PROJECT_NAME}
```

Exemplo:

```text
MeuProjeto.Domain
MeuProjeto.Application
MeuProjeto.Infrastructure
MeuProjeto.API.Admin
MeuProjeto.API.Site
```

---

# 3. Stack

## Backend

Utilizar:

* .NET
* ASP.NET Core Web API
* C#
* Entity Framework Core
* CQRS
* MediatR ou Mediator
* FluentValidation
* AutoMapper
* JWT
* Swagger / OpenAPI
* Serilog
* Dependency Injection
* Repository Pattern
* Domain Events

Banco padrão:

```text
SQL Server
```

Preparar arquitetura para permitir outros providers futuramente.

---

# 4. Frontend

Utilizar:

* React
* TypeScript
* Vite
* React Router
* Axios
* React Hook Form
* Zod
* TanStack Query
* Context API ou Zustand para estado global simples

Evitar Redux inicialmente.

Adicionar somente caso exista necessidade real.

---

# 5. Aplicações

A solução terá quatro aplicações principais.

## Backend

```text
MeuProjeto.API.Admin
MeuProjeto.API.Site
```

## Frontend

```text
frontend/admin
frontend/site
```

---

# 6. Responsabilidade das APIs

## API Admin

Responsável pelas funcionalidades administrativas.

Exemplos:

* Login administrativo
* Dashboard
* Usuários
* Perfis
* Permissões
* Configurações
* Cadastros
* Relatórios

Projeto:

```text
MeuProjeto.API.Admin
```

---

## API Site

Responsável pelas funcionalidades públicas e do usuário final.

Exemplos:

* Login
* Cadastro
* Recuperação de senha
* Perfil
* Conteúdo público
* Serviços do site

Projeto:

```text
MeuProjeto.API.Site
```

---

# 7. Autenticação

Não criar uma API separada exclusivamente para autenticação.

Auth será tratado como módulo compartilhado.

Exemplo:

```text
Application
└── Auth
    ├── Commands
    ├── Queries
    ├── DTOs
    ├── Validators
    └── Services
```

Domínio:

```text
Domain
└── Identity
    ├── Entities
    ├── ValueObjects
    ├── Events
    └── Enums
```

Endpoints de autenticação poderão ser expostos pelas APIs:

```text
/api/auth/login
/api/auth/refresh-token
/api/auth/forgot-password
/api/auth/reset-password
```

---

# 8. Estrutura geral

```text
MeuProjeto
│
├── backend
│   │
│   ├── src
│   │   │
│   │   ├── API
│   │   │   ├── MeuProjeto.API.Admin
│   │   │   └── MeuProjeto.API.Site
│   │   │
│   │   ├── Application
│   │   │   └── MeuProjeto.Application
│   │   │
│   │   ├── Domain
│   │   │   └── MeuProjeto.Domain
│   │   │
│   │   ├── Infrastructure
│   │   │   └── MeuProjeto.Infrastructure
│   │   │
│   │   └── CrossCutting
│   │       └── MeuProjeto.CrossCutting
│   │
│   ├── tests
│   │   ├── unit
│   │   │   ├── MeuProjeto.Domain.Tests
│   │   │   └── MeuProjeto.Application.Tests
│   │   │
│   │   └── integration
│   │       ├── MeuProjeto.API.Admin.IntegrationTests
│   │       ├── MeuProjeto.API.Site.IntegrationTests
│   │       └── MeuProjeto.Infrastructure.IntegrationTests
│   │
│   └── MeuProjeto.sln
│
├── frontend
│   │
│   ├── admin
│   └── site
│
├── docs
│
├── tasks
│   ├── specs
│   ├── skills
│   └── rules
│
├── docker-compose.yml
├── .env.example
├── .gitignore
├── README.md
└── CRIAR-PROJETO.md
```

---

# 9. Arquitetura Backend

A arquitetura deverá respeitar:

```text
API
 ↓
Application
 ↓
Domain

Infrastructure
 ↑
Application
```

O Domain NÃO poderá depender de:

```text
Application
Infrastructure
API
```

Application poderá depender de:

```text
Domain
```

Infrastructure poderá depender de:

```text
Domain
Application
```

API poderá depender de:

```text
Application
CrossCutting
```

---

# 10. Domain

Estrutura sugerida:

```text
Domain
│
├── Common
│   ├── Entity.cs
│   ├── AggregateRoot.cs
│   ├── ValueObject.cs
│   └── IDomainEvent.cs
│
├── Users
│   ├── Entities
│   ├── ValueObjects
│   ├── Events
│   ├── Enums
│   └── Repositories
│
└── Identity
    ├── Entities
    ├── ValueObjects
    ├── Events
    └── Enums
```

O Domain deverá conter apenas regras de negócio.

Não colocar:

```text
DbContext
Entity Framework
Controller
HTTP
DTO de API
SQL
Redis
RabbitMQ
```

---

# 11. Application

Organizar por funcionalidade.

Exemplo:

```text
Application
│
├── Users
│   │
│   ├── Commands
│   │   ├── CreateUser
│   │   ├── UpdateUser
│   │   └── DeleteUser
│   │
│   ├── Queries
│   │   ├── GetUserById
│   │   ├── GetUsers
│   │   └── GetPagedUsers
│   │
│   ├── DTOs
│   ├── Mappings
│   └── Validators
│
└── Auth
    ├── Commands
    ├── Queries
    ├── DTOs
    ├── Validators
    └── Services
```

---

# 12. CQRS

Commands modificam estado.

Exemplos:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
```

Queries somente consultam dados.

Exemplos:

```text
GetUserByIdQuery
GetUsersQuery
GetPagedUsersQuery
```

Nunca utilizar Query para modificar dados.

Nunca utilizar Command para retornar estruturas complexas de consulta.

---

# 13. Domain Events

Toda alteração de negócio relevante poderá gerar Domain Event.

Exemplo:

```text
UserCreatedDomainEvent
UserUpdatedDomainEvent
UserDeletedDomainEvent
```

Fluxo:

```text
Entity
   ↓
Domain Event
   ↓
Mediator
   ↓
Domain Event Handler
```

---

# 14. Infrastructure

Estrutura sugerida:

```text
Infrastructure
│
├── Persistence
│   ├── Context
│   ├── Configurations
│   ├── Migrations
│   └── Repositories
│
├── Identity
├── Cache
├── Messaging
├── Logging
└── Services
```

Implementações concretas dos repositories devem ficar aqui.

---

# 15. CrossCutting

Responsável pelo registro das dependências.

Exemplo:

```text
CrossCutting
│
├── DependencyInjection
│   ├── ApplicationDependencyInjection.cs
│   ├── InfrastructureDependencyInjection.cs
│   └── ServiceCollectionExtensions.cs
│
└── Configuration
```

---

# 16. APIs

Controllers devem possuir pouca lógica.

Fluxo:

```text
Controller
   ↓
Mediator
   ↓
Command / Query
   ↓
Handler
```

Não colocar regra de negócio em Controller.

Exemplo:

```text
Controllers
├── AuthController.cs
├── UsersController.cs
└── HealthController.cs
```

---

# 17. Frontend

Existirão somente duas aplicações React:

```text
frontend/admin
frontend/site
```

Cada aplicação deverá utilizar:

```text
public

src
├── app
├── assets
├── components
├── hooks
├── layouts
├── modules
├── routes
├── services
├── shared
├── types
└── utils
```

---

# 18. Estrutura por módulo React

Exemplo:

```text
modules
└── users
    ├── components
    ├── hooks
    ├── pages
    │   ├── UserList
    │   ├── UserCreate
    │   ├── UserEdit
    │   └── UserDetails
    │
    ├── schemas
    ├── services
    └── types
```

Cada funcionalidade deverá ficar dentro do seu módulo.

---

# 19. Admin

Criar inicialmente:

```text
modules
├── auth
├── dashboard
├── users
└── settings
```

## Auth

Criar:

```text
Login
ForgotPassword
ResetPassword
```

## Dashboard

Criar dashboard inicial com cards e dados de exemplo.

## Users

Criar CRUD contendo:

```text
List
Create
Edit
Details
```

Implementar:

* paginação
* pesquisa
* autocomplete
* ordenação
* validação
* mensagens de erro
* loading
* confirmação de exclusão

## Settings

Permitir configuração do painel.

Exemplos:

* tema claro/escuro
* cor principal
* tamanho de menu
* menu recolhido
* preferências do usuário

---

# 20. Site

Criar inicialmente:

```text
modules
├── home
├── auth
├── account
└── contact
```

Páginas iniciais:

```text
Home
Login
Cadastro
Recuperar Senha
Perfil
Contato
404
```

---

# 21. API Services

Centralizar chamadas HTTP.

Exemplo:

```text
services
├── api.ts
├── auth.service.ts
└── token.service.ts
```

Não utilizar URLs diretamente dentro de componentes.

Utilizar `.env`.

Admin:

```text
VITE_API_URL=http://localhost:5001
```

Site:

```text
VITE_API_URL=http://localhost:5002
```

---

# 22. Skills

As Skills representam tarefas reutilizáveis para criação e manutenção do projeto.

Criar:

```text
tasks
└── skills
    ├── create-entity
    ├── create-value-object
    ├── create-command
    ├── create-query
    ├── create-handler
    ├── create-validator
    ├── create-domain-event
    ├── create-repository
    ├── create-controller
    ├── create-endpoint
    ├── create-unit-test
    ├── create-integration-test
    ├── create-react-module
    ├── create-react-page
    ├── create-react-form
    ├── create-react-service
    └── create-react-crud
```

Cada Skill deverá possuir:

```text
SKILL.md
```

---

# 23. Exemplo de Skill

Arquivo:

```text
tasks/skills/create-command/SKILL.md
```

Conteúdo:

```text
# Skill: Create Command

## Objetivo

Criar um Command seguindo CQRS.

## Entrada

- nome do módulo
- nome do command
- propriedades
- retorno esperado

## Criar

Application/{Modulo}/Commands/{NomeCommand}/

Arquivos:

- {NomeCommand}Command.cs
- {NomeCommand}CommandHandler.cs
- {NomeCommand}CommandValidator.cs

## Regras

- usar CQRS
- usar Mediator
- usar FluentValidation
- não acessar DbContext diretamente
- utilizar Repository
- respeitar CancellationToken
- utilizar async/await
```

---

# 24. Rules

Criar:

```text
tasks
└── rules
    ├── architecture.md
    ├── backend.md
    ├── domain.md
    ├── application.md
    ├── infrastructure.md
    ├── api.md
    ├── frontend.md
    ├── react.md
    ├── tests.md
    └── docker.md
```

Rules representam regras obrigatórias.

Skills representam como executar uma tarefa.

Specs representam o que precisa ser desenvolvido.

---

# 25. Specs

Toda nova funcionalidade deverá possuir uma especificação.

Estrutura:

```text
tasks
└── specs
    ├── changes
    └── archive
```

Exemplo:

```text
tasks/specs/changes/001-create-user-crud.md
```

Depois de concluída:

```text
tasks/specs/archive/001-create-user-crud.md
```

---

# 26. Template de Spec

```text
# TASK

## Nome

CRUD de usuários

## Objetivo

Criar gerenciamento completo de usuários.

## Backend

Criar:

- Entity
- Value Objects
- Repository
- Commands
- Queries
- Validators
- Domain Events
- Endpoints
- Testes

## Frontend Admin

Criar:

- List
- Create
- Edit
- Details
- Form
- Service
- Types
- Validation

## Regras

Aplicar todas as regras existentes em:

tasks/rules/

Aplicar Skills disponíveis em:

tasks/skills/
```

---

# 27. Testes

Utilizar testes unitários para:

```text
Domain
Application
Validators
Handlers
```

Utilizar testes de integração para:

```text
API
Infrastructure
Repositories
Database
```

Manter:

```text
unit
integration
```

separados.

---

# 28. Docker

O `docker-compose.yml` raiz será responsável por subir todo o ambiente.

Estrutura esperada:

```text
Admin React
Site React
Admin API
Site API
SQL Server
Redis
```

Opcionalmente poderão ser adicionados:

```text
RabbitMQ
MongoDB
Kafka
```

Não adicionar infraestrutura que não esteja sendo utilizada.

---

# 29. Portas padrão

Utilizar inicialmente:

```text
Admin Frontend
http://localhost:8081

Site Frontend
http://localhost:8082

Admin API
http://localhost:5001

Site API
http://localhost:5002

SQL Server
localhost:1433

Redis
localhost:6379
```

---

# 30. Segurança

Nunca armazenar:

```text
senha
secret
connection string
JWT secret
token
```

diretamente no código.

Utilizar:

```text
.env
appsettings
environment variables
user secrets
```

Adicionar somente exemplos em:

```text
.env.example
appsettings.Development.example.json
```

---

# 31. Padrões gerais Backend

Obrigatório:

* async/await
* CancellationToken
* Dependency Injection
* nullable habilitado
* DTOs
* validação
* tratamento global de exceção
* ProblemDetails
* logging estruturado
* paginação padronizada

Evitar:

* lógica em Controller
* repositories genéricos excessivos
* classes gigantes
* dependências diretas entre módulos
* acesso direto ao DbContext pela API

---

# 32. Padrões gerais Frontend

Obrigatório:

* TypeScript
* componentes reutilizáveis
* separação por módulos
* services para comunicação HTTP
* schemas para validação
* tratamento de loading
* tratamento de erros
* componentes de feedback
* rotas centralizadas

Evitar:

* `any`
* URL de API hardcoded
* lógica HTTP dentro de componentes
* componentes gigantes
* repetição de código
* CSS espalhado sem padrão

---

# 33. Ordem para geração

Ao receber a instrução:

```text
CRIAR PROJETO
```

executar nesta ordem:

```text
01. Criar estrutura de diretórios
02. Criar Solution .NET
03. Criar projetos Backend
04. Configurar referências
05. Criar estrutura Domain
06. Criar estrutura Application
07. Criar Infrastructure
08. Criar CrossCutting
09. Criar APIs
10. Configurar Swagger
11. Configurar logging
12. Configurar exception handling
13. Configurar banco
14. Criar estrutura de testes
15. Criar React Admin
16. Criar React Site
17. Configurar rotas
18. Configurar services HTTP
19. Configurar autenticação
20. Criar Dockerfiles
21. Criar docker-compose
22. Criar .env.example
23. Criar README
24. Executar build Backend
25. Executar build Frontend
26. Corrigir erros
27. Executar testes
```

---

# 34. Regra para IA

Antes de criar código:

1. Ler este arquivo.
2. Ler `tasks/rules`.
3. Identificar Skills necessárias.
4. Ler somente as Skills necessárias.
5. Ler a Spec que será executada.
6. Implementar.
7. Executar build.
8. Executar testes.
9. Corrigir erros.
10. Registrar conclusão.

Não alterar arquitetura sem necessidade.

Não criar novos padrões quando já existir padrão equivalente no projeto.

Reutilizar implementações existentes sempre que possível.

---

# 35. Resultado esperado

Ao finalizar a criação inicial, a solução deverá executar:

```bash
docker compose up -d
```

E disponibilizar:

```text
Admin
http://localhost:8081

Site
http://localhost:8082

Admin API Swagger
http://localhost:5001/swagger

Site API Swagger
http://localhost:5002/swagger
```

O Backend e o Frontend deverão compilar sem erros e possuir estrutura pronta para receber novas Specs.
