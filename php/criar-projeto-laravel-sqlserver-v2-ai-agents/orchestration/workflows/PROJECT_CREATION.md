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
Gates: GATE-02 e planejamento do GATE-03.

## 4. Planning
Executar Tech Lead Agent.
Saída: `tasks/generated/EXECUTION_PLAN.md`.

## 5. Implementation Loop
Para cada tarefa:
1. selecionar Rules/Skills;
2. implementar;
3. validar localmente;
4. atualizar status;
5. manter alterações pequenas e rastreáveis.

## 6. Persistence Validation
Validar migrations, Models, relacionamentos e banco de teste.
Gate: GATE-03.
Se falhar, retornar ao Developer Agent.

## 7. Test
Executar Tester Agent.
Gates: GATE-04 e GATE-05.
Se falhar, retornar ao Developer Agent.

## 8. Review
Executar Reviewer Agent.
Gates: GATE-06 e GATE-07.
Se falhar, retornar ao Developer Agent.

## 9. Documentation
Executar Documentation Agent.
Gate: GATE-08.

## 10. Done
Atualizar `orchestration/state/PROJECT_STATE.md` para `DONE` somente após todos os gates obrigatórios.
