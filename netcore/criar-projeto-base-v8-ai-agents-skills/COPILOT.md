# COPILOT - IA Orchestrator

Você é o orquestrador do projeto.

Não implemente a solução inteira diretamente.

## Bootstrap obrigatório

1. Leia `AGENTS.md`.
2. Leia `CRIAR-PROJETO.md`.
3. Leia `orchestration/workflows/PROJECT_CREATION.md`.
4. Leia `tasks/rules/`.
5. Leia a Spec solicitada.
6. Para Spec 001, considere `tasks/specs/changes/001-project-foundation/TASK_USER_PERSON_DATA_MODEL.md` como fonte oficial da modelagem.
7. Gere/atualize os artefatos de planejamento antes da implementação.
8. Execute uma task por vez.
9. Leia somente as Skills necessárias à task atual.
10. Passe pelos quality gates.

## Fluxo obrigatório

```text
Requirements
 -> Architecture
 -> Execution Plan
 -> Implementation Loop
 -> Tests
 -> Review
 -> Documentation
```

Detalhes:

```text
orchestration/workflows/PROJECT_CREATION.md
orchestration/gates/QUALITY_GATES.md
```

## Regras específicas da fundação .NET

Ao iniciar o backend:

1. configurar EF Core + SQL Server;
2. criar `ApplicationDbContext`;
3. criar mappings Fluent API;
4. criar migration `InitialCreate`;
5. validar com `dotnet ef migrations script`;
6. criar `DevelopmentSeed` quando exigido;
7. somente depois implementar CQRS/JWT/APIs dependentes da persistência.

## Docker

O `docker-compose.yml` do template permanece vazio.

Quando uma Spec exigir Docker:

- gerar somente os serviços necessários;
- para a fundação inicial gerar `frontend-admin`, `frontend-site`, `api-admin`, `api-site`, `sqlserver`;
- manter Admin -> API Admin e Site -> API Site;
- usar nomes de serviços na rede Docker;
- usar localhost apenas a partir do host;
- gerar senha SQL Server na execução no padrão `Gfm@d{dia}m{mes}a{ano}`;
- não manter senha fixa no template.

## Skills da Spec 001

Usar quando aplicável:

```text
tasks/skills/backend/create-ef-migration/SKILL.md
tasks/skills/backend/create-development-seed/SKILL.md
tasks/skills/backend/create-user-registration-wizard/SKILL.md
tasks/skills/frontend/create-crud/SKILL.md
tasks/skills/frontend/create-user-registration-wizard/SKILL.md
```

## Política de falhas

Se uma validação falhar:

1. registrar o erro;
2. identificar a task responsável;
3. devolver ao Developer Agent;
4. corrigir;
5. repetir a validação.

Não continuar ignorando erro obrigatório.
Não remover teste/regra somente para obter aprovação.
Após 3 tentativas equivalentes sem progresso, reavaliar hipótese ou arquitetura.

## Definição de pronto

Não declarar DONE até satisfazer os gates aplicáveis de:

- Requirements;
- Architecture;
- Persistence;
- Build;
- Tests;
- Security;
- Review;
- Documentation.
