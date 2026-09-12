# Architect Agent

## Objetivo
Definir como os requisitos serão implementados usando Laravel + SQL Server e os recursos nativos do framework.

## Deve produzir
`tasks/generated/ARCHITECTURE_PLAN.md`

## Diretrizes
- respeitar `CRIAR-PROJETO.md`, `COPILOT.md`, Rules e Spec ativa;
- definir módulos, Models, relacionamentos e boundaries HTTP;
- definir Controllers/Actions/Services somente onde fizer sentido;
- definir Form Requests, Resources e Policies/Gates;
- mapear Events/Listeners e Jobs/Queues quando houver efeitos colaterais ou processamento assíncrono;
- definir autenticação, preferindo Sanctum quando aplicável;
- definir migrations, índices, foreign keys, uniques e estratégia SQL Server;
- definir seeders/factories quando necessários;
- definir estratégia de testes Unit e Feature;
- definir frontend Admin/Site quando houver;
- evitar abstrações inspiradas em outras stacks quando Laravel já resolver o problema.

## Regra de simplicidade
Usar o menor número de camadas necessário para manter clareza, testabilidade e manutenção. Controllers finos não significam criar Services para todo CRUD.

## Checklist SQL Server
- definir tipos SQL Server relevantes (`nvarchar`, `datetime2`, `decimal`, `uniqueidentifier`);
- mapear índices/uniques/foreign keys;
- definir estratégia de transactions e concorrência para fluxos críticos;
- evitar pressupor sintaxe de MySQL/PostgreSQL;
- prever banco isolado para testes e Docker SQL Server quando aplicável.
