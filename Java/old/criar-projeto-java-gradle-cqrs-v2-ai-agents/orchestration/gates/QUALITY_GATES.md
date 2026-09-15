# Quality Gates

## GATE-01 — Requirements
- escopo e critérios de aceite claros;
- Commands e Queries identificados;
- segurança/persistência/integracões mapeadas.

## GATE-02 — Architecture
- arquitetura coerente com Spring Boot + CQRS;
- sem mediator artificial;
- dependências entre camadas corretas;
- estratégia de eventos, transações e erros definida.

## GATE-03 — Persistence
- entidades/mapeamentos JPA válidos;
- migrations Flyway versionadas;
- índices/constraints considerados;
- banco de teste isolado;
- risco de N+1 avaliado.

## GATE-04 — Build
- Gradle Wrapper funciona;
- `./gradlew clean test` passa;
- nenhum snapshot/RC por padrão;
- dependências compatíveis.

## GATE-05 — Tests
- unit tests relevantes;
- integration tests relevantes;
- Testcontainers quando houver persistência;
- migrations aplicam do zero no ambiente de teste.

## GATE-06 — Security
- Spring Security/JWT corretos;
- PasswordEncoder seguro;
- autorização por authorities/policies do projeto;
- sem secrets versionados;
- validação de entrada e erros seguros.

## GATE-07 — Architecture Review
- Commands alteram estado;
- Queries não alteram estado;
- Controllers finos;
- handlers focados;
- eventos não escondem fluxo principal;
- sem dependências indevidas.

## GATE-08 — Documentation
- README atualizado;
- execução, testes, migrations e variáveis documentados;
- decisões arquiteturais importantes registradas.
