# AGENTS — Java + Gradle + Spring Boot + CQRS

Este template usa agentes especializados para planejar, implementar, validar e documentar projetos.

## Fluxo obrigatório

Requirements -> Architect -> Tech Lead -> Developer -> Tester -> Reviewer -> Documentation

Nenhum agente deve pular os Quality Gates definidos em `orchestration/gates/QUALITY_GATES.md`.

## Princípios
- preservar convenções Java/Spring;
- CQRS sem copiar MediatR do .NET;
- Spring DI resolve handlers;
- Commands alteram estado; Queries não alteram estado;
- Controllers finos;
- Domain Events apenas para efeitos colaterais desacoplados;
- Gradle Wrapper + Kotlin DSL obrigatórios;
- migrations versionadas com Flyway;
- testes de integração com banco real via Testcontainers;
- nenhuma tarefa é concluída com build/testes quebrados.
