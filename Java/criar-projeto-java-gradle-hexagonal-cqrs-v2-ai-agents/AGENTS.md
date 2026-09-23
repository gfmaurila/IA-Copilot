# AGENTS — Java + Gradle + Hexagonal + CQRS

Este template usa agentes especializados. Eles não substituem as `tasks/skills`; eles coordenam as Skills existentes e produzem artefatos auditáveis.

## Fluxo obrigatório

```text
Spec / solicitação
  -> Requirements Agent
  -> Architect Agent
  -> Tech Lead Agent
  -> Developer Agent
  -> Tester Agent
  -> Reviewer Agent
  -> Documentation Agent
```

Se Tester ou Reviewer reprovar, o fluxo retorna ao Developer e repete build, testes e review.

## Regra arquitetural absoluta

Dependências apontam para dentro:

```text
Adapter In -> Application -> Domain
Adapter Out -> Application/Domain
```

O Domain não depende de Spring, JPA, Hibernate, HTTP, JWT, MySQL, Docker ou adapters.
A Application depende somente do Domain e de abstrações próprias (Ports).
Adapters implementam Ports.

## Artefatos obrigatórios

Antes de implementar:
- `tasks/generated/REQUIREMENTS.md`
- `tasks/generated/ARCHITECTURE_PLAN.md`
- `tasks/generated/EXECUTION_PLAN.md`

Após implementar:
- `tasks/reports/TEST_REPORT.md`
- `tasks/reports/REVIEW_REPORT.md`

Estado: `orchestration/state/PROJECT_STATE.md`.

## Continuidade e compatibilidade multi-IA

Este arquivo é o ponto de entrada do Codex. O projeto também pode ser trabalhado por Claude Code e GitHub Copilot.

Antes de implementar, leia `PROJECT.md`, `PROJECT-STATE.md`, `AI-WORKFLOW.md`, documentação, Gradle, código e testes existentes.

O projeto já possui estrutura: não recrie o scaffold, não substitua Hexagonal/CQRS e não avance além da task solicitada. Preserve contratos, ports, adapters, domínio, testes, migrations e configurações existentes.
