# LawFirm - .NET Vertical Slices + AI Agents

Template para **criação, evolução e refatoração automatizada de aplicações Full Stack** utilizando **ASP.NET Core, Vertical Slice Architecture, CQRS, Domain Events, React e agentes especializados de IA**.

O projeto combina arquitetura orientada a funcionalidades com um pipeline de engenharia baseado em:

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

A proposta é fazer com que a IA não seja apenas uma geradora de código, mas participe de um processo estruturado de:

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
ASP.NET Core
Minimal APIs
Vertical Slice Architecture
CQRS
Domain Events
Domain Model
Entity Framework Core
EF Core Migrations
FluentValidation
JWT
Refresh Token
Policies
Permissions
```

## Frontend

```text
React Admin
React Site
```

## Qualidade

```text
Unit Tests
Integration Tests
Build Validation
Security Validation
Architecture Review
```

## Infraestrutura

```text
Docker
Docker Compose
Environment Configuration
```

## AI Engineering

```text
Rules
Skills
Specs
Agents
Workflows
Quality Gates
State
```

> As versões do .NET, ASP.NET Core, Entity Framework Core, React e demais dependências devem ser revalidadas no momento da geração para utilização de versões estáveis e compatíveis.

---

# 🎯 Objetivo

O objetivo do template é permitir que uma solicitação como:

```text
Criar gerenciamento de usuários
```

não seja imediatamente transformada em código.

O pipeline primeiro deve entender:

```text
O que precisa ser feito?
        ↓
Quais são as regras?
        ↓
Qual arquitetura será utilizada?
        ↓
Quais componentes serão alterados?
        ↓
Como será implementado?
        ↓
Como será testado?
```

Somente depois começa a implementação.

---

# 🏗️ Vertical Slice Architecture

A principal regra arquitetural do projeto é organizar o código por **funcionalidade**, e não apenas por tipo técnico.

Em uma arquitetura horizontal tradicional:

```text
Controllers/
Services/
Handlers/
Validators/
Repositories/
DTOs/
```

elementos relacionados à mesma funcionalidade ficam espalhados pelo projeto.

Este template evita esse modelo.

A organização preferencial é:

```text
Features/
└── Users/
    │
    ├── Create/
    │   ├── Command.cs
    │   ├── Validator.cs
    │   ├── Handler.cs
    │   ├── Endpoint.cs
    │   └── Response.cs
    │
    ├── Update/
    │   ├── Command.cs
    │   ├── Validator.cs
    │   ├── Handler.cs
    │   ├── Endpoint.cs
    │   └── Response.cs
    │
    ├── Delete/
    │   ├── Command.cs
    │   ├── Handler.cs
    │   └── Endpoint.cs
    │
    ├── GetById/
    │   ├── Query.cs
    │   ├── Handler.cs
    │   ├── Endpoint.cs
    │   └── Response.cs
    │
    └── List/
        ├── Query.cs
        ├── Handler.cs
        ├── Endpoint.cs
        └── Response.cs
```

A regra é simples:

> **Tudo que pertence à mesma funcionalidade deve permanecer o mais próximo possível.**

---

# 🔀 Vertical Slice + CQRS

Cada Slice representa uma operação da aplicação.

Exemplo:

```text
POST /users
     │
     ▼
Create User Slice
     │
     ├── Command
     ├── Validator
     ├── Handler
     ├── Endpoint
     └── Response
```

Para consultas:

```text
GET /users/{id}
       │
       ▼
Get User By Id Slice
       │
       ├── Query
       ├── Handler
       ├── Endpoint
       └── Response
```

CQRS mantém clara a separação entre:

```text
COMMAND
   │
   └── modifica estado

QUERY
   │
   └── consulta estado
```

---

# 🌐 Minimal APIs

Os endpoints devem utilizar **Minimal APIs**.

Exemplo conceitual:

```csharp
group.MapPost("/", CreateUserEndpoint.HandleAsync);
group.MapGet("/{id:guid}", GetUserByIdEndpoint.HandleAsync);
group.MapPut("/{id:guid}", UpdateUserEndpoint.HandleAsync);
group.MapDelete("/{id:guid}", DeleteUserEndpoint.HandleAsync);
```

O objetivo é evitar controllers genéricos acumulando diversas responsabilidades.

Cada endpoint deve permanecer próximo ao Slice correspondente.

---

# 🧠 Domain Model

O domínio contém as regras centrais da aplicação.

Exemplo:

```text
Domain/
├── Entities/
├── ValueObjects/
├── Events/
├── Exceptions/
└── Services/
```

O Domain Model deve concentrar comportamentos relevantes de negócio e evitar entidades utilizadas apenas como estruturas de dados.

---

# 📡 Domain Events

Eventos de domínio representam fatos importantes ocorridos dentro do domínio.

Exemplo:

```text
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
PasswordChangedEvent
```

Fluxo:

```text
Command
   ↓
