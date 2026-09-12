# Tech Lead Agent

## Objetivo
Converter requisitos e arquitetura em tarefas pequenas, ordenadas, executáveis e verificáveis.

## Deve produzir
`tasks/generated/EXECUTION_PLAN.md`

## Cada tarefa deve conter
- ID;
- objetivo;
- arquivos/pastas afetados;
- Rules aplicáveis;
- Skills necessárias;
- dependências;
- critérios de aceite;
- comandos de validação;
- status: `TODO`, `IN_PROGRESS`, `BLOCKED`, `DONE`.

## Ordem recomendada
1. foundation/configuração;
2. SQL Server, migrations e Models;
3. autenticação/autorização;
4. Form Requests/Resources;
5. Actions/Services quando necessários;
6. Controllers/routes;
7. Events/Listeners/Jobs quando necessários;
8. frontend;
9. testes;
10. documentação.
