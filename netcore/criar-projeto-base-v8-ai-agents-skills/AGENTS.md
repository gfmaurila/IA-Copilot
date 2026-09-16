# AGENTS - IA Copilot Project Builder

Este arquivo define a orquestração dos agentes responsáveis pela criação e evolução do projeto.

## Princípio principal

Nenhum agente deve tentar resolver todo o projeto sozinho.

O fluxo padrão é:

```text
User Request
   -> Requirements Agent
   -> Architect Agent
   -> Tech Lead Agent
   -> Developer Agent
   -> Tester Agent
   -> Reviewer Agent
   -> Documentation Agent
```

Em caso de falha:

```text
Tester/Reviewer
   -> feedback report
   -> Developer
   -> build/test novamente
```

## Ordem obrigatória de leitura

Antes de executar uma tarefa, o orquestrador deve ler:

1. `CRIAR-PROJETO.md`
2. `COPILOT.md`
3. `tasks/rules/`
4. Spec solicitada em `tasks/specs/changes/`
5. Catálogo em `tasks/skills/SKILLS.md` e somente as Skills necessárias em `tasks/skills/`
6. Estado atual em `orchestration/state/PROJECT_STATE.md`
7. Artefatos já produzidos em `tasks/generated/`

## Responsabilidades

### Requirements Agent

Transforma o pedido em requisitos verificáveis.

Saída obrigatória:

```text
tasks/generated/REQUIREMENTS.md
```

Não implementa código.

### Architect Agent

Define arquitetura, dependências, limites, persistência, integração e decisões técnicas.

Saída obrigatória:

```text
tasks/generated/ARCHITECTURE_PLAN.md
```

Não implementa features.

### Tech Lead Agent

Quebra a implementação em tarefas pequenas, ordenadas e testáveis.

Saída obrigatória:

```text
tasks/generated/EXECUTION_PLAN.md
```

Cada task deve conter:

- objetivo;
- arquivos prováveis;
- dependências;
- skills necessárias;
- critério de aceite;
- comandos de validação.

### Developer Agent

Executa uma task por vez.

Antes de alterar arquivos:

- ler a task;
- ler apenas as skills necessárias;
- respeitar os rules;
- evitar alterações fora do escopo.

Após implementar:

- registrar alterações;
- executar validações locais pertinentes;
- atualizar o status da task.

### Tester Agent

Executa build, testes, migrations e validações automatizadas.

Saída:

```text
tasks/reports/TEST_REPORT.md
```

Em caso de falha, deve fornecer erro reproduzível e devolver a execução ao Developer Agent.

### Reviewer Agent

Revisa arquitetura, segurança, código, regras do projeto e critérios de aceite.

Saída:

```text
tasks/reports/REVIEW_REPORT.md
```

Não deve aprovar uma entrega com build/testes obrigatórios falhando.

### Documentation Agent

Atualiza README, documentação técnica e instruções de execução somente após aprovação dos gates.

Saída esperada:

- `README.md` atualizado;
- documentação complementar em `docs/` quando necessária.

## Regra de contexto

Para reduzir consumo de tokens:

- não reler todos os arquivos do repositório;
- abrir somente arquivos relacionados à task atual;
- usar Specs como fonte de verdade;
- usar Skills como procedimentos reutilizáveis;
- manter decisões consolidadas nos artefatos de `tasks/generated/`;
- manter progresso em `orchestration/state/PROJECT_STATE.md`.
