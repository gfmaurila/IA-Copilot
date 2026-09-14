# Java + Gradle + Spring Boot + CQRS + MySQL

Template de projeto para construção de aplicações **Java modernas, escaláveis e orientadas a domínio**, utilizando **Spring Boot, CQRS, Domain Events, MySQL, React e automação assistida por IA**.

A versão **AI Agents v2** adiciona um fluxo completo de desenvolvimento baseado em agentes especializados, planejamento prévio e **Quality Gates obrigatórios**.

---

## 🚀 Stack principal

| Tecnologia      | Referência                       |
| --------------- | -------------------------------- |
| Java            | 25 LTS                           |
| Spring Boot     | 4.1.x                            |
| Gradle          | 9.7.x                            |
| Build DSL       | Kotlin DSL                       |
| Banco de Dados  | MySQL                            |
| ORM             | Spring Data JPA                  |
| Migrations      | Flyway                           |
| Segurança       | Spring Security + JWT            |
| Testes          | JUnit 5                          |
| Integração      | Testcontainers                   |
| Front-end Admin | React                            |
| Front-end Site  | React                            |
| Arquitetura     | CQRS + Domain Events             |
| IA              | Rules + Skills + Specs + Copilot |
| Orquestração    | AI Agents v2                     |

> **Importante:** as versões informadas representam a referência do template.
> Antes da geração ou atualização do projeto, as versões devem ser **revalidadas** para utilização das releases estáveis, compatíveis e suportadas no momento da execução.

---

# 🧠 AI Agents — v2

A versão **v2** introduz uma arquitetura de desenvolvimento orientada por agentes de IA.

Cada agente possui uma responsabilidade específica dentro do ciclo de desenvolvimento.

```text
Requirements
     ↓
Architect
     ↓
Tech Lead
     ↓
Developer
     ↓
Tester
     ↓
Reviewer
     ↓
Documentation
```

O objetivo é evitar geração direta de código sem planejamento.

Antes da implementação, os requisitos são analisados, a arquitetura é definida e um plano de execução é produzido.

---

## 🤖 Agentes

### Requirements Agent

Responsável por interpretar a solicitação e transformar a necessidade inicial em requisitos claros.

Gera:

```text
REQUIREMENTS.md
```

Responsabilidades:

* interpretar requisitos funcionais;
* identificar requisitos não funcionais;
* identificar regras de negócio;
* detectar ambiguidades;
* definir critérios de aceite;
* identificar dependências;
* levantar riscos iniciais.

---

### Architect Agent

Responsável pelas decisões arquiteturais.

Gera:

```text
ARCHITECTURE_PLAN.md
```

Define:

* arquitetura da solução;
* divisão de módulos;
* domínio;
* bounded contexts quando aplicável;
* Commands;
* Queries;
* Domain Events;
* persistência;
* integrações;
* segurança;
* estratégia de testes;
* dependências entre componentes.

---

### Tech Lead Agent

Transforma arquitetura e requisitos em um plano técnico executável.

Gera:

```text
EXECUTION_PLAN.md
```

O plano pode conter:

```text
TASK-001
TASK-002
TASK-003
TASK-004
...
```

Cada tarefa deve possuir:

* objetivo;
* arquivos envolvidos;
* dependências;
* critérios de aceite;
* testes necessários;
* status.

---

### Developer Agent

Responsável pela implementação.

Implementa:

* Domain;
* Commands;
* Queries;
* Handlers;
* Domain Events;
* Controllers/Endpoints;
* Entities;
* Repositories;
* Services;
* Security;
* JWT;
* migrations;
* integrações;
* configurações.

O agente deve respeitar obrigatoriamente:

```text
REQUIREMENTS.md
ARCHITECTURE_PLAN.md
EXECUTION_PLAN.md
```

---

### Tester Agent

Responsável pela validação automatizada.

Executa e/ou cria:

