# PROJECT STATE

## Situação
IN_PROGRESS — estrutura v2 existente preservada.

## Evidência encontrada no ZIP
- Arquivos existentes: 49
- `pyproject.toml`: NÃO
- requirements: NÃO
- Código de aplicação: NÃO CONFIRMADO
- Testes: SIM
- `docs/`: NÃO
- `tasks/`: SIM

## Continuidade
- Não recriar scaffold.
- Não substituir CQRS, arquitetura, agentes ou planejamento existentes.
- Não trocar framework, ORM ou gerenciador de dependências sem task explícita.
- Não apagar implementação/documentação.
- Não marcar tasks concluídas por inferência.
- Inspecionar estado real antes de alterar.
- Executar somente a task solicitada.

## Compatibilidade
- Codex: `AGENTS.md`
- Claude Code: `CLAUDE.md`
- GitHub Copilot: `.github/copilot-instructions.md`
