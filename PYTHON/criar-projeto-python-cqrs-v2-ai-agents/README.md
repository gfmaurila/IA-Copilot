# Python + FastAPI + CQRS + MySQL + AI Agents

Template para **criação, evolução e refatoração automatizada de projetos Full Stack** utilizando:

**Python + FastAPI + Pydantic + SQLAlchemy + MySQL + CQRS + React**

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

O objetivo é fazer com que a IA participe de um processo estruturado de engenharia:

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
Python 3.12+
FastAPI
Pydantic v2
SQLAlchemy 2
Alembic
MySQL
CQRS
Domain Events
JWT
```

## Frontend

```text
React Admin
React Site
```

## Qualidade

```text
pytest
Ruff
mypy ou pyright
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
Rules
Skills
Specs
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

não deve resultar imediatamente na geração de código.

Primeiro o pipeline deve responder:

```text
O que precisa ser feito?
        ↓
Quais são os requisitos?
        ↓
Quais regras precisam ser respeitadas?
        ↓
Quais decisões arquiteturais são necessárias?
        ↓
Quais Commands e Queries serão criados?
        ↓
Como a persistência será alterada?
        ↓
Como a funcionalidade será testada?
```

Somente depois deve começar a implementação.

---

# 🧠 Princípios Arquiteturais

O projeto utiliza CQRS e Domain Events, mas deve continuar sendo um projeto **Python idiomático**.

Princípios centrais:

```text
Command altera estado.

Query somente lê.

Handler orquestra um caso de uso.

Router FastAPI não contém regra de negócio.

Domain concentra regras.

Infrastructure concentra persistência e integrações.

Pydantic valida contratos.

SQLAlchemy 2 implementa persistência.

Alembic controla evolução do schema.

Python deve permanecer tipado e idiomático.
```

Evitar abstrações apenas para reproduzir estruturas existentes em:

```text
C#
.NET
Java
Spring
```

---

# 🏗️ Arquitetura Base

Fluxo conceitual:

```text
HTTP Request
     ↓
FastAPI Router
     ↓
Pydantic Schema
     ↓
Command / Query
     ↓
Handler
     ↓
Domain
     ↓
Repository Port
     ↓
Infrastructure
     ↓
SQLAlchemy
     ↓
MySQL
```

Para consultas:

```text
HTTP Request
     ↓
Router
     ↓
Query
     ↓
Query Handler
     ↓
Repository / SQLAlchemy
     ↓
Response Model
```

Para alterações:

```text
HTTP Request
     ↓
Router
     ↓
Command
     ↓
Command Handler
     ↓
Domain Entity
     ↓
Repository
     ↓
Unit of Work
     ↓
Database
     ↓
Domain Events
```

---

# 📁 Estrutura Sugerida

```text
backend/
├── app/
│   ├── main.py
│   │
│   ├── api/
│   │   ├── dependencies/
│   │   ├── routers/
│   │   └── errors/
│   │
│   ├── application/
│   │   ├── commands/
│   │   ├── queries/
│   │   ├── handlers/
│   │   ├── dto/
│   │   └── services/
│   │
│   ├── domain/
│   │   ├── entities/
│   │   ├── value_objects/
│   │   ├── events/
│   │   ├── exceptions/
│   │   └── services/
│   │
│   ├── infrastructure/
│   │   ├── database/
│   │   ├── repositories/
│   │   ├── security/
│   │   ├── integrations/
│   │   └── messaging/
│   │
│   ├── schemas/
│   ├── config/
│   └── shared/
│
├── migrations/
│
├── tests/
│   ├── unit/
│   ├── integration/
│   └── api/
│
└── pyproject.toml
```

A estrutura pode ser adaptada conforme a Spec, desde que as responsabilidades permaneçam claras.

---

# ⚡ FastAPI

FastAPI é responsável pela exposição HTTP da aplicação.

Exemplo conceitual:

