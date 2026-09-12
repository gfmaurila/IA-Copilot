# CRIAR PROJETO - ESTRUTURA INICIAL COMPLETA

## Objetivo

Criar toda a estrutura inicial do projeto `MeuProjeto`, incluindo:

- backend em .NET
- frontend em React separado por módulos
- testes
- documentação
- estrutura de tasks/specs
- skills
- rules
- Dockerfiles
- Docker Compose separado para backend
- Docker Compose separado para frontend
- Docker Compose geral na raiz

Esta etapa deverá criar a estrutura física completa do projeto.

Não implementar regras de negócio ainda.

---

# 1. Nome do projeto

Utilizar inicialmente:

```text
MeuProjeto
```

O nome deverá ser utilizado em:

- solution
- projects
- namespaces
- APIs
- testes

---

# 2. Estrutura final obrigatória

Criar exatamente esta estrutura:

```text
MeuProjeto
│
├── backend
│   │
│   ├── src
│   │   │
│   │   ├── API
│   │   │   ├── MeuProjeto.API.Auth
│   │   │   ├── MeuProjeto.API.Person
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
│   ├── test
│   │   ├── unitario
│   │   │   ├── MeuProjeto.Domain.Tests
│   │   │   └── MeuProjeto.Application.Tests
│   │   └── integrado
│   │       ├── MeuProjeto.API.IntegrationTests
│   │       └── MeuProjeto.Infrastructure.IntegrationTests
│   │
│   ├── docs
│   │   ├── architecture.md
│   │   ├── project-structure.md
│   │   ├── backend.md
│   │   ├── frontend.md
│   │   ├── docker.md
│   │   └── testing.md
│   │
│   ├── task
│   │   ├── specs
│   │   │   ├── changes
│   │   │   └── archive
│   │   ├── skills
│   │   │   ├── create-entity
│   │   │   ├── create-value-object
│   │   │   ├── create-command
│   │   │   ├── create-query
│   │   │   ├── create-handler
│   │   │   ├── create-validator
│   │   │   ├── create-domain-event
│   │   │   ├── create-repository
│   │   │   ├── create-controller
│   │   │   ├── create-unit-test
│   │   │   ├── create-integration-test
│   │   │   ├── react-module
│   │   │   ├── react-page
│   │   │   ├── react-form
│   │   │   └── react-service
│   │   ├── rules
│   │   │   ├── architecture.md
│   │   │   ├── backend.md
│   │   │   ├── domain.md
│   │   │   ├── application.md
│   │   │   ├── infrastructure.md
│   │   │   ├── api.md
│   │   │   ├── frontend.md
│   │   │   ├── tests.md
│   │   │   └── docker.md
│   │   └── EXECUTAR-TODAS.md
│   │
│   ├── MeuProjeto.sln
│   ├── docker-compose.yml
│   ├── .dockerignore
│   ├── README.md
│   └── .gitignore
│
├── frontend
│   ├── admin
│   │   ├── public
│   │   ├── src
│   │   │   ├── app
│   │   │   ├── assets
│   │   │   ├── components
│   │   │   ├── hooks
│   │   │   ├── layouts
│   │   │   ├── modules
│   │   │   ├── routes
│   │   │   ├── services
│   │   │   ├── shared
│   │   │   ├── types
│   │   │   └── utils
│   │   ├── Dockerfile
│   │   ├── package.json
│   │   ├── vite.config.ts
│   │   ├── tsconfig.json
│   │   └── .env.example
│   │
│   ├── auth
│   │   ├── public
│   │   ├── src
│   │   │   ├── app
│   │   │   ├── assets
│   │   │   ├── components
│   │   │   ├── hooks
│   │   │   ├── layouts
│   │   │   ├── modules
│   │   │   ├── routes
│   │   │   ├── services
│   │   │   ├── shared
│   │   │   ├── types
│   │   │   └── utils
│   │   ├── Dockerfile
│   │   ├── package.json
│   │   ├── vite.config.ts
│   │   ├── tsconfig.json
│   │   └── .env.example
│   │
│   ├── site
│   │   ├── public
│   │   ├── src
│   │   │   ├── app
│   │   │   ├── assets
│   │   │   ├── components
│   │   │   ├── hooks
│   │   │   ├── layouts
│   │   │   ├── modules
│   │   │   ├── routes
│   │   │   ├── services
│   │   │   ├── shared
│   │   │   ├── types
│   │   │   └── utils
│   │   ├── Dockerfile
│   │   ├── package.json
│   │   ├── vite.config.ts
│   │   ├── tsconfig.json
│   │   └── .env.example
│   │
│   ├── docker-compose.yml
│   ├── .dockerignore
│   ├── README.md
│   └── .gitignore
│
├── docker-compose.yml
├── .env.example
├── .gitignore
├── README.md
└── CRIAR-PROJETO.md
```

