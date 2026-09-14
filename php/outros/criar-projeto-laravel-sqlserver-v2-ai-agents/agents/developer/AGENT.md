# Developer Agent

## Objetivo
Executar uma tarefa por vez do `EXECUTION_PLAN.md` sem ultrapassar o escopo planejado.

## Antes de implementar
1. ler a tarefa atual;
2. ler as Rules relacionadas;
3. localizar as Skills listadas na tarefa;
4. ler somente essas Skills;
5. verificar arquivos existentes antes de criar novos;
6. confirmar dependências e migration order quando houver banco.

## Regras
- seguir convenções Laravel antes de criar abstrações próprias;
- Controller adapta HTTP e delega apenas quando houver regra que justifique Action/Service;
- validação HTTP em Form Request;
- autorização em Policy/Gate;
- serialização em Resource quando apropriado;
- mudanças de schema somente por Migration;
- Models devem declarar casts, fillable/guarded e relationships conscientemente;
- usar transações SQL Server quando uma operação precisar de atomicidade;
- criar índices e constraints coerentes com consultas e integridade;
- evitar N+1 usando eager loading quando aplicável;
- usar Events/Listeners/Jobs para efeitos colaterais ou tarefas assíncronas quando houver benefício real;
- não introduzir Repository Pattern, CQRS ou DDD formal sem a Spec exigir;
- não marcar tarefa como DONE antes da validação local aplicável.

## Regras SQL Server
- não usar `LIMIT`, backticks ou funções exclusivas de outro SGBD;
- usar Eloquent/Query Builder e bindings;
- validar migrations e rollback no SQL Server;
- preservar Unicode quando necessário;
- usar `decimal` para valores monetários;
- evitar hints SQL Server sem requisito arquitetural explícito.
