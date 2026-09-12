# .NET Vertical Slices + AI Agents

Template para criação automatizada de projetos Full Stack usando IA com fluxo de agentes especializados.

## Stack arquitetural

- ASP.NET Core
- Minimal APIs
- Vertical Slice Architecture
- CQRS
- Domain Events
- Domain Model
- EF Core + Migrations
- FluentValidation
- JWT + Refresh Token
- Policies/Permissions
- React Admin
- React Site
- Unit Tests
- Integration Tests
- Docker
- Rules + Skills + Specs
- AI Agents + Quality Gates

## Fluxo de IA

```text
Pedido / Spec
     ↓
Requirements Agent
     ↓
Architecture Agent
     ↓
Tech Lead Agent
     ↓
Execution Plan
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

Falhas de testes/review retornam ao Developer até os gates obrigatórios passarem.

## Estrutura de automação

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

## Artefatos produzidos antes do código

A IA deve gerar:

```text
tasks/generated/REQUIREMENTS.md
tasks/generated/ARCHITECTURE_PLAN.md
tasks/generated/EXECUTION_PLAN.md
```

Isso reduz implementação prematura e deixa as decisões verificáveis.

## Quality Gates

- GATE-01 Requirements
- GATE-02 Architecture
- GATE-03 Persistence
- GATE-04 Build
- GATE-05 Tests
- GATE-06 Security
- GATE-07 Architecture Review
- GATE-08 Documentation

## Regra central de Vertical Slice

Uma funcionalidade deve manter seus componentes próximos:

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

Evitar estrutura horizontal global de `Controllers/Services/Handlers/Validators`.

## Como iniciar

Para uma IA compatível com as instruções do repositório:

```text
Leia COPILOT.md e execute a Spec ativa seguindo o workflow de agentes.
```

Ou use o conteúdo de:

```text
prompts/CREATE_PROJECT.md
```

## Spec inicial

`tasks/specs/changes/001-project-foundation.md`
