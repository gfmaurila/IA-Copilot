# Como Usar — 3 Passos

## 1. Copie a pasta do kit pro seu projeto

Copie tudo (`CLAUDE.md`, `agent_docs/`, `.claude/`) para a raiz do
projeto — mesma pasta do `package.json`, `requirements.txt`, `go.mod` ou
equivalente.

## 2. Abra sua ferramenta de IA e cole este comando

```
Leia o arquivo CLAUDE.md deste projeto — ele começa com um bloco de
comentário HTML com instruções para você ("META-INSTRUCTIONS FOR AI
SETUP"). Siga essas instruções: me entreviste sobre este projeto —
stack, regras de negócio críticas, segurança, ferramentas que já uso —
pesquise as melhores práticas atuais para o stack que eu usar, e
distribua o conteúdo entre os arquivos certos exatamente como as
instruções descrevem. Configure também o hook de exemplo em
.claude/hooks/ com os comandos reais deste projeto. Ao final, remova
os blocos de instrução e me mostre o resultado.

Eu uso: [ex. "só Claude Code" ou "Claude Code e Cursor" ou "Cursor e
Copilot"] — se eu usar mais de uma ferramenta, siga a instrução de
multi-tool setup (AGENTS.md como fonte da verdade). Se eu usar só
Claude Code, preencha o CLAUDE.md direto, sem criar AGENTS.md.
```

Troque o colchete pelas ferramentas que você realmente usa. Funciona com
Claude Code, Cursor, Windsurf, GitHub Copilot ou qualquer assistente que
leia e edite arquivos no seu projeto.

## 3. Responda a entrevista e faça commit

A IA vai perguntar sobre seu projeto (stack, regras de negócio,
segurança, ferramentas que você já usa). Responda com o que for real —
"ainda não sei" é uma resposta válida para o que genuinamente não existe
ainda.

No final, dê uma lida rápida no resultado e suba tudo pro repositório.
Pronto — toda sessão nova de IA nesse projeto já nasce sabendo o
contexto.

---

## Avisos rápidos

- **As ferramentas sugeridas (lint, type-check, testes) são
  recomendação, não regra fixa** — mudam de acordo com a linguagem, e a
  IA adapta isso sozinha durante a entrevista.
- **O hook de validação é o único ponto de enforcement real** deste kit
  — o resto é contexto que orienta a IA. Vale configurar o hook com os
  comandos reais do seu projeto, não deixar como placeholder.
- **Sem internet no momento do setup?** A IA avisa e usa o conhecimento
  mais atualizado que tiver — vale conferir versões/libs manualmente
  depois.
- **Não é definitivo.** Projeto mudou de direção? Peça pra IA atualizar
  os arquivos relevantes — mais rápido que reescrever tudo do zero.

---

## Perguntas frequentes

#### Por que isso é mais de um arquivo, e não só um CLAUDE.md?

A própria Anthropic recomenda manter o CLAUDE.md curto — abaixo de ~200
linhas — porque um arquivo grande demais faz a IA perder precisão nas
regras que importam, mesmo que elas estejam lá escritas. Este kit separa
o conteúdo em camadas por isso:

- **`CLAUDE.md`** — carregado sempre, em toda sessão. Fica enxuto: resumo
  do projeto, comandos, estrutura, e "ponteiros" pros outros arquivos.
- **`agent_docs/`** — carregado só quando relevante pra tarefa. Aqui
  ficam regras de negócio, segurança, qualidade, arquitetura e
  produtividade — pode ser longo sem custar contexto toda hora.
- **`.claude/rules/`** — regras que só se aplicam a parte do código (ex:
  convenções de frontend só carregam quando a IA mexe em frontend).
- **`.claude/hooks/`** — validação automática de verdade (ex: barrar
  commit se o lint falhar) — não depende da IA lembrar de rodar o
  comando.

Você não precisa entender os detalhes técnicos — a IA organiza tudo
sozinha durante a entrevista do Passo 2.

#### Uso mais de uma ferramenta de IA — como isso funciona?

Em 2026, o mercado convergiu num arquivo aberto chamado **`AGENTS.md`** —
lido nativamente por Cursor, GitHub Copilot, Gemini CLI, Windsurf, Codex
e a maioria das outras ferramentas. **O Claude Code é a exceção**: ele só
lê `CLAUDE.md`, não lê `AGENTS.md` sozinho.

Por isso, se você usa mais de uma ferramenta, o setup certo não é copiar
o mesmo conteúdo em vários arquivos (isso desalinha com o tempo). O
comando do Passo 2 já resolve isso automaticamente:

1. **`AGENTS.md`** guarda todo o conteúdo real — é a fonte única da
   verdade, lida por quase tudo.
2. **`CLAUDE.md`** vira um "atalho": só uma linha (`@AGENTS.md`, que
   importa o arquivo acima) mais qualquer coisa específica só do Claude
   Code, se houver.
3. Se sua ferramenta tem formato próprio de regras com escopo (ex: o
   `.cursor/rules/*.mdc` do Cursor), a IA cria esse arquivo também, mas
   igualmente enxuto.

| Ferramenta | Lê nativamente | Arquivo/local |
|---|---|---|
| Claude Code | Só `CLAUDE.md` | raiz do projeto |
| Cursor | `AGENTS.md` + `.cursor/rules/*.mdc` (escopo) | raiz + `.cursor/rules/` |
| GitHub Copilot | `AGENTS.md` + `.github/copilot-instructions.md` (os dois juntos, se existirem) | raiz + `.github/` |
| Windsurf (rebatizado Devin Desktop em jun/2026) | `AGENTS.md` + `.devin/rules/` (ou `.windsurf/rules/`, ainda funciona) | raiz + `.devin/rules/` |
| Codex / Gemini CLI / outras | `AGENTS.md` (padrão aberto) | raiz do projeto |

Se você usa **só** Claude Code, ignore essa tabela — a IA preenche o
`CLAUDE.md` direto, sem criar `AGENTS.md` nenhum.

#### Comecei só com Claude Code, agora quero adicionar Cursor. E agora?

Não precisa refazer a entrevista. É só pedir:

```
Hoje eu só tenho CLAUDE.md configurado neste projeto. Agora também uso
[Cursor / Copilot / outra]. Siga a instrução de multi-tool setup:
crie o AGENTS.md com o conteúdo que já está no CLAUDE.md, transforme o
CLAUDE.md num wrapper fino que importa o AGENTS.md, e crie o arquivo de
escopo específico dessa ferramenta se ela tiver um (pesquise o formato
e local corretos se não tiver certeza).
```

#### O sistema fica desatualizado com o tempo?

Não, se você aceitar as sugestões da IA. O `CLAUDE.md` tem uma instrução
permanente ("Keeping This File Current") que faz a IA avisar quando
perceber algo importante durante o trabalho normal — uma regra de
negócio nova, uma decisão de arquitetura, um "nunca faça X aqui" — e
perguntar se deve documentar isso, e em qual arquivo. Aceitar essas
sugestões é o que mantém o sistema útil ao longo do tempo.

#### Esse kit inclui o sistema completo de hooks/automação?

Não — este kit entrega **um** hook de exemplo funcional (validação
pré-commit: barra o commit se lint/typecheck falhar). Sistema completo
de hooks (múltiplos eventos, slash commands, orquestração de
subagentes) é mais avançado e fica fora do escopo deste kit.
