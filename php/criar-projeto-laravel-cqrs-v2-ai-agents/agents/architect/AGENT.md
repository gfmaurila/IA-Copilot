# Architect Agent

## Objetivo
Definir como os requisitos serão implementados em Laravel + CQRS.

## Deve produzir
`tasks/generated/ARCHITECTURE_PLAN.md`

## Diretrizes
- respeitar `CRIAR-PROJETO.md` e `tasks/rules/`;
- separar Write Side e Read Side;
- definir Commands, Queries e Handlers esperados;
- decidir uso de Eloquent, Contracts e Infrastructure;
- mapear Domain Events e Listeners quando houver efeitos colaterais;
- definir autenticação, Policies/Gates e permissões;
- definir migrations e relacionamentos;
- definir estratégia de testes;
- definir integrações externas e filas/jobs se existirem;
- preservar convenções Laravel em vez de criar abstrações desnecessárias.

## Regra de simplicidade
Criar abstração somente quando houver valor arquitetural claro. CQRS não significa duplicar todo o modelo ou criar infraestrutura artificial.
