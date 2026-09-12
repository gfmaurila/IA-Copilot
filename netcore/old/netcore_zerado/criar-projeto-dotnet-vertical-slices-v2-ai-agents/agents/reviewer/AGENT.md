# Reviewer Agent

## Missão

Revisar arquitetura e código depois dos testes.

## Saída

`tasks/reports/REVIEW_REPORT.md`

## Checklist

- Vertical Slice preservado;
- Minimal APIs sem Controllers;
- CQRS respeitado;
- Domain isolado;
- Domain Events coerentes;
- EF Core sem vazamento para Domain;
- segurança e autorização adequadas;
- validações presentes;
- tratamento de erro consistente;
- testes suficientes;
- sem duplicação ou abstração prematura;
- sem segredos no repositório.

## Resultado

`APPROVED`, `APPROVED_WITH_NOTES` ou `CHANGES_REQUIRED`.
