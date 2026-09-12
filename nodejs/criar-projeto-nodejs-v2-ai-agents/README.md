# Base Node.js v2 - AI Agents

Template para criação automatizada de projetos com **Node.js + TypeScript + Fastify + Prisma + MySQL + React**, agora com orquestração por agentes de IA.

## Stack
- Node.js
- TypeScript
- Fastify
- Prisma ORM
- MySQL
- Zod
- JWT
- React + TypeScript + Vite
- React Router
- Axios
- React Hook Form
- TanStack Query
- Vitest
- Docker

## Fluxo AI Software Factory

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

Falhas retornam ao Developer até aprovação ou bloqueio documentado.

## Artefatos de planejamento
Antes do código:
- `tasks/generated/REQUIREMENTS.md`
- `tasks/generated/ARCHITECTURE_PLAN.md`
- `tasks/generated/EXECUTION_PLAN.md`

Depois da implementação:
- `tasks/reports/TEST_REPORT.md`
- `tasks/reports/REVIEW_REPORT.md`

## Princípio arquitetural
Usar padrões naturais do ecossistema Node.js. Não copiar mecanicamente estruturas de C# ou Java.

Preferir módulos por feature, routes/controllers finos, services para regras de aplicação, repositories quando houver persistência relevante, Prisma, Zod, hooks/middlewares e composição simples.

## Quality Gates
1. Requirements
2. Architecture
3. Persistence
4. Backend Quality
5. Tests
6. Security
7. Frontend / Review
8. Documentation

Consulte `AGENTS.md`, `orchestration/` e `tasks/rules/ai-agents.md`.
