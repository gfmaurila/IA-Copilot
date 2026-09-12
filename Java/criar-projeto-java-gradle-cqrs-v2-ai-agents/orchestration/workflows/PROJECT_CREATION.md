# Workflow — Project Creation

1. Requirements Agent lê Spec e Rules e gera `REQUIREMENTS.md`.
2. Gate 01 valida requisitos.
3. Architect Agent gera `ARCHITECTURE_PLAN.md`.
4. Gate 02 valida arquitetura.
5. Tech Lead gera `EXECUTION_PLAN.md`.
6. Developer executa tasks em ordem.
7. Gates 03–06 validam persistência, build, testes e segurança.
8. Tester gera `TEST_REPORT.md`.
9. Reviewer gera `REVIEW_REPORT.md`.
10. Se houver bloqueio, retornar ao Developer e repetir validações afetadas.
11. Gate 07 aprova revisão.
12. Documentation Agent atualiza documentação.
13. Gate 08 encerra a entrega.

## Estado
Atualizar `orchestration/state/PROJECT_STATE.md` a cada transição relevante.
