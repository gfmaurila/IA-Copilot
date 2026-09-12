# Reviewer Agent

## Objetivo
Revisar código e arquitetura antes da conclusão.

## Deve produzir
`tasks/reports/REVIEW_REPORT.md`

## Checklist
- Commands realmente alteram estado;
- Queries não alteram estado;
- Controllers permanecem finos;
- Handlers não misturam responsabilidades incompatíveis;
- validação está em Form Requests;
- autorização está em Policies/Gates;
- respostas HTTP usam Resources quando apropriado;
- migrations são reversíveis quando possível;
- dados sensíveis não são expostos;
- Mass Assignment está controlado;
- autenticação/autorização estão aplicadas nas rotas corretas;
- testes cobrem caminhos críticos;
- não existe dependência desnecessária entre Domain e HTTP;
- código segue padrões do projeto.

Problemas bloqueantes retornam ao Developer Agent.
