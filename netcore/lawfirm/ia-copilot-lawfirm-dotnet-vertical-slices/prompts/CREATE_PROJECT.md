# Prompt — Create Project

Crie o projeto seguindo obrigatoriamente o workflow de agentes deste repositório.

## Ordem

1. Leia `CRIAR-PROJETO.md`.
2. Leia `AGENTS.md`.
3. Leia todas as Rules.
4. Leia a Spec ativa.
5. Gere `REQUIREMENTS.md` a partir do template.
6. Gere `ARCHITECTURE_PLAN.md`.
7. Gere `EXECUTION_PLAN.md`.
8. Execute as tasks uma por vez.
9. Leia somente as Skills necessárias para cada task.
10. Valide cada task.
11. Execute build, migrations e testes.
12. Gere TEST_REPORT e REVIEW_REPORT.
13. Corrija falhas até os gates obrigatórios passarem.
14. Atualize documentação e PROJECT_STATE.

## Regras invioláveis

- Vertical Slice Architecture.
- Minimal APIs.
- CQRS.
- Domain isolado.
- Não criar Controllers MVC.
- Não criar Application horizontal para handlers.
- Não criar abstrações genéricas sem uso real.
