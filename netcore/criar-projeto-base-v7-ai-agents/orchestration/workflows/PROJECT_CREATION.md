# Workflow - Project Creation

## Fase 0 - Intake

Entrada:

- pedido do usuário;
- Spec selecionada;
- rules;
- skills disponíveis.

Gate de saída:

- escopo identificado;
- fontes oficiais identificadas;
- conflitos documentados.

## Fase 1 - Requirements

Executar `agents/requirements/AGENT.md`.

Gerar:

```text
tasks/generated/REQUIREMENTS.md
```

Gate:

- requisitos funcionais definidos;
- requisitos não funcionais definidos;
- critérios de aceite verificáveis;
- fora de escopo explicitado.

## Fase 2 - Architecture

Executar `agents/architect/AGENT.md`.

Gerar:

```text
tasks/generated/ARCHITECTURE_PLAN.md
```

Gate:

- arquitetura respeita `tasks/rules/architecture.md`;
- dependências válidas;
- persistência definida;
- estratégia de segurança definida;
- estratégia de testes definida;
- Docker/infra definidos quando aplicável.

## Fase 3 - Planning

Executar `agents/tech-lead/AGENT.md`.

Gerar:

```text
tasks/generated/EXECUTION_PLAN.md
```

Regras:

- tasks pequenas;
- ordem explícita;
- dependências explícitas;
- cada task deve ser validável isoladamente;
- persistência/migrations devem anteceder features dependentes do banco.

## Fase 4 - Implementation Loop

Para cada task pendente:

```text
Tech Lead task
 -> Developer
 -> Tester
 -> Reviewer
 -> aprovado? próxima task
 -> reprovado? Developer corrige
```

Máximo de ciclos sem mudança de abordagem: 3.

Após 3 falhas equivalentes:

- registrar bloqueio;
- reavaliar arquitetura/hipótese;
- não repetir cegamente a mesma correção.

## Fase 5 - Final Validation

Executar:

- restore/install;
- build;
- unit tests;
- integration tests;
- migration validation;
- frontend build/test quando aplicável;
- Docker config validation quando aplicável.

Gerar relatórios em `tasks/reports/`.

## Fase 6 - Documentation

Somente após os gates principais passarem:

- atualizar README;
- registrar comandos;
- registrar URLs/portas;
- registrar migrations;
- registrar decisões relevantes.

## Fase 7 - Done

A entrega só pode ser marcada como DONE quando:

- requisitos obrigatórios estiverem implementados;
- build passar;
- testes obrigatórios passarem;
- migrations forem válidas;
- reviewer não tiver blocker;
- documentação mínima estiver atualizada.