```python
@router.post("/users")
async def create_user(
    request: CreateUserRequest,
    handler: CreateUserHandler = Depends(),
):
    command = CreateUserCommand(
        name=request.name,
        email=request.email,
    )

    return await handler.handle(command)
```

O Router deve ser responsável principalmente por:

```text
HTTP
Dependency Injection
Request Mapping
Response Mapping
Status Codes
```

Evitar:

```text
Regra de negócio
SQL direto
Lógica complexa
Processamento de domínio
```

dentro dos routers.

---

# 🔀 CQRS

CQRS separa operações de escrita e leitura.

```text
COMMAND
   │
   └── altera estado

QUERY
   │
   └── consulta estado
```

Exemplo:

```text
application/
├── commands/
│   └── users/
│       ├── create_user.py
│       ├── update_user.py
│       └── delete_user.py
│
└── queries/
    └── users/
        ├── get_user.py
        └── list_users.py
```

---

# ✍️ Commands

Commands representam intenções de alteração de estado.

Exemplos:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand
ChangePasswordCommand
```

Exemplo conceitual:

```python
from dataclasses import dataclass


@dataclass(frozen=True)
class CreateUserCommand:
    name: str
    email: str
```

Commands devem carregar os dados necessários para o caso de uso.

---

# 🔎 Queries

Queries representam operações de leitura.

Exemplos:

```text
GetUserByIdQuery
ListUsersQuery
SearchUsersQuery
```

Exemplo:

```python
from dataclasses import dataclass
from uuid import UUID


@dataclass(frozen=True)
class GetUserByIdQuery:
    user_id: UUID
```

Queries não devem provocar efeitos colaterais de negócio.

---

# 🧩 Handlers

Handlers orquestram casos de uso.

Exemplo:

```python
class CreateUserHandler:
    def __init__(
        self,
        repository: UserRepository,
        unit_of_work: UnitOfWork,
    ):
        self.repository = repository
        self.unit_of_work = unit_of_work

    async def handle(
        self,
        command: CreateUserCommand,
    ) -> User:
        ...
```

Responsabilidades:

```text
Carregar dados necessários
Executar regra de aplicação
Interagir com Domain
Persistir alterações
Coordenar transação
Publicar eventos quando necessário
```

Evitar Handlers gigantes ou responsáveis por múltiplos casos de uso.

---

# 🧬 Domain Model

O Domain concentra regras de negócio.

Estrutura sugerida:

```text
domain/
├── entities/
├── value_objects/
├── events/
├── exceptions/
└── services/
```

Exemplo de entidade:

```python
class User:
    def change_email(self, email: Email) -> None:
        if self.email == email:
            return

        self.email = email

        self.add_event(
            UserEmailChangedEvent(
                user_id=self.id,
                email=email.value,
            )
        )
```

O Domain não deve depender diretamente de:

```text
FastAPI
SQLAlchemy
MySQL
Pydantic
HTTP
```

---

# 📡 Domain Events

Domain Events representam fatos relevantes ocorridos dentro do domínio.

Exemplos:

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

Os eventos podem disparar comportamentos secundários.

Exemplo:

```text
UserCreated
   ↓
SendWelcomeEmail
   ↓
AuditUserCreation
```

A implementação deve evitar infraestrutura excessiva quando um dispatcher simples atender ao projeto.

---

# 📦 Pydantic v2

Pydantic deve ser utilizado principalmente nas fronteiras da aplicação.

Exemplos:

```text
HTTP Requests
HTTP Responses
Environment Settings
External Integrations
Serialization
```

Exemplo:

```python
from pydantic import BaseModel, EmailStr


class CreateUserRequest(BaseModel):
    name: str
    email: EmailStr
```

Response:

```python
class UserResponse(BaseModel):
    id: str
    name: str
    email: EmailStr
