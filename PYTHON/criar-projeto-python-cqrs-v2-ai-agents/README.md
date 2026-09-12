# Python + FastAPI + CQRS + MySQL + AI Agents

Template base para criação/refatoração de projetos usando IA com planejamento, implementação, testes e revisão controlados por gates.

## Stack

- Python 3.12+
- FastAPI
- Pydantic v2
- SQLAlchemy 2
- Alembic
- MySQL
- CQRS
- Domain Events
- JWT
- React Admin
- React Site
- pytest
- Ruff / mypy ou pyright
- Docker

## Fluxo de agentes

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

## Planejamento obrigatório

Antes do código:

```text
tasks/generated/
├── REQUIREMENTS.md
├── ARCHITECTURE_PLAN.md
└── EXECUTION_PLAN.md
```

Após implementação:

```text
tasks/reports/
├── TEST_REPORT.md
└── REVIEW_REPORT.md
```

## Princípios

- Command altera estado.
- Query somente lê.
- Handler orquestra caso de uso.
- Router FastAPI não contém regra de negócio.
- Domain concentra regras.
- Infrastructure concentra banco, repositories e integrações.
- Pydantic valida contratos.
- SQLAlchemy 2 implementa persistência.
- Alembic controla schema.
- Python deve permanecer idiomático e tipado.

## Quality Gates

1. Requirements
2. Architecture
3. Persistence
4. Python Quality
5. Tests
6. Security
7. Architecture Review
8. Documentation

Consulte `AGENTS.md` e `orchestration/gates/QUALITY_GATES.md`.