---

# 3. Backend

Criar todos os projetos .NET dentro de:

```text
backend
```

A Solution deverá ficar obrigatoriamente em:

```text
backend/MeuProjeto.sln
```

Não criar `MeuProjeto.sln` na raiz do projeto.

---

# 4. Criar Solution

Dentro de `backend`, executar:

```bash
dotnet new sln -n MeuProjeto
```

Resultado esperado:

```text
backend/MeuProjeto.sln
```

---

# 5. APIs

Criar quatro projetos ASP.NET Core Web API:

```text
backend/src/API/MeuProjeto.API.Auth
backend/src/API/MeuProjeto.API.Person
backend/src/API/MeuProjeto.API.Admin
backend/src/API/MeuProjeto.API.Site
```

Cada API deve utilizar Controllers.

Não utilizar Minimal API como arquitetura principal.

Cada API deve possuir inicialmente:

```text
Controllers
Extensions
Middleware
Properties
Program.cs
appsettings.json
appsettings.Development.json
Dockerfile
```

Remover arquivos de exemplo desnecessários, como `WeatherForecast.cs` e `WeatherForecastController.cs`, caso sejam gerados.

---

# 6. Health Controller

Criar em cada API:

```text
Controllers/HealthController.cs
```

Endpoint:

```http
GET /api/health
```

Respostas:

```json
{
  "application": "MeuProjeto.API.Auth",
  "status": "OK"
}
```

```json
{
  "application": "MeuProjeto.API.Person",
  "status": "OK"
}
```

```json
{
  "application": "MeuProjeto.API.Admin",
  "status": "OK"
}
```

```json
{
  "application": "MeuProjeto.API.Site",
  "status": "OK"
}
```

---

# 7. Application

Criar:

```text
backend/src/Application/MeuProjeto.Application
```

Tipo:

```text
Class Library
```

Estrutura:

```text
MeuProjeto.Application
│
├── Common
├── Behaviors
├── Interfaces
├── Mappings
├── Auth
│   ├── Commands
│   └── Queries
├── Person
│   ├── Commands
│   └── Queries
├── Admin
│   ├── Commands
│   └── Queries
└── Site
    ├── Commands
    └── Queries
```

Não implementar Commands ou Queries nesta etapa.

---

# 8. Domain

Criar:

```text
backend/src/Domain/MeuProjeto.Domain
```

Tipo:

```text
Class Library
```

Estrutura:

```text
MeuProjeto.Domain
│
├── Core
│   ├── Entities
│   ├── ValueObjects
│   ├── Events
│   ├── Exceptions
│   ├── Interfaces
│   └── Enums
├── Auth
├── Person
├── Admin
├── Site
└── Shared
```

O Domain deverá ser independente.

Não adicionar referência para:

- Application
- Infrastructure
- CrossCutting
- API
- Entity Framework
- ASP.NET Core

---

# 9. Infrastructure

Criar:

```text
backend/src/Infrastructure/MeuProjeto.Infrastructure
```

Tipo:

```text
Class Library
```

Estrutura:

```text
MeuProjeto.Infrastructure
│
├── Persistence
│   ├── Context
│   ├── Configurations
│   └── Migrations
├── Repositories
├── Authentication
├── Cache
├── Messaging
├── Logging
├── Services
└── DependencyInjection
```

Não criar DbContext ou banco nesta etapa.

---

# 10. CrossCutting

Criar:

```text
backend/src/CrossCutting/MeuProjeto.CrossCutting
```

