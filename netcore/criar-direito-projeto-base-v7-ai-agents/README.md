# Criar Projeto Base v7 — AI Agents

Template para **geração, evolução e validação automatizada de projetos Full Stack utilizando Inteligência Artificial**, estruturado sobre:

```text id="b6n60m"
Specs
+
Rules
+
Skills
+
Agents
+
Workflows
+
Quality Gates
+
State
```

A versão **v7** evolui o modelo utilizado na v6 adicionando uma camada de **engenharia e orquestração por agentes especializados**.

O objetivo é fazer com que a IA deixe de atuar apenas como um gerador de código e passe a operar como uma **pequena equipe de engenharia de software**.

---

# 🎯 Objetivo

O template organiza o desenvolvimento assistido por IA em um processo previsível:

```text id="0lzk02"
PEDIDO
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

Cada etapa possui responsabilidades, artefatos e critérios de validação.

A IA não deve declarar uma tarefa concluída apenas porque o código foi gerado.

---

# 🆕 O que mudou em relação à v6

A **v6** já organizava o conhecimento do projeto utilizando:

```text id="z8br9e"
Spec
 ↓
Rules
 ↓
Skills
 ↓
Implementação
```

Esse modelo define:

```text id="a0by9p"
Spec   → O que fazer
Rules  → Quais regras respeitar
Skills → Como fazer
```

A **v7 mantém esse modelo**, mas adiciona uma camada de engenharia e orquestração.

```text id="k80r7w"
                    PEDIDO
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
                   ENTREGA
```

Agora a IA deve **analisar, planejar, implementar, testar, revisar e documentar** antes de considerar o trabalho concluído.

---

# 🧠 Conceito da v7

A v7 separa o conhecimento e as responsabilidades em sete componentes principais.

```text id="0h9k1f"
Specs
  │
  ├── O que entregar
  │
Rules
  │
  ├── O que obrigatoriamente respeitar
  │
Skills
  │
  ├── Como executar operações
  │
Agents
  │
  ├── Quem toma cada decisão
  │
Workflow
  │
  ├── Em qual ordem executar
  │
Quality Gates
  │
  ├── Quando pode avançar
  │
State
  │
  └── Onde estamos
```

---

# 📋 Specs

As **Specs** descrevem:

> **O que deve ser entregue.**

Exemplos:

```text id="b0bdnn"
Criar autenticação
Criar CRUD de usuários
Criar dashboard
Adicionar permissões
Adicionar nova entidade
Criar integração externa
Criar infraestrutura Docker
```

Localização:

```text id="7t8p7v"
tasks/
└── specs/
```

Mudanças específicas podem ser organizadas em:

```text id="9xyj1j"
tasks/
└── specs/
    └── changes/
```

Exemplo:

```text id="9vw2j1"
tasks/specs/changes/001-project-foundation.md
```

---

# 📜 Rules

As **Rules** definem:

> **Restrições permanentes do projeto.**

Exemplos:

```text id="nnzj7u"
Arquitetura
Padrões de código
Persistência
Segurança
Testes
Frontend
Docker
Logging
CQRS
Domain Events
```

Localização:

```text id="8icpbq"
tasks/
└── rules/
```

Exemplo:

```text id="h1odps"
tasks/rules/
├── architecture.rules.md
├── domain.rules.md
├── cqrs.rules.md
├── database.rules.md
├── security.rules.md
├── testing.rules.md
├── frontend.rules.md
└── docker.rules.md
```

Uma Rule não deve ser ignorada apenas para simplificar uma implementação.

---

# 🧩 Skills

As **Skills** definem:

> **Como executar operações repetíveis.**

Localização:

```text id="r4y86k"
tasks/
└── skills/
```

Exemplos:

```text id="5hrg8i"
create-entity/
create-command/
create-query/
create-domain-event/
create-migration/
create-api/
create-unit-test/
create-integration-test/
create-react-page/
create-docker-service/
```

A ideia é evitar repetir grandes instruções em cada Spec.

---

# 🤖 Agents

Os **Agents** definem:

> **Quem é responsável por cada tipo de decisão.**

Estrutura:

```text id="oacbs5"
agents/
├── requirements/
├── architect/
├── tech-lead/
├── developer/
├── tester/
├── reviewer/
└── documentation/
```

Cada agente possui responsabilidade específica dentro do processo.

---

# 🔎 Requirements Agent

Responsável por transformar a solicitação inicial em requisitos estruturados.

Analisa:

```text id="v8v5dz"
Requisitos funcionais
Requisitos não funcionais
Regras de negócio
Critérios de aceite
Restrições
Dependências
Riscos
Ambiguidades
```

Produz:

```text id="6b03td"
tasks/generated/REQUIREMENTS.md
```

---

# 🏛️ Architect Agent

Responsável pelas decisões arquiteturais.

Analisa:

```text id="wbq4z4"
Arquitetura existente
Domain
Application
Infrastructure
CQRS
Domain Events
Persistência
Segurança
Integrações
Frontend
Docker
Testes
```

Produz:

```text id="1smhzb"
tasks/generated/ARCHITECTURE_PLAN.md
```

---

# 👨‍💻 Tech Lead Agent

Responsável por transformar requisitos e arquitetura em um plano técnico executável.

Produz:

```text id="ysvb71"
tasks/generated/EXECUTION_PLAN.md
```

O plano deve dividir a implementação em tarefas menores.

Exemplo:

```text id="3jfw63"
TASK-001
TASK-002
TASK-003
TASK-004
TASK-005
```

Cada tarefa deve possuir:

```text id="n4g3np"
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

