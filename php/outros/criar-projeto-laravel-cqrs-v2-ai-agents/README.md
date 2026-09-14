# Laravel + CQRS + AI Agents

Template para criação automatizada de projetos Full Stack com Laravel, CQRS e fluxo de desenvolvimento orientado por agentes de IA.

## Stack base

- PHP / Laravel
- MySQL
- CQRS
- Commands / Queries / Handlers
- Domain Events
- Eloquent
- Form Requests
- API Resources
- Sanctum
- Policies / Gates
- React Admin
- React Site
- Unit Tests
- Feature/Integration Tests
- Docker
- Rules + Skills + Specs
- AI Agents + Quality Gates

## Fluxo de IA

```text
Solicitação / Spec
        ↓
Requirements Agent
        ↓
Architect Agent
        ↓
Tech Lead Agent
        ↓
Developer Agent
        ↓
Tester Agent
        ↓
Reviewer Agent
        ↓
Documentation Agent
        ↓
DONE
```

## Artefatos de planejamento

Antes da implementação, o fluxo gera:

```text
tasks/generated/REQUIREMENTS.md
tasks/generated/ARCHITECTURE_PLAN.md
tasks/generated/EXECUTION_PLAN.md
```

Depois da implementação:

```text
tasks/reports/TEST_REPORT.md
tasks/reports/REVIEW_REPORT.md
```

## Estrutura adicionada

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
tasks/generated/
tasks/reports/
```

## Princípio arquitetural

```text
Write Side = Commands
Read Side  = Queries
```

Laravel continua sendo usado de forma idiomática. A camada de agentes não substitui Rules e Skills: ela as orquestra.

## Início

Leia nesta ordem:

1. `AGENTS.md`
2. `CRIAR-PROJETO.md`
3. `COPILOT.md`
4. `orchestration/workflows/PROJECT_CREATION.md`
5. `tasks/rules/`
6. Spec ativa

Depois, siga os Quality Gates de `orchestration/gates/QUALITY_GATES.md`.
