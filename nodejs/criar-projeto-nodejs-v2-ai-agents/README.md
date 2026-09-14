# Base Node.js v2 — AI Agents

Template para **criação, evolução e refatoração automatizada de projetos Full Stack** utilizando:

**Node.js + TypeScript + Fastify + Prisma + MySQL + React**

com um processo de engenharia assistido por IA baseado em:

```text
Specs
+
Rules
+
Skills
+
AI Agents
+
Workflows
+
Quality Gates
+
State
```

O objetivo é permitir que a IA não apenas gere código, mas participe de um fluxo estruturado de:

```text
Requisitos
   ↓
Arquitetura
   ↓
Planejamento
   ↓
Implementação
   ↓
Testes
   ↓
Review
   ↓
Documentação
   ↓
Entrega
```

---

# 🚀 Stack

## Backend

```text
Node.js
TypeScript
Fastify
Prisma ORM
MySQL
Zod
JWT
```

## Frontend

```text
React
TypeScript
Vite
React Router
Axios
React Hook Form
TanStack Query
```

## Testes

```text
Vitest
Unit Tests
Integration Tests
API Tests
```

## Infraestrutura

```text
Docker
Docker Compose
Environment Variables
```

## AI Engineering

```text
Specs
Rules
Skills
Agents
Workflows
Quality Gates
State
```

> As versões das dependências devem ser revalidadas no momento da geração para utilizar versões estáveis, compatíveis e suportadas.

---

# 🎯 Objetivo

Uma solicitação como:

```text
Criar gerenciamento de usuários
```

não deve iniciar imediatamente a geração de código.

Primeiro o pipeline deve responder:

```text
O que precisa ser feito?
        ↓
Quais são os requisitos?
        ↓
Quais regras precisam ser respeitadas?
        ↓
Qual será a solução arquitetural?
        ↓
Quais componentes serão modificados?
        ↓
Como será implementado?
        ↓
Como será testado?
```

Somente depois dessa análise começa a implementação.

---

# 🧠 Princípio arquitetural

Este projeto deve utilizar **padrões naturais do ecossistema Node.js**.

Não copiar mecanicamente estruturas provenientes de:

```text
C#
.NET
Java
Spring
```

Evitar abstrações apenas porque são comuns em outros ecossistemas.

A arquitetura deve permanecer:

```text
Simples
Modular
Testável
Previsível
Evolutiva
```

Preferir:

```text
Modules por Feature
Routes finas
Controllers finos quando necessários
Services
Repositories quando necessários
Prisma
Zod
Hooks
Middlewares
Plugins Fastify
Dependency Composition
```

---

# 📦 Organização por Feature

A organização principal deve favorecer funcionalidades.

Exemplo:

```text
src/
├── modules/
│   │
│   ├── auth/
│   │   ├── auth.routes.ts
│   │   ├── auth.controller.ts
│   │   ├── auth.service.ts
│   │   ├── auth.schema.ts
│   │   └── auth.types.ts
│   │
│   ├── users/
│   │   ├── users.routes.ts
│   │   ├── users.controller.ts
│   │   ├── users.service.ts
│   │   ├── users.repository.ts
│   │   ├── users.schema.ts
│   │   └── users.types.ts
│   │
│   └── permissions/
│       ├── permissions.routes.ts
│       ├── permissions.service.ts
│       └── permissions.schema.ts
│
├── plugins/
├── hooks/
├── middlewares/
├── config/
├── lib/
└── app.ts
```

Evitar uma estrutura global excessivamente horizontal como:

```text
controllers/
services/
repositories/
schemas/
routes/
```

quando isso espalhar componentes relacionados à mesma funcionalidade por todo o projeto.

---

# ⚡ Fastify

O Fastify é responsável pela camada HTTP.

Exemplo conceitual:

```typescript
fastify.register(usersRoutes, {
  prefix: "/users",
});

fastify.register(authRoutes, {
  prefix: "/auth",
});
```

As routes devem permanecer simples.

Fluxo recomendado:

```text
Request
   ↓
Route
   ↓
Schema / Validation
   ↓
Controller
   ↓
Service
   ↓
Repository / Prisma
   ↓
Database
```

Para funcionalidades simples:

```text
Request
   ↓
Route
   ↓
Validation
   ↓
Service
   ↓
Prisma
```

Não é obrigatório criar Controller ou Repository quando não houver benefício real.

---

# 🧩 Services

Services concentram regras de aplicação.

Exemplo:

```text
users.service.ts
auth.service.ts
permissions.service.ts
```

Responsabilidades:

```text
Orquestração
Regras de aplicação
Validações de negócio
Integrações
Coordenação da persistência
```

Routes não devem conter regras complexas de negócio.

---

# 🗄️ Repositories

Repositories devem ser utilizados quando trouxerem benefício arquitetural real.

Exemplo:

```text
users.repository.ts
```

Responsabilidades:

```text
Consultas reutilizáveis
Persistência complexa
Isolamento de queries
Abstração de acesso relevante
```

Evitar:

```text
Repository
    ↓
Prisma
```

quando o Repository apenas replica cada método do Prisma sem adicionar qualquer valor.

---

# 🔷 Prisma ORM

O Prisma é utilizado como camada principal de acesso ao banco.

Estrutura:

```text
prisma/
├── schema.prisma
├── migrations/
└── seed.ts
```

Fluxo:

```text
Prisma Schema
      ↓
Migration
      ↓
MySQL
      ↓
Prisma Client
      ↓
Application
```

---

# 🗃️ MySQL

O banco inicial do template é:

```text
MySQL
```

A configuração deve ser realizada através de variável de ambiente.

Exemplo:

```env
DATABASE_URL="mysql://user:password@localhost:3306/app"
```

Credenciais reais nunca devem ser versionadas.

---

# 🔄 Migrations

Alterações estruturais do banco devem gerar migrations.

Fluxo:

```text
Model Change
     ↓
schema.prisma
     ↓
Prisma Migration
     ↓
Migration Review
     ↓
Database
```

Exemplo:

```bash
npx prisma migrate dev --name create_users
```

Para geração do Prisma Client:

```bash
npx prisma generate
```

---

# 🌱 Seed

O projeto pode possuir:

```text
prisma/seed.ts
```

para criação de dados iniciais.

Exemplos:

```text
Admin User
Roles
Permissions
Configuration
Development Data
```

O Seed deve ser seguro para o ambiente em que será executado.

---

# ✅ Zod

Zod é utilizado para validação e definição de schemas.

Exemplo:

```typescript
const createUserSchema = z.object({
  name: z.string().min(3),
  email: z.string().email(),
  password: z.string().min(8),
});
```

Pode ser utilizado para:

```text
Request validation
Environment validation
DTO validation
Configuration validation
```

---

# 🔐 Autenticação

O template prevê autenticação utilizando:

```text
JWT
```

Fluxo:

```text
Credentials
     ↓
Validation
     ↓
Authentication
     ↓
JWT
     ↓
Protected Route
```

A fundação pode contemplar:

```text
Login
Logout
Access Token
Refresh Token
Forgot Password
Reset Password
```

conforme definido pela Spec.

---

# 🛡️ Authorization

A autorização pode trabalhar com:

```text
Roles
Permissions
Policies
```

Exemplo:

```text
User
 ↓
Role
 ↓
Permissions
 ↓
Route
```

Permissões:

```text
users.read
users.create
users.update
users.delete
```

Hooks ou middlewares podem validar permissões antes da execução da funcionalidade.

---

# 🔌 Fastify Plugins

Funcionalidades compartilhadas devem preferencialmente utilizar o sistema de plugins do Fastify quando apropriado.

Exemplo:

```text
plugins/
├── prisma.ts
├── auth.ts
├── cors.ts
├── security.ts
└── logger.ts
```

Isso permite composição modular da aplicação.

---

# 🪝 Hooks e Middlewares

Podem ser utilizados para responsabilidades transversais.

Exemplos:

```text
Authentication
Authorization
Logging
Request Context
Error Handling
Audit
Rate Limiting
```

