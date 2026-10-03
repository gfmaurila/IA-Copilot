Leia integralmente o arquivo `prompts.md` e toda a documentação existente deste projeto.

Analise também o estado atual do código-fonte, infraestrutura, Docker, diagramas, testes e configurações.

O objetivo desta execução é RETOMAR o projeto existente, preservar tudo que já estiver corretamente implementado e incorporar os novos requisitos abaixo antes de continuar o desenvolvimento.

# 1. REGRA PRINCIPAL DE RETOMADA

NÃO recrie o projeto do zero.

Antes de alterar qualquer coisa:

1. Leia integralmente o `prompts.md`.
2. Leia a documentação existente.
3. Analise a estrutura atual do projeto.
4. Identifique o que já foi implementado.
5. Compare a implementação atual com o `prompts.md`.
6. Identifique:
   - tarefas concluídas;
   - tarefas parcialmente concluídas;
   - tarefas pendentes;
   - inconsistências;
   - novos requisitos ainda não documentados.
7. Preserve tudo que estiver correto.
8. Corrija somente o necessário.
9. Continue a execução a partir do estado atual.

---

# 2. PRIMEIRA TAREFA OBRIGATÓRIA — ATUALIZAR A DOCUMENTAÇÃO

ANTES de implementar os novos requisitos, atualize o `prompts.md` e os documentos arquiteturais do projeto para incorporar integralmente os requisitos descritos nesta task.

Quando aplicável, atualize também:

- `README.md`;
- `REQUIREMENTS.md`;
- `ARCHITECTURE_PLAN.md`;
- `EXECUTION_PLAN.md`;
- documentação de infraestrutura;
- documentação Docker;
- documentação AWS;
- documentação de observabilidade;
- documentação de mensageria;
- documentação CQRS;
- documentação de Domain Events;
- documentação de cache;
- documentação de testes.

A documentação passa a ser a fonte oficial para a implementação.

---

# 3. CRUD COMPLETO

O projeto deve possuir pelo menos um fluxo CRUD completo de referência demonstrando toda a arquitetura.

Implementar:

- Create;
- Read;
- Read By Id;
- Update;
- Delete;
- paginação;
- filtros;
- ordenação;
- validação;
- tratamento de erros;
- logs;
- auditoria quando aplicável.

O CRUD deve utilizar os padrões arquiteturais definidos pelo projeto.

---

# 4. CQRS

Separar claramente operações de escrita e leitura.

## Commands

Operações de escrita:

- Create;
- Update;
- Delete.

Devem utilizar Commands/Handlers.

## Queries

Operações de leitura:

- GetById;
- GetAll;
- Search;
- paginação;
- filtros.

Devem utilizar Queries/Handlers.

Não misturar responsabilidades de leitura e escrita.

---

# 5. DOMAIN EVENTS

Toda alteração relevante no domínio deve gerar Domain Events.

Exemplos:

`EntityCreatedDomainEvent`

`EntityUpdatedDomainEvent`

`EntityDeletedDomainEvent`

Fluxo esperado:

API
→ Command
→ Command Handler
→ Domain
→ Persistência
→ Domain Event
→ Event Handler
→ Integrações/Cache/Mensageria

Domain Events devem permanecer independentes da tecnologia de mensageria.

Não acoplar diretamente o domínio ao Kafka, RabbitMQ, AWS SQS ou AWS SNS.

Quando necessário para garantir consistência entre banco e mensageria, implementar ou preparar arquitetura para Transactional Outbox Pattern.

---

# 6. CACHE COM REDIS

Redis será utilizado como cache distribuído.

Fluxo de leitura:

Query
→ Query Handler
→ Redis
→ CACHE HIT
→ retorna dados

Quando ocorrer:

CACHE MISS
→ consulta banco de persistência
→ popula Redis
→ retorna dados

Nas operações:

Create
Update
Delete

o cache relacionado aos dados alterados deverá ser invalidado ou atualizado.

Implementar estratégia explícita de:

