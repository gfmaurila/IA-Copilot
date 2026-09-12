# COPILOT

Antes de executar qualquer Spec:

1. Leia `CRIAR-PROJETO.md`.
2. Leia `tasks/rules`.
3. Leia a Spec.
4. Leia somente Skills necessárias.
5. Verifique versões estáveis atuais.
6. Implemente Arquitetura Hexagonal + CQRS.
7. Garanta que dependências apontem para dentro.
8. Garanta que Domain não dependa de Spring/JPA.
9. Execute Flyway.
10. Execute `./gradlew clean test`.
11. Execute testes de integração.
12. Execute build dos frontends.
13. Corrija erros antes de concluir.
14. Arquive a Spec somente depois de tudo validado.

Baseline:

- Java 25 LTS
- Spring Boot 4.1.1
- Gradle 9.7.1

Não usar SNAPSHOT, M1/M2, RC ou versões preview por padrão.

---

# AI Agent Orchestration

Use `AGENTS.md` como contrato principal de orquestração.
Não comece codificando: produza Requirements, Architecture Plan e Execution Plan.
Na revisão, trate como erro bloqueante qualquer dependência de Domain para Spring/JPA/infra ou Application para adapters.