O Developer deve utilizar como contexto:

```text id="uwhzsm"
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

O Developer não deve alterar decisões arquiteturais sozinho.

Caso seja encontrada uma inconsistência relevante, ela deve retornar ao estágio responsável.

---

# 🧪 Tester Agent

Responsável pela validação da implementação.

Executa:

```text id="gwvwp8"
Build
Unit Tests
Integration Tests
Database Tests
API Tests
Security Tests
Frontend Tests
```

Produz:

```text id="2o5qzb"
tasks/reports/TEST_REPORT.md
```

O relatório deve registrar:

```text id="sq2z1s"
Testes executados
Testes aprovados
Testes falhando
Erros encontrados
Cobertura relevante
Riscos
Resultado final
```

---

# 🔍 Reviewer Agent

Responsável pela revisão técnica da implementação.

Verifica:

```text id="65kspm"
Arquitetura
Código
SOLID
CQRS
Domain Events
Persistência
Segurança
Testes
Tratamento de erros
Duplicação
Performance
Regras da Spec
Rules
```

Produz:

```text id="cogfge"
tasks/reports/REVIEW_REPORT.md
```

Problemas críticos bloqueiam a conclusão.

---

# 📚 Documentation Agent

Responsável por manter a documentação sincronizada com a implementação.

Pode atualizar:

```text id="bbzg0o"
README.md
docs/
CHANGELOG.md
API.md
ARCHITECTURE.md
```

A documentação deve representar o estado real do projeto depois da implementação.

---

# 🔄 Workflow

O **Workflow** define:

> **A ordem do processo.**

Localização:

```text id="91h0va"
orchestration/
└── workflows/
```

Fluxo principal:

```text id="rsvghu"
Pedido
  │
  ▼
Spec
  │
  ▼
Requirements
  │
  ▼
Architecture
  │
  ▼
Execution Plan
  │
  ▼
Implementation
  │
  ▼
Build
  │
  ▼
Tests
  │
  ▼
Review
  │
  ▼
Documentation
  │
  ▼
Delivery
```

---

# 🚦 Quality Gates

Os **Quality Gates** definem:

> **Quando a IA pode avançar ou concluir.**

Localização:

```text id="fjlf8u"
orchestration/
└── gates/
```

Exemplo de pipeline:

```text id="vxdkx2"
GATE 01 ─ Spec
GATE 02 ─ Requirements
GATE 03 ─ Architecture
GATE 04 ─ Execution Plan
GATE 05 ─ Implementation
GATE 06 ─ Build & Tests
GATE 07 ─ Review
GATE 08 ─ Documentation
```

Fluxo:

```text id="1l0jwi"
          QUALITY GATE
               │
        ┌──────┴──────┐
        │             │
       PASS           FAIL
        │             │
        ▼             ▼
 Próxima etapa      Correção
                      │
                      ▼
                 Nova validação