```

Evitar transformar entidades de domínio em modelos Pydantic apenas por conveniência.

---

# 🗄️ SQLAlchemy 2

SQLAlchemy 2 é responsável pela persistência.

Preferir APIs atuais do SQLAlchemy.

Exemplo:

```python
stmt = select(UserModel).where(
    UserModel.id == user_id
)

result = await session.execute(stmt)

user = result.scalar_one_or_none()
```

Estrutura sugerida:

```text
infrastructure/
└── database/
    ├── models/
    ├── mappings/
    ├── session.py
    └── unit_of_work.py
```

---

# 🗃️ Repository

Repositories isolam operações relevantes de persistência.

Exemplo de contrato:

```python
from typing import Protocol


class UserRepository(Protocol):
    async def get_by_id(self, user_id: UUID) -> User | None:
        ...

    async def add(self, user: User) -> None:
        ...
```

Implementação:

```text
Domain / Application
       ↓
Repository Port
       ↓
SQLAlchemy Repository
       ↓
MySQL
```

Evitar criar repositories apenas para reproduzir todos os métodos do SQLAlchemy sem agregar valor.

---

# 🔄 Unit of Work

Quando necessário, o Unit of Work coordena transações.

Fluxo:

```text
Handler
   ↓
Unit of Work
   ↓
Repositories
   ↓
SQLAlchemy Session
   ↓
Transaction
```

Exemplo conceitual:

```python
async with unit_of_work:
    await repository.add(user)
    await unit_of_work.commit()
```

---

# 🐬 MySQL

O banco inicial é:

```text
MySQL
```

Configuração através de variáveis de ambiente.

Exemplo:

```env
DATABASE_URL=mysql+asyncmy://app:password@mysql:3306/app
```

Credenciais reais não devem ser versionadas.

---

# 🔄 Alembic

Alembic controla a evolução do schema.

Estrutura:

```text
migrations/
├── env.py
├── script.py.mako
└── versions/
```

Fluxo:

```text
SQLAlchemy Models
       ↓
Alembic Revision
       ↓
Migration Review
       ↓
Upgrade
       ↓
MySQL
```

Criar migration:

```bash
alembic revision --autogenerate -m "create users"
```

Executar:

```bash
alembic upgrade head
```

---

# 🔐 JWT

O template suporta autenticação baseada em JWT.

Fluxo:

```text
Credentials
    ↓
Login
    ↓
Password Verification
    ↓
Access Token
    +
Refresh Token
```

Pode contemplar:

```text
Login
Refresh Token
Logout
Forgot Password
Reset Password
```

conforme a Spec.

---

# 🛡️ Authorization

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
Role / Group
 ↓
Permissions
 ↓
Endpoint
```

Permissões:

```text
users.read
users.create
users.update
users.delete
```

A validação pode ser implementada através de Dependencies do FastAPI.

---

# ⚛️ Frontend

O template suporta:

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
├── Groups
├── Roles
├── Permissions
└── Settings
```

CRUDs:

```text
Users/
├── List/
├── New/
├── Edit/
└── Detail/
```

---

# 🌐 React Site

Aplicação voltada ao usuário final.

Fluxo:

```text
Browser
   ↓
React Site
   ↓
FastAPI
   ↓
Application
   ↓
SQLAlchemy
   ↓
MySQL
```

---

# 🧪 Testes

O projeto utiliza:

```text
pytest
```

Separação sugerida:

```text
tests/
├── unit/
├── integration/
└── api/
```

---

# 🧪 Unit Tests

Devem priorizar:

```text
Domain
Commands
Queries
Handlers
Services
Validation
Business Rules
```

Devem ser rápidos e isolados de infraestrutura sempre que possível.

---

# 🔗 Integration Tests

Devem validar:

```text
SQLAlchemy
Repositories
MySQL
Alembic
Transactions
Authentication
Authorization
```

Dependendo da estratégia do template, podem usar banco real de teste em Docker.

---

# 🌐 API Tests

Devem validar:

```text
Routes
Requests
Responses
Validation
HTTP Status
Authentication
Permissions
Error Handling
```

Exemplo:

```python
async def test_create_user(client):
    response = await client.post(
        "/users",
        json={
            "name": "Test User",
            "email": "user@example.com",
        },
    )

    assert response.status_code == 201
