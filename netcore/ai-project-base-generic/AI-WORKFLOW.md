# AI WORKFLOW — Multi-Provider

## Fluxo oficial
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

## Papéis
RESEARCHER -> REQUIREMENTS -> ARCHITECT -> TECH LEAD -> DEVELOPER/FRONTEND -> TESTER -> REVIEWER -> DOCUMENTATION

## Regras
1. Ler `PROJECT.md`, `PROJECT-STATE.md`, `ai-core/CONSTITUTION.md` e `tasks/CURRENT.md` antes de alterar código.
2. Executar somente o escopo da tarefa atual.
3. Não antecipar tarefas futuras.
4. Não substituir requisito explícito por suposição.
5. Antes de mudança estrutural relevante, registrar decisão em ADR.
6. Ao final, executar build/lint/testes aplicáveis.
7. Aplicar `ai-core/standards/QUALITY-GATES.md`.
8. Reportar conforme `ai-core/contracts/TASK-RESULT.md`.
9. Atualizar `PROJECT-STATE.md` somente com fatos comprovados.
10. O fluxo deve funcionar com Claude Code, OpenAI Codex/ChatGPT e GitHub Copilot.
