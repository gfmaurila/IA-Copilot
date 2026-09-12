# Java + Gradle + Hexagonal + CQRS + MySQL

Template com:

- Java 25 LTS
- Spring Boot 4.1.1
- Gradle 9.7.1
- Kotlin DSL
- Arquitetura Hexagonal
- Ports & Adapters
- CQRS
- Domain Events
- Spring Security
- JWT
- Spring Data JPA
- MySQL
- Flyway
- JUnit 5
- Mockito
- AssertJ
- Testcontainers
- React Admin
- React Site
- Rules + Skills + Specs + Copilot

O template deve revalidar versões estáveis antes da implementação.

---

## AI Agents — v2

Esta versão adiciona desenvolvimento orientado por agentes sem alterar a arquitetura Hexagonal original.

Fluxo: `Requirements -> Architect -> Tech Lead -> Developer -> Tester -> Reviewer -> Documentation`.

Antes do código, são gerados `REQUIREMENTS.md`, `ARCHITECTURE_PLAN.md` e `EXECUTION_PLAN.md`. A conclusão exige os Quality Gates em `orchestration/gates/QUALITY_GATES.md`.

Regra bloqueante: Domain não depende de Spring/JPA/infra; Application não depende de adapters; adapters implementam Ports.
