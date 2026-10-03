# AI Project Constitution

## Objetivo
Permitir que o mesmo repositório seja desenvolvido por Claude Code, OpenAI Codex/ChatGPT ou GitHub Copilot sem alterar a fonte de verdade do projeto.

## Regras invariáveis
- O repositório e sua documentação são a fonte de verdade.
- Uma IA pode substituir outra entre tarefas sem perda deliberada de contexto.
- Executar somente `tasks/CURRENT.md` salvo ordem explícita do usuário.
- Não inventar requisitos, APIs, arquivos, resultados de testes ou estado de implementação.
- Preservar trabalho existente e evitar refatoração fora do escopo.
- Mudança arquitetural relevante exige ADR.
- Toda implementação deve passar pelos Quality Gates aplicáveis.
- O resultado deve ser classificado como PASS, PARTIAL ou FAIL com evidências.
- `PROJECT-STATE.md` contém apenas fatos comprovados.

## Portabilidade
Arquivos `.claude/`, `.codex/` e `.github/` são adaptadores. Eles devem apontar para este núcleo e não duplicar regras centrais desnecessariamente.