* testes unitários;
* testes de integração;
* testes de domínio;
* testes de repositories;
* testes de endpoints;
* testes de autenticação;
* testes utilizando Testcontainers.

Nenhuma funcionalidade deve ser considerada concluída com testes obrigatórios falhando.

---

### Reviewer Agent

Responsável pela revisão técnica da implementação.

Verifica:

* aderência arquitetural;
* qualidade do código;
* duplicação;
* segurança;
* tratamento de erros;
* responsabilidades das classes;
* cobertura dos requisitos;
* consistência do CQRS;
* Domain Events;
* persistência;
* testes.

Problemas encontrados devem retornar para correção antes da aprovação.

---

### Documentation Agent

Responsável pela documentação final.

Pode atualizar ou gerar:

```text
README.md
docs/
CHANGELOG.md
API.md
ARCHITECTURE.md
```

Também deve documentar:

* configuração;
* execução;
* banco de dados;
* migrations;
* autenticação;
* endpoints;
* testes;
* Docker, quando existente;
* decisões arquiteturais relevantes.

---

# 🔄 Pipeline AI Agents

O fluxo principal é:

```text
Solicitação
    │
    ▼
Requirements Agent
    │
    ├── REQUIREMENTS.md
    │
    ▼
Architect Agent
    │
    ├── ARCHITECTURE_PLAN.md
    │
    ▼
Tech Lead Agent
    │
    ├── EXECUTION_PLAN.md
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
Entrega
```

Caso algum Quality Gate seja reprovado:

```text
Quality Gate
     │
     ├── APROVADO ──────► próximo estágio
     │
     └── REPROVADO
             │
             ▼
          Correção
             │
             ▼
        Nova validação
```

---

# 🛡️ Quality Gates

A entrega utiliza **8 Quality Gates**.

```text
GATE 01 ─ Requirements
GATE 02 ─ Architecture
GATE 03 ─ Execution Plan
GATE 04 ─ Implementation
GATE 05 ─ Build
GATE 06 ─ Tests
GATE 07 ─ Code Review
GATE 08 ─ Documentation
```

### Gate 01 — Requirements

Valida se os requisitos foram compreendidos e documentados.

Saída esperada:

```text
REQUIREMENTS.md
```

---

### Gate 02 — Architecture

Valida as decisões arquiteturais.

Saída esperada:

```text
ARCHITECTURE_PLAN.md
```

---

### Gate 03 — Execution Plan

Valida se existe um plano técnico executável.

Saída esperada:

```text
EXECUTION_PLAN.md
```

---

### Gate 04 — Implementation

Verifica se a implementação está aderente aos requisitos e à arquitetura definida.

---

### Gate 05 — Build

O projeto deve compilar corretamente.

Exemplo:

```bash
./gradlew clean build
```

No Windows:

```powershell
gradlew.bat clean build
```

---

### Gate 06 — Tests

Todos os testes obrigatórios devem ser executados com sucesso.

```bash
./gradlew test
```

Incluindo, quando aplicável:

```text
Unit Tests
Integration Tests
Repository Tests
API Tests
Security Tests
Testcontainers
```

---

### Gate 07 — Code Review

O Reviewer Agent analisa a implementação antes da entrega.

O gate deve bloquear problemas relevantes relacionados a:

* arquitetura;
* segurança;
* qualidade;
* manutenção;
* regras de negócio;
* testes;
* inconsistências com as Specs.

---

### Gate 08 — Documentation

A entrega somente é concluída quando a documentação estiver consistente com a implementação final.

---

# 🏗️ Arquitetura

O backend utiliza uma arquitetura orientada a domínio com separação entre operações de escrita e leitura através de **CQRS**.

Fluxo simplificado:

```text
HTTP Request
     │
     ▼
Controller / Endpoint
     │
     ├──────────────┐
     ▼              ▼
  Command         Query
     │              │
     ▼              ▼
CommandHandler   QueryHandler
     │              │
     ▼              ▼
   Domain        Repository
     │
     ▼
Domain Events
     │
     ▼
Repository
     │
     ▼
Spring Data JPA
     │
     ▼
   MySQL
```

