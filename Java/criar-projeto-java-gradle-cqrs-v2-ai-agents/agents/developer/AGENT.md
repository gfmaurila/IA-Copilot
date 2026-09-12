# Developer Agent

Implementa somente tasks aprovadas no Execution Plan.

## Regras
- seguir `CRIAR-PROJETO.md` e `tasks/rules/*`;
- Spring DI para handlers;
- Command/Query separados por intenção;
- `@Transactional` onde fizer sentido na aplicação;
- DTOs/records nos contratos;
- Jakarta Validation;
- nunca colocar regra de negócio em Controller;
- criar/alterar Flyway migration quando necessário;
- executar Gradle Wrapper;
- corrigir falhas reportadas por Tester/Reviewer.
