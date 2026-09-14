# Base Laravel + MySQL — AI Agents

Template para **criação, evolução e refatoração automatizada de projetos Full Stack** utilizando:

**Laravel + MySQL + React**

com engenharia assistida por IA baseada em:

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

O objetivo é permitir que a IA participe de um fluxo estruturado de:

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

# 🚀 Stack Base

## Backend

```text
Laravel API
Eloquent ORM
Form Requests
API Resources
Policies / Gates
Events / Listeners
Jobs / Queues
Laravel Sanctum
```

## Banco de Dados

```text
MySQL
Migrations
Seeders
Factories
```

## Frontend

```text
React Admin
React Site
```

## Segurança

```text
Laravel Sanctum
Groups
Permissions
Policies
Gates
```

## Testes

```text
Unit Tests
Feature Tests
API Tests
Database Tests
Authorization Tests
```

## Infraestrutura

```text
Docker
Docker Compose
Environment Variables
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

> As versões de Laravel, PHP, MySQL, React e demais dependências devem ser revalidadas no momento da geração para utilizar versões estáveis, compatíveis e suportadas.

---

# 🎯 Objetivo

Uma solicitação como:

```text
Criar gerenciamento de usuários
```

não deve resultar imediatamente na geração de arquivos.

Primeiro o pipeline deve identificar:

```text
O que precisa ser entregue?
        ↓
Quais regras devem ser respeitadas?
        ↓
Qual solução Laravel é mais adequada?
        ↓
Quais Models e relacionamentos existem?
        ↓
Quais Migrations serão necessárias?
        ↓
Quais endpoints serão criados?
        ↓
Quais Policies serão utilizadas?
        ↓
Como tudo será testado?
```

Somente depois começa a implementação.

---

# 🧠 Princípio Arquitetural

A regra central deste template é:

> **Laravel nativo primeiro.**

O projeto deve utilizar os recursos naturais do Laravel antes de introduzir abstrações adicionais.

Preferir:

```text
Eloquent Models
Controllers finos
Form Requests
API Resources
Policies
Gates
Events
Listeners
Jobs
Queues
Migrations
Seeders
Factories
```

Não introduzir automaticamente:

```text
Repository Pattern
CQRS
DDD formal
Mediator
Command Bus
Query Bus
Camadas artificiais
Abstrações inspiradas em .NET
Abstrações inspiradas em Java
```

Esses padrões somente devem existir quando a **Spec** ou a complexidade real do projeto justificar.

---

# 🏗️ Arquitetura Laravel

Estrutura conceitual:

```text
Request
   ↓
Route
   ↓
Middleware
   ↓
Form Request
   ↓
Controller
   ↓
Action / Service
   ↓
Eloquent
   ↓
MySQL
   ↓
API Resource
   ↓
Response
```

Nem todas as funcionalidades precisam utilizar todas essas etapas.

Para operações simples:

```text
Route
  ↓
Controller
  ↓
Eloquent
  ↓
Resource
```

Para operações complexas:

```text
Route
  ↓
Controller
  ↓
Form Request
  ↓
Action / Service
  ↓
Domain Operation
  ↓
Eloquent
  ↓
Events
  ↓
Resource
```

---

# 📦 Organização por Feature

Quando útil, funcionalidades relacionadas podem permanecer próximas.

Exemplo:

```text
app/
├── Http/
│   ├── Controllers/
│   │   ├── Auth/
│   │   └── Users/
│   │
│   ├── Requests/
│   │   ├── Auth/
│   │   └── Users/
│   │
│   └── Resources/
│       └── Users/
│
├── Models/
├── Policies/
├── Actions/
├── Services/
├── Events/
├── Listeners/
├── Jobs/
└── Support/
```

O template não precisa forçar uma arquitetura específica quando a estrutura padrão do Laravel já resolve bem o problema.

---

# 🧩 Controllers

Controllers devem permanecer pequenos.

Responsabilidades esperadas:

```text
Receber request
Autorizar operação
Delegar validação
Executar Action / Service quando necessário
Retornar Resource / Response
```

Evitar:

```text
Controllers com centenas de linhas
Regra de negócio extensa
Queries complexas diretamente no controller
Processamento assíncrono pesado
```

---

# ✅ Form Requests

Validação de entrada deve preferencialmente utilizar:

```text
Form Requests
```

Exemplo:

```php
class StoreUserRequest extends FormRequest
{
    public function rules(): array
    {
        return [
            'name' => ['required', 'string', 'max:255'],
            'email' => ['required', 'email', 'unique:users,email'],
        ];
    }
}
```

Podem concentrar:

```text
Validation Rules
Authorization Rules
Validation Messages
Input Preparation
```

---

# 📤 API Resources

Respostas da API devem preferencialmente utilizar:

```text
API Resources
```

Isso evita exposição direta do Model.

Fluxo:

```text
Eloquent Model
      ↓