Handler
   ↓
Domain Entity
   ↓
Business Rule
   ↓
Domain Event
   ↓
Event Handler
```

Os Domain Events permitem que comportamentos secundários sejam desacoplados da operação principal.

---

# 🗄️ Persistência

O projeto utiliza:

```text
Entity Framework Core
+
SQL Server
+
Migrations
```

Fluxo recomendado:

```text
Domain Entities
      ↓
Infrastructure
      ↓
ApplicationDbContext
      ↓
Fluent Configurations
      ↓
Migration
      ↓
Migration Validation
      ↓
Development Seed
      ↓
CQRS Features
```

A persistência deve ser validada antes da implementação das funcionalidades dependentes dela.

---

# 🔄 EF Core Migrations

As alterações estruturais devem gerar migrations versionadas.

Exemplo:

```text
Migrations/
├── 202601010001_InitialCreate.cs
├── 202601020001_CreatePermissions.cs
└── 202601030001_CreateRefreshTokens.cs
```

O pipeline deve validar:

```text
Entity
   ↓
Configuration
   ↓
DbContext
   ↓
Migration
   ↓
Database
```

---

# 🔐 Autenticação

O template prevê:

```text
Login
Access Token
Refresh Token
Logout
Forgot Password
Reset Password
```

Fluxo:

```text
Credentials
     ↓
Login
     ↓
Validation
     ↓
JWT Access Token
     +
Refresh Token
```

---

# 🛡️ Authorization

O sistema utiliza:

```text
Policies
+
Permissions
```

Fluxo conceitual:

```text
User
  ↓
Roles / Groups
  ↓
Permissions
  ↓
Policy
  ↓
Endpoint
```

Os endpoints podem exigir permissões específicas.

Exemplo:

```text
users.read
users.create
users.update
users.delete
```

---

# ✅ FluentValidation

Cada Slice pode possuir seu próprio Validator.

Exemplo:

```text
Features/
└── Users/
    └── Create/
        ├── Command.cs
        ├── Validator.cs
        ├── Handler.cs
        ├── Endpoint.cs
        └── Response.cs
```

Isso mantém a validação próxima da funcionalidade.

---

# ⚛️ Frontend

O template prevê duas aplicações React.

```text
frontend/
├── admin/
└── site/
```

## React Admin

Voltado à administração.

Exemplo:

```text
Admin
├── Dashboard
├── Users
├── Roles
├── Permissions
├── Groups
├── Audit
└── Settings
```

Cada CRUD pode seguir:

```text
Users/
├── List/
├── New/
├── Edit/
└── Detail/
```

## React Site

Aplicação destinada ao usuário final.

```text
Browser
   │
   ├── React Admin
   │       ↓
   │     API
   │
   └── React Site
           ↓
         API
```

---

# 🤖 AI Agents

O projeto utiliza agentes especializados para separar responsabilidades durante a geração.

```text
Pedido / Spec
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
Execution Plan
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

---

# 🔎 Requirements Agent

Responsável por interpretar a Spec.

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
Vertical Slices
Domain Model
CQRS
Domain Events
Persistência
Segurança
Frontend
Infraestrutura
Testes
```

Produz:

```text
tasks/generated/ARCHITECTURE_PLAN.md
```

Uma responsabilidade importante desse agente é impedir que novas funcionalidades transformem o projeto em uma arquitetura horizontal.

---

# 👨‍💻 Tech Lead Agent

Transforma requisitos e arquitetura em tarefas executáveis.

Produz:

```text
tasks/generated/EXECUTION_PLAN.md
```

Exemplo:

```text
TASK-001 - Domain Model
TASK-002 - Persistence
TASK-003 - Migration
TASK-004 - Create User Slice
TASK-005 - Get User Slice
TASK-006 - Tests
TASK-007 - Frontend
```

Cada tarefa deve possuir:

```text
Objetivo
Dependências
Arquivos
Critérios de aceite
Testes
Status
```

---

# 💻 Developer Agent

Responsável pela implementação.

Deve considerar:

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

O Developer não deve ignorar decisões arquiteturais para simplificar o código.

---

# 🧪 Tester Agent

Responsável pelos testes.

Executa:

```text
Unit Tests
Integration Tests
Persistence Tests
API Tests
Authentication Tests
Authorization Tests
```

Produz:

```text
tasks/reports/TEST_REPORT.md
```

Se algum teste obrigatório falhar:

```text
Tester
  │
  ▼
