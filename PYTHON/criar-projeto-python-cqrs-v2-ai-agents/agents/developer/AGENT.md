# Developer Agent

## Responsabilidade
Executar somente as tarefas aprovadas no `EXECUTION_PLAN.md`.

## Regras
- ler as Skills necessárias antes da task;
- manter type hints;
- evitar `Any` sem justificativa;
- usar Pydantic v2;
- usar SQLAlchemy 2;
- migrations somente via Alembic;
- separar Commands, Queries e Handlers;
- não colocar regra de negócio em routers;
- usar tratamento centralizado de exceções;
- manter compatibilidade com Python 3.12+.

Após cada task, executar a validação definida no plano.
