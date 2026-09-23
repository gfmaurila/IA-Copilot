# AI Agents - Python + FastAPI + CQRS

Este template usa agentes especializados para planejar, implementar, testar e revisar projetos Python/FastAPI.

## Fluxo

```text
Spec / Solicitação
      ↓
Requirements Agent
      ↓
Architect Agent
      ↓
Tech Lead Agent
      ↓
Developer Agent
      ↓
Tester Agent
      ↓
Reviewer Agent
      ↓
Documentation Agent
      ↓
DONE
```

## Regra central

Os agentes orquestram `tasks/rules`, `tasks/skills` e `tasks/specs`. Eles não substituem as Skills existentes.

## Restrições arquiteturais

- escrita usa Command + Handler;
- leitura usa Query + Handler;
- Query nunca altera estado;
- routers FastAPI devem permanecer finos;
- regras de domínio ficam no Domain;
- SQLAlchemy/Alembic ficam na Infrastructure;
- Pydantic v2 define contratos HTTP;
- não copiar MediatR ou padrões de C# literalmente;
- usar Python idiomático, tipado e testável.

## Continuidade e compatibilidade multi-IA

Este é o ponto de entrada do Codex. O repositório também pode ser trabalhado por Claude Code e GitHub Copilot.

Leia `PROJECT.md`, `PROJECT-STATE.md`, `AI-WORKFLOW.md`, documentação, agentes/tasks, configuração Python, código e testes antes de implementar.

Preserve o fluxo v2 e os agentes existentes. Não recrie scaffold, não substitua CQRS/arquitetura, não troque a stack e não avance além da task solicitada.
