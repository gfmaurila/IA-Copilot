# Workflow - Project Creation

1. Requirements Agent cria `REQUIREMENTS.md`.
2. Executar GATE-01.
3. Architect Agent cria `ARCHITECTURE_PLAN.md`.
4. Executar GATE-02.
5. Tech Lead Agent cria `EXECUTION_PLAN.md`.
6. Developer Agent executa tasks em ordem.
7. Validar migrations/persistência com GATE-03.
8. Executar GATE-04 e GATE-05.
9. Tester Agent cria `TEST_REPORT.md`.
10. Executar GATE-06.
11. Reviewer Agent cria `REVIEW_REPORT.md`.
12. Executar GATE-07.
13. Documentation Agent atualiza documentação.
14. Executar GATE-08.
15. Marcar `PROJECT_STATE.md` como DONE.

## Loop de correção

```text
Tester/Reviewer FAIL
        ↓
Developer corrige
        ↓
valida novamente
        ↓
Tester/Reviewer
```

Nunca encerrar com gate obrigatório falhando.
