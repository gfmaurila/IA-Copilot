# COPILOT — Orquestração por Agentes

## Entrada obrigatória

1. Leia `CRIAR-PROJETO.md`.
2. Leia `AGENTS.md`.
3. Leia `orchestration/workflows/PROJECT_CREATION.md`.
4. Leia todas as Rules.
5. Leia a Spec ativa.

## Antes de programar

Gerar, nesta ordem:

1. `tasks/generated/REQUIREMENTS.md`
2. `tasks/generated/ARCHITECTURE_PLAN.md`
3. `tasks/generated/EXECUTION_PLAN.md`

Use os `.template.md` correspondentes como base.

## Implementação

- Trabalhe uma task por vez.
- Leia somente Skills necessárias à task.
- Implemente por Vertical Slice.
- Use Minimal APIs.
- Use CQRS.
- Preserve o Domain isolado.
- Não criar Controllers MVC.
- Não mover Handlers para pasta global.
- Não criar Services genéricos sem responsabilidade real.

## Validação

Após implementação:

1. migrations;
2. build backend;
3. testes unitários;
4. testes de integração;
5. build dos frontends;
6. validação Docker quando aplicável;
7. `TEST_REPORT.md`;
8. `REVIEW_REPORT.md`.

Leia `orchestration/gates/QUALITY_GATES.md` para critérios de aprovação.

Se qualquer gate obrigatório falhar, corrija e valide novamente.

A Spec somente pode ser arquivada após aprovação dos gates e atualização de `PROJECT_STATE.md`.