FAIL
  │
  ▼
Developer
  │
  ▼
Fix
  │
  ▼
Tester
```

---

# 🔍 Reviewer Agent

Responsável pela revisão técnica.

Verifica:

```text
Vertical Slice Architecture
CQRS
Domain Model
Domain Events
Security
Persistence
SOLID
Duplicação
Tratamento de erros
Testes
Rules
Spec
```

Produz:

```text
tasks/reports/REVIEW_REPORT.md
```

Se houver problemas críticos:

```text
Reviewer
    │
    ▼
FAIL
    │
    ▼
Developer
    │
    ▼
Correction
    │
    ▼
Tester
    │
    ▼
Reviewer
```

---

# 📚 Documentation Agent

Responsável pela documentação final.

Pode atualizar:

```text
README.md
ARCHITECTURE.md
API.md
CHANGELOG.md
docs/
```

A documentação deve refletir a implementação efetivamente entregue.

---

# 📁 Estrutura de automação

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

Rules representam:

> **Restrições permanentes do projeto.**

Exemplo:

```text
tasks/rules/
├── architecture.rules.md
├── vertical-slices.rules.md
├── domain.rules.md
├── cqrs.rules.md
├── persistence.rules.md
├── security.rules.md
├── testing.rules.md
├── frontend.rules.md
└── docker.rules.md
```

---

# 🧩 Skills

Skills representam:

> **Como executar operações repetíveis.**

Exemplo:

```text
tasks/skills/
├── create-vertical-slice/
├── create-command/
├── create-query/
├── create-domain-event/
├── create-migration/
├── create-endpoint/
├── create-unit-test/
├── create-integration-test/
└── create-react-page/
```

---

# 📋 Specs

Specs representam:

> **O que deve ser entregue.**

Localização:

```text
tasks/specs/
```

Mudanças:

```text
tasks/specs/changes/
```

A Spec inicial do template é:

```text
tasks/specs/changes/001-project-foundation.md
```

---

# 📄 Artefatos antes do código

Antes da implementação, obrigatoriamente devem ser produzidos:

```text
tasks/generated/
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
└── EXECUTION_PLAN.md
```

O fluxo é:

```text
SPEC
  │
  ▼
REQUIREMENTS.md
  │
  ▼
ARCHITECTURE_PLAN.md
  │
  ▼
EXECUTION_PLAN.md
  │
  ▼
CODE
```

E não:

```text
SPEC
  │
  ▼
CODE
```

Essa separação reduz implementação prematura e torna as decisões verificáveis.

---

# 🚦 Quality Gates

O projeto possui oito Quality Gates principais.

```text
GATE-01 Requirements
GATE-02 Architecture
GATE-03 Persistence
GATE-04 Build
GATE-05 Tests
GATE-06 Security
GATE-07 Architecture Review
GATE-08 Documentation
```

---

## GATE-01 — Requirements

Valida:

```text
REQUIREMENTS.md
Critérios de aceite
Regras de negócio
Restrições
Dependências
```

---

## GATE-02 — Architecture

Valida:

```text
ARCHITECTURE_PLAN.md
Vertical Slices
CQRS
Domain Model
Domain Events
Dependências
```

---

## GATE-03 — Persistence

Valida:

```text
Entities
DbContext
Fluent Configurations
Relationships
Indexes
Migrations
Migration Script
Development Seed
```

---

## GATE-04 — Build

O projeto deve compilar sem erros.

```powershell
dotnet restore
dotnet build
```

---

## GATE-05 — Tests

Executa:

```powershell
dotnet test
```

Devem ser aprovados os testes obrigatórios definidos pela Spec.

---

## GATE-06 — Security

Valida:

```text
JWT
Refresh Token
Policies
Permissions
Authentication
Authorization
Secrets
Sensitive Data
```

---

## GATE-07 — Architecture Review

Verifica principalmente se o projeto continua utilizando organização por Vertical Slices.

Deve detectar crescimento indevido de estruturas como:

```text
Controllers/
Services/
Handlers/
Validators/
```

quando esses componentes poderiam permanecer dentro das respectivas Features.

---

## GATE-08 — Documentation

Valida:

```text
README
API
Architecture
Configuration
Execution
Tests
Docker
Changes
```

---

# 🔁 Gate Failure

Qualquer Gate obrigatório pode interromper o pipeline.

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
                       Correction
                           │
                           ▼
                        Tester
                           │
                           ▼
                       Reviewer
                           │
                           └────► Gate
```

