# Como Instalar as 10 Skills — Guia Rápido

## O que são

10 pastas, cada uma com um arquivo `SKILL.md` dentro. Skills são
carregadas sob demanda — a IA só lê o conteúdo completo de uma skill
quando a tarefa que você pede realmente combina com o que ela faz. Até lá,
custam quase nada de contexto (só o nome e a descrição ficam "de prontidão").

Isso segue o **Agent Skills**, um padrão aberto criado pela Anthropic e
hoje adotado por mais de 30 ferramentas de IA — Claude Code, Cursor,
GitHub Copilot, Gemini CLI, Codex CLI, Windsurf/Devin, e outras. Isso
significa: **a mesma pasta de skill funciona sem nenhuma alteração em
praticamente qualquer ferramenta de IA de código que você use** — só muda
o lugar onde você a coloca.

## Passo 1 — Escolha o escopo

- **Global** (disponível em todos os seus projetos): vai para a pasta de
  configuração pessoal da sua ferramenta (ver tabela abaixo).
- **Por projeto** (só naquele repositório, compartilhado com o time via
  Git): vai para a pasta de configuração dentro do próprio projeto.

## Passo 2 — Copie as pastas para o lugar certo

| Ferramenta | Escopo pessoal (global) | Escopo do projeto |
|---|---|---|
| Claude Code | `~/.claude/skills/` | `.claude/skills/` |
| Cursor | — (usa só escopo de projeto) | `.cursor/skills/` |
| Codex CLI | `~/.codex/skills/` | `.codex/skills/` |
| Gemini CLI | `~/.gemini/skills/` | `.gemini/skills/` |
| Outras ferramentas compatíveis com Agent Skills | Verifique a documentação da ferramenta — o padrão costuma ser `~/.<nome-da-ferramenta>/skills/` | `.<nome-da-ferramenta>/skills/` |

Exemplo prático — instalar todas as 10 skills globalmente no Claude Code:

```bash
cp -r skills/* ~/.claude/skills/
```

Para usar as mesmas 10 skills também no Gemini CLI, sem reescrever nada:

```bash
cp -r skills/* ~/.gemini/skills/
```

Ou, se preferir manter uma única fonte e não duplicar arquivos no disco:

```bash
ln -s ~/.claude/skills/* ~/.gemini/skills/
```

## Passo 3 — Confirme que carregou

Abra sua ferramenta de IA dentro de um projeto e peça algo que combine
claramente com uma das skills — por exemplo, "revise esse código" (deve
ativar `code-review`) ou "me ajuda a debugar esse erro" (deve ativar
`debug-assistant`). Se a IA seguir o processo estruturado descrito na
skill em vez de responder de forma genérica, ela carregou corretamente.

## Se sua ferramenta não é nenhuma da tabela

Muitas ferramentas mais novas também suportam esse mesmo padrão aberto —
a lista de ferramentas compatíveis cresce constantemente. Pergunte
diretamente à sua ferramenta de IA: **"Você suporta o padrão Agent Skills
(SKILL.md)? Se sim, onde devo colocar as pastas de skill?"** — a maioria
das ferramentas atuais sabe responder isso sobre si mesma.

Se sua ferramenta genuinamente não suportar esse padrão ainda, as 10
skills continuam úteis como **referência de processo**: você pode colar o
conteúdo de qualquer uma diretamente numa conversa, como instrução
avulsa, e a IA vai seguir o mesmo raciocínio estruturado — só perde a
ativação automática por contexto.

## As 10 skills

Cada pasta contém `SKILL.md` (processo, sempre) e `references/`
(`checklist.md`, `examples.md` e `anti-patterns.md` — carregados sob demanda).
Copie a **pasta inteira**, não só o `SKILL.md`.

| Skill | O que faz |
|---|---|
| `code-review` | Revisa mudanças de código por severidade, cruzando com as regras de negócio e segurança do projeto |
| `debug-assistant` | Debugging estruturado: reproduzir → isolar → diagnosticar → corrigir com teste de regressão |
| `pr-writer` | Escreve título e descrição de PR a partir do diff real, não da conversa |
| `test-generator` | Gera testes cobrindo casos reais de borda, não só o caminho feliz |
| `doc-writer` | Documenta o contrato (pré-condições, efeitos), não a mecânica óbvia |
| `frontend-design` | UI com ponto de vista deliberado + acessibilidade WCAG 2.2 AA |
| `security-audit` | Auditoria de segurança específica da stack e do domínio, não checklist genérico |
| `api-design` | Endpoints consistentes (HTTP, erros RFC 9457, paginação) |
| `refactor-guide` | Muda estrutura sem mudar comportamento, com rede de testes |
| `feature-planner` | Plano curto e verificável antes de codar features não-triviais |

Todas seguem o mesmo princípio das outras peças deste kit: pesquisar
antes de afirmar, e progressive disclosure (detalhe só quando a tarefa
precisa).