API Resource
      ↓
JSON Response
```

Exemplo:

```text
User
 ↓
UserResource
 ↓
API
```

---

# 🗄️ Eloquent ORM

Eloquent é o mecanismo padrão de persistência.

Preferir:

```text
Models
Relationships
Scopes
Casts
Accessors
Mutators
Query Builder
```

Relacionamentos comuns:

```text
hasOne
hasMany
belongsTo
belongsToMany
morphOne
morphMany
```

Queries complexas devem permanecer legíveis e testáveis.

---

# 🐬 MySQL

O banco padrão do template é:

```text
MySQL
```

Configuração através de variáveis de ambiente:

```env
DB_CONNECTION=mysql
DB_HOST=mysql
DB_PORT=3306
DB_DATABASE=app
DB_USERNAME=app
DB_PASSWORD=password
```

Credenciais reais nunca devem ser versionadas.

---

# 🔄 Migrations

Alterações estruturais devem utilizar Migrations.

Estrutura:

```text
database/
└── migrations/
```

Fluxo:

```text
Data Model
   ↓
Migration
   ↓
Migration Review
   ↓
MySQL
```

Exemplo:

```bash
php artisan make:migration create_users_table
```

Execução:

```bash
php artisan migrate
```

---

# 🌱 Seeders

Dados iniciais devem utilizar:

```text
database/seeders/
```

Exemplos:

```text
Admin User
Groups
Roles
Permissions
Application Configuration
Development Data
```

Execução:

```bash
php artisan db:seed
```

---

# 🧪 Factories

Factories devem ser utilizadas para:

```text
Tests
Development Data
Seed Data
Scenarios
```

Estrutura:

```text
database/factories/
```

Exemplo:

```php
User::factory()->count(20)->create();
```

---

# 🔐 Laravel Sanctum

Quando aplicável, a autenticação deve utilizar:

```text
Laravel Sanctum
```

Possíveis cenários:

```text
SPA Authentication
API Tokens
React Admin
React Site
```

Fluxo SPA:

```text
React
  ↓
CSRF Cookie
  ↓
Login
  ↓
Laravel Sanctum
  ↓
Authenticated Session
```

A escolha entre autenticação baseada em sessão ou token deve ser definida conforme a arquitetura do projeto.

---

# 🛡️ Groups e Permissions

A fundação pode trabalhar com:

```text
Users
Groups
Roles
Permissions
```

Exemplo:

```text
User
  ↓
Group / Role
  ↓
Permissions
```

Permissões:

```text
users.view
users.create
users.update
users.delete
```

A modelagem exata deve ser definida pela Spec.

---

# 🔒 Policies

Policies devem ser utilizadas para autorização relacionada a Models e recursos.

Exemplo:

```text
UserPolicy
PostPolicy
OrderPolicy
```

Fluxo:

```text
Authenticated User
       ↓
Policy
       ↓
Operation
```

---

# 🚪 Gates

Gates podem ser utilizados para regras simples ou globais de autorização.

Exemplo:

```php
Gate::define('access-admin', function (User $user) {
    return $user->hasPermission('admin.access');
});
```

Policies e Gates devem utilizar as capacidades nativas do Laravel antes da criação de sistemas customizados de autorização.

---

# ⚙️ Actions e Services

Actions ou Services devem ser criados quando realmente reduzirem complexidade.

Exemplo:

```text
CreateUserAction
ResetPasswordAction
GenerateInvoiceAction
ImportCustomersAction
```

Preferir:

```text
Uma responsabilidade
Entrada clara
Saída clara
Testável
```

Evitar criar um Service para cada Model apenas por convenção.

---

# 📡 Events e Listeners

Eventos devem representar fatos relevantes.

Exemplo:

```text
UserCreated
PasswordChanged
OrderCompleted
```

Fluxo:

```text
Application
    ↓
