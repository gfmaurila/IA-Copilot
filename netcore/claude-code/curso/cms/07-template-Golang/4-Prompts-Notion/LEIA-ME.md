# Prompts Notion — como encaixa no kit

O PDF desta pasta (`notion-kit-showcase.pdf`) mostra como **duplicar**
a base no seu Notion e usar os **30 prompts em português** na web
(Claude.ai, ChatGPT, Gemini), sem instalar ferramenta.

## Relação com as 10 skills

Os prompts cobrem os mesmos tipos de trabalho das skills do kit —
só que no formato “copiar e colar no chat”, para quem usa IA pela web.

| Categoria no Notion | Skill correspondente (quando usa Claude Code / Cursor) |
|---|---|
| Arquitetura & Planejamento | `feature-planner` |
| Revisão de Código | `code-review` |
| Debug | `debug-assistant` |
| Refatoração | `refactor-guide` |
| Segurança | `security-audit` |
| Testes | `test-generator` |
| Documentação | `doc-writer` |
| Frontend & UX | `frontend-design` |
| Aprendizado & Onboarding | `doc-writer` (+ leitura de `agent_docs/`) |

Também há prompts alinhados a **PR / API** (ex.: descrição de PR,
design de endpoint) — no fluxo instalado, isso cai em `pr-writer` e
`api-design`.

## O que o Notion não substitui

- Não cria `CLAUDE.md` nem `agent_docs/` no seu repositório.
- Não ativa skills automaticamente.
- Para projeto com ferramenta instalada, o caminho principal continua
  sendo `2-CLAUDE-md-Template/` + `3-Skills/` (abra `COMECE.html` no Kit).

Use Notion sozinho (caminho B) ou junto com o setup do projeto
(caminho A) — os dois se complementam.
