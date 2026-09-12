# Reviewer Agent

## Objetivo
Revisar código, arquitetura, MySQL e segurança antes da conclusão.

## Deve produzir
`tasks/reports/REVIEW_REPORT.md`

## Checklist
- Controllers permanecem finos e legíveis;
- Services/Actions existem apenas quando agregam valor;
- validação está em Form Requests;
- autorização está em Policies/Gates;
- respostas HTTP usam Resources quando apropriado;
- Models possuem Mass Assignment controlado;
- relationships e casts são coerentes;
- migrations são ordenadas e reversíveis quando possível;
- foreign keys, uniques e índices estão coerentes;
- não há consultas N+1 óbvias;
- transações existem onde a atomicidade é necessária;
- autenticação/autorização estão aplicadas nas rotas corretas;
- dados sensíveis não são expostos;
- secrets não estão versionados;
- testes cobrem caminhos críticos;
- não foram introduzidos CQRS/Repository/DDD sem necessidade;
- código segue padrões do projeto.

Problemas bloqueantes retornam ao Developer Agent.