Event
    ↓
Listener
```

Exemplos de Listeners:

```text
SendWelcomeEmail
RegisterAuditEntry
NotifyAdministrator
```

---

# ⚡ Jobs e Queues

Processamentos demorados ou assíncronos podem utilizar:

```text
Jobs
Queues
```

Exemplos:

```text
SendEmailJob
ProcessImportJob
GenerateReportJob
SyncExternalSystemJob
```

Fluxo:

```text
Request
   ↓
Dispatch Job
   ↓
Queue
   ↓
Worker
```

A infraestrutura de fila somente deve ser adicionada quando a Spec realmente exigir.

---

# ⚛️ Frontend

O template suporta duas aplicações:

```text
frontend/
├── admin/
└── site/
```

---

# 🖥️ React Admin

Voltado para administração.

Exemplo:

```text
Admin
├── Dashboard
├── Users
├── Groups
├── Permissions
└── Settings
```

CRUDs podem seguir:

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
Laravel API
  ↓
Eloquent
  ↓
MySQL
```

---

# 🤖 Fluxo de IA

O projeto utiliza agentes especializados.

```text
Spec / Solicitação
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

Falhas retornam ao Developer até aprovação ou bloqueio documentado.

---

# 🔎 Requirements Agent

Responsável por interpretar a solicitação.

Produz:

```text
tasks/generated/REQUIREMENTS.md
```

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

---

# 🏛️ Architect Agent

Responsável pelas decisões arquiteturais.

Produz:

```text
tasks/generated/ARCHITECTURE_PLAN.md
```

Analisa:

```text
Laravel Architecture
Routes
Controllers
Form Requests
Resources
Eloquent
Policies
Events
Jobs
React
MySQL
Docker
```

Também deve impedir overengineering.

Uma pergunta obrigatória desse agente deve ser:

```text
O Laravel já fornece uma solução nativa para isso?
```

Se a resposta for sim, a solução nativa deve ser preferida, salvo justificativa técnica documentada.

---

# 👨‍💻 Tech Lead Agent

Transforma arquitetura e requisitos em um plano executável.

Produz:

```text
tasks/generated/EXECUTION_PLAN.md
```

Exemplo:

```text
TASK-001 Database Model
TASK-002 Migrations
TASK-003 Models / Relationships
TASK-004 Authentication
TASK-005 Users API
TASK-006 Policies
TASK-007 Tests
TASK-008 React Admin
```

Cada Task deve definir:

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

O Developer deve utilizar Laravel de forma natural.

Não deve transformar o projeto automaticamente em:

```text
DDD
CQRS
Clean Architecture
Hexagonal Architecture
Repository Pattern
```

sem que exista necessidade técnica ou requisito explícito.

---

# 🧪 Tester Agent

Responsável pelos testes.

Executa:

```text
Unit Tests
Feature Tests
API Tests
Database Tests
Authentication Tests
Authorization Tests
Frontend Validation
```

Produz:

```text
tasks/reports/TEST_REPORT.md
```

Fluxo de falha:

```text
Tester
  ↓
FAIL
  ↓
Developer
  ↓
Fix
  ↓
Tester
```

---

# 🔍 Reviewer Agent

Responsável pelo review técnico.

Analisa:

```text
Laravel Conventions
Controllers
Form Requests
Resources
Eloquent
Policies
Security
Database
Tests
Frontend
Duplicação
Complexidade
Spec
Rules
```

Produz:

```text
tasks/reports/REVIEW_REPORT.md
```

Um dos principais objetivos do review é identificar:

```text
Overengineering
Abstrações desnecessárias
Duplicação
Violação de convenções Laravel
Código difícil de manter
```

---

# 📚 Documentation Agent

Responsável pela atualização da documentação.

Pode atualizar:

```text
README.md
ARCHITECTURE.md
API.md
CHANGELOG.md
docs/
```

A documentação deve refletir o estado real do projeto.

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
├── laravel.rules.md
├── mysql.rules.md
├── security.rules.md
├── testing.rules.md
├── frontend.rules.md
├── docker.rules.md
└── ai-agents.md
```