```

Uma falha crítica deve impedir o avanço do workflow.

---

# 💾 State

O **State** mantém:

> **Um resumo pequeno do progresso atual.**

Localização:

```text id="4l1xho"
orchestration/
└── state/
```

Seu objetivo é evitar que a IA precise reler todo o repositório a cada interação.

O State pode registrar:

```text id="5p50ri"
Spec atual
Fase atual
Tasks concluídas
Tasks pendentes
Quality Gates
Último build
Últimos testes
Problemas conhecidos
Próxima ação
```

Fluxo:

```text id="qq5eup"
Repository
    │
    ▼
State resumido
    │
    ▼
AI Agent
```

em vez de:

```text id="rzf0e6"
Repository inteiro
       │
       ▼
releitura completa
       │
       ▼
AI Agent
```

Isso ajuda a reduzir contexto e consumo de tokens.

---

# 📁 Estrutura principal

```text id="m61dn5"
.
├── AGENTS.md
├── COPILOT.md
├── CRIAR-PROJETO.md
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
│
├── tasks/
│   ├── rules/
│   ├── skills/
│   ├── specs/
│   ├── generated/
│   └── reports/
│
├── docs/
│
├── .env.example
├── docker-compose.yml
└── README.md
```

---

# 📄 Arquivos principais

## AGENTS.md

Define os agentes disponíveis, suas responsabilidades e limites.

```text id="j0qlbs"
Requirements
Architect
Tech Lead
Developer
Tester
Reviewer
Documentation
```

---

## COPILOT.md

Ponto principal de entrada para a IA.

Define:

```text id="z29jhp"
Como interpretar o projeto
Onde encontrar Rules
Onde encontrar Skills
Onde encontrar Specs
Como executar Agents
Como utilizar Workflow
Como validar Quality Gates
Como atualizar State
```

---

## CRIAR-PROJETO.md

Contém as instruções para criação e inicialização de novos projetos utilizando o template.

---

# 🚀 Criando a fundação

Para criar a fundação inicial:

```text id="il4g1u"
Leia COPILOT.md e execute a Spec:

tasks/specs/changes/001-project-foundation.md
```

O orquestrador deve iniciar o pipeline.

---

# 📋 Artefatos de planejamento

Antes de gerar código, devem existir:

```text id="r7fxhs"
tasks/generated/
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
└── EXECUTION_PLAN.md
```

Fluxo:

```text id="1xow6x"
Spec
  │
  ▼
Requirements Agent
  │
  └── REQUIREMENTS.md
  │
  ▼
Architect Agent
  │
  └── ARCHITECTURE_PLAN.md
  │
  ▼
Tech Lead Agent
  │
  └── EXECUTION_PLAN.md
  │
  ▼
Developer Agent
```

Somente depois desse planejamento a implementação deve começar.

---

# 📊 Relatórios

Após a implementação:

```text id="hzoxkj"
tasks/reports/
├── TEST_REPORT.md
└── REVIEW_REPORT.md
```

Esses relatórios fazem parte dos Quality Gates.

---

# 🏗️ Primeira entrega do template

A fundação inicial mantém as capacidades previstas na versão anterior.

## Backend

```text id="icv6p4"
.NET
ASP.NET Core
DDD
CQRS
Domain Events
SQL Server
Entity Framework Core
Migrations
JWT
RBAC
Permissions
```

## Frontend

```text id="64qzt1"
React
TypeScript
Admin
Site
```

## Qualidade

```text id="4f1h6b"
Unit Tests
Integration Tests
Build Validation
Code Review
Documentation
```

## Infraestrutura

```text id="jknw4a"
Docker
Docker Compose
Environment Configuration
```

---

# 🗄️ Persistência

O fluxo inicial obrigatório é:

```text id="xpk3la"
Domain Entities
      ↓
Infrastructure
      ↓
ApplicationDbContext
      ↓
Fluent Configurations
      ↓
InitialCreate
      ↓
Migration Script Validation
      ↓
DevelopmentSeed
      ↓
CQRS
      ↓
JWT
      ↓