Tipo:

```text
Class Library
```

Estrutura:

```text
MeuProjeto.CrossCutting
│
├── DependencyInjection
├── Middleware
├── Exceptions
├── Extensions
├── Constants
├── Options
└── Configuration
```

---

# 11. Referências entre projetos

Configurar:

```text
Application -> Domain

Infrastructure -> Application
Infrastructure -> Domain

CrossCutting -> Application
CrossCutting -> Infrastructure

API.Auth -> Application
API.Auth -> CrossCutting

API.Person -> Application
API.Person -> CrossCutting

API.Admin -> Application
API.Admin -> CrossCutting

API.Site -> Application
API.Site -> CrossCutting
```

Dependências proibidas:

```text
Domain -> Application
Domain -> Infrastructure
Domain -> CrossCutting
Domain -> API

Application -> Infrastructure
Application -> CrossCutting
Application -> API

Infrastructure -> API
```

---

# 12. Adicionar projetos à Solution

Adicionar à:

```text
backend/MeuProjeto.sln
```

os projetos:

```text
MeuProjeto.API.Auth
MeuProjeto.API.Person
MeuProjeto.API.Admin
MeuProjeto.API.Site

MeuProjeto.Application
MeuProjeto.Domain
MeuProjeto.Infrastructure
MeuProjeto.CrossCutting
```

---

# 13. Testes

Criar:

```text
backend/test/unitario/MeuProjeto.Domain.Tests
backend/test/unitario/MeuProjeto.Application.Tests

backend/test/integrado/MeuProjeto.API.IntegrationTests
backend/test/integrado/MeuProjeto.Infrastructure.IntegrationTests
```

Utilizar xUnit.

Referências:

```text
Domain.Tests -> Domain

Application.Tests -> Application
Application.Tests -> Domain
```

Adicionar todos os projetos de teste à Solution.

Criar ao menos um teste inicial simples em cada projeto.

---

# 14. Frontend

O frontend deverá ficar fora de `backend`.

Criar três aplicações independentes:

```text
frontend/admin
frontend/auth
frontend/site
```

Utilizar:

- React
- TypeScript
- Vite

Não criar `backend/frontend`.

---

# 15. Estrutura Frontend

Cada módulo deverá possuir:

```text
src
│
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

Página inicial:

```text
MeuProjeto - Admin
MeuProjeto - Auth
MeuProjeto - Site
```

Dependências iniciais:

```text
react
react-dom
typescript
vite
react-router-dom
axios
```

Não instalar ainda:

```text
TanStack Query
React Hook Form
Zod
UI Framework
```

---

# 16. Environment Frontend

Criar `.env.example` em cada projeto.

Admin:

```env
VITE_AUTH_API_URL=http://localhost:5001
VITE_PERSON_API_URL=http://localhost:5002
VITE_ADMIN_API_URL=http://localhost:5003
VITE_SITE_API_URL=http://localhost:5004
```

Auth:

```env
VITE_AUTH_API_URL=http://localhost:5001
```

Site:

```env
VITE_SITE_API_URL=http://localhost:5004
```

---

# 17. Docker Backend

Criar:

```text
backend/docker-compose.yml
```

Serviços:

```text
auth-api
person-api
admin-api
site-api
sqlserver
redis
```

Portas:

```text
Auth API       5001
Person API     5002
Admin API      5003
Site API       5004
SQL Server     1433
Redis          6379
```

Criar Dockerfile multi-stage em cada API:

```text
backend/src/API/MeuProjeto.API.Auth/Dockerfile
backend/src/API/MeuProjeto.API.Person/Dockerfile
backend/src/API/MeuProjeto.API.Admin/Dockerfile
backend/src/API/MeuProjeto.API.Site/Dockerfile
```

---

# 18. Docker Frontend

Criar:

```text
frontend/docker-compose.yml
```

Serviços:

```text
admin
auth
site
```

Portas:

```text
Admin  8081
Auth   8082
Site   8083
```

Criar Dockerfile multi-stage em:

```text
frontend/admin/Dockerfile
frontend/auth/Dockerfile
frontend/site/Dockerfile
```

Fluxo:

```text
Node
↓
npm install
↓
npm run build
↓
Nginx
```

---

# 19. Docker Compose da raiz

Criar obrigatoriamente:

```text
/docker-compose.yml
```

Este será o Docker Compose principal.

Deverá subir:

```text
Auth API
Person API
Admin API
Site API
SQL Server
Redis

