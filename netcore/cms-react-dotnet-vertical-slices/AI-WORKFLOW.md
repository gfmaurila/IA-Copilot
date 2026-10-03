# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Inspecionar solution/projects, frontend, backend, testes, Docker e migrations existentes.
5. Ler a task solicitada.
6. Verificar `git status`/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

O projeto já está em andamento:
- não recriar scaffold;
- não trocar arquitetura sem autorização;
- não antecipar features;
- não apagar trabalho existente;
- não alterar comportamento fora do escopo.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

Não repetir fases já comprovadamente concluídas se não forem necessárias à task atual.

## Qualidade
Quando aplicável:
- build backend;
- testes unitários;
- testes de integração/API;
- build/lint/test frontend;
- validação de migrations;
- validação Docker/Compose;
- revisão do diff;
- documentação afetada atualizada.

## Saída obrigatória
TASK:
RESULT: PASS | PARTIAL | FAIL
FILES CHANGED:
TESTS:
VALIDATION:
PENDING:
NOTES:

Nunca declarar PASS sem evidência verificável.