Evitar colocar regras específicas de negócio em middlewares globais.

---

# ⚛️ Frontend

O frontend utiliza:

```text
React
TypeScript
Vite
React Router
Axios
React Hook Form
TanStack Query
```

O template pode gerar duas aplicações:

```text
frontend/
├── admin/
└── site/
```

---

# 🖥️ React Admin

Aplicação administrativa.

Exemplo:

```text
Admin
├── Dashboard
├── Users
├── Roles
├── Permissions
└── Settings
```

CRUDs podem utilizar:

```text
Users/
├── List/
├── New/
├── Edit/
└── Detail/
```

---

# 🌐 React Site

Aplicação destinada ao usuário final.

Fluxo:

```text
Browser
   ↓
React Site
   ↓
Axios
   ↓
Fastify API
   ↓
Prisma
   ↓
MySQL
```

---

# 🔄 TanStack Query

TanStack Query deve ser utilizado para gerenciamento de estado de servidor.

Exemplo:

```text
React Component
      ↓
TanStack Query
      ↓
API Client
      ↓
Fastify
```

Responsabilidades:

```text
Queries
Mutations
Caching
Refetch
Loading State
Error State
Invalidation
```

---

# 📝 React Hook Form

Formulários devem preferencialmente utilizar:

```text
React Hook Form
+
Schema Validation
```

Exemplo:

```text
Form
 ↓
React Hook Form
 ↓
Validation
 ↓
Mutation
 ↓
API
```

---

# 🤖 AI Software Factory

A geração utiliza agentes especializados.

```text
Solicitação / Spec
        │
        ▼
Requirements Agent
        │
        ▼
Architect Agent
        │
        ▼
Tech Lead Agent
        │
        ▼
Developer Agent
        │
        ▼
Tester Agent
        │
        ▼
Reviewer Agent
        │
        ▼
Documentation Agent
        │
        ▼
DONE
```

Cada agente possui responsabilidades específicas.

---

# 🔎 Requirements Agent

Responsável por transformar a Spec em requisitos claros.

Analisa:

```text
Requisitos funcionais
Requisitos não funcionais
Regras de negócio
Critérios de aceite
Restrições
Dependências
Riscos
```

Produz:

```text
tasks/generated/REQUIREMENTS.md
```

---

# 🏛️ Architect Agent

Responsável pelas decisões arquiteturais.

Analisa:

```text
Modules
Fastify
Prisma
MySQL
Security
Frontend
Docker
Integrações
Testabilidade
```

Produz:

```text
tasks/generated/ARCHITECTURE_PLAN.md
```

Uma responsabilidade importante é impedir **overengineering**.

---

# 👨‍💻 Tech Lead Agent

Transforma os requisitos e a arquitetura em tarefas executáveis.

Produz:

```text
tasks/generated/EXECUTION_PLAN.md
```

Exemplo:

```text
TASK-001 Database Model
TASK-002 Prisma Migration
TASK-003 Users Module
TASK-004 Authentication
TASK-005 Authorization
TASK-006 Unit Tests
TASK-007 Integration Tests
TASK-008 React Admin
```

Cada Task deve possuir:

```text
Objetivo
Dependências
Arquivos envolvidos
Critérios de aceite
Testes
Status
```

---

# 💻 Developer Agent

Responsável pela implementação.

Utiliza:

```text
Spec
+
Rules
+
Skills
+
REQUIREMENTS.md
+
ARCHITECTURE_PLAN.md
+
EXECUTION_PLAN.md
```

O Developer deve seguir padrões naturais de Node.js e TypeScript.

Não deve criar abstrações desnecessárias apenas para reproduzir arquiteturas utilizadas nos templates .NET ou Java.

---

# 🧪 Tester Agent

Responsável por executar e validar testes.

Analisa:

```text
Unit Tests
Integration Tests
API Tests
Persistence
Authentication
Authorization
Frontend
```

Produz:

```text
tasks/reports/TEST_REPORT.md
```

Se houver falha:

```text
Tester
  ↓
FAIL
  ↓
Developer
  ↓
Correction
  ↓
Tester
```

