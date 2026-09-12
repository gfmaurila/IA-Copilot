# Prompt - Refactor Project

Refatore o projeto existente preservando comportamento e contratos, salvo mudança explícita na Spec.

## Processo
1. inventarie a estrutura atual;
2. identifique desvios das Rules e convenções Laravel;
3. registre requisitos de preservação;
4. gere arquitetura alvo;
5. gere plano incremental de refatoração;
6. altere em etapas pequenas;
7. não altere schema sem Migration;
8. valide SQL Server, migrations e rollback quando aplicável;
9. rode testes após cada bloco crítico;
10. revise autenticação, autorização, Mass Assignment, N+1 e contratos de API;
11. não introduza CQRS/Repository/DDD sem exigência;
12. documente mudanças relevantes.
