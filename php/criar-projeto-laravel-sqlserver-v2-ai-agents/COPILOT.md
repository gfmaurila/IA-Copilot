# COPILOT - Laravel + SQL Server + AI Agents

## Fluxo obrigatório

1. Leia `CRIAR-PROJETO.md`.
2. Leia `AGENTS.md`.
3. Leia `orchestration/workflows/PROJECT_CREATION.md`.
4. Leia `tasks/rules/`.
5. Leia a Spec solicitada.
6. Execute Requirements Agent e gere `REQUIREMENTS.md`.
7. Execute Architect Agent e gere `ARCHITECTURE_PLAN.md`.
8. Execute Tech Lead Agent e gere `EXECUTION_PLAN.md`.
9. Para cada tarefa, leia somente as Skills necessárias.
10. Implemente seguindo convenções Laravel/SQL Server.
11. Execute migrations em ambiente apropriado.
12. Execute `php artisan test`.
13. Execute build do frontend quando aplicável.
14. Execute Review Agent.
15. Corrija falhas até os Quality Gates passarem.
16. Execute Documentation Agent.
17. Só então marque o projeto/Spec como concluído.

## Restrições

- Não introduza Repository Pattern, CQRS ou DDD formal sem a Spec exigir.
- Prefira recursos nativos Laravel.
- SQL Server é o banco padrão deste template.
- Nunca use banco Development/Production para testes automatizados.
- Nunca marque a entrega como concluída com gate obrigatório em FAIL.
