# Criar Projeto Base v7 - AI Agents

Template para geração e evolução automatizada de projetos Full Stack usando IA com **Specs + Rules + Skills + Agents + Quality Gates**.

## O que mudou em relação ao v6

A v6 já organizava o conhecimento em:

```text
Spec -> Rules -> Skills -> Implementação
```

A v7 adiciona uma camada de engenharia/orquestração:

```text
Pedido
 -> Requirements Agent
 -> Architect Agent
 -> Tech Lead Agent
 -> Developer Agent
 -> Tester Agent
 -> Reviewer Agent
 -> Documentation Agent
```

A IA passa a gerar artefatos intermediários e validar a solução antes de declarar conclusão.

## Estrutura principal

```text
.
├── AGENTS.md
├── COPILOT.md
├── CRIAR-PROJETO.md
├── agents/
│   ├── requirements/
│   ├── architect/
│   ├── tech-lead/
│   ├── developer/
│   ├── tester/
│   ├── reviewer/
│   └── documentation/
├── orchestration/
│   ├── workflows/
│   ├── gates/
│   └── state/
├── prompts/
├── tasks/
│   ├── rules/
│   ├── skills/
│   ├── specs/
│   ├── generated/
│   └── reports/
├── docs/
├── .env.example
└── docker-compose.yml
```

## Conceito

### Specs

Dizem **o que deve ser entregue**.

### Rules

Definem **restrições permanentes do projeto**.

### Skills

Definem **como executar operações repetíveis**.

### Agents

Definem **quem é responsável por cada tipo de decisão**.

### Workflow

Define **a ordem do processo**.

### Quality Gates

Definem **quando a IA pode avançar ou concluir**.

### State

Mantém um resumo pequeno do progresso para evitar reler todo o repositório.

## Fluxo recomendado

Para criar a fundação:

```text
Leia COPILOT.md e execute a Spec:
tasks/specs/changes/001-project-foundation.md
```

O orquestrador deverá produzir:

```text
tasks/generated/REQUIREMENTS.md
tasks/generated/ARCHITECTURE_PLAN.md
tasks/generated/EXECUTION_PLAN.md
```

Depois executar as tasks e gerar:

```text
tasks/reports/TEST_REPORT.md
tasks/reports/REVIEW_REPORT.md
```

## Primeira entrega do template

Mantém a fundação prevista na versão anterior:

- .NET / ASP.NET Core;
- DDD;
- CQRS;
- Domain Events;
- SQL Server;
- Entity Framework Core;
- migrations;
- JWT;
- RBAC/Permissions;
- React + TypeScript;
- testes unitários;
- testes de integração;
- Docker gerado conforme a Spec.

## Persistência

Fluxo obrigatório inicial:

```text
Domain entities
 -> Infrastructure
 -> ApplicationDbContext
 -> Fluent configurations
 -> InitialCreate
 -> migration script validation
 -> DevelopmentSeed
 -> CQRS / JWT / APIs
```

A modelagem oficial da fundação está em:

```text
tasks/specs/changes/001-project-foundation/TASK_USER_PERSON_DATA_MODEL.md
```

## Docker

`docker-compose.yml` começa vazio e é gerado durante a execução da Spec.

Topologia inicial esperada:

```text
Browser
├── localhost:8081 -> frontend-admin -> api-admin -> sqlserver
└── localhost:8082 -> frontend-site  -> api-site  -> sqlserver
```

## Objetivo da v7

Fazer com que a IA opere mais como uma pequena equipe de engenharia do que como um único gerador de código, mantendo o template simples, versionável em Git e independente de uma ferramenta específica de IA.
