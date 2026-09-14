# Java + Gradle + Hexagonal + CQRS + MySQL

Template para desenvolvimento de aplicações **Java modernas, modulares, testáveis e desacopladas de infraestrutura**, utilizando **Arquitetura Hexagonal (Ports & Adapters)**, **CQRS**, **Domain Events**, Spring Boot, MySQL e React.

A versão **AI Agents v2** adiciona um pipeline de desenvolvimento orientado por agentes, planejamento prévio e Quality Gates, **sem alterar ou violar as regras da Arquitetura Hexagonal**.

---

# 🚀 Stack

| Tecnologia      | Versão / Referência              |
| --------------- | -------------------------------- |
| Java            | 25 LTS                           |
| Spring Boot     | 4.1.1                            |
| Gradle          | 9.7.1                            |
| Build DSL       | Kotlin DSL                       |
| Arquitetura     | Hexagonal                        |
| Padrão          | Ports & Adapters                 |
| Aplicação       | CQRS                             |
| Eventos         | Domain Events                    |
| Segurança       | Spring Security                  |
| Autenticação    | JWT                              |
| Persistência    | Spring Data JPA                  |
| Banco           | MySQL                            |
| Migrations      | Flyway                           |
| Testes          | JUnit 5                          |
| Mocking         | Mockito                          |
| Assertions      | AssertJ                          |
| Integração      | Testcontainers                   |
| Front-end Admin | React                            |
| Front-end Site  | React                            |
| IA              | Rules + Skills + Specs + Copilot |
| Orquestração    | AI Agents v2                     |

> **Importante:** as versões acima são referências do template.
>
> Antes da implementação, as versões devem ser revalidadas para garantir o uso de releases **estáveis, compatíveis e suportadas** no momento da execução.

---

# 🏗️ Arquitetura Hexagonal

O projeto utiliza **Hexagonal Architecture**, também conhecida como:

```text
Ports & Adapters
```

O objetivo principal é manter as regras de negócio independentes de frameworks, banco de dados, APIs externas, mensageria e outras tecnologias de infraestrutura.

Visão simplificada:

```text
                     ┌──────────────────────┐
                     │    REST / React      │
                     │   Input Adapters     │
                     └──────────┬───────────┘
                                │
                         Input Ports
                                │
                                ▼
                ┌───────────────────────────┐
                │        Application        │
                │                           │
                │   Commands     Queries    │
                │      │            │       │
                │      ▼            ▼       │
                │   Handlers     Handlers   │
                └──────────┬────────────────┘
                           │
                           ▼
                ┌───────────────────────────┐
                │          Domain           │
                │                           │
                │ Entities                  │
                │ Value Objects             │
                │ Domain Services           │
                │ Domain Events             │
                │ Business Rules            │
                └──────────┬────────────────┘
                           │
                      Output Ports
                           │
          ┌────────────────┼────────────────┐
          ▼                ▼                ▼
      Persistence      Messaging       External APIs
       Adapter          Adapter           Adapter
          │
          ▼
        JPA
          │
          ▼
        MySQL
```

---

# 🚨 Regra Arquitetural Bloqueante

A separação entre as camadas é uma regra obrigatória deste template.

```text
DOMAIN
   ↓
não depende de Spring
não depende de JPA
não depende de banco
não depende de infraestrutura
não depende de adapters
```

A camada:

```text
APPLICATION
```

pode utilizar:

```text
Domain
Ports
Commands
Queries
Use Cases
```

mas:

```text
APPLICATION
    ✕
ADAPTERS
```

A Application **não pode depender diretamente de adapters**.

Os adapters devem implementar Ports definidos pelo núcleo da aplicação.

```text
Application
     │
     ▼
   Port
     ▲
     │ implements
     │
   Adapter
```

Portanto:

```text
Domain → independente

Application → Domain + Ports

Adapters → implementam Ports

Infrastructure → detalhes tecnológicos
```

Qualquer violação dessa regra deve reprovar o Quality Gate arquitetural.

---

# 🔌 Ports & Adapters

## Input Ports

Representam operações disponibilizadas pela aplicação.

Exemplos:

```text
CreateUserUseCase
UpdateUserUseCase
DeleteUserUseCase
GetUserUseCase
SearchUsersUseCase
```

---

## Output Ports

Representam dependências necessárias para executar os casos de uso.

Exemplos:

```text
UserRepositoryPort
TokenProviderPort
PasswordEncoderPort
EventPublisherPort
EmailSenderPort
```

O núcleo conhece apenas os contratos.

Exemplo:

```text
UserRepositoryPort
        ▲
        │ implements
        │
JpaUserRepositoryAdapter
```

A implementação concreta pertence ao adapter.

---

# ⚡ CQRS

O projeto utiliza **Command Query Responsibility Segregation — CQRS**.

