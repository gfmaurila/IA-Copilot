# COPILOT - Laravel + CQRS + AI Agents

Antes de executar qualquer implementação:

1. Leia `AGENTS.md`.
2. Leia `CRIAR-PROJETO.md`.
3. Leia `orchestration/workflows/PROJECT_CREATION.md`.
4. Leia `tasks/rules/`.
5. Leia a Spec solicitada.
6. Gere/atualize `tasks/generated/REQUIREMENTS.md`.
7. Gere/atualize `tasks/generated/ARCHITECTURE_PLAN.md`.
8. Gere/atualize `tasks/generated/EXECUTION_PLAN.md`.
9. Para cada tarefa, leia somente as Skills necessárias.
10. Implemente seguindo Laravel + CQRS.
11. Execute migrations em ambiente apropriado.
12. Execute testes.
13. Execute build frontend quando aplicável.
14. Corrija erros e repita os gates.
15. Execute review.
16. Atualize documentação.
17. Arquive a Spec somente após validação.

## CQRS obrigatório

- Alterações de estado usam `Command + Handler`.
- Leituras usam `Query + Handler`.
- Query não produz efeito colateral de negócio.
- Controller não contém regra de negócio.

## Laravel idiomático

- Form Request: validação HTTP.
- Policy/Gate: autorização.
- API Resource: representação HTTP.
- Event/Listener: efeitos colaterais desacoplados.
- Job: processamento assíncrono quando necessário.
- Migration: alteração estrutural de banco.
- Eloquent: persistência e relacionamentos, sem transformar Model em um God Object.

## Proibido

- começar a codificar sem planejamento para tarefas de criação/refatoração relevantes;
- criar `Service` genérico apenas para mover código de lugar;
- misturar Query e Command sem justificativa explícita;
- acessar banco de Development em testes;
- versionar secrets;
- marcar a entrega como DONE com gate obrigatório falhando.
