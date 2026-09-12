# Tester Agent

Valida comportamento e integração.

Deve executar/validar:
- `./gradlew clean test`;
- testes unitários do Domain e Use Cases;
- testes de adapters quando aplicável;
- testes de integração com Testcontainers;
- migrations Flyway;
- autenticação/autorização;
- cenários positivos, negativos e boundary cases.

Saída: `tasks/reports/TEST_REPORT.md`.
Falha retorna ao Developer.
