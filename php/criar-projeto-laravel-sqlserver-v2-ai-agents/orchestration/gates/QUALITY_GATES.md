# Quality Gates - Laravel + SQL Server

## GATE-01 - Requirements
PASS quando:
- objetivo está claro;
- requisitos funcionais estão listados;
- critérios de aceite existem;
- premissas relevantes estão registradas.

## GATE-02 - Architecture
PASS quando:
- componentes Laravel principais estão definidos;
- autenticação e autorização estão definidas;
- estratégia SQL Server e migrations estão definidas;
- estratégia de testes está definida;
- abstrações extras possuem justificativa.

## GATE-03 - SQL Server / Persistence
PASS quando:
- alterações estruturais possuem migrations;
- migrations executam do zero no banco de teste;
- rollback é válido quando aplicável;
- Models e relacionamentos são coerentes;
- foreign keys, uniques e índices essenciais estão definidos;
- seeders/factories necessários existem;
- testes não usam Development/Production.

## GATE-04 - Backend Validation
PASS quando:
- aplicação configura/inicia corretamente;
- migrations executam;
- `php artisan test` não apresenta falhas bloqueantes;
- endpoints críticos possuem cobertura Feature.

## GATE-05 - Frontend Validation
Quando houver frontend, PASS quando:
- dependências instalam;
- typecheck/lint configurados passam;
- build de produção conclui.

## GATE-06 - Security
PASS quando:
- autenticação está aplicada;
- autorização por Policies/Gates está aplicada;
- validação de entrada está presente;
- Mass Assignment está controlado;
- secrets não estão versionados;
- respostas não expõem dados sensíveis;
- queries usam APIs seguras do framework e não concatenam SQL inseguro.

## GATE-07 - Laravel Review
PASS quando:
- Controllers permanecem finos;
- responsabilidades estão nos componentes Laravel adequados;
- não há N+1 crítico evidente;
- transações são usadas quando necessárias;
- não há abstrações desnecessárias;
- CQRS/Repository/DDD não foram adicionados sem exigência explícita.

## GATE-08 - Documentation
PASS quando:
- README reflete a execução real;
- `.env.example` está atualizado;
- instruções SQL Server/migrations/testes/build estão documentadas;
- Spec e estado final estão atualizados.

## Evidências adicionais obrigatórias - SQL Server
Para mudanças de persistência, considerar FAIL quando:
- `.env.example` não utilizar `sqlsrv`;
- migrations utilizarem tipos/sintaxe incompatíveis com SQL Server;
- SQL nativo não utilizar bindings;
- não houver validação em SQL Server para funcionalidade dependente do SGBD;
- valores monetários forem modelados como ponto flutuante sem justificativa.