- cache key;
- TTL;
- invalidação;
- cache miss;
- serialização;
- tratamento de indisponibilidade do Redis.

A indisponibilidade do cache não deve provocar perda dos dados persistentes.

---

# 7. BANCOS DE DADOS

O projeto deverá suportar:

## MySQL

Banco relacional principal para dados transacionais.

## MongoDB

Utilizar para cenários documentais, projeções, histórico, read models ou dados que façam sentido dentro da arquitetura.

Não duplicar dados entre MySQL e MongoDB sem justificativa arquitetural.

## Redis

Utilizar para:

- cache;
- dados temporários;
- mecanismos distribuídos quando apropriado.

Redis NÃO deve ser tratado como banco transacional principal.

---

# 8. MENSAGERIA

Preparar infraestrutura e abstrações para:

## Apache Kafka

Utilizar para eventos distribuídos/event streaming quando apropriado.

## RabbitMQ

Utilizar para filas e processamento assíncrono quando apropriado.

Implementar exemplos funcionais de:

Producer
Consumer

quando previstos pelo projeto.

Prever:

- retry;
- timeout;
- idempotência;
- correlation ID;
- tratamento de falhas;
- Dead Letter Queue quando suportado;
- logging;
- observabilidade.

Não acoplar Application/Domain diretamente ao broker.

Criar abstrações apropriadas na Infrastructure.

---

# 9. AWS

Adicionar documentação, abstrações, configurações e exemplos necessários para:

## SQS

Filas gerenciadas.

## SNS

Pub/Sub e distribuição de eventos.

## Lambda

Processamentos serverless/event-driven.

## S3

Armazenamento de objetos/arquivos.

## EC2

Documentar cenário de execução em máquinas virtuais.

## ECS

Documentar/preparar execução containerizada.

A aplicação deve continuar executável localmente sem necessidade de uma conta AWS.

Credenciais AWS nunca devem ser colocadas no código-fonte.

Utilizar configuração por:

- environment variables;
- secrets;
- IAM Roles quando executado na AWS.

Quando viável para desenvolvimento/testes locais, preparar arquitetura compatível com serviços AWS simulados/localizados.

---

# 10. DOCKER

Toda infraestrutura necessária para desenvolvimento e testes deve ser executável via Docker.

Preparar Docker Compose para subir, conforme necessário:

- APIs;
- aplicações auxiliares;
- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- infraestrutura de observabilidade.

Evitar dependências instaladas manualmente na máquina do desenvolvedor além de Docker e ferramentas essenciais do projeto.

---

# 11. AMBIENTES

Separar claramente:

## TEST

Utilizado exclusivamente para testes automatizados.

Exemplos:

`database_test`

Redis de teste.

MongoDB de teste.

Filas/tópicos exclusivos para testes.

## DEV

Ambiente local de desenvolvimento.

Exemplos:

`database_dev`

Redis DEV.

MongoDB DEV.

Filas/tópicos DEV.

## HML

Ambiente de homologação.

Configurações isoladas de DEV e PROD.

## PROD

Ambiente de produção.

Nenhuma credencial real deve estar versionada.

Preparar arquivos/configurações apropriadas para:

- test;
- dev;
- hml;
- prod.

As configurações devem ser externas à aplicação sempre que possível.

---

# 12. TESTES UNITÁRIOS

Criar testes unitários para:

- domínio;
- Commands;
- Command Handlers;
- Queries;
- Query Handlers;
- validators;
- Domain Events;
- regras de negócio;
- cache abstractions quando aplicável.

Testes unitários NÃO devem depender de bancos externos reais.

Quando persistência for necessária para determinado teste, utilizar estratégia de teste apropriada e isolada.

---

# 13. TESTES DE INTEGRAÇÃO

Criar testes reais de integração para:

- API;
- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- persistência;
- migrations;
- cache;
- producers;
- consumers.

Utilizar containers isolados sempre que possível.

Os testes NÃO devem utilizar DEV, HML ou PROD.

Devem possuir infraestrutura TEST independente.

---

