# Base Laravel + MySQL - AI Agents

Template para criação e evolução automatizada de projetos Laravel + React + MySQL usando Rules, Skills, Specs e agentes especializados.

## Stack base

- Laravel API
- MySQL
- React Admin
- React Site
- Laravel Sanctum quando aplicável
- Groups/Permissions
- Policies/Gates
- Eloquent
- Migrations / Seeders / Factories
- Unit Tests
- Feature Tests
- Docker gerado durante a Spec

## Fluxo de IA

```text
Spec / Solicitação
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

Antes do código, o fluxo gera:

```text
tasks/generated/REQUIREMENTS.md
tasks/generated/ARCHITECTURE_PLAN.md
tasks/generated/EXECUTION_PLAN.md
```

Depois da implementação, gera evidências em:

```text
tasks/reports/TEST_REPORT.md
tasks/reports/REVIEW_REPORT.md
```

## Quality Gates

1. Requirements
2. Architecture
3. MySQL / Persistence
4. Backend Validation
5. Frontend Validation
6. Security
7. Laravel Review
8. Documentation

## Princípio arquitetural

O template continua sendo **Laravel nativo primeiro**.

Não introduzir automaticamente:

- Repository Pattern
- CQRS
- DDD formal
- camadas artificiais inspiradas em outras stacks

Preferir:

- Eloquent Models
- Controllers finos
- Form Requests
- API Resources
- Policies / Gates
- Actions / Services somente quando necessários
- Events / Listeners
- Jobs / Queues
- Migrations
- Seeders
- Factories

## Arquivos principais

- `CRIAR-PROJETO.md`
- `COPILOT.md`
- `AGENTS.md`
- `agents/`
- `orchestration/`
- `prompts/`
- `tasks/rules/`
- `tasks/skills/`
- `tasks/specs/`
- `tasks/generated/`
- `tasks/reports/`

## Entrada recomendada

Use `prompts/CREATE_PROJECT.md` para criação/evolução e `prompts/REFACTOR_PROJECT.md` para refatorações controladas.