---

# 📁 Estrutura sugerida

```text
project/
│
├── backend/
│   ├── src/
│   │   ├── main/
│   │   │   ├── java/
│   │   │   │   └── com/company/project/
│   │   │   │       │
│   │   │   │       ├── domain/
│   │   │   │       │   ├── entities/
│   │   │   │       │   ├── events/
│   │   │   │       │   ├── repositories/
│   │   │   │       │   └── services/
│   │   │   │       │
│   │   │   │       ├── application/
│   │   │   │       │   ├── commands/
│   │   │   │       │   ├── queries/
│   │   │   │       │   ├── handlers/
│   │   │   │       │   └── dto/
│   │   │   │       │
│   │   │   │       ├── infrastructure/
│   │   │   │       │   ├── persistence/
│   │   │   │       │   ├── security/
│   │   │   │       │   └── configuration/
│   │   │   │       │
│   │   │   │       └── presentation/
│   │   │   │           └── controllers/
│   │   │   │
│   │   │   └── resources/
│   │   │       ├── db/
│   │   │       │   └── migration/
│   │   │       └── application.yml
│   │   │
│   │   └── test/
│   │
│   ├── build.gradle.kts
│   └── settings.gradle.kts
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
├── rules/
├── skills/
├── specs/
├── docs/
│
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
├── EXECUTION_PLAN.md
└── README.md
```

---

# ⚡ CQRS

O projeto separa operações em:

```text
Commands → alteração de estado
Queries  → consulta de dados
```

Exemplo:

```text
CreateUserCommand
UpdateUserCommand
DeleteUserCommand

GetUserByIdQuery
GetUsersQuery
SearchUsersQuery
```

Handlers:

```text
CreateUserCommandHandler
UpdateUserCommandHandler
DeleteUserCommandHandler

GetUserByIdQueryHandler
GetUsersQueryHandler
SearchUsersQueryHandler
```

Essa separação facilita:

* manutenção;
* testes;
* evolução;
* isolamento das regras de negócio;
* observabilidade;
* escalabilidade futura.

---

# 📡 Domain Events

Eventos de domínio representam fatos relevantes ocorridos dentro do domínio.

Exemplo:

```text
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
```

Fluxo:

```text
Command
   ↓
CommandHandler
   ↓
Domain
   ↓
Domain Event
   ↓
Event Handler
```

Os eventos permitem reduzir o acoplamento entre funcionalidades.

---

# 🔐 Segurança

A autenticação utiliza:

```text
Spring Security
JWT Access Token
JWT Refresh Token
```

Estrutura prevista:

```text
Login
Refresh Token
Logout
Forgot Password
Reset Password
Authorization
Roles
Permissions
```

Endpoints protegidos devem validar autenticação e autorização antes da execução da regra de negócio.

---

# 🗄️ Banco de dados

Banco principal:

```text
MySQL
```

Persistência:

```text
Spring Data JPA
```

Versionamento do banco:

```text
Flyway
```

Migrations:

```text
src/main/resources/db/migration/
```

Exemplo:

```text
V1__create_users.sql
V2__create_roles.sql
V3__create_permissions.sql
V4__create_user_roles.sql
```

---

# 🧪 Testes

O template utiliza:

```text
JUnit 5
Spring Boot Test
Testcontainers
```

O objetivo é permitir testes utilizando infraestrutura real e isolada.

Exemplo:

```text
JUnit
   │
   ▼
Testcontainers
   │
   ▼
MySQL Container
   │
   ▼
Migration Flyway
   │
   ▼
Integration Tests
```

Ao finalizar os testes, os containers são descartados.

---

# ⚛️ Front-end

O template prevê duas aplicações React independentes.

```text
frontend/
├── admin/
└── site/
```

### Admin

Voltado à administração do sistema.

Pode conter:

```text
Dashboard
Usuários
Grupos
Roles
Permissões
Configurações
Auditoria
```

### Site

Aplicação destinada ao usuário final.

Ambos podem consumir a mesma API Spring Boot.

---

# 📜 Rules

A pasta:

```text
rules/
```

contém regras obrigatórias para geração e manutenção do projeto.

Exemplos:

```text
architecture.rules.md
backend.rules.md
frontend.rules.md
database.rules.md
security.rules.md
testing.rules.md
documentation.rules.md
```

As Rules definem **como o projeto deve ser desenvolvido**.

---

# 🧩 Skills

A pasta:

```text
skills/
```

contém capacidades reutilizáveis para os agentes.

Exemplos:

```text
create-crud/
create-command/
create-query/
create-domain-event/
create-migration/
create-unit-test/
create-integration-test/
create-react-page/
```

As Skills definem **como executar tarefas recorrentes**.

---

# 📋 Specs

A pasta:

```text
specs/
```

contém especificações funcionais e técnicas.

Exemplo:

```text
specs/
├── auth/
├── users/
├── roles/
├── permissions/
└── dashboard/
```

Cada funcionalidade pode possuir sua própria especificação.

---

# 🤖 GitHub Copilot

O template foi estruturado para permitir utilização de IA durante todo o ciclo de desenvolvimento.

A IA deve utilizar como contexto:

```text
Rules
   +
Skills
   +
Specs
   +
Requirements
   +
Architecture Plan
   +
Execution Plan
```

Fluxo:

```text
              ┌──────── Rules
              │
              ├──────── Skills
              │
Solicitação ──┼──────── Specs
              │
              ├──────── REQUIREMENTS.md
              │
              ├──────── ARCHITECTURE_PLAN.md
              │
              └──────── EXECUTION_PLAN.md
                       │
                       ▼
                   AI Agents
                       │
                       ▼
                     Código
                       │
                       ▼
                 Quality Gates
```

---

# 🚦 Critério de conclusão

Uma solicitação **não deve ser considerada concluída apenas porque o código foi gerado**.

A entrega somente poderá ser finalizada quando:

```text
[✓] Requirements aprovado
[✓] Architecture aprovado
[✓] Execution Plan aprovado
[✓] Implementation concluída
[✓] Build aprovado
[✓] Tests aprovados
[✓] Review aprovado
[✓] Documentation aprovada
```

Portanto:

```text
CODE GENERATED != DONE

BUILD + TESTS + REVIEW + DOCS = DONE
```

---

# 🎯 Objetivo do template

O objetivo deste template é transformar uma solicitação de software em um processo estruturado:

```text
IDEIA
  ↓
REQUISITOS
  ↓
ARQUITETURA
  ↓
PLANEJAMENTO
  ↓
IMPLEMENTAÇÃO
  ↓
TESTES
  ↓
REVIEW
  ↓
DOCUMENTAÇÃO
  ↓
ENTREGA
```

Em vez de utilizar IA apenas como geradora de código, o projeto utiliza IA como parte de um **pipeline de engenharia de software**, com responsabilidades definidas, artefatos intermediários e validações obrigatórias.

---

## 📌 Resumo

**Backend**

```text
Java 25 LTS
Spring Boot 4.1.x
Gradle 9.7.x
Kotlin DSL
CQRS
Domain Events
Spring Data JPA
MySQL
Flyway
Spring Security
JWT
JUnit 5
Testcontainers
```

**Frontend**

```text
React Admin
React Site
```

**AI Engineering**

```text
Rules
Skills
Specs
GitHub Copilot
AI Agents v2
8 Quality Gates
```

**Pipeline**

```text
Requirements
    ↓
Architect
    ↓
Tech Lead
    ↓
Developer
    ↓
Tester
    ↓
Reviewer
    ↓
Documentation
```

---

## 📄 Licença

Defina a licença do projeto conforme a necessidade da organização ou do repositório onde este template será utilizado.