---

# 🔍 Reviewer Agent

Responsável pela revisão técnica.

Analisa:

```text
Arquitetura
TypeScript
Fastify
Prisma
Security
Error Handling
Duplicação
Testes
Frontend
Rules
Spec
```

Produz:

```text
tasks/reports/REVIEW_REPORT.md
```

Falhas críticas retornam ao Developer.

---

# 📚 Documentation Agent

Responsável por atualizar:

```text
README.md
ARCHITECTURE.md
API.md
CHANGELOG.md
docs/
```

A documentação deve refletir o estado real da implementação.

---

# 📁 Estrutura da AI Software Factory

```text
agents/
├── requirements/
├── architect/
├── tech-lead/
├── developer/
├── tester/
├── reviewer/
└── documentation/

orchestration/
├── workflows/
├── gates/
└── state/

prompts/
├── CREATE_PROJECT.md
└── REFACTOR_PROJECT.md

tasks/
├── rules/
├── skills/
├── specs/
├── generated/
└── reports/
```

---

# 📜 Rules

Rules definem:

> **Restrições permanentes do projeto.**

Exemplo:

```text
tasks/rules/
├── architecture.rules.md
├── nodejs.rules.md
├── typescript.rules.md
├── fastify.rules.md
├── prisma.rules.md
├── security.rules.md
├── testing.rules.md
├── frontend.rules.md
└── ai-agents.md
```

---

# 🧩 Skills

Skills definem:

> **Como executar operações repetíveis.**

Exemplo:

```text
tasks/skills/
├── create-module/
├── create-route/
├── create-service/
├── create-repository/
├── create-prisma-model/
├── create-migration/
├── create-test/
├── create-react-page/
└── create-docker-service/
```

---

# 📋 Specs

Specs definem:

> **O que deve ser entregue.**

Estrutura:

```text
tasks/specs/
└── changes/
```

Exemplo:

```text
tasks/specs/changes/001-project-foundation.md
```

---

# 📄 Artefatos antes do código

Antes da implementação devem existir:

```text
tasks/generated/
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
└── EXECUTION_PLAN.md
```

Fluxo obrigatório:

```text
SPEC
 ↓
REQUIREMENTS
 ↓
ARCHITECTURE
 ↓
EXECUTION PLAN
 ↓
IMPLEMENTATION
```

Evitar:

```text
SPEC
 ↓
CODE
```

Isso reduz implementação prematura e torna decisões técnicas verificáveis.

---

# 📊 Artefatos após implementação

Depois da implementação:

```text
tasks/reports/
├── TEST_REPORT.md
└── REVIEW_REPORT.md
```

Esses arquivos fazem parte dos critérios de conclusão.

---

# 🚦 Quality Gates

O pipeline possui oito gates principais.

```text
GATE-01 Requirements
GATE-02 Architecture
GATE-03 Persistence
GATE-04 Backend Quality
GATE-05 Tests
GATE-06 Security
GATE-07 Frontend / Review
GATE-08 Documentation
```

---

## GATE-01 — Requirements

Valida:

```text
REQUIREMENTS.md
Critérios de aceite
Regras de negócio
Dependências
Restrições
```

---

## GATE-02 — Architecture

Valida:

```text
ARCHITECTURE_PLAN.md
Organização por Feature
Fastify
Prisma
Frontend
Dependências
Simplicidade arquitetural
```

Também deve verificar se padrões de outros ecossistemas não foram copiados desnecessariamente.

---

## GATE-03 — Persistence

Valida:

```text
schema.prisma
Models
Relations
Indexes
Migrations
Seed
Database
```

---

## GATE-04 — Backend Quality

Valida:

```text
TypeScript
Lint
Type Checking
Fastify
Zod
Error Handling
Logging
Code Structure
```

Exemplo:

```bash
npm run lint
npm run typecheck
npm run build
```

---

## GATE-05 — Tests

Executa:

```bash
npm run test
```

ou:

```bash
npm run test:unit
npm run test:integration
```

Devem ser aprovados todos os testes obrigatórios definidos pela Spec.

---