As operações são separadas em:

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
commands/
├── CreateUserCommand
├── UpdateUserCommand
└── DeleteUserCommand

queries/
├── GetUserByIdQuery
├── GetUsersQuery
└── SearchUsersQuery
```

Handlers:

```text
handlers/
├── CreateUserCommandHandler
├── UpdateUserCommandHandler
├── DeleteUserCommandHandler
├── GetUserByIdQueryHandler
├── GetUsersQueryHandler
└── SearchUsersQueryHandler
```

---

# 📡 Domain Events

Eventos de domínio representam fatos relevantes ocorridos dentro do negócio.

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
Command Handler
   ↓
Domain
   ↓
Business Rule
   ↓
Domain Event
   ↓
Event Handler
```

Domain Events devem permanecer independentes da tecnologia utilizada para transportá-los.

O domínio não deve conhecer:

```text
Kafka
RabbitMQ
Spring Events
Redis
HTTP
```

Caso uma dessas tecnologias seja utilizada, sua implementação pertence aos **Adapters**.

---

# 📁 Estrutura sugerida

```text
project/
│
├── backend/
│   │
│   ├── src/
│   │   ├── main/
│   │   │   ├── java/
│   │   │   │   └── com/company/project/
│   │   │   │       │
│   │   │   │       ├── domain/
│   │   │   │       │   ├── model/
│   │   │   │       │   ├── valueobjects/
│   │   │   │       │   ├── events/
│   │   │   │       │   ├── services/
│   │   │   │       │   └── exceptions/
│   │   │   │       │
│   │   │   │       ├── application/
│   │   │   │       │   ├── ports/
│   │   │   │       │   │   ├── input/
│   │   │   │       │   │   └── output/
│   │   │   │       │   ├── commands/
│   │   │   │       │   ├── queries/
│   │   │   │       │   ├── handlers/
│   │   │   │       │   └── dto/
│   │   │   │       │
│   │   │   │       ├── adapters/
│   │   │   │       │   ├── input/
│   │   │   │       │   │   └── web/
│   │   │   │       │   └── output/
│   │   │   │       │       ├── persistence/
│   │   │   │       │       ├── messaging/
│   │   │   │       │       └── external/
│   │   │   │       │
│   │   │   │       └── infrastructure/
│   │   │   │           ├── configuration/
│   │   │   │           └── security/
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
├── orchestration/
│   └── gates/
│       └── QUALITY_GATES.md
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

# 🔐 Segurança

A segurança utiliza:

```text
Spring Security
      +
     JWT
```

O template prevê:

```text
Login
Access Token
Refresh Token
Logout
Forgot Password
Reset Password
Roles
Permissions
Authorization
```

Entretanto, a arquitetura deve continuar respeitando os Ports.

Exemplo:

```text
Application
     │
     ▼
TokenProviderPort
     ▲
     │
JwtTokenAdapter
     │
     ▼
Spring Security
```

Assim, a regra de negócio não depende diretamente do mecanismo JWT.

---

# 🗄️ Persistência

Banco principal:

```text
MySQL
```

Persistência:

```text
Spring Data JPA
```

Migrations:

```text
Flyway
```

O domínio não deve utilizar diretamente:

```text
@Entity
@Table
@Column
JpaRepository
EntityManager
```

A persistência é responsabilidade dos adapters.

Fluxo:

```text
Domain
   │
   ▼
Repository Port
   ▲
   │ implements
   │
Persistence Adapter
   │
   ▼
Spring Data JPA
   │
   ▼
MySQL
```

---

# 🗃️ Flyway

As migrations ficam em:

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

Alterações estruturais do banco devem ser versionadas.

---

# 🧪 Testes

O template utiliza:

```text
JUnit 5
Mockito
AssertJ
Testcontainers
```

A estratégia de testes deve respeitar as fronteiras arquiteturais.

## Domain Tests

Devem testar regras de negócio sem Spring.

```text
Domain
   +
JUnit
   +
AssertJ
```

Idealmente:

```text
Spring Context = NÃO
Database       = NÃO
Infrastructure = NÃO
```

---

## Application Tests

Os Ports podem ser simulados utilizando:

```text
Mockito
```

Exemplo:

```text
Command Handler
      │
      ▼
Repository Port
      ▲
      │ mock
      │
    Mockito
```

---

## Integration Tests

Para integração real:

```text
JUnit
   │
   ▼
Spring Boot Test
   │
   ▼
Testcontainers
   │
   ▼
MySQL Container
   │
   ▼
Flyway
   │
   ▼
Persistence Adapter
```

Isso permite validar o adapter utilizando infraestrutura próxima do ambiente real.

---

# ⚛️ Front-end

O projeto prevê duas aplicações React:

```text
frontend/
├── admin/
└── site/
```

## React Admin

Área administrativa.

Pode conter:

```text
Dashboard