APIs
```

A ordem é importante.

Não devem ser criadas APIs ou funcionalidades CQRS sobre uma modelagem de persistência ainda não validada.

---

# 🧬 Modelagem oficial

A modelagem da fundação está definida em:

```text id="gg5g98"
tasks/specs/changes/
└── 001-project-foundation/
    └── TASK_USER_PERSON_DATA_MODEL.md
```

Esse documento deve ser tratado como referência oficial para a modelagem inicial.

---

# 🔐 Autenticação e autorização

A fundação prevê:

```text id="3wxybv"
JWT
 │
 ├── Login
 ├── Access Token
 ├── Refresh Token
 ├── Forgot Password
 └── Reset Password
```

Autorização:

```text id="gln2pg"
User
  │
  ▼
Roles / Groups
  │
  ▼
Permissions
  │
  ▼
Resources / Actions
```

O modelo exato deve seguir a Spec e a modelagem oficial da fundação.

---

# ⚡ CQRS

O backend utiliza separação entre:

```text id="8ukup6"
Commands
    │
    └── Alteração de estado

Queries
    │
    └── Consulta de estado
```

Exemplo:

```text id="e7sk0c"
CreateUserCommand
UpdateUserCommand
DeleteUserCommand

GetUserByIdQuery
GetUsersQuery
SearchUsersQuery
```

---

# 📡 Domain Events

Eventos de domínio representam acontecimentos relevantes dentro do domínio.

Exemplo:

```text id="goyw31"
UserCreatedEvent
UserUpdatedEvent
UserDeletedEvent
```

Os eventos devem seguir as Rules arquiteturais definidas pelo projeto.

---

# 🐳 Docker

O arquivo:

```text id="e6b5m4"
docker-compose.yml
```

começa vazio.

A infraestrutura é gerada durante a execução da Spec.

Isso evita manter serviços que não fazem parte da necessidade real do projeto.

---

# 🌐 Topologia inicial

A fundação prevê:

```text id="yutq1g"
                    Browser
                       │
             ┌─────────┴─────────┐
             │                   │
             ▼                   ▼
      localhost:8081      localhost:8082
             │                   │
             ▼                   ▼
      frontend-admin       frontend-site
             │                   │
             ▼                   ▼
         api-admin             api-site
             │                   │
             └─────────┬─────────┘
                       │
                       ▼
                   SQL Server
```

Resumidamente:

```text id="2a7tq4"
localhost:8081
      ↓
frontend-admin
      ↓
api-admin
      ↓
sqlserver
```

e:

```text id="d9ug5n"
localhost:8082
      ↓
frontend-site
      ↓
api-site
      ↓
sqlserver
```

---

# 🐳 Geração do Docker Compose

O Docker Compose deve ser criado conforme as necessidades identificadas pela Spec.

Exemplo:

```text id="tz48tb"
Spec
  │
  ▼
Architect Agent
  │
  ▼
Define infraestrutura
  │
  ▼
Tech Lead Agent
  │
  ▼
Define tasks
  │
  ▼
Developer Agent
  │
  ▼
docker-compose.yml
```

Nenhum serviço deve ser adicionado apenas porque existe no template.

---

# 🧠 Estratégia de contexto

Uma das metas da v7 é reduzir o contexto necessário para cada operação.

Em vez de enviar:

```text id="k6uw7h"
TODO O REPOSITÓRIO
       ↓
       IA
```

o processo deve preferir:

```text id="ibnzzj"
Spec relevante
     +
Rules relevantes
     +
Skills relevantes
     +
State
     +
Arquivos necessários
       ↓
       IA
```

Isso reduz:

```text id="u2mxhf"
Tokens
Ruído
Tempo de processamento
Risco de inconsistência
```

---

# 🔄 Ciclo de execução

```text id="yhfvea"
                   ┌───────────────┐
                   │     PEDIDO    │
                   └───────┬───────┘
                           │
                           ▼
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
                      Tester Agent
                           │
                           ▼
                      TEST REPORT
                           │
                           ▼
                     Reviewer Agent
                           │
                           ▼
                     REVIEW REPORT
                           │
                           ▼
                 Documentation Agent
                           │
                           ▼
                    QUALITY GATES
                           │
                  ┌────────┴────────┐
                  │                 │
                 PASS              FAIL
                  │                 │
                  ▼                 ▼
               DELIVERY          CORREÇÃO
                                    │
                                    └──────► Pipeline
