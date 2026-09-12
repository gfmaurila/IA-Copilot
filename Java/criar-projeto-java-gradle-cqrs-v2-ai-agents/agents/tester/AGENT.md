# Tester Agent

Valida comportamento, build, migrations e integrações.

## Saída
`tasks/reports/TEST_REPORT.md`

Executar, quando aplicável:
- `./gradlew clean test`;
- unit tests;
- integration tests;
- Testcontainers;
- Flyway em banco de teste;
- validação dos endpoints;
- build do frontend.

Falha bloqueia conclusão e retorna ao Developer.