Users
├── List
├── New
├── Edit
└── Detail

Roles
Permissions
Groups
Settings
Audit
```

## React Site

Aplicação destinada ao usuário final.

Ambas consomem os adapters HTTP disponibilizados pelo backend.

---

# 🤖 AI Agents — v2

A versão **AI Agents v2** adiciona desenvolvimento orientado por agentes sem modificar os princípios da Arquitetura Hexagonal.

Pipeline:

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

A IA não deve começar diretamente pela geração do código.

Primeiro devem ser produzidos os artefatos de planejamento.

---

# 📋 Requirements Agent

Responsável pela análise inicial.

Gera:

```text
REQUIREMENTS.md
```

Deve identificar:

```text
Requisitos funcionais
Requisitos não funcionais
Regras de negócio
Critérios de aceite
Dependências
Riscos
Restrições
Integrações
```

---

# 🏛️ Architect Agent

Responsável pela arquitetura.

Gera:

```text
ARCHITECTURE_PLAN.md
```

Deve definir:

```text
Domain
Application
Input Ports
Output Ports
Input Adapters
Output Adapters
Commands
Queries
Domain Events
Persistência
Segurança
Integrações
Testes
```

Também deve validar que nenhuma decisão arquitetural cria dependência indevida do núcleo com infraestrutura.

---

# 👨‍💻 Tech Lead Agent

Transforma os requisitos e arquitetura em tarefas executáveis.

Gera:

```text
EXECUTION_PLAN.md
```

Exemplo:

```text
TASK-001
TASK-002
TASK-003
TASK-004
...
```

Cada tarefa deve possuir:

```text
Objetivo
Arquivos envolvidos
Dependências
Critérios de aceite
Testes
Status
```

---

# 💻 Developer Agent

Responsável pela implementação.

O Developer deve seguir obrigatoriamente:

```text
REQUIREMENTS.md
        +
ARCHITECTURE_PLAN.md
        +
EXECUTION_PLAN.md
        +
Rules
        +
Skills
        +
Specs
```

O agente não possui autorização para quebrar as fronteiras da Arquitetura Hexagonal para simplificar uma implementação.

---

# 🧪 Tester Agent

Responsável por:

```text
Unit Tests
Domain Tests
Application Tests
Integration Tests
Repository Adapter Tests
Security Tests
API Tests
Testcontainers
```

Nenhuma implementação com testes obrigatórios falhando pode avançar.

---

# 🔎 Reviewer Agent

Responsável pela revisão técnica.

Verifica:

```text
Arquitetura
CQRS
Ports & Adapters
Domain Events
SOLID
Segurança
Persistência
Testes
Qualidade
Duplicação
Tratamento de erros
Regras de negócio
```

Principal validação:

```text
Domain → Infrastructure
```

Se essa dependência existir:

```text
REPROVADO
```

Também deve reprovar:

```text
Application → Adapter
Domain → Spring
Domain → JPA
Domain → MySQL
Domain → Infrastructure
```

---

# 📚 Documentation Agent

Responsável pela documentação final.

Pode gerar ou atualizar:

```text
README.md
ARCHITECTURE.md
API.md
CHANGELOG.md
docs/
```

A documentação deve refletir a implementação real entregue pelo projeto.

---

# 🧠 Rules + Skills + Specs

O projeto utiliza três fontes principais de instrução para os agentes.

```text
Rules
  │
  ├── Como o projeto DEVE ser construído
  │
Skills
  │
  ├── Como executar tarefas
  │
Specs
  │
  └── O que cada funcionalidade deve fazer
```

---

# 📜 Rules

Exemplo:

```text
rules/
├── architecture.rules.md
├── hexagonal.rules.md
├── cqrs.rules.md
├── domain.rules.md
├── security.rules.md
├── database.rules.md
├── testing.rules.md
└── frontend.rules.md
```

---

# 🧩 Skills

Exemplo:

```text
skills/
├── create-domain/
├── create-port/
├── create-adapter/
├── create-command/
├── create-query/
├── create-domain-event/
├── create-migration/
├── create-unit-test/
├── create-integration-test/
└── create-react-page/
```

---

# 📑 Specs

Exemplo:

```text
specs/
├── auth/
├── users/
├── roles/
├── permissions/
└── dashboard/
```

---

# 🚦 Quality Gates

A conclusão do desenvolvimento depende dos Quality Gates definidos em:

```text
orchestration/
└── gates/
    └── QUALITY_GATES.md
```

Pipeline sugerido:

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

Fluxo:

```text
Quality Gate
     │
     ├── PASS ─────────────► próximo estágio
     │
     └── FAIL
          │
          ▼
       Correção
          │
          ▼
     Nova validação
