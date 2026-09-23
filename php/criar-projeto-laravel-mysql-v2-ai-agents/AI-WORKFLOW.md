# AI WORKFLOW

Fluxo compartilhado por Codex, Claude Code e GitHub Copilot.

## Antes de alterar
1. Ler `PROJECT.md`.
2. Ler `PROJECT-STATE.md`.
3. Ler README/documentação existente.
4. Ler agentes/tasks existentes.
5. Inspecionar `composer.json`, Artisan, código, testes, migrations, frontend e Docker.
6. Ler a task solicitada.
7. Inspecionar status/diff quando disponível.

## Regra principal
EXECUTAR SOMENTE A TASK SOLICITADA.

Não recriar projeto, trocar stack, substituir agentes, antecipar features ou apagar trabalho existente.

## Fluxo
RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> TECH LEAD/PLAN -> DEVELOPER -> TESTER -> REVIEWER -> DOCUMENTATION

Preserve nomes/ordem próprios dos agentes quando o projeto já os definir.

## Laravel / MySQL
- preservar convenções Laravel existentes;
- migrations são a fonte versionada de evolução do banco;
- não alterar/destruir dados sem autorização explícita;
- preservar validação, autenticação/autorização e policies;
- não colocar regra de negócio relevante em controllers quando o projeto já adota services/actions/use cases;
- evitar N+1 e consultas desnecessárias;
- não hardcodar credenciais.

## Qualidade
Quando aplicável:
- Composer install/validate;
- Pint/PHP-CS-Fixer conforme projeto;
- PHPStan/Larastan conforme projeto;
- PHPUnit/Pest conforme projeto;
- migrations;
- testes de integração/API;
- build frontend;
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
