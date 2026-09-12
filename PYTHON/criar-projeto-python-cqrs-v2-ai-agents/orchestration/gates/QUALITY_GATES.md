# Quality Gates - Python + FastAPI + CQRS

## GATE-01 Requirements
- requisitos e critérios de aceite definidos;
- endpoints/atores/escopo identificados;
- persistência e segurança consideradas.

## GATE-02 Architecture
- Commands e Queries separados;
- handlers definidos;
- routers finos;
- Domain separado de Infrastructure;
- Pydantic/SQLAlchemy/Alembic usados nos papéis corretos.

## GATE-03 Persistence
- mudanças de schema possuem Alembic migration;
- upgrade/rollback considerados;
- constraints/índices necessários definidos;
- banco de teste separado do dev.

## GATE-04 Python Quality
- Python 3.12+;
- type hints;
- Ruff sem erros quando configurado;
- mypy/pyright sem erro bloqueador quando configurado;
- imports e async corretos.

## GATE-05 Tests
- testes unitários e integração relevantes aprovados;
- autenticação/autorização cobertas quando aplicável;
- Commands/Queries/Handlers testados;
- API validada.

## GATE-06 Security
- JWT/credenciais sem hardcode;
- hash seguro de senha;
- autorização centralizada;
- SQL parametrizado/ORM;
- validação de entrada com Pydantic;
- `.env`/secrets protegidos.

## GATE-07 Architecture Review
- Query não altera estado;
- Router não contém regra de domínio;
- Infrastructure não vazou para Domain;
- sem padrões artificiais copiados de outras stacks;
- duplicação e complexidade revisadas.

## GATE-08 Documentation
- README e execução atualizados;
- env vars documentadas;
- migrations/endpoints descritos;
- relatórios de teste/review disponíveis;
- estado final DONE.