```

---

# 🛑 Architecture Gate

Além dos Quality Gates gerais, a arquitetura Hexagonal possui regras bloqueantes.

```text
DOMAIN
  ✕ Spring
  ✕ JPA
  ✕ MySQL
  ✕ Infrastructure
  ✕ Adapters
```

```text
APPLICATION
  ✓ Domain
  ✓ Ports

  ✕ Adapters
  ✕ Infrastructure concreta
```

```text
ADAPTERS
  ✓ Ports
  ✓ Application contracts
  ✓ Frameworks
  ✓ Infrastructure
```

Portanto:

```text
DEPENDENCY DIRECTION

Adapters
    │
    ▼
Application
    │
    ▼
Domain
```

Nunca:

```text
Domain
   │
   ▼
Infrastructure
```

Essa violação deve bloquear automaticamente a entrega.

---

# 🔨 Build

Linux/macOS:

```bash
./gradlew clean build
```

Windows:

```powershell
gradlew.bat clean build
```

---

# 🧪 Executando testes

Linux/macOS:

```bash
./gradlew test
```

Windows:

```powershell
gradlew.bat test
```

Para os testes de integração, o ambiente deve possuir suporte ao runtime de containers exigido pelo Testcontainers.

---

# 🔄 Fluxo completo

```text
SOLICITAÇÃO
     │
     ▼
Requirements Agent
     │
     ├── REQUIREMENTS.md
     ▼
Architect Agent
     │
     ├── ARCHITECTURE_PLAN.md
     ▼
Tech Lead Agent
     │
     ├── EXECUTION_PLAN.md
     ▼
Developer Agent
     │
     ▼
Implementation
     │
     ▼
Build
     │
     ▼
Tester Agent
     │
     ▼
Tests
     │
     ▼
Reviewer Agent
     │
     ▼
Architecture Review
     │
     ▼
Documentation Agent
     │
     ▼
Documentation
     │
     ▼
QUALITY GATES
     │
     ▼
DELIVERY
```

---

# 🤖 Copilot + AI Agents

O contexto utilizado pelos agentes deve considerar:

```text
Rules
        +
Skills
        +
Specs
        +
REQUIREMENTS.md
        +
ARCHITECTURE_PLAN.md
        +
EXECUTION_PLAN.md
        │
        ▼
    AI Agents
        │
        ▼
Implementation
        │
        ▼
Quality Gates
```

Isso transforma o Copilot de um simples gerador de código em parte de um processo estruturado de engenharia de software.

---

# ✅ Definition of Done

Código gerado não significa tarefa concluída.

```text
CODE GENERATED != DONE
```

Uma entrega somente pode ser considerada concluída quando:

```text
[✓] Requirements aprovado

[✓] Architecture aprovado

[✓] Execution Plan aprovado

[✓] Arquitetura Hexagonal preservada

[✓] Domain independente de frameworks

[✓] Ports definidos corretamente

[✓] Adapters implementando Ports

[✓] CQRS validado

[✓] Domain Events validados

[✓] Build aprovado

[✓] Unit Tests aprovados

[✓] Integration Tests aprovados

[✓] Code Review aprovado

[✓] Documentation atualizada

[✓] Quality Gates aprovados
```

Portanto:

```text
BUILD
  +
TESTS
  +
ARCHITECTURE
  +
REVIEW
  +
DOCUMENTATION
  =
DONE
```

---

# 🎯 Objetivo

Este template tem como objetivo unir:

```text
Java
+
Spring Boot
+
Hexagonal Architecture
+
Ports & Adapters
+
CQRS
+
Domain Events
+
MySQL
+
React
+
Automated Tests
+
AI Agents
```

em um processo estruturado de desenvolvimento:

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
BUILD
  ↓
TESTES
  ↓
REVIEW
  ↓
DOCUMENTAÇÃO
  ↓
ENTREGA
```

A IA participa de todo o ciclo, mas deve respeitar as mesmas regras arquiteturais impostas a um desenvolvedor humano.

---

# 📌 Resumo

## Backend

```text
Java 25 LTS
Spring Boot 4.1.1
Gradle 9.7.1
Kotlin DSL
Hexagonal Architecture
Ports & Adapters
CQRS
Domain Events
Spring Security
JWT
Spring Data JPA
MySQL
Flyway
```

## Testes

```text
JUnit 5
Mockito
AssertJ
Testcontainers
```

## Front-end

```text
React Admin
React Site
```

## AI Engineering

```text
Rules
Skills
Specs
Copilot
AI Agents v2
Quality Gates
```

## Agentes

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

## Princípio fundamental

```text
Business Rules
      ↓
independentes de
      ↓
Frameworks / Database / Infrastructure
```

**O domínio é o centro da aplicação. A tecnologia é apenas um detalhe externo.**

---

# 📄 Licença

Defina a licença conforme a necessidade do projeto ou da organização.