---

# 🧩 Skills

Skills definem:

> **Como executar operações repetíveis.**

Exemplo:

```text
tasks/skills/
├── create-model/
├── create-migration/
├── create-controller/
├── create-form-request/
├── create-resource/
├── create-policy/
├── create-action/
├── create-event/
├── create-listener/
├── create-job/
├── create-test/
└── create-react-page/
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

# 📄 Artefatos Antes do Código

Antes de qualquer implementação relevante devem existir:

```text
tasks/generated/
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
└── EXECUTION_PLAN.md
```

Fluxo:

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

---

# 📊 Artefatos Depois da Implementação

Após a implementação:

```text
tasks/reports/
├── TEST_REPORT.md
└── REVIEW_REPORT.md
```

Esses relatórios fazem parte dos Quality Gates.

---

# 🚦 Quality Gates

O projeto possui oito gates principais:

```text
GATE-01 Requirements
GATE-02 Architecture
GATE-03 MySQL / Persistence
GATE-04 Backend Validation
GATE-05 Frontend Validation
GATE-06 Security
GATE-07 Laravel Review
GATE-08 Documentation
```

---

# GATE-01 — Requirements

Valida:

```text
REQUIREMENTS.md
Regras de negócio
Critérios de aceite
Dependências
Restrições
```

---

# GATE-02 — Architecture

Valida:

```text
ARCHITECTURE_PLAN.md
Laravel Conventions
Simplicidade
Separação de responsabilidades
Ausência de abstrações desnecessárias
```

---

# GATE-03 — MySQL / Persistence

Valida:

```text
Models
Relationships
Migrations
Indexes
Constraints
Seeders
Factories
Database Integrity
```

---

# GATE-04 — Backend Validation

Valida:

```text
Laravel
PHP
Routes
Controllers
Form Requests
Resources
Eloquent
Error Handling
```

Comandos podem incluir:

```bash
php artisan route:list
php artisan migrate:status
php artisan test
```

---

# GATE-05 — Frontend Validation

Valida:

```text
React Admin
React Site
Routes
Forms
API Integration
Build
Error Handling
```

---

# GATE-06 — Security

Valida:

```text
Sanctum
Authentication
Authorization
Policies
Gates
Permissions
Passwords
Secrets
Environment Variables
Mass Assignment
Validation
```

---

# GATE-07 — Laravel Review

Verifica se o projeto continua utilizando Laravel de forma natural.

Detecta:

```text
Repository sem necessidade
Service vazio
Controller excessivamente complexo
Duplicação
Abstrações artificiais
Queries problemáticas
N+1
Violação de conventions
Overengineering
```

---

# GATE-08 — Documentation

Valida:

```text
README
API
Environment
Database
Docker
Tests
Architecture
Changes
```

---

# 🔁 Falha de Quality Gate

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

Falhas que não possam ser corrigidas automaticamente devem gerar bloqueio documentado.

---

# 💾 State

A pasta:

```text
orchestration/state/
```

mantém um resumo pequeno do progresso.

Pode conter:

```text
Spec ativa
Fase atual
Tasks concluídas
Tasks pendentes
Último teste
Quality Gates
Problemas conhecidos
Bloqueios
Próxima ação
```

Objetivo:

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

O arquivo:

```text
docker-compose.yml
```

deve ser gerado conforme a necessidade da Spec.

Topologia comum:

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
                   Laravel API
                        │
                        ▼
                      MySQL
```

Outros serviços somente devem ser adicionados quando necessários.

Exemplos:

```text
Redis
Queue Worker
Mail Service
Scheduler
```

---

# 📂 Estrutura Sugerida

```text
.
├── backend/
│   ├── app/
│   │   ├── Actions/
│   │   ├── Events/
│   │   ├── Http/
│   │   │   ├── Controllers/
│   │   │   ├── Middleware/
│   │   │   ├── Requests/
│   │   │   └── Resources/
│   │   ├── Jobs/
│   │   ├── Listeners/
│   │   ├── Models/
│   │   ├── Policies/
│   │   ├── Providers/
│   │   └── Services/
│   │
│   ├── database/
│   │   ├── factories/
│   │   ├── migrations/
│   │   └── seeders/
│   │
│   ├── routes/
│   │   ├── api.php
│   │   └── web.php
│   │
│   ├── tests/
│   │   ├── Feature/
│   │   └── Unit/
│   │
│   └── composer.json
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
├── CRIAR-PROJETO.md
├── COPILOT.md
├── AGENTS.md
├── .env.example
├── docker-compose.yml
└── README.md
```

