# COPILOT — AI Agents

Antes de implementar:

1. Leia `AGENTS.md`.
2. Leia `CRIAR-PROJETO.md`.
3. Leia todas as Rules.
4. Leia a Spec solicitada.
5. Leia somente as Skills necessárias.
6. Leia `orchestration/workflows/PROJECT_CREATION.md`.
7. Gere `tasks/generated/REQUIREMENTS.md`.
8. Gere `tasks/generated/ARCHITECTURE_PLAN.md`.
9. Gere `tasks/generated/EXECUTION_PLAN.md`.
10. Implemente task por task.
11. Execute migrations, `./gradlew clean test`, integration tests e build React quando aplicável.
12. Gere TEST_REPORT e REVIEW_REPORT.
13. Corrija erros antes de concluir.
14. Atualize documentação e `PROJECT_STATE.md`.

## Regras essenciais
- Java + Spring Boot + Gradle + CQRS.
- Gradle Wrapper e Kotlin DSL.
- Spring DI resolve handlers.
- Não criar Mediator customizado sem necessidade.
- Não copiar padrões .NET literalmente.
- Query nunca altera estado.
- Controllers permanecem finos.
- Não usar snapshots/RC/milestones por padrão.
- Nenhum Quality Gate bloqueado pode ser ignorado.
