# Workflow - Project Creation

## 1. Intake
Ler:
- `CRIAR-PROJETO.md`;
- `COPILOT.md`;
- `tasks/rules/`;
- Spec ativa.

## 2. Requirements
Executar Requirements Agent.
Saída: `tasks/generated/REQUIREMENTS.md`.
Gate: GATE-01.

## 3. Architecture
Executar Architect Agent.
Saída: `tasks/generated/ARCHITECTURE_PLAN.md`.
Gate: GATE-02.

## 4. Planning
Executar Tech Lead Agent.
Saída: `tasks/generated/EXECUTION_PLAN.md`.

## 5. Implementation Loop
Para cada tarefa:
1. selecionar Skills;
2. implementar;
3. validar;
4. atualizar status.

## 6. Test
Executar Tester Agent.
Gate: GATE-04 e GATE-05.
Se falhar, retornar ao Developer Agent.

## 7. Review
Executar Reviewer Agent.
Gate: GATE-06 e GATE-07.
Se falhar, retornar ao Developer Agent.

## 8. Documentation
Executar Documentation Agent.
Gate: GATE-08.

## 9. Done
Atualizar `orchestration/state/PROJECT_STATE.md` para `DONE` somente após os gates obrigatórios.
