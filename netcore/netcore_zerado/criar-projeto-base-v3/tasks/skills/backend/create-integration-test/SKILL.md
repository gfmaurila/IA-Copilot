# Skill: Create Integration Test

## Objetivo
Criar teste de integração isolado do ambiente de desenvolvimento.

## Fluxo obrigatório
1. criar banco exclusivo para a suíte
2. aplicar migrations
3. preparar seed do cenário
4. iniciar WebApplicationFactory
5. executar chamadas HTTP/repositório
6. validar resultado
7. limpar recursos
8. dropar banco ao finalizar

## Regras
- nunca usar banco Development
- nunca compartilhar dados entre testes sem reset
- usar nome de banco único quando necessário
- garantir teardown mesmo se o teste falhar
- testes precisam ser reproduzíveis
