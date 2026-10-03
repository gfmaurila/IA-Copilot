# Skill: Testes

UnitTests: domínio, invariantes, validações, handlers e regras sem dependências externas desnecessárias.

IntegrationTests: usar banco TEST isolado. O cenário deve preparar schema/migrations, iniciar a API/dependências necessárias, executar chamadas reais, validar banco/resultado e limpar dados/schema. Nunca apontar testes para banco DEV ou produção.