```

---

# 🧹 Ruff

Ruff pode ser utilizado para:

```text
Lint
Import Validation
Formatting
Code Quality
```

Exemplo:

```bash
ruff check .
```

Correção automática:

```bash
ruff check . --fix
```

Formatação:

```bash
ruff format .
```

---

# 🔎 Type Checking

O projeto deve utilizar:

```text
mypy
```

ou:

```text
pyright
```

Exemplo:

```bash
mypy app
```

ou:

```bash
pyright
```

Evitar uso indiscriminado de:

```python
Any
```

quando um tipo claro puder ser definido.

---

# 🤖 Fluxo de Agentes

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

Falhas retornam ao Developer até que os gates obrigatórios sejam aprovados ou exista um bloqueio documentado.

---

# 🔎 Requirements Agent

Responsável por transformar a solicitação em requisitos verificáveis.

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
FastAPI
CQRS
Domain
Domain Events
SQLAlchemy
Alembic
MySQL
Security
React
Docker
Testing
```

Também deve avaliar se cada abstração realmente agrega valor.

---

# 👨‍💻 Tech Lead Agent

Transforma requisitos e arquitetura em tarefas executáveis.

Produz:

```text
tasks/generated/EXECUTION_PLAN.md
```

Exemplo:

```text
TASK-001 Domain Model
TASK-002 Persistence Model
TASK-003 Alembic Migration
TASK-004 Create User Command
TASK-005 User Queries
TASK-006 Authentication
TASK-007 Tests
TASK-008 React Admin
```

Cada task deve definir:

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

Deve utilizar:

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

O Developer deve preservar:

```text
Tipagem
Legibilidade
Simplicidade
Separação de responsabilidade
Padrões idiomáticos Python
```

---

# 🧪 Tester Agent

Executa:

```text
Unit Tests
Integration Tests
API Tests
Database Tests
Authentication Tests
Authorization Tests
```

Produz:

```text
tasks/reports/TEST_REPORT.md
```

Falhas retornam ao Developer:

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

Analisa:

```text
Python Style
Typing
FastAPI
CQRS
Domain
Domain Events
SQLAlchemy
Alembic
Security
Tests
Complexidade
Duplicação
Spec
Rules
```

Produz:

```text
tasks/reports/REVIEW_REPORT.md
```

O Reviewer deve detectar especialmente:

```text
Overengineering
Handlers gigantes
Routers com regra de negócio
Domain dependente de framework
Repositories inúteis
Any excessivo
SQLAlchemy mal utilizado
N+1
Ausência de transação
```

---

# 📚 Documentation Agent

Pode atualizar:

```text
README.md
ARCHITECTURE.md
API.md
CHANGELOG.md
docs/
```

A documentação deve refletir o estado real da implementação.

---

# 📁 Estrutura de Automação

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
├── python.rules.md
├── fastapi.rules.md
├── cqrs.rules.md
├── domain.rules.md
├── persistence.rules.md
├── security.rules.md
├── testing.rules.md
├── frontend.rules.md
└── ai-agents.md
```

---

# 🧩 Skills

Skills representam:

> **Como executar operações repetíveis.**

Exemplo:

```text
tasks/skills/
├── create-command/
├── create-query/
├── create-handler/
├── create-domain-event/
├── create-router/
├── create-repository/
├── create-migration/
├── create-unit-test/
├── create-integration-test/
└── create-react-page/
```

---

# 📋 Specs

Specs representam:

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

# 📄 Planejamento Obrigatório

Antes do código:

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
CODE
```

Evitar:

```text
SPEC
 ↓
CODE
```

---

# 📊 Relatórios Obrigatórios