# 14. TESTES DO FLUXO DE CACHE

Criar testes que comprovem:

Primeira consulta:

API
→ Redis MISS
→ MySQL/MongoDB
→ Redis SET
→ Response

Segunda consulta:

API
→ Redis HIT
→ Response

Sem nova consulta desnecessária à persistência.

Após Update/Delete:

→ cache invalidado ou atualizado corretamente.

---

# 15. TESTES DE DOMAIN EVENTS

Validar:

Create
→ persistência
→ Domain Event

Update
→ persistência
→ Domain Event

Delete
→ persistência
→ Domain Event

Quando houver integração externa:

Domain Event
→ Outbox/Event Handler
→ Message Broker

Garantir idempotência quando necessário.

---

# 16. OBSERVABILIDADE

Implementar observabilidade estruturada.

Preparar:

- structured logging;
- correlation ID;
- distributed tracing;
- metrics;
- health checks;
- readiness checks;
- liveness checks.

Utilizar OpenTelemetry como abstração principal quando compatível com a stack.

Instrumentar pelo menos:

HTTP requests
Database
Redis
Mensageria
External APIs

Permitir identificar um fluxo distribuído:

Request
→ API
→ Command
→ Database
→ Domain Event
→ Broker
→ Consumer

mantendo Trace/Correlation ID.

Adicionar infraestrutura local de observabilidade via Docker quando apropriado.

---

# 17. DOCKER COMPOSE DE DESENVOLVIMENTO

Criar/ajustar o comando de desenvolvimento para subir toda a infraestrutura necessária.

Objetivo esperado:

docker compose up -d

Deve iniciar os componentes necessários ao ambiente DEV.

---

# 18. EXECUÇÃO DOS TESTES POR DOCKER

Criar um comando único para executar toda a suíte automatizada.

Objetivo:

docker compose -f docker-compose.test.yml up --build --abort-on-container-exit

ou fornecer uma abstração ainda mais simples, como:

make test

ou script equivalente compatível com Windows/Linux.

Esse processo deve:

1. criar infraestrutura TEST;
2. criar bancos TEST;
3. executar migrations;
4. iniciar dependências;
5. executar testes unitários;
6. executar testes de integração;
7. executar testes de infraestrutura;
8. coletar resultados;
9. finalizar containers;
10. retornar exit code diferente de zero caso qualquer teste falhe.

Nenhum teste automatizado deve depender manualmente da infraestrutura DEV.

---

# 19. HEALTH CHECKS

Adicionar health checks para:

- MySQL;
- MongoDB;
- Redis;
- Kafka;
- RabbitMQ;
- serviços externos relevantes.

Separar quando possível:

`/health/live`

`/health/ready`

---

# 20. DIAGRAMAS DE ARQUITETURA

ATUALIZE todos os diagramas existentes após incorporar estes requisitos.

Os diagramas principais devem continuar editáveis no Draw.io.

Atualizar arquitetura para representar:

Frontend
→ API
→ Application
→ CQRS
→ Domain
→ Infrastructure

e:

Commands
→ MySQL
→ Domain Events
→ Outbox/Event Bus
→ Kafka/RabbitMQ/AWS

Queries
→ Redis
→ Cache Miss
→ Persistence
→ Cache Population

Representar também:

MySQL
MongoDB
Redis
Kafka
RabbitMQ

AWS:

SQS
SNS
Lambda
S3
EC2
ECS

Observabilidade:

OpenTelemetry
Logs
Metrics
Traces
Health Checks

---

# 21. DIAGRAMAS ADICIONAIS

Quando fizer sentido, gerar/atualizar:

- arquitetura geral;
- C4 Context;
- C4 Container;
- C4 Component;
- UML;
- ER;
- Sequence Diagram de Command;
- Sequence Diagram de Query + Cache;
- Sequence Diagram de Domain Event;
- Sequence Diagram de mensageria;
- Deployment Diagram;
- AWS Deployment Diagram.

Manter arquivos fonte editáveis.

---