---

# 🛠️ Comandos Principais

## Instalação

```bash
composer install
```

## Configuração

```bash
cp .env.example .env
php artisan key:generate
```

## Migration

```bash
php artisan migrate
```

## Seed

```bash
php artisan db:seed
```

## Desenvolvimento

```bash
php artisan serve
```

## Testes

```bash
php artisan test
```

## Listar Rotas

```bash
php artisan route:list
```

## Limpar Cache

```bash
php artisan optimize:clear
```

## Docker

```bash
docker compose up -d
```

---

# ▶️ Entrada Recomendada

Para criação ou evolução:

```text
prompts/CREATE_PROJECT.md
```

Para refatorações controladas:

```text
prompts/REFACTOR_PROJECT.md
```

Uma IA compatível com as instruções do projeto também pode iniciar com:

```text
Leia COPILOT.md e execute a Spec ativa seguindo o workflow de agentes.
```

---

# 📌 Spec Inicial

A fundação inicial deve ser definida em:

```text
tasks/specs/changes/001-project-foundation.md
```

Ela deve estabelecer, conforme necessário:

```text
Backend
Database
Models
Authentication
Groups
Permissions
Policies
React Admin
React Site
Tests
Docker
```

---

# 🛡️ Definition of Done

Código gerado não representa conclusão.

```text
CODE GENERATED != DONE
```

Para atingir `DONE`:

```text
[✓] Spec analisada

[✓] REQUIREMENTS.md gerado

[✓] ARCHITECTURE_PLAN.md gerado

[✓] EXECUTION_PLAN.md gerado

[✓] Arquitetura Laravel aprovada

[✓] Models definidos

[✓] Relationships validadas

[✓] Migrations aprovadas

[✓] Seeders / Factories validados

[✓] Backend implementado

[✓] Frontend implementado quando aplicável

[✓] Unit Tests aprovados

[✓] Feature Tests aprovados

[✓] Segurança validada

[✓] Policies / Gates validados

[✓] Laravel Review aprovado

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

# 🔑 Princípios Fundamentais

```text
1. Laravel nativo primeiro.

2. Usar Eloquent como mecanismo principal de persistência.

3. Controllers devem permanecer simples.

4. Form Requests cuidam da validação.

5. API Resources controlam a saída.

6. Policies e Gates cuidam da autorização.

7. Actions / Services somente quando agregarem valor.

8. Repository Pattern não é obrigatório.

9. CQRS não é obrigatório.

10. DDD formal não é obrigatório.

11. Não copiar arquiteturas de .NET ou Java mecanicamente.

12. Migrations fazem parte da arquitetura.

13. Testes fazem parte da entrega.

14. Review faz parte da entrega.

15. Nenhum Agent pode ignorar Quality Gates obrigatórios.
```

---

# 🧠 Arquitetura da Aplicação

```text
React Admin / React Site
          │
          ▼
      Laravel API
          │
          ▼
        Routes
          │
          ▼
     Form Requests
          │
          ▼
      Controllers
          │
          ▼
   Actions / Services
          │
          ▼
       Eloquent
          │
          ▼
        MySQL
```

A quantidade de abstrações deve acompanhar a complexidade real da funcionalidade.

---

# 🤖 Arquitetura da Geração

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

# 🚀 Visão Final

O template combina:

```text
LARAVEL APPLICATION
────────────────────────

Laravel
Eloquent
MySQL
Sanctum
Policies
Gates
Events
Jobs
React

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

# Base Laravel + MySQL — AI Agents

**Laravel + MySQL + React + Rules + Skills + Specs + AI Agents + Quality Gates**

> O objetivo não é transformar Laravel em outra arquitetura. É utilizar bem o ecossistema Laravel, automatizando planejamento, implementação, testes, revisão e documentação com IA.
