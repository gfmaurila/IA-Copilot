# Quality Gates

## GATE-01 — Requirements
- requisitos e critérios de aceite claros;
- Commands e Queries identificados;
- requisitos de segurança/persistência documentados.

## GATE-02 — Hexagonal Architecture
- Domain independente de frameworks;
- Application depende apenas do Domain;
- Input/Output Ports definidos;
- Adapters mapeados para Ports;
- direção das dependências apontando para dentro.

## GATE-03 — Persistence
- Flyway consistente;
- JPA restrito ao adapter de persistência;
- entidade JPA não é entidade de domínio;
- mappers Domain <-> Persistence explícitos;
- índices, constraints e transações revisados.

## GATE-04 — Build
- Gradle Wrapper usado;
- `./gradlew clean build` aprovado;
- sem dependências SNAPSHOT/RC/Milestone por padrão.

## GATE-05 — Tests
- unit tests aprovados;
- integration tests aprovados;
- Testcontainers quando integração real for necessária;
- casos negativos e autorização cobertos.

## GATE-06 — Security
- Spring Security/JWT revisado;
- secrets fora do código;
- autorização aplicada no boundary correto;
- inputs validados;
- sem exposição indevida de dados internos.

## GATE-07 — Architecture Review
- nenhuma dependência proibida no Domain;
- Application não conhece adapters;
- CQRS preservado;
- sem repository JPA sendo usado diretamente por web adapter;
- sem regras de domínio em Controller/adapter.

## GATE-08 — Documentation
- README coerente com implementação;
- execução, testes, Docker, migrations e endpoints documentados;
- TEST_REPORT e REVIEW_REPORT aprovados.