```

---

# 🛡️ Regra de conclusão

A v7 introduz uma regra importante:

```text id="bj8n0q"
CODE GENERATED != DONE
```

Gerar código é apenas uma das etapas.

Para considerar uma Spec concluída:

```text id="gk6grj"
[✓] Spec interpretada

[✓] Requirements gerado

[✓] Architecture Plan gerado

[✓] Execution Plan gerado

[✓] Tasks executadas

[✓] Build aprovado

[✓] Unit Tests aprovados

[✓] Integration Tests aprovados

[✓] Test Report gerado

[✓] Review aprovado

[✓] Review Report gerado

[✓] Documentação atualizada

[✓] State atualizado

[✓] Quality Gates aprovados
```

Somente então:

```text id="bc13u5"
SPEC = DONE
```

---

# 🤖 Independência de ferramenta

O template foi projetado para não depender conceitualmente de uma única ferramenta de IA.

A arquitetura:

```text id="dnq44f"
Specs
Rules
Skills
Agents
Workflows
Quality Gates
State
```

é baseada em arquivos versionáveis.

Portanto, a intenção é permitir utilização com diferentes ferramentas capazes de interpretar o repositório e executar suas instruções.

O comportamento esperado está documentado dentro do próprio projeto.

---

# 📦 Versionamento

Todos os componentes importantes podem ser versionados no Git:

```text id="46nrgq"
Specs
Rules
Skills
Agents
Prompts
Workflows
Quality Gates
Documentation
```

Isso permite acompanhar não apenas:

> **O que mudou no código?**

mas também:

> **Por que a IA tomou determinada decisão?**

e:

> **Quais instruções estavam vigentes quando a implementação foi realizada?**

---

# 📌 v6 vs v7

```text id="f3pqt4"
V6
────────────────────────
Specs
Rules
Skills
Implementação


V7
────────────────────────
Specs
Rules
Skills
Agents
Workflows
Quality Gates
State

Requirements
Architecture
Execution Plan
Implementation
Tests
Review
Documentation
```

A v7 não elimina o modelo anterior.

Ela adiciona uma camada de **orquestração, responsabilidade e validação** sobre ele.

---

# 🎯 Filosofia da v7

O objetivo não é criar dezenas de agentes apenas por utilizar IA.

O objetivo é separar responsabilidades importantes do processo de engenharia.

```text id="p3psgr"
Requirements → entende

Architect → decide

Tech Lead → planeja

Developer → implementa

Tester → valida

Reviewer → questiona

Documentation → documenta
```

Enquanto:

```text id="kbicm1"
Specs → dizem O QUÊ

Rules → dizem AS REGRAS

Skills → dizem COMO

Agents → dizem QUEM

Workflow → diz EM QUAL ORDEM

Quality Gates → dizem SE PODE AVANÇAR

State → diz ONDE ESTAMOS
```

---

# 🚀 Visão final

```text id="4ed5rn"
                         IA-COPILOT
                             │
                             ▼
                           SPEC
                             │
              ┌──────────────┴──────────────┐
              │                             │
            RULES                         SKILLS
              │                             │
              └──────────────┬──────────────┘
                             │
                             ▼
                          AGENTS
                             │
                             ▼
                         WORKFLOW
                             │
                             ▼
                 ┌───────────────────────┐
                 │     Requirements      │
                 │      Architect        │
                 │      Tech Lead        │
                 │      Developer        │
                 │       Tester          │
                 │      Reviewer         │
                 │    Documentation      │
                 └───────────┬───────────┘
                             │
                             ▼
                       QUALITY GATES
                             │
                             ▼
                           STATE
                             │
                             ▼
                         DELIVERY
```

---

# 📄 Licença

Defina a licença conforme as necessidades do projeto.

---

# Criar Projeto Base v7

**Specs + Rules + Skills + Agents + Workflows + Quality Gates + State**

> IA não apenas gerando código, mas participando de um processo estruturado de engenharia de software.