## GATE-06 — Security

Valida:

```text
JWT
Authentication
Authorization
Permissions
Password Hashing
Environment Variables
Secrets
Input Validation
Sensitive Data
```

---

## GATE-07 — Frontend / Review

Valida:

```text
React
TypeScript
Routes
Forms
Queries
Mutations
API Integration
Error Handling
Architecture Review
```

---

## GATE-08 — Documentation

Valida:

```text
README
Architecture
API
Environment
Docker
Tests
Execution
Changes
```

---

# 🔁 Falha de Quality Gate

Falhas obrigatórias retornam ao processo de implementação.

```text
             QUALITY GATE
                   │
            ┌──────┴──────┐
            │             │
           PASS          FAIL
            │             │
            ▼             ▼
       Next Gate       Developer
                          │
                          ▼
                       Fix
                          │
                          ▼
                       Tester
                          │
                          ▼
                      Reviewer
                          │
                          └────► Gate
```

Se não for possível corrigir automaticamente, o bloqueio deve ser documentado.

---

# 💾 State

A pasta:

```text
orchestration/state/
```

mantém um resumo pequeno do progresso.

Pode registrar:

```text
Spec ativa
Etapa atual
Tasks concluídas
Tasks pendentes
Último build
Últimos testes
Quality Gates
Bloqueios
Próxima ação
```

Isso reduz a necessidade de reler todo o repositório.

Preferir:

```text
State
+
Spec
+
Rules relevantes
+
Skills relevantes
+
Arquivos necessários
        ↓
       IA
```

em vez de:

```text
Repository inteiro
       ↓
      IA
```

---

# 🐳 Docker

O projeto suporta Docker e Docker Compose.

Topologia conceitual:

```text
                     Browser
                        │
             ┌──────────┴──────────┐
             │                     │
             ▼                     ▼
         React Admin           React Site
             │                     │
             └──────────┬──────────┘
                        │
                        ▼
                     Fastify
                        │
                        ▼
                     Prisma
                        │
                        ▼
                      MySQL
```

Serviços devem ser adicionados conforme necessidade da Spec.

Evitar adicionar infraestrutura sem utilização real.

---

# 📂 Estrutura sugerida

```text
.
├── backend/
│   ├── src/
│   │   ├── modules/
│   │   │   ├── auth/
│   │   │   ├── users/
│   │   │   ├── roles/
│   │   │   └── permissions/
│   │   │
│   │   ├── plugins/
│   │   ├── hooks/
│   │   ├── middlewares/
│   │   ├── config/
│   │   ├── lib/
│   │   └── app.ts
│   │
│   ├── prisma/
│   │   ├── schema.prisma
│   │   ├── migrations/
│   │   └── seed.ts
│   │
│   ├── tests/
│   │   ├── unit/
│   │   └── integration/
│   │
│   └── package.json
│
├── frontend/
│   ├── admin/
│   └── site/
│
├── agents/
│   ├── requirements/
│   ├── architect/
│   ├── tech-lead/
│   ├── developer/
│   ├── tester/
│   ├── reviewer/
│   └── documentation/
│
├── orchestration/
│   ├── workflows/
│   ├── gates/
│   └── state/
│
├── prompts/
│   ├── CREATE_PROJECT.md
│   └── REFACTOR_PROJECT.md
│
├── tasks/
│   ├── rules/
│   ├── skills/
│   ├── specs/
│   ├── generated/
│   └── reports/
│
├── docs/
├── .env.example
├── docker-compose.yml
└── README.md
```

---

# 🛠️ Comandos principais

## Instalação

```bash
npm install
```

## Desenvolvimento

```bash
npm run dev
```

## Build

```bash
npm run build
```

## Testes

```bash
npm run test
```

## Lint

```bash
npm run lint
```

## Type Check

```bash
npm run typecheck
```

## Prisma Client

```bash
npx prisma generate
```

## Migration

```bash
npx prisma migrate dev
```

## Docker

```bash
docker compose up -d
```

---

# ▶️ Como iniciar

Para uma IA compatível com as instruções do repositório:

