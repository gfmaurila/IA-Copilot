# COPILOT

Antes de executar qualquer tarefa:

1. Leia `CRIAR-PROJETO.md`.
2. Leia `tasks/rules/`.
3. Leia a Spec solicitada.
4. Leia somente as Skills necessárias.
5. Implemente seguindo Laravel + CQRS.
6. Execute migrations.
7. Execute testes.
8. Execute build frontend.
9. Corrija erros.
10. Arquive a Spec somente após validação.

## CQRS obrigatório

Alterações de estado devem usar Command + Handler.

Leituras devem usar Query + Handler.

Controllers não devem conter regra de negócio.

Não misturar leitura e escrita no mesmo fluxo sem justificativa.