Frontend Admin
Frontend Auth
Frontend Site
```

Com:

```bash
docker compose up -d
```

Criar network:

```text
meuprojeto-network
```

Criar volumes:

```text
sqlserver-data
redis-data
```

O compose da raiz deverá ser independente e não exigir a execução prévia dos composes internos.

---

# 20. Função dos três Docker Compose

```text
backend/docker-compose.yml
→ desenvolvimento somente do backend

frontend/docker-compose.yml
→ desenvolvimento somente do frontend

/docker-compose.yml
→ execução completa do projeto
```

---

# 21. Documentação

Criar:

```text
backend/docs
```

Arquivos:

```text
architecture.md
project-structure.md
backend.md
frontend.md
docker.md
testing.md
```

`architecture.md` deverá documentar:

```text
API
 ↓
Application
 ↓
Domain
```

e:

```text
Infrastructure
 ↓
Application
 ↓
Domain
```

---

# 22. Tasks

Criar:

```text
backend/task
```

Estrutura:

```text
task
│
├── specs
│   ├── changes
│   └── archive
├── skills
├── rules
└── EXECUTAR-TODAS.md
```

---

# 23. Skills

Criar:

```text
create-entity
create-value-object
create-command
create-query
create-handler
create-validator
create-domain-event
create-repository
create-controller
create-unit-test
create-integration-test

react-module
react-page
react-form
react-service
```

Cada pasta deve possuir:

```text
SKILL.md
```

Conteúdo inicial:

```markdown
# Nome da Skill

## Objetivo

Definir o padrão utilizado pelo projeto para executar esta tarefa.

## Regras

As regras serão evoluídas nas próximas especificações.
```

---

# 24. Rules

Criar:

```text
backend/task/rules/architecture.md
backend/task/rules/backend.md
backend/task/rules/domain.md
backend/task/rules/application.md
backend/task/rules/infrastructure.md
backend/task/rules/api.md
backend/task/rules/frontend.md
backend/task/rules/tests.md
backend/task/rules/docker.md
```

Regra inicial de arquitetura:

```markdown
# Architecture Rules

## Domain

Domain não depende de nenhuma outra camada.

## Application

Application depende somente de Domain.

## Infrastructure

Infrastructure pode depender de:

- Application
- Domain

## API

API pode depender de:

- Application
- CrossCutting

## CrossCutting

CrossCutting centraliza configurações e Dependency Injection.

## Controllers

Controllers não devem possuir regras de negócio.

## CQRS

Commands serão responsáveis por alterações.

Queries serão responsáveis por consultas.
```

---

# 25. EXECUTAR-TODAS.md

Criar:

```text
backend/task/EXECUTAR-TODAS.md
```

Conteúdo:

```markdown
# EXECUTAR TODAS AS SPECS

Você é o agente orquestrador do projeto.

As especificações ficam em:

backend/task/specs/changes

Execute sempre em ordem numérica.

Para cada SPEC:

1. leia a especificação;
2. leia as rules relacionadas;
3. leia as skills necessárias;
4. implemente somente o escopo solicitado;
5. não altere módulos sem necessidade;
6. execute build;
7. execute testes;
8. valide critérios de aceite;
9. corrija falhas;
10. crie result.md;
11. finalize a SPEC.

Somente o orquestrador pode iniciar automaticamente a próxima SPEC.

