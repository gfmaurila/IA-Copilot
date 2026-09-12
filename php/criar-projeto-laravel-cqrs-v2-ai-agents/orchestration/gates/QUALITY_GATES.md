# Quality Gates - Laravel + CQRS

## GATE-01 - Requirements
PASS quando:
- objetivo está claro;
- requisitos funcionais estão listados;
- critérios de aceite existem;
- premissas relevantes estão registradas.

## GATE-02 - Architecture
PASS quando:
- Write Side e Read Side estão definidos;
- Commands/Queries/Handlers principais estão mapeados;
- persistência, autenticação e autorização estão definidas;
- estratégia de testes está definida.

## GATE-03 - Persistence
PASS quando:
- alterações estruturais possuem migrations;
- migrations executam em ambiente de teste;
- models/relacionamentos são coerentes;
- seeders/factories necessários existem.

## GATE-04 - Backend Validation
PASS quando:
- aplicação inicia/configura corretamente;
- migrations executam;
- `php artisan test` não apresenta falhas bloqueantes.

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
- secrets não estão versionados;
- respostas não expõem dados sensíveis.

## GATE-07 - Architecture Review
PASS quando:
- Command não é usado para leitura;
- Query não altera estado;
- Controllers são finos;
- responsabilidades Laravel estão nos componentes adequados;
- não há abstrações desnecessárias ou duplicação crítica.

## GATE-08 - Documentation
PASS quando:
- README reflete a execução real;
- `.env.example` está atualizado;
- instruções de migrations/testes/build estão documentadas;
- Spec e estado final estão atualizados.
