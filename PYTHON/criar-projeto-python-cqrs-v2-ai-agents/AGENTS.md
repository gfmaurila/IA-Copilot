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