Uma SPEC individual deve encerrar após sua própria validação.
```

---

# 26. Specs iniciais

Criar as pastas abaixo em:

```text
backend/task/specs/changes
```

```text
001-criar-estrutura-projeto
002-configurar-backend
003-configurar-dependency-injection
004-configurar-cqrs
005-configurar-validation
006-configurar-domain-events
007-configurar-logging
008-configurar-exception-handling
009-configurar-api-response
010-configurar-entity-framework
011-configurar-sqlserver
012-configurar-redis
013-configurar-health-check
014-configurar-swagger
015-auth-domain
016-auth-user
017-auth-role
018-auth-permission
019-auth-jwt
020-auth-refresh-token
021-auth-login
022-auth-logout
023-auth-forgot-password
024-auth-reset-password
025-auth-change-password
026-auth-current-user
027-person-domain
028-person-create
029-person-update
030-person-delete
031-person-get-by-id
032-person-get-all
033-person-pagination
034-person-search
035-admin-dashboard-api
036-admin-users-api
037-admin-roles-api
038-admin-permissions-api
039-admin-settings-api
040-admin-logs-api
041-frontend-auth-base
042-frontend-auth-login
043-frontend-auth-forgot-password
044-frontend-auth-reset-password
045-frontend-admin-base
046-frontend-admin-layout
047-frontend-admin-dashboard
048-frontend-admin-users-list
049-frontend-admin-users-create
050-frontend-admin-users-edit
051-frontend-admin-users-detail
052-frontend-admin-person-list
053-frontend-admin-person-create
054-frontend-admin-person-edit
055-frontend-admin-person-detail
056-frontend-admin-settings
057-frontend-site-base
058-frontend-site-home
059-frontend-site-contact
060-testes-domain
061-testes-application
062-testes-api
063-testes-infrastructure
064-docker-backend
065-docker-frontend
066-docker-root
067-documentacao
068-github-actions
069-code-quality
070-final-validation
```

Não implementar estas specs nesta execução.

Criar somente as pastas.

---

# 27. README da raiz

Criar:

```text
README.md
```

Conteúdo inicial:

```markdown
# MeuProjeto

Projeto composto por backend .NET e frontend React.

## Backend

Local:

backend

Solution:

backend/MeuProjeto.sln

## Frontend

Local:

frontend

Aplicações:

- admin
- auth
- site

## Docker

Backend:

backend/docker-compose.yml

Frontend:

frontend/docker-compose.yml

Projeto completo:

docker-compose.yml

## Tasks

backend/task

## Documentação

backend/docs
```

---

# 28. .gitignore

Criar `.gitignore` na raiz compatível com:

- .NET
- Visual Studio
- VS Code
- JetBrains
- Node
- React
- Vite
- Docker

Ignorar pelo menos:

```text
bin/
obj/
.vs/
.idea/

node_modules/
dist/

.env
.env.local
.env.*.local

coverage/

*.user
*.suo
```

Não ignorar:

```text
.env.example
```

---

# 29. .dockerignore Backend

Criar:

```text
backend/.dockerignore
```

Ignorar:

```text
**/bin
**/obj
.vs
.git
.gitignore
README.md
```

---

# 30. .dockerignore Frontend

Criar:

```text
frontend/.dockerignore
```

Ignorar:

```text
**/node_modules
**/dist
.git
.gitignore
README.md
```

---

# 31. Environment raiz

Criar:

```text
.env.example
```

Conteúdo:

```env
# SQL SERVER
SQLSERVER_PORT=1433
SQLSERVER_DATABASE=MeuProjeto
SQLSERVER_USER=sa
SQLSERVER_PASSWORD=CHANGE_ME

# REDIS
REDIS_PORT=6379

# BACKEND
AUTH_API_PORT=5001
PERSON_API_PORT=5002
ADMIN_API_PORT=5003
SITE_API_PORT=5004

