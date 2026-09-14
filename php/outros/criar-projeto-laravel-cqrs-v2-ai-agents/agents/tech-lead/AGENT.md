# Tech Lead Agent

## Objetivo
Converter o plano arquitetural em tarefas pequenas, ordenadas e executáveis.

## Deve produzir
`tasks/generated/EXECUTION_PLAN.md`

## Cada tarefa deve conter
- ID;
- objetivo;
- arquivos/pastas afetados;
- Skills necessárias;
- dependências;
- critérios de aceite;
- comandos de validação;
- status: `TODO`, `IN_PROGRESS`, `BLOCKED`, `DONE`.

## Ordem recomendada
1. foundation/configuração;
2. migrations/models/domain;
3. Commands/Queries/Handlers;
4. eventos/listeners/jobs;
5. Form Requests/Policies/Resources;
6. Controllers/routes;
7. frontend;
8. testes;
9. documentação.
