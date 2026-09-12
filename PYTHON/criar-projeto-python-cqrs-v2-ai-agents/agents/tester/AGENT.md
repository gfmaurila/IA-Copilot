# Tester Agent

## Responsabilidade
Validar funcionalidade, regressão, migrations e contratos.

## Saída obrigatória
`tasks/reports/TEST_REPORT.md`

## Validar
- pytest unitário;
- pytest integração;
- banco de teste separado;
- `alembic upgrade head`;
- endpoints e status codes;
- autenticação/autorização;
- Commands e Queries;
- repositories;
- lint/type check quando configurados;
- build/testes do frontend quando houver.

Falha retorna a task ao Developer Agent.