# FRONTEND
ADMIN_FRONTEND_PORT=8081
AUTH_FRONTEND_PORT=8082
SITE_FRONTEND_PORT=8083
```

Nunca criar senha real no repositório.

---

# 32. Build Backend

Após criar a estrutura, executar dentro de `backend`:

```bash
dotnet restore MeuProjeto.sln
dotnet build MeuProjeto.sln
dotnet test MeuProjeto.sln
```

Resultado esperado:

```text
0 erros
todos os testes aprovados
```

---

# 33. Build Frontend

Executar:

```bash
cd frontend/admin
npm install
npm run build
```

Depois:

```bash
cd frontend/auth
npm install
npm run build
```

Depois:

```bash
cd frontend/site
npm install
npm run build
```

Todos os builds devem finalizar sem erros.

---

# 34. Validar Docker

Backend:

```bash
cd backend
docker compose config
```

Frontend:

```bash
cd frontend
docker compose config
```

Raiz:

```bash
docker compose config
```

Nenhum compose poderá apresentar erro de sintaxe.

---

# 35. Restrições desta execução

NÃO implementar ainda:

```text
DDD funcional
entidades reais
CQRS funcional
MediatR
FluentValidation
AutoMapper
Entity Framework
DbContext
Migrations
JWT
Refresh Token
Login
Redis funcional
CRUD
Dashboard
Roles
Permissions
Person
User
Mensageria
GitHub Actions
```

Nesta execução preparar somente:

```text
estrutura
projetos
pastas
referências
build
frontends
docker
docs
task
skills
rules
testes iniciais
```

---

# 36. Critérios de aceite

A execução somente estará concluída quando:

- [ ] `backend` existir
- [ ] `frontend` existir
- [ ] `backend/MeuProjeto.sln` existir
- [ ] não existir Solution na raiz
- [ ] quatro APIs existirem
- [ ] Application existir
- [ ] Domain existir
- [ ] Infrastructure existir
- [ ] CrossCutting existir
- [ ] testes unitários existirem
- [ ] testes integrados existirem
- [ ] todos os projetos .NET estiverem adicionados à Solution
- [ ] referências entre projetos estiverem corretas
- [ ] Domain não possuir dependências proibidas
- [ ] `frontend/admin` existir
- [ ] `frontend/auth` existir
- [ ] `frontend/site` existir
- [ ] Admin compilar
- [ ] Auth compilar
- [ ] Site compilar
- [ ] Dockerfile existir nas quatro APIs
- [ ] Dockerfile existir em admin
- [ ] Dockerfile existir em auth
- [ ] Dockerfile existir em site
- [ ] `backend/docker-compose.yml` existir
- [ ] `frontend/docker-compose.yml` existir
- [ ] `/docker-compose.yml` existir
- [ ] Docker Compose backend estiver válido
- [ ] Docker Compose frontend estiver válido
- [ ] Docker Compose raiz estiver válido
- [ ] `backend/task` existir
- [ ] `backend/task/specs` existir
- [ ] `backend/task/skills` existir
- [ ] `backend/task/rules` existir
- [ ] as 70 pastas de specs iniciais existirem
- [ ] documentação inicial existir
- [ ] README raiz existir
- [ ] README backend existir
- [ ] README frontend existir
- [ ] `dotnet restore` funcionar
- [ ] `dotnet build` funcionar
- [ ] `dotnet test` funcionar
- [ ] npm build do admin funcionar
- [ ] npm build do auth funcionar
- [ ] npm build do site funcionar

---

# 37. Resultado da execução

Ao terminar criar:

```text
backend/task/specs/changes/001-criar-estrutura-projeto/result.md
```

Conteúdo:

```markdown
# RESULTADO - 001 CRIAR ESTRUTURA DO PROJETO

## Status

Concluído / Falhou

## Backend

### Solution

Resultado da criação da Solution.

### Projetos

Listar todos os projetos criados.

### Build

Resultado do `dotnet build`.

### Tests

Resultado do `dotnet test`.

## Frontend

### Admin

Resultado do npm build.

### Auth

Resultado do npm build.

### Site

Resultado do npm build.

## Docker

### Backend

Resultado do `docker compose config`.

### Frontend

Resultado do `docker compose config`.

### Root

Resultado do `docker compose config`.

## Arquivos criados

Resumo da estrutura criada.

## Problemas encontrados

Listar problemas e respectivas correções.

## Critérios de aceite

Informar quais critérios foram validados.

## Próxima SPEC

002-configurar-backend
```

---

# 38. Regra final

Esta especificação representa somente o bootstrap inicial.

Ao finalizar:

1. validar backend;
2. validar frontend;
3. validar Docker;
4. validar testes;
5. gerar `result.md`;
6. encerrar.

NÃO iniciar automaticamente:

```text
002-configurar-backend
```

A próxima especificação somente poderá ser iniciada explicitamente pelo orquestrador.
