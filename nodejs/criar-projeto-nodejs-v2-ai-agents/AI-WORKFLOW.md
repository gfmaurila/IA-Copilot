# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Ler agentes/tasks existentes.
5. Inspecionar `package.json`, lockfile, código, testes, banco e Docker.
6. Ler a task solicitada.
7. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar stack, substituir agentes, antecipar features ou apagar trabalho existente.

## Fluxo padrão
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> TECH LEAD/PLAN -> DEVELOPER -> TESTER -> REVIEWER -> DOCUMENTATION

Se o projeto já possuir nomes/ordem próprios de agentes, preserve-os. Este fluxo é uma regra de coordenação, não uma razão para duplicar arquivos existentes.

## Qualidade
Quando aplicável:
- install/restore respeitando lockfile;
- lint;
- typecheck;
- testes unitários;
- integração/API;
- build;
- migrations;
- Docker/Compose;
- revisão do diff;
- documentação afetada.

## Saída obrigatória
TASK:
RESULT: PASS | PARTIAL | FAIL
FILES CHANGED:
TESTS:
VALIDATION:
PENDING:
NOTES:

Nunca declarar PASS sem evidência verificável.