Depois da implementação:

```text
tasks/reports/
├── TEST_REPORT.md
└── REVIEW_REPORT.md
```

Esses documentos fazem parte dos critérios de conclusão.

---

# 🚦 Quality Gates

O projeto possui oito gates principais.

```text
GATE-01 Requirements
GATE-02 Architecture
GATE-03 Persistence
GATE-04 Python Quality
GATE-05 Tests
GATE-06 Security
GATE-07 Architecture Review
GATE-08 Documentation
```

---

# GATE-01 — Requirements

Valida:

```text
REQUIREMENTS.md
Critérios de aceite
Regras de negócio
Restrições
Dependências
```

---

# GATE-02 — Architecture

Valida:

```text
ARCHITECTURE_PLAN.md
CQRS
Domain
FastAPI
SQLAlchemy
Dependências
Simplicidade
Tipagem
```

---

# GATE-03 — Persistence

Valida:

```text
SQLAlchemy Models
Repositories
Relationships
Indexes
Constraints
Alembic
Migration
Database
```

---

# GATE-04 — Python Quality

Executa ou valida:

```bash
ruff check .
ruff format --check .
mypy app
```

ou:

```bash
pyright
```

Também pode validar:

```text
Imports
Typing
Async usage
Naming
Complexity
Dead Code
```

---

# GATE-05 — Tests

Executa:

```bash
pytest
```

ou:

```bash
pytest tests/unit
pytest tests/integration
pytest tests/api
```

Todos os testes obrigatórios da Spec devem ser aprovados.

---

# GATE-06 — Security

Valida:

```text
JWT
Refresh Token
Password Hashing
Authentication
Authorization
Permissions
Input Validation
Secrets
Environment Variables
Sensitive Data
```

---

# GATE-07 — Architecture Review

Verifica:

```text
Router sem regra de negócio
CQRS respeitado
Queries sem alteração de estado
Commands corretamente separados
Domain independente
Infrastructure isolada
Repositories justificados
SQLAlchemy bem utilizado
Domain Events coerentes
```

---

# GATE-08 — Documentation

Valida:

```text
README
API
Architecture
Environment
Database
Migrations
Tests
Docker
Execution
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

Bloqueios que não puderem ser resolvidos automaticamente devem ser documentados.

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

em vez de enviar todo o repositório novamente.

---

# 🐳 Docker

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
                      FastAPI
                         │
                         ▼
                     SQLAlchemy
                         │
                         ▼
                       MySQL
```

Serviços adicionais somente devem ser incluídos quando a Spec exigir.

---

# 📂 Estrutura Completa Sugerida

```text
.
├── backend/
│   ├── app/
│   │   ├── main.py
│   │   ├── api/
│   │   ├── application/
│   │   │   ├── commands/
│   │   │   ├── queries/
│   │   │   ├── handlers/
│   │   │   └── dto/
│   │   ├── domain/
│   │   │   ├── entities/
│   │   │   ├── value_objects/
│   │   │   ├── events/
│   │   │   └── services/
│   │   ├── infrastructure/
│   │   │   ├── database/
│   │   │   ├── repositories/
│   │   │   ├── security/
│   │   │   └── integrations/
│   │   ├── schemas/
│   │   ├── config/
│   │   └── shared/
│   │
│   ├── migrations/
│   ├── tests/
│   │   ├── unit/
│   │   ├── integration/
│   │   └── api/
│   └── pyproject.toml
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
├── COPILOT.md
├── AGENTS.md
├── CRIAR-PROJETO.md
├── .env.example
├── docker-compose.yml
└── README.md
```

---

# 🛠️ Comandos Principais

## Ambiente

```bash
python -m venv .venv
```

Linux/macOS:

```bash
source .venv/bin/activate
```

Windows:

```powershell
.venv\Scripts\Activate.ps1
```

---

## Dependências

Conforme o gerenciador adotado pelo template:

```bash
pip install -r requirements.txt
```

ou:

```bash
pip install -e .
```

---

## Executar API

```bash
uvicorn app.main:app --reload
```

---

## Migration

```bash
alembic upgrade head
```

---

## Testes

```bash
pytest
```

---

## Ruff

```bash
ruff check .
ruff format --check .
```

---

## Type Check

```bash
mypy app
```

ou:

```bash
pyright
```

---

## Docker

```bash
docker compose up -d
```

---

# ▶️ Como Iniciar

Uma IA compatível com as instruções do projeto pode iniciar com:

```text
Leia COPILOT.md e execute a Spec ativa seguindo o workflow de agentes.
```

Para criação:

```text
prompts/CREATE_PROJECT.md
```

Para refatoração:

```text
prompts/REFACTOR_PROJECT.md
```

---

# 📌 Spec Inicial

A fundação inicial deve estar em:

```text
tasks/specs/changes/001-project-foundation.md
```

Ela pode estabelecer:

```text
Backend
Domain
CQRS
Persistence
Authentication
Permissions
React Admin
React Site
Testing
Docker
```

---

# 🛡️ Definition of Done

Código gerado não representa conclusão.

```text
CODE GENERATED != DONE
```

Para uma Spec alcançar `DONE`:

```text
[✓] Spec analisada

[✓] REQUIREMENTS.md gerado

[✓] ARCHITECTURE_PLAN.md gerado

[✓] EXECUTION_PLAN.md gerado

[✓] Arquitetura aprovada

[✓] Domain validado

[✓] CQRS validado

[✓] Persistência validada

[✓] Alembic Migration validada

[✓] Implementação concluída

[✓] Ruff aprovado

[✓] Type Check aprovado

[✓] Unit Tests aprovados

[✓] Integration Tests aprovados

[✓] API Tests aprovados

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
SPEC = DONE
```

---

# 🔑 Princípios Fundamentais

```text
1. Python deve permanecer idiomático.

2. Python deve permanecer tipado.

3. Router FastAPI não contém regra de negócio.

4. Command altera estado.

5. Query somente lê.

6. Handler orquestra um caso de uso.

7. Domain concentra regras de negócio.

8. Domain não depende de FastAPI ou SQLAlchemy.

9. Infrastructure concentra persistência e integrações.

10. Pydantic valida contratos e fronteiras.

11. SQLAlchemy 2 implementa persistência.

12. Alembic controla a evolução do schema.

13. Domain Events devem representar fatos relevantes.

14. Repository deve agregar valor.

15. Não copiar estruturas de .NET ou Java mecanicamente.

16. Não iniciar implementação sem planejamento.

17. Build e lint não substituem testes.

18. Testes não substituem review.

19. Nenhum Agent ignora Quality Gates obrigatórios.
```

---

# 🧠 Arquitetura da Aplicação

```text
React Admin / React Site
          │
          ▼
       FastAPI
          │
          ▼
        Router
          │
          ▼
   Command / Query
          │
          ▼
        Handler
          │
          ▼
        Domain
          │
          ▼
      Repository
          │
          ▼
      SQLAlchemy
          │
          ▼
         MySQL
```

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
PYTHON APPLICATION
────────────────────────

Python
FastAPI
Pydantic
CQRS
Domain Model
Domain Events
SQLAlchemy
Alembic
MySQL
JWT
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
Validação Python
    ↓
Testes
    ↓
Review
    ↓
Documentação
    ↓
Quality Gates
    ↓
Entrega
```

---

# 📄 Licença

Defina a licença conforme as necessidades do projeto.

---

# Python + FastAPI + CQRS + MySQL + AI Agents

**Python + FastAPI + CQRS + Domain Events + SQLAlchemy + MySQL + React + AI Agents + Quality Gates**

> O objetivo não é apenas gerar uma API Python. É produzir uma solução tipada, idiomática, testada, revisada e validada antes de considerá-la concluída.
