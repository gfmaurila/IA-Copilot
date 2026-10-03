# AI Project Base Generic v2 — Multi-AI

Template genérico para desenvolvimento assistido por IA com **uma fonte de verdade** e três executores suportados:

- Claude Code
- OpenAI Codex / ChatGPT
- GitHub Copilot

## Princípio central

O projeto é **AI Provider Agnostic**. Requisitos, arquitetura, tarefas, estado, papéis, Quality Gates e contratos ficam no repositório e não pertencem a uma IA específica.

```text
                       AI PROJECT CORE
                              |
              +---------------+---------------+
              |               |               |
         Claude Code     Codex/ChatGPT   GitHub Copilot
          CLAUDE.md        AGENTS.md       .github/
              |               |               |
              +---------------+---------------+
                              |
                     MESMA FONTE DE VERDADE
```

## Núcleo compartilhado

- `PROJECT.md` — definição do projeto
- `PROJECT-STATE.md` — estado comprovado
- `AI-WORKFLOW.md` — fluxo oficial
- `ai-core/CONSTITUTION.md` — regras invariáveis
- `ai-core/roles/` — papéis lógicos
- `ai-core/standards/` — Quality Gates e protocolo
- `ai-core/contracts/` — formato de resultado
- `tasks/CURRENT.md` — única tarefa em execução

## Adaptadores

- Claude Code: `CLAUDE.md` + `.claude/`
- Codex/ChatGPT: `AGENTS.md` + `.codex/`
- GitHub Copilot: `.github/copilot-instructions.md` + `.github/instructions/`

## Fluxo

`RESEARCH -> REQUIREMENTS -> ARCHITECTURE -> PLAN -> IMPLEMENT -> TEST -> REVIEW -> DOCUMENT`

## Uso recomendado

1. Preencha `PROJECT.md`.
2. Registre requisitos e arquitetura.
3. Cadastre telas/referências quando houver UI.
4. Crie tarefas usando `tasks/TASK-TEMPLATE.md`.
5. Coloque somente a tarefa autorizada em `tasks/CURRENT.md`.
6. Abra o projeto com qualquer uma das três IAs.
7. Solicite: **"Leia as instruções do projeto e execute SOMENTE a tarefa atual."**
8. Exija Quality Gates e relatório PASS/PARTIAL/FAIL.
9. Troque de IA entre tarefas sem alterar a fonte de verdade.

## Regra de ouro

Nunca coloque regra de negócio, requisito, decisão arquitetural ou estado crítico somente em arquivos específicos de Claude, Codex ou Copilot.