```text
Leia COPILOT.md e execute a Spec ativa seguindo o workflow de agentes.
```

Também pode ser utilizado:

```text
prompts/CREATE_PROJECT.md
```

Para refatoração:

```text
prompts/REFACTOR_PROJECT.md
```

---

# 📌 Spec inicial

A fundação inicial deve ser definida em:

```text
tasks/specs/changes/001-project-foundation.md
```

Essa Spec deve estabelecer:

```text
Backend
Frontend
Database
Authentication
Authorization
Testing
Docker
Project Structure
```

---

# 🛡️ Definition of Done

Código gerado não significa trabalho concluído.

```text
CODE GENERATED != DONE
```

Para atingir `DONE`:

```text
[✓] Spec analisada

[✓] REQUIREMENTS.md gerado

[✓] ARCHITECTURE_PLAN.md gerado

[✓] EXECUTION_PLAN.md gerado

[✓] Arquitetura aprovada

[✓] Prisma Schema validado

[✓] Migrations validadas

[✓] Backend implementado

[✓] Frontend implementado quando aplicável

[✓] Type Check aprovado

[✓] Build aprovado

[✓] Unit Tests aprovados

[✓] Integration Tests aprovados

[✓] Segurança validada

[✓] Review aprovado

[✓] TEST_REPORT.md gerado

[✓] REVIEW_REPORT.md gerado

[✓] Documentação atualizada

[✓] State atualizado

[✓] Quality Gates aprovados
```

Somente então:

```text
SPEC = DONE
```

---

# 🔑 Princípios fundamentais

```text
1. Utilizar padrões naturais de Node.js.

2. Organizar funcionalidades por módulos/features.

3. Routes devem permanecer simples.

4. Services concentram regras de aplicação.

5. Repositories somente quando agregarem valor.

6. Prisma é a camada principal de persistência.

7. Zod valida dados nas fronteiras da aplicação.

8. Não criar abstrações apenas para imitar C# ou Java.

9. Não iniciar implementação antes do planejamento.

10. Build não substitui testes.

11. Testes não substituem review.

12. Nenhum Agent pode ignorar Quality Gates obrigatórios.
```

---

# 🧠 Arquitetura da aplicação

```text
React Admin / React Site
          │
          ▼
       Fastify
          │
          ▼
        Routes
          │
          ▼
       Services
          │
          ▼
Repository / Prisma
          │
          ▼
         MySQL
```

A quantidade de camadas deve acompanhar a complexidade real da funcionalidade.

---

# 🤖 Arquitetura da geração

```text
                    SPEC
                     │
                     ▼
             Requirements Agent
                     │
                     ▼
               Architect Agent
                     │
                     ▼
               Tech Lead Agent
                     │
                     ▼
               Developer Agent
                     │
                     ▼
                Tester Agent
                     │
                     ▼
               Reviewer Agent
                     │
                     ▼
            Documentation Agent
                     │
                     ▼
               Quality Gates
                     │
              ┌──────┴──────┐
              │             │
             PASS          FAIL
              │             │
              ▼             ▼
             DONE        Developer
```

---

# 🚀 Visão final

O template combina:

```text
NODE.JS APPLICATION
────────────────────────

Node.js
TypeScript
Fastify
Prisma
MySQL
Zod
JWT
React
Vitest

          +

AI SOFTWARE FACTORY
────────────────────────

Specs
Rules
Skills
Agents
Workflows
Quality Gates
State
```

Resultado:

```text
Solicitação
     ↓
Planejamento
     ↓
Arquitetura
     ↓
Implementação
     ↓
Testes
     ↓
Review
     ↓
Documentação
     ↓
Validação
     ↓
Entrega
```

---

# 📄 Licença

Defina a licença conforme as necessidades do projeto.

---

# Base Node.js v2 — AI Agents

**Node.js + TypeScript + Fastify + Prisma + MySQL + React + AI Agents + Quality Gates**

> O objetivo não é simplesmente gerar código Node.js. É gerar uma solução simples, coerente com o ecossistema, testada, revisada e validada antes de considerá-la concluída.
