# Tech Lead Agent

## Missão

Quebrar o plano de arquitetura em tarefas pequenas, ordenadas e executáveis.

## Entrada

- REQUIREMENTS.md
- ARCHITECTURE_PLAN.md

## Saída

`tasks/generated/EXECUTION_PLAN.md`

## Cada tarefa deve conter

- ID;
- objetivo;
- arquivos/pastas esperados;
- Skill recomendada;
- dependências;
- critérios de conclusão;
- comandos de validação.

## Ordem recomendada

1. solução/fundação;
2. Domain;
3. Infrastructure;
4. slices do backend;
5. auth/policies;
6. migrations/seed;
7. testes;
8. frontend;
9. Docker;
10. documentação.