# 22. SEGURANÇA

Nunca versionar:

- senhas reais;
- connection strings reais;
- AWS Access Keys;
- tokens;
- secrets;
- certificados privados.

Criar `.env.example` com valores fictícios.

Garantir que arquivos reais de secrets estejam no `.gitignore`.

---

# 23. QUALITY GATES

Antes de declarar a tarefa concluída:

- restore deve funcionar;
- build deve funcionar;
- testes unitários devem passar;
- testes de integração devem passar;
- infraestrutura TEST deve subir;
- infraestrutura DEV deve subir;
- migrations devem funcionar;
- seed DEV deve funcionar;
- Redis deve funcionar;
- MongoDB deve funcionar;
- Kafka deve funcionar;
- RabbitMQ deve funcionar;
- health checks devem responder;
- diagramas devem estar atualizados;
- documentação deve refletir a implementação.

Não declare sucesso caso algum Quality Gate obrigatório esteja falhando.

---

# 24. NÃO IMPLEMENTAR TECNOLOGIA APENAS PARA "MARCAR CHECKBOX"

Cada tecnologia deve possuir responsabilidade documentada.

Antes de implementar, documente por que existe:

MySQL → dados transacionais.

Redis → cache distribuído.

MongoDB → documentos/read models/histórico quando justificado.

Kafka → event streaming/eventos distribuídos.

RabbitMQ → filas/work queues/processamento assíncrono.

AWS SQS/SNS → alternativas/integrações cloud.

S3 → objetos/arquivos.

Lambda → processamento orientado a eventos.

EC2/ECS → opções de deployment.

Evite criar múltiplas implementações fazendo exatamente a mesma coisa apenas para demonstrar tecnologias.

---

# 25. ORDEM DE EXECUÇÃO

Execute nesta ordem:

1. Ler `prompts.md`.
2. Analisar estado atual.
3. Atualizar `prompts.md`.
4. Atualizar requisitos.
5. Atualizar arquitetura planejada.
6. Atualizar diagramas Draw.io.
7. Planejar alterações.
8. Implementar infraestrutura.
9. Implementar CQRS.
10. Implementar CRUD de referência.
11. Implementar Domain Events.
12. Implementar Redis/cache.
13. Implementar MongoDB quando justificado.
14. Implementar Kafka.
15. Implementar RabbitMQ.
16. Preparar integrações AWS.
17. Implementar observabilidade.
18. Preparar ambientes TEST/DEV/HML/PROD.
19. Implementar testes.
20. Implementar execução completa via Docker.
21. Executar Quality Gates.
22. Atualizar documentação final.

Não peça confirmação entre etapas normais e reversíveis.

Caso encontre problema não bloqueante, registre-o e continue.

---

# 26. RELATÓRIO FINAL

Ao terminar, apresente:

## Estado inicial encontrado

O que já existia antes desta execução.

## Implementado

Tudo que foi implementado.

## Alterado

Arquivos e componentes modificados.

## Infraestrutura

Containers e serviços disponíveis.

## CQRS e Cache

Fluxo final implementado.

## Domain Events

Eventos e handlers existentes.

## Mensageria

Kafka/RabbitMQ implementados.

## AWS

Componentes preparados/documentados.

## Observabilidade

Logs, métricas, tracing e health checks.

## Testes

Quantidade e tipos de testes executados.

## Docker

Comandos necessários para DEV e TEST.

## Diagramas

Arquivos Draw.io criados/alterados.

## Quality Gates

Resultado individual de cada validação.

## Pendências

Itens ainda não concluídos.

## Próxima etapa

Próxima atividade recomendada com base no `prompts.md`.

IMPORTANTE:

Não apenas gere documentação dizendo que essas funcionalidades deverão existir.

Implemente efetivamente tudo que puder ser executado no ambiente local.

Quando alguma funcionalidade depender exclusivamente de infraestrutura ou credenciais externas AWS, implemente a abstração, configuração, testes locais/mocks quando apropriado e documente claramente o que depende do ambiente AWS real.