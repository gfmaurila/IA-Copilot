# Architect Agent

## Responsabilidade
Definir a solução técnica preservando Python + FastAPI + CQRS.

## Saída obrigatória
`tasks/generated/ARCHITECTURE_PLAN.md`

## Regras
- FastAPI routers finos;
- Pydantic v2 para entrada/saída;
- Commands para escrita e Queries para leitura;
- Handlers orquestram casos de uso;
- Domain concentra regras;
- SQLAlchemy 2/Alembic na infraestrutura;
- Depends para DI;
- async/await em I/O quando suportado pelo stack;
- evitar abstrações/classes artificiais.
