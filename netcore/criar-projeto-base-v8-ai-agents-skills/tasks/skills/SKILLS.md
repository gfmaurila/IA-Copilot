# Skills Registry — IA Copilot

Catálogo de procedimentos reutilizáveis carregados sob demanda pelos agentes.

## Regra principal

Skills não são agentes e não definem escopo. A Spec/Requisitos define **o que** fazer; Rules definem **o que respeitar**; Agents definem **quem decide**; Skills definem **como executar**.

## Seleção

1. Ler a task atual.
2. Selecionar somente as skills explicitamente necessárias.
3. Não carregar uma categoria inteira por padrão.
4. Em conflito: Spec/Requisitos > Rules > Architecture Plan > Skill.
5. Se uma skill não se aplicar à stack atual, ignorá-la.

## Catálogo adicional v8

| Skill | Uso principal | Agentes |
|---|---|---|
| architecture/vertical-slices | organizar feature por caso de uso | Architect, Developer, Reviewer |
| architecture/cqrs | separar Commands e Queries | Architect, Developer, Reviewer |
| architecture/domain-events | eventos de domínio | Architect, Developer, Reviewer |
| architecture/clean-architecture | dependências e limites | Architect, Reviewer |
| backend/minimal-api | endpoints Minimal API | Developer |
| backend/validation | validação de entrada/use case | Developer, Tester |
| database/sqlserver | decisões SQL Server | Architect, Developer |
| database/oracle | decisões Oracle | Architect, Developer |
| database/mysql | decisões MySQL | Architect, Developer |
| database/dapper | acesso a dados com Dapper | Developer |
| database/ef-core | persistência com EF Core | Developer |
| infrastructure/docker | Docker/Compose | Developer, Tester |
| infrastructure/redis | cache/estado efêmero | Architect, Developer |
| infrastructure/rabbitmq | mensageria RabbitMQ | Architect, Developer |
| infrastructure/kafka | eventos Kafka | Architect, Developer |
| quality/code-review | revisão estruturada | Reviewer |
| quality/unit-testing | testes unitários | Developer, Tester |
| quality/integration-testing | testes de integração | Developer, Tester |
| security/secure-coding | checklist de segurança | Architect, Developer, Reviewer |
| documentation/project-docs | documentação final | Documentation |

As skills legadas em `backend/create-*` e `frontend/create-*` continuam válidas.
