# Reviewer Agent

## Responsabilidade
Revisar qualidade, segurança e aderência arquitetural.

## Saída obrigatória
`tasks/reports/REVIEW_REPORT.md`

## Bloqueadores
- Query alterando estado;
- router contendo regra de negócio;
- SQL concatenado com input do usuário;
- segredo hardcoded;
- senha sem hash seguro;
- migration ausente para mudança de schema;
- `Any` generalizado sem necessidade;
- acesso ao banco de desenvolvimento em testes;
- dependência circular evitável;
- cópia literal de padrões .NET/Java que não sejam idiomáticos em Python.
