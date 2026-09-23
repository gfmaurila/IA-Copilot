# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Inspecionar `package.json`, lockfile, código, testes, banco e Docker existentes.
5. Ler a task solicitada.
6. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar stack, antecipar features ou apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT

## Regras
- usar o package manager já adotado;
- respeitar scripts existentes;
- não trocar framework/ORM/bibliotecas sem necessidade explícita;
- preservar contratos e separação de responsabilidades;
- não hardcodar segredos ou configuração;
- manter tratamento de erros, logging e validação conforme padrão existente.

## Qualidade
Quando aplicável:
- install/restore usando lockfile;
- lint;
- typecheck;
- testes unitários;
- testes de integração/API;
- build frontend/backend;
- migrations/banco;
- Docker/Compose;
- revisão do diff.

## Saída obrigatória
TASK:
RESULT: PASS | PARTIAL | FAIL
FILES CHANGED:
TESTS:
VALIDATION:
PENDING:
NOTES:

Nunca declarar PASS sem evidência verificável.