Nenhuma falha crítica deve ser ignorada apenas para concluir a execução.

---

# 💾 State

A pasta:

```text
orchestration/state/
```

mantém um resumo pequeno do estado atual.

Pode armazenar:

```text
Spec ativa
Fase atual
Tasks concluídas
Tasks pendentes
Último build
Último teste
Quality Gates
Problemas conhecidos
Próxima ação
```

O objetivo é evitar reler todo o repositório em cada interação.

Em vez de:

```text
Repository inteiro
       ↓
      IA
```

preferir:

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

---

# 🐳 Docker

A infraestrutura pode ser criada conforme as necessidades da Spec.

Exemplo:

```text
Browser
   │
   ├── React Admin
   │       ↓
   │      API
   │
   └── React Site
           ↓
          API
           │
           ▼
       SQL Server
```

Serviços não devem ser adicionados ao Docker Compose sem necessidade arquitetural ou funcional.

---

# 🧪 Estratégia de testes

## Unit Tests

Devem validar principalmente:

```text
Domain
Validators
Handlers
Business Rules
Mappings
```

## Integration Tests

Devem validar:

```text
Database
EF Core
Migrations
Endpoints
Authentication
Authorization
Vertical Slices
```

O objetivo é testar o fluxo real das funcionalidades críticas.

---

# 🏗️ Estrutura conceitual do projeto

```text
src/
│
├── Api/
│
├── Domain/
│
├── Infrastructure/
│
└── Features/
    │
    ├── Auth/
    │
    ├── Users/
    │
    ├── Roles/
    │
    └── Permissions/

frontend/
├── admin/
└── site/

tests/
├── UnitTests/
└── IntegrationTests/

agents/
orchestration/
prompts/
tasks/
docs/
```

A estrutura concreta pode evoluir conforme a Spec, desde que preserve os princípios arquiteturais definidos pelas Rules.

---

# 🛠️ Criando um projeto

Para iniciar através de uma IA compatível com as instruções do repositório:

```text
Leia COPILOT.md e execute a Spec ativa seguindo o workflow de agentes.
```

O ponto de entrada para criação também está disponível em:

```text
prompts/CREATE_PROJECT.md
```

---

# ♻️ Refatorando um projeto

Para refatorações:

```text
prompts/REFACTOR_PROJECT.md
```

O processo deve analisar primeiro a arquitetura existente antes de modificar arquivos.

Fluxo:

```text
Existing Project
      ↓
Requirements
      ↓
Architecture Analysis
      ↓
Execution Plan
      ↓
Refactoring
      ↓
Tests
      ↓
Review
      ↓
Documentation
```

---

# 📌 Spec inicial

A primeira Spec é:

```text
tasks/specs/changes/001-project-foundation.md
```

Ela representa a fundação inicial sobre a qual as próximas funcionalidades serão construídas.

---

# 🛡️ Definition of Done

Uma funcionalidade não está concluída quando apenas o código foi gerado.

```text
CODE GENERATED != DONE
```

Para atingir `DONE`:

```text
[✓] Spec analisada

[✓] REQUIREMENTS.md gerado

[✓] ARCHITECTURE_PLAN.md gerado

[✓] EXECUTION_PLAN.md gerado

[✓] Vertical Slices preservadas

[✓] Persistência validada

[✓] Migrations validadas

[✓] Implementação concluída

[✓] Build aprovado

[✓] Unit Tests aprovados

[✓] Integration Tests aprovados

[✓] Segurança validada

[✓] Architecture Review aprovado

[✓] TEST_REPORT.md gerado

[✓] REVIEW_REPORT.md gerado

[✓] Documentação atualizada

[✓] State atualizado

[✓] Quality Gates aprovados
```

Somente então:

```text
FEATURE / SPEC = DONE
```

---

# 🔑 Princípios fundamentais

```text
1. Organizar por funcionalidade.

2. Manter componentes da mesma Feature próximos.

3. Separar Commands e Queries.

4. Proteger as regras do Domain Model.

5. Validar persistência antes das Features dependentes.

6. Não começar implementação sem Requirements,
   Architecture Plan e Execution Plan.

7. Build não substitui testes.

8. Testes não substituem review.

9. Código gerado não significa código aprovado.

10. Nenhum Agent pode ignorar Quality Gates obrigatórios.
```

---

# 🧠 Modelo de engenharia

O template combina dois conceitos.

### Arquitetura da aplicação

```text
Vertical Slices
+
Minimal APIs
+
CQRS
+
Domain Model
+
Domain Events
+
EF Core
```

### Arquitetura da geração

```text
Specs
+
Rules
+
Skills
+
Agents
+
Workflow
+
Quality Gates
+
State
```

O resultado esperado é:

```text
                 SOFTWARE
                    ▲
                    │
        ┌───────────┴───────────┐
        │                       │
 Application Architecture   AI Engineering
        │                       │
 Vertical Slices              Specs
 CQRS                         Rules
 Domain Model                 Skills
 Domain Events                Agents
 Minimal APIs                 Workflows
 EF Core                      Gates
        │                     State
        └───────────┬───────────┘
                    │
                    ▼
             Validated Delivery
```

---

# 🚀 Visão geral do pipeline

```text
                         SPEC
                          │
                          ▼
                 Requirements Agent
                          │
                          ▼
                    REQUIREMENTS
                          │
                          ▼
                  Architect Agent
                          │
                          ▼
                 ARCHITECTURE PLAN
                          │
                          ▼
                  Tech Lead Agent
                          │
                          ▼
                   EXECUTION PLAN
                          │
                          ▼
                   Developer Agent
                          │
                          ▼
                   IMPLEMENTATION
                          │
                          ▼
                     BUILD
                          │
                          ▼
                    Tester Agent
                          │
                          ▼
                     TESTS
                          │
                          ▼
                   Reviewer Agent
                          │
                          ▼
               ARCHITECTURE REVIEW
                          │
                          ▼
               Documentation Agent
                          │
                          ▼
                   QUALITY GATES
                          │
                   ┌──────┴──────┐
                   │             │
                  PASS          FAIL
                   │             │
                   ▼             ▼
                  DONE       CORRECTION
                                  │
                                  └──────► Developer
```

---




# 💰 Resumo de Estimativa — GitHub Copilot

Estimativa para geração completa do projeto **LawFirm**, considerando Backend ASP.NET Core, React Admin, React Site, testes, builds, correções, documentação e execução dos Quality Gates.

| Item | Estimativa |
|---|---:|
| Tokens — econômico | 20–30 milhões |
| Tokens — provável | 35–55 milhões |
| Tokens — conservador | 60–90 milhões |
| Tokens para orçamento | **50 milhões** |
| Custo provável | **US$ 200–400** |
| Reserva recomendada | **US$ 500** |
| Reserva aproximada em reais | **R$ 2.575** |
| Tempo provável de geração | **40–55 horas** |
| Faixa total estimada | **32–66+ horas** |

> **Referência para orçamento:** considerar **50 milhões de tokens**, **US$ 500 (aproximadamente R$ 2.575)** de reserva para uso de IA e **40–55 horas** de processamento, mantendo margem de segurança de até **90 milhões de tokens** e **66+ horas** para ciclos adicionais de testes, revisão e correção.

> Os valores são estimativas de planejamento e podem variar conforme o modelo utilizado no GitHub Copilot, quantidade de contexto processado, número de iterações, correções, testes e revisões executadas.







# 📄 Licença

Defina a licença conforme as necessidades do projeto.

---

# .NET Vertical Slices + AI Agents

**Minimal APIs + Vertical Slices + CQRS + Domain Model + Domain Events + React + AI Agents + Quality Gates**

> O objetivo não é apenas gerar um projeto. É gerar, testar, revisar e validar uma solução antes de considerá-la concluída.
