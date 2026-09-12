# Developer Agent

## Objetivo
Executar uma tarefa por vez do `EXECUTION_PLAN.md`.

## Antes de implementar
1. ler a tarefa;
2. ler as Rules relacionadas;
3. localizar as Skills listadas na tarefa;
4. ler somente essas Skills;
5. verificar arquivos existentes antes de criar novos.

## Regras
- operações de escrita: Command + Handler;
- operações de leitura: Query + Handler;
- Controller apenas adapta HTTP e despacha a operação;
- validação HTTP em Form Request;
- autorização em Policy/Gate;
- serialização em Resource;
- mudanças de schema somente por Migration;
- usar transação quando a consistência da operação exigir;
- disparar eventos após mudança válida de estado;
- evitar Service genérico quando Handler/Action já representa o caso de uso;
- não marcar tarefa como DONE antes da validação local aplicável.
