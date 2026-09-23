# AGENTS - Node.js AI Software Factory

Este template usa agentes especializados para transformar uma solicitação em uma entrega validada.

## Fluxo oficial

`Requirements -> Architect -> Tech Lead -> Developer -> Tester -> Reviewer -> Documentation`

## Regra central

Os agentes orquestram as Rules, Skills e Specs existentes. Eles não substituem as convenções do stack.

Stack padrão:
- Node.js + TypeScript
- Fastify
- Prisma + MySQL
- Zod
- JWT
- React + TypeScript + Vite
- Vitest

## Agentes

### Requirements Agent
Converte a solicitação em requisitos funcionais, não funcionais, critérios de aceite, restrições e dúvidas assumidas.
Saída: `tasks/generated/REQUIREMENTS.md`.

### Architect Agent
Define módulos/features, contratos, persistência, autenticação/autorização, integrações e decisões arquiteturais sem importar padrões de C#/Java.
Saída: `tasks/generated/ARCHITECTURE_PLAN.md`.

### Tech Lead Agent
Quebra o plano em tarefas pequenas, ordenadas, verificáveis e associadas às Skills necessárias.
Saída: `tasks/generated/EXECUTION_PLAN.md`.

### Developer Agent
Implementa uma tarefa por vez, seguindo Rules + Skills + Spec. Deve manter TypeScript forte, Fastify idiomático e Prisma como persistência padrão.

### Tester Agent
Executa lint/typecheck quando existente, migrations, testes unitários, integração, build backend e frontend. Registra evidências.
Saída: `tasks/reports/TEST_REPORT.md`.

### Reviewer Agent
Revisa segurança, arquitetura, qualidade, tipagem, erros, banco, HTTP, frontend e aderência ao plano. Se reprovar, devolve ao Developer.
Saída: `tasks/reports/REVIEW_REPORT.md`.

### Documentation Agent
Atualiza README/docs, variáveis de ambiente, comandos, endpoints, migrations e decisões relevantes somente após os gates técnicos aprovarem.

## Ciclo de correção

`Developer -> Tester/Reviewer -> falha -> Developer -> nova validação`

Nenhuma tarefa deve ser marcada como DONE com build/testes/review pendentes.

## Continuidade e compatibilidade multi-IA

Este arquivo é o ponto de entrada do Codex. O repositório também pode ser trabalhado por Claude Code e GitHub Copilot.

Antes de implementar, leia `PROJECT.md`, `PROJECT-STATE.md`, `AI-WORKFLOW.md`, documentação, agentes/tasks, `package.json`, código e testes existentes.

Preserve o fluxo v2 e os agentes já existentes. Não recrie scaffold, não troque a stack e não avance além da task solicitada.
