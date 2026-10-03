# INSTALAÇÃO E CONFIGURAÇÃO DO KIT IA DEV

Você vai me ajudar a instalar, configurar e adaptar o **Kit IA Dev** ao meu projeto COBOL.

Fale comigo sempre em **português do Brasil**.

O objetivo não é apenas copiar arquivos do Kit.

Você deve configurar o Kit para que a ferramenta de IA compreenda e preserve:

- arquitetura;
- regras de negócio;
- organização dos programas;
- convenções COBOL;
- copybooks;
- persistência;
- transações;
- integração;
- segurança;
- testes;
- build/compilação;
- execução;
- características do ambiente existente.

Este é um projeto **backend/CRUD sem frontend**.

---

# 1. PRINCÍPIO FUNDAMENTAL

COBOL não deve ser tratado como Java, C#, C++, Node.js ou Python com sintaxe diferente.

Antes de qualquer implementação, descubra o ambiente real.

Não presuma automaticamente:

```text
COBOL = Mainframe
COBOL = IBM
COBOL = CICS
COBOL = DB2
COBOL = JCL
```

Essas tecnologias são comuns em determinados ambientes, mas não são obrigatórias.

Primeiro investigue.

---

# 2. STACK PRINCIPAL

Linguagem:

```text
COBOL
```

Antes de configurar o projeto, identifique:

## Compilador/runtime

Possibilidades incluem:

```text
IBM Enterprise COBOL
GnuCOBOL
Micro Focus COBOL
OpenText COBOL
ACUCOBOL
outro
```

Não escolha automaticamente.

## Plataforma

Identifique se o sistema executa em:

```text
IBM z/OS
Linux
Unix
Windows
container
outro ambiente
```

## Modelo de execução

Identifique:

```text
Batch
Online/Transactional
API/Service
File Processing
Messaging
Job-based
Híbrido
```

## Tecnologias relacionadas

Verifique se existem:

```text
CICS
JCL
DB2
VSAM
IMS
MQ
SQL
Stored Procedures
REST adapters
SOAP adapters
outros
```

Preserve as tecnologias existentes.

---

# 3. ARQUIVOS DO KIT

Pacotes disponíveis:

- Kit IA Dev
- Templates por Stack
- Skills Avançadas

Ferramenta de IA:

- Claude Code; ou
- outra ferramenta compatível com instruções de projeto e Agent Skills.

## Kit

```text
Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev.zip
```

## Templates

```text
Order-Bump-Templates-por-Stack/
```

ou:

```text
Kit-IA-Dev-Templates-por-Stack.zip
```

## Skills Avançadas

```text
Upsell1-Kit-IA-Dev/
```

ou:

```text
Kit-IA-Dev-Skills-Avancadas.zip
```

Se algo estiver indisponível, solicite:

- caminho absoluto; ou
- ZIP.

Não invente conteúdo dos pacotes.

---

# 4. FORMA DE CONDUÇÃO

Execute um passo por vez.

Regras:

- inspecione antes de alterar;
- informe o resultado de cada etapa;
- espere minha confirmação;
- preserve arquitetura existente;
- preserve convenções COBOL existentes;
- preserve naming conventions;
- preserve formato dos fontes;
- preserve copybooks;
- preserve contratos externos;
- preserve layouts de arquivos;
- preserve layouts de registros;
- preserve interfaces existentes;
- preserve comportamento legado;
- não modernize silenciosamente;
- não introduza tecnologia apenas porque é mais moderna;
- não reescreva COBOL em outra linguagem;
- não transforme COBOL em pseudo-Java;
- faça no máximo 1 ou 2 perguntas quando houver ambiguidade relevante.

Converse comigo em PT-BR.

Documentos destinados à IA, como:

```text
CLAUDE.md
AGENTS.md
SKILL.md
agent_docs/
```

devem permanecer em inglês, salvo padrão contrário existente.

---

# 5. OBJETIVO

Este projeto deve servir como base empresarial para implementação de **CRUDs e regras de negócio em COBOL**.

Exemplos de domínios:

```text
CUSTOMER
PRODUCT
CATEGORY
ACCOUNT
ORDER
USER
ROLE
PERMISSION
```

O objetivo não é impor arquitetura web.

CRUD pode ser exposto através de:

```text
CICS transaction
Batch
API adapter
Service
Message
File
Database operation
outro mecanismo
```

dependendo do ambiente.

---

# 6. SEM FRONTEND

Não crie:

- React;
- Angular;
- Vue;
- HTML;
- Admin UI;
- Site UI;
- JavaScript frontend.

O escopo é:

```text
Business Logic
+
Application Flow
+
Persistence
+
Integration
+
Security
+
Tests
+
Runtime/Deployment
```

---

# 7. ARQUITETURA

A arquitetura deve preservar conceitualmente:

```text
Domain / Business Rules
        ↓
Application / Use Cases
        ↓
Infrastructure / Persistence
        ↓
Interface / Integration
```

Essas são **fronteiras conceituais**.

Não force obrigatoriamente:

```text
domain/
application/
infrastructure/
api/
```

como diretórios físicos.

Em COBOL, separação pode ocorrer através de:

- PROGRAM-ID;
- subprograms;
- copybooks;
- modules;
- paragraphs;
- sections;
- libraries;
- load modules;
- transaction programs;
- batch programs.

Adapte a arquitetura à organização natural do ambiente COBOL.

---

# 8. REGRA PRINCIPAL

Não concentre todas as responsabilidades em um único programa COBOL gigantesco quando o sistema permitir separação segura.

Ao mesmo tempo:

**não fragmente um programa COBOL estável apenas para reproduzir arquitetura de outra linguagem.**

A arquitetura deve equilibrar:

```text
Manutenibilidade
Compatibilidade
Coesão
Baixo acoplamento
Rastreabilidade
Segurança da alteração
Convenções COBOL
```

---

# 9. DOMAIN / BUSINESS RULES

As regras de negócio devem permanecer claramente identificáveis.

Exemplos:

```text
CUSTOMER STATUS TRANSITION
PRODUCT PRICE VALIDATION
ACCOUNT BALANCE RULE
ORDER CANCELLATION RULE
USER PERMISSION RULE
```

Não esconda regras críticas em:

- SQL;
- JCL;
- screen handling;
- serialization;
- file I/O;
- adapter REST;
- código duplicado.

Quando possível, centralize regras reutilizáveis em módulos/subprograms apropriados.

---

# 10. PROGRAM-ID

Cada programa deve possuir responsabilidade clara.

Antes de criar novo `PROGRAM-ID`, analise:

- naming convention;
- limite de caracteres;
- convenções da organização;
- tipo de programa;
- calling convention;
- deployment;
- runtime.

Não invente convenções incompatíveis.

---

# 11. DIVISIONS

Preserve a estrutura COBOL adequada:

```text
IDENTIFICATION DIVISION
ENVIRONMENT DIVISION
DATA DIVISION
PROCEDURE DIVISION
```

Não reorganize código de maneira incompatível com compilador ou padrão existente.

---

# 12. DATA DIVISION

Analise cuidadosamente:

```text
WORKING-STORAGE SECTION
LOCAL-STORAGE SECTION
LINKAGE SECTION
FILE SECTION
```

Não mova estruturas entre sections sem entender:

- lifetime;
- compartilhamento;
- calling convention;
- reentrancy;
- concorrência;
- comportamento existente.

---

# 13. PROCEDURE DIVISION

A lógica deve possuir organização legível.

Preserve convenções existentes de:

```text
SECTION
PARAGRAPH
PERFORM
PERFORM THRU
EVALUATE
IF
```

Não introduza `GO TO` indiscriminadamente.

Não remova `GO TO` legado automaticamente sem análise de fluxo.

Modernização estrutural deve preservar comportamento.

---

# 14. COPYBOOKS

Copybooks são contratos importantes.

Antes de alterar:

```text
COPY
```

analise todos os consumidores conhecidos.

Copybooks podem representar:

- estruturas compartilhadas;
- layouts;
- interfaces;
- mensagens;
- registros;
- parâmetros;
- contratos de integração.

Não altere tamanho, posição ou tipo de campo compartilhado sem análise de impacto.

---

# 15. REDEFINES

Antes de alterar:

```text
REDEFINES
```

entenda completamente:

- layout;
- tamanho;
- consumidores;
- formato físico;
- semântica.

Não trate `REDEFINES` como simples herança ou type casting.

---

# 16. OCCURS

Antes de alterar:

```text
OCCURS
OCCURS DEPENDING ON
```

analise:

- tamanho;
- índices;
- limites;
- formato persistido;
- integração;
- comportamento do compilador.

Evite acessos fora dos limites.

---

# 17. PIC

Alterações em:

```text
PIC
PICTURE
```

podem alterar contratos de dados.

Analise:

- tamanho;
- sinal;
- casas decimais;
- representação;
- persistência;
- arquivos;
- DB;
- mensagens;
- integração.

Não altere `PIC` apenas para acomodar novo valor sem análise de impacto.

---

# 18. COMP / BINARY / PACKED DECIMAL

Identifique uso de:

```text
COMP
COMP-3
BINARY
PACKED-DECIMAL
DISPLAY
```

Não altere representação física indiscriminadamente.

Considere:

- tamanho;
- performance;
- compatibilidade;
- arquivos;
- banco;
- integração.

---

# 19. VALORES MONETÁRIOS

Valores financeiros devem preservar:

- escala;
- precisão;
- arredondamento;
- sinal;
- representação.

Não utilize conversões que introduzam perda de precisão.

Regras financeiras pertencem ao domínio.

---

# 20. DATAS

Antes de modificar representação de datas, identifique:

- formato existente;
- timezone quando aplicável;
- século;
- contratos externos;
- armazenamento.

Não presuma automaticamente ISO 8601 internamente se o sistema possui contrato legado diferente.

Conversões podem ocorrer nas fronteiras.

---

# 21. CRUD

Um CRUD conceitual possui:

```text
CREATE
READ
LIST/SEARCH
UPDATE
DELETE
```

Mas não presuma que `DELETE` significa remoção física.

Antes de implementar delete, determine se o domínio utiliza:

```text
Physical Delete
Logical Delete
Inactive
Cancelled
Closed
Archived
```

Não invente comportamento.

---

# 22. COMMANDS E QUERIES

CQRS deve ser adaptado ao COBOL.

Não force classes `Command` e `Query`.

Conceitualmente:

```text
Write Operation
    ↓
Application Flow
    ↓
Business Rules
    ↓
Persistence
```

e:

```text
Read Operation
    ↓
Query Flow
    ↓
Persistence
    ↓
Output
```

A separação pode ocorrer através de:

- programas distintos;
- entry points;
- paragraphs;
- modules;
- transaction programs;
- batch programs.

---

# 23. CQRS

CQRS significa separar responsabilidades de leitura e alteração quando isso trouxer benefício.

Não significa obrigatoriamente:

- Event Sourcing;
- message broker;
- bancos diferentes;
- classes;
- frameworks.

Não crie arquitetura artificial para afirmar que CQRS está sendo usado.

---

# 24. APPLICATION FLOW

Casos de uso devem ser identificáveis.

Exemplos:

```text
CREATE-CUSTOMER
UPDATE-CUSTOMER
GET-CUSTOMER
LIST-CUSTOMERS
DELETE-CUSTOMER
```

A nomenclatura real deve respeitar padrões existentes.

Um caso de uso coordena:

```text
INPUT
 ↓
VALIDATION
 ↓
BUSINESS RULES
 ↓
PERSISTENCE
 ↓
OUTPUT
```

---

# 25. VALIDATION

Separe conceitualmente:

```text
Input Validation
Business Validation
Persistence Validation
```

Input Validation:

- formato;
- presença;
- tamanho;
- domínio básico.

Business Validation:

- invariantes;
- estados;
- regras;
- consistência.

Persistence Validation:

- constraints;
- integridade técnica.

Não dependa apenas do banco para proteger regras de negócio.

---

# 26. RESULTADOS E RETURN CODES

Preserve a estratégia existente.

Pode existir:

```text
RETURN-CODE
STATUS-CODE
ERROR-CODE
SQLCODE
RESP
RESP2
FILE STATUS
```

Não crie um `Result<T>` artificial como em linguagens modernas.

Adapte Result Pattern ao COBOL através de contratos claros de:

```text
STATUS
ERROR CODE
ERROR MESSAGE
OUTPUT DATA
```

quando apropriado.

---

# 27. ERROR HANDLING

Erros devem ser tratados explicitamente.

Não ignore:

```text
FILE STATUS
SQLCODE
CICS RESP
CICS RESP2
RETURN-CODE
```

quando aplicáveis.

Diferencie:

```text
Business Error
Validation Error
Persistence Error
Integration Error
System Error
```

---

# 28. PERSISTÊNCIA

Primeiro identifique a tecnologia.

Pode ser:

```text
DB2
VSAM
IMS DB
Oracle
SQL Server
PostgreSQL
arquivo sequencial
indexed file
outro
```

Não escolha automaticamente.

Preserve mecanismo existente.

---

# 29. DB2

Se DB2 estiver presente, preserve:

- SQL existente;
- host variables;
- SQLCA quando aplicável;
- cursor strategy;
- transaction boundaries;
- isolation;
- error handling.

Não assuma DB2 se ele não existir.

---

# 30. EMBEDDED SQL

Quando houver:

```text
EXEC SQL
...
END-EXEC
```

SQL é detalhe de persistência.

Não esconda regras críticas exclusivamente em queries.

Analise sempre:

```text
SQLCODE
SQLSTATE
```

conforme convenção existente.

---

# 31. CURSORS

Antes de alterar cursors, analise:

```text
DECLARE
OPEN
FETCH
CLOSE
```

Considere:

- volume;
- ordenação;
- locks;
- transaction;
- error handling;
- performance.

Garanta fechamento adequado.

---

# 32. TRANSACTIONS

Identifique a autoridade transacional.

Pode ser:

- DB2;
- CICS;
- IMS;
- application;
- outro mecanismo.

Não introduza `COMMIT`/`ROLLBACK` arbitrariamente.

A fronteira transacional deve corresponder ao caso de uso.

---

# 33. VSAM

Se VSAM estiver presente, analise:

- KSDS;
- ESDS;
- RRDS;
- keys;
- alternate indexes;
- file status;
- locking;
- access mode.

Não trate VSAM como banco relacional.

---

# 34. FILE PROCESSING

Quando houver arquivos:

```text
SEQUENTIAL
INDEXED
RELATIVE
```

preserve layouts e contratos.

Sempre analise:

```text
FILE STATUS
OPEN
READ
WRITE
REWRITE
DELETE
CLOSE
```

Não ignore erros de I/O.

---

# 35. JCL

Se JCL estiver presente, trate-o como parte da solução operacional.

Analise:

```text
JOB
EXEC
DD
PROC
STEP
COND
PARM
DISP
```

Não coloque regras de negócio novas em JCL quando elas pertencem ao programa COBOL.

Não altere datasets ou disposition sem análise.

---

# 36. BATCH

Quando o CRUD for executado em batch, identifique:

```text
Input Dataset/File
Processing Program
Business Rules
Database/File Updates
Output
Reject/Error File
Return Code
```

Defina comportamento para:

- sucesso;
- rejeições;
- erros;
- restart;
- partial processing.

---

# 37. RESTART / RECOVERY

Para batch de grande volume, analise se existe:

- checkpoint;
- restart;
- commit interval;
- recovery;
- idempotência.

Não implemente processamento massivo sem considerar falha parcial quando isso for relevante.

---

# 38. CICS

Se CICS estiver presente, preserve o modelo transacional existente.

Analise:

```text
COMMAREA
CHANNELS
CONTAINERS
BMS
LINK
XCTL
START
RETURN
SYNCPOINT
```

somente quando realmente utilizados.

Não introduza CICS em ambiente que não o utiliza.

---

# 39. COMMAREA

Quando houver COMMAREA, ela é contrato.

Alterações podem afetar consumidores.

Analise:

- tamanho;
- layout;
- versionamento;
- compatibilidade.

Não altere silenciosamente.

---

# 40. CHANNELS E CONTAINERS

Quando CICS Channels/Containers estiverem presentes, preserve contratos existentes.

Não migre COMMAREA para Channels/Containers automaticamente.

Modernização exige decisão explícita.

---

# 41. IMS

Se IMS estiver presente, primeiro identifique:

```text
IMS DB
IMS TM
ambos
```

Não trate IMS como DB2.

Preserve modelo de acesso existente.

---

# 42. MENSAGERIA

Identifique se existe:

```text
IBM MQ
Kafka
RabbitMQ
outro
```

Não introduza broker automaticamente.

Quando houver mensageria, diferencie:

```text
Business Event
Integration Message
Transport Message
```

---

# 43. DOMAIN EVENTS

O conceito de Domain Event pode ser utilizado quando fizer sentido.

Exemplos:

```text
CUSTOMER-CREATED
ACCOUNT-CLOSED
ORDER-CANCELLED
```

Não obrigue uma infraestrutura de eventos.

O evento pode inicialmente representar apenas um fato de domínio utilizado pelo fluxo da aplicação.

---

# 44. EVENT SOURCING

Não implemente Event Sourcing automaticamente.

CRUD COBOL não implica Event Sourcing.

Use somente quando existir requisito explícito.

---

# 45. INTERFACES ENTRE PROGRAMAS

Antes de alterar chamadas:

```text
CALL
LINKAGE SECTION
USING
```

analise:

- ordem dos parâmetros;
- tamanho;
- modo de passagem;
- contrato;
- consumidor;
- compilador;
- runtime.

Não altere assinatura compartilhada silenciosamente.

---

# 46. CALL

Identifique se chamadas são:

```text
STATIC
DYNAMIC
```

ou seguem mecanismo específico do ambiente.

Não altere estratégia de linking sem necessidade.

---

# 47. COPYBOOK DE INTERFACE

Quando programas compartilham interface, prefira contrato consistente.

Exemplo conceitual:

```text
CUSTOMER-REQUEST
CUSTOMER-RESPONSE
STATUS-CODE
ERROR-CODE
```

Não invente nomes sem analisar naming convention existente.

---

# 48. API

Se COBOL estiver exposto por API, identifique como isso ocorre.

Pode existir:

```text
z/OS Connect
CICS REST
API Gateway
Java adapter
C++ adapter
Micro Focus REST
outro mecanismo
```

Não escolha automaticamente.

A API é uma fronteira.

Não mova regras de negócio do COBOL para o adapter apenas para facilitar exposição HTTP.

---

# 49. JSON

Se houver JSON, identifique mecanismo existente.

Não presuma que o programa COBOL manipula JSON diretamente.

Pode haver:

```text
adapter
mapping
transformation layer
runtime support
```

Preserve separação entre:

```text
JSON Contract
COBOL Data Contract
Business Model
```

---

# 50. SEGURANÇA

Antes de implementar segurança, identifique ambiente.

Pode existir:

```text
RACF
ACF2
Top Secret
CICS Security
API Gateway
OAuth/OIDC adapter
outro
```

Não implemente autenticação caseira se a plataforma já fornecer mecanismo corporativo.

---

# 51. AUTORIZAÇÃO

Quando o sistema utilizar:

```text
User
Role
Permission
```

preserve conceitualmente:

```text
USER
  → ROLE
      → PERMISSION
```

Exemplo de operações:

```text
CUSTOMER.READ
CUSTOMER.CREATE
CUSTOMER.UPDATE
CUSTOMER.DELETE
```

A autorização deve ser aplicada na fronteira apropriada e/ou no caso de uso quando necessário.

---

# 52. DADOS SENSÍVEIS

Não exponha em:

- DISPLAY;
- logs;
- dumps voluntários;
- arquivos temporários;
- mensagens de erro;

dados sensíveis desnecessários.

Isso inclui:

```text
PASSWORD
TOKEN
SECRET
CREDENTIAL
PERSONAL DATA
FINANCIAL DATA
```

conforme o contexto.

---

# 53. DISPLAY

Não utilize `DISPLAY` indiscriminadamente como estratégia permanente de logging.

Se o sistema possuir logging/monitoramento corporativo, preserve-o.

Não exponha dados sensíveis.

---

# 54. TESTES

O projeto deve distinguir conceitualmente:

```text
Unit Tests
Integration Tests
End-to-End/System Tests
```

A implementação depende do ambiente COBOL.

Não force framework de testes de outra linguagem.

---

# 55. UNIT TESTS

Unit Tests devem validar principalmente:

- regras de negócio;
- validações;
- cálculos;
- transições;
- programas/subprograms isoláveis.

Não devem depender de banco real quando o objetivo for testar regra pura.

---

# 56. INTEGRATION TESTS

Devem validar quando aplicável:

- DB2;
- VSAM;
- IMS;
- files;
- MQ;
- CICS;
- adapters;
- contratos.

Utilize ambiente TEST.

Nunca execute testes destrutivos em DEV ou produção.

---

# 57. SYSTEM TESTS

Quando aplicável, devem validar o fluxo completo:

```text
INPUT
 ↓
INTERFACE
 ↓
COBOL
 ↓
BUSINESS RULE
 ↓
PERSISTENCE
 ↓
OUTPUT
```

---

# 58. TEST DATA

Dados de teste devem ser:

- controlados;
- repetíveis;
- identificáveis;
- removíveis quando necessário.

Não utilize dados reais sensíveis sem autorização e proteção apropriada.

---

# 59. DEV E TEST

Ambientes devem ser separados.

Conceitualmente:

```text
DEV
TEST
```

Quando existir banco:

```text
database-dev
database-test
```

Quando existirem datasets/files:

```text
DEV datasets
TEST datasets
```

Nunca utilize recursos DEV para testes destrutivos.

---

# 60. COMPILAÇÃO

Identifique o compilador e processo real.

Não invente comando universal de build.

Pode envolver:

```text
JCL compilation
compiler command
Make
CMake
scripts
IDE/build system
pipeline
```

Preserve o processo existente.

---

# 61. COMPILER OPTIONS

Antes de alterar opções de compilação, identifique:

- dialect;
- source format;
- optimization;
- debug;
- encoding;
- SQL preprocessing;
- CICS preprocessing;
- linkage;
- runtime.

Não altere indiscriminadamente.

---

# 62. SOURCE FORMAT

Identifique:

```text
Fixed Format
Free Format
```

Não converta automaticamente.

Se fixed-format for utilizado, preserve corretamente:

- sequence area;
- indicator area;
- Area A;
- Area B;
- identification area quando aplicável.

---

# 63. ENCODING

Identifique encoding real.

Pode envolver:

```text
EBCDIC
ASCII
UTF-8
outro
```

Não faça conversões silenciosas.

Considere integração e arquivos.

---

# 64. COMPATIBILIDADE

Preservar compatibilidade possui prioridade alta.

Antes de modificar contrato compartilhado, analise:

```text
quem chama?
quem lê?
quem grava?
quem compila?
quem executa?
quem depende do layout?
```

---

# 65. PERFORMANCE

Em sistemas COBOL, alterações aparentemente simples podem afetar grandes volumes.

Antes de otimizar:

1. identifique volume;
2. identifique gargalo;
3. analise I/O;
4. analise SQL;
5. analise cursors;
6. analise commits;
7. analise processamento;
8. meça.

Não faça micro-otimizações sem evidência.

---

# 66. SQL PERFORMANCE

Quando DB relacional estiver presente, analise:

- índices;
- predicates;
- joins;
- cursor;
- cardinalidade;
- access path;
- quantidade de chamadas;
- fetch strategy.

Não mova regra de negócio inteira para SQL apenas por performance sem avaliar impacto arquitetural.

---

# 67. LEGACY CODE

Código legado não deve ser considerado incorreto apenas por ser antigo.

Antes de refatorar:

- entenda comportamento;
- encontre consumidores;
- encontre contratos;
- crie testes quando possível;
- faça alteração incremental.

Não faça reescrita total sem solicitação explícita.

---

# 68. DEAD CODE

Não remova código aparentemente morto sem confirmar:

- entry points;
- dynamic calls;
- JCL;
- CICS;
- batch schedules;
- external callers;
- copybooks;
- runtime configuration.

Busca textual isolada pode não ser suficiente.

---

# 69. COMMENTS

Preserve comentários úteis que expliquem:

- regra;
- contrato;
- motivo;
- workaround;
- restrição operacional.

Não mantenha comentários incorretos.

Não adicione comentários que apenas traduzem a instrução COBOL para linguagem natural.

---

# 70. NOMENCLATURA

Preserve naming convention existente.

Pode existir nomenclatura baseada em:

```text
sistema
módulo
tipo de programa
transação
domínio
sequência
```

Não imponha nomes longos modernos se o ambiente possuir restrições ou convenções históricas.

---

# 71. CHECKLIST DE CRUD

Ao receber solicitação de CRUD, verifique os itens aplicáveis:

- [ ] entidade/conceito de negócio
- [ ] chave/identidade
- [ ] layout de dados
- [ ] regras de negócio
- [ ] validações
- [ ] CREATE
- [ ] READ
- [ ] LIST/SEARCH
- [ ] UPDATE
- [ ] DELETE ou transição equivalente
- [ ] status/return codes
- [ ] error handling
- [ ] persistência
- [ ] transação
- [ ] SQL/VSAM/IMS/files quando aplicável
- [ ] interface de entrada
- [ ] interface de saída
- [ ] copybooks quando necessários
- [ ] contratos compartilhados
- [ ] autenticação quando aplicável
- [ ] autorização quando aplicável
- [ ] logging/auditoria quando aplicável
- [ ] Unit Tests
- [ ] Integration Tests
- [ ] System Tests quando aplicável
- [ ] ambiente TEST
- [ ] build/compile
- [ ] deployment/runtime quando necessário
- [ ] documentação técnica
- [ ] impacto em consumidores existentes

Não considere o CRUD concluído enquanto os itens aplicáveis não estiverem atendidos.

---

# 72. EXEMPLO — CUSTOMER CRUD

Uma solicitação:

```text
"crie um CRUD de clientes"
```

não deve resultar simplesmente em um programa gigante:

```text
CUSTOMERCRUD.cbl
```

contendo toda a solução sem análise.

Primeiro identifique:

```text
CUSTOMER
    ↓
IDENTITY / KEY
    ↓
DATA CONTRACT
    ↓
BUSINESS RULES
    ↓
CREATE FLOW
    ↓
READ FLOW
    ↓
LIST/SEARCH FLOW
    ↓
UPDATE FLOW
    ↓
DELETE/DEACTIVATE FLOW
    ↓
PERSISTENCE
    ↓
TRANSACTION
    ↓
ERROR/STATUS CONTRACT
    ↓
INTERFACE
    ↓
SECURITY
    ↓
TESTS
```

Depois adapte isso ao padrão COBOL existente.

---

# 73. DELETE

Nunca presuma:

```text
DELETE CUSTOMER
=
physical database delete
```

Pode significar:

```text
ACTIVE → INACTIVE
ACTIVE → CLOSED
ACTIVE → DELETED
```

A decisão pertence ao domínio.

---

# 74. AUDITORIA

Quando exigida, preserve informações como:

```text
CREATED-BY
CREATED-DATE
UPDATED-BY
UPDATED-DATE
TRANSACTION-ID
```

somente conforme requisitos reais.

Não adicione campos automaticamente.

---

# 75. IDEMPOTÊNCIA

Em integrações, batch e mensageria, analise necessidade de idempotência.

Uma operação repetida não deve causar duplicidade quando o contrato exigir processamento idempotente.

Não implemente mecanismo complexo sem necessidade.

---

# 76. CONCORRÊNCIA

Analise:

- locking;
- optimistic/pessimistic control;
- transaction isolation;
- record locking;
- concurrent updates.

Não implemente update sem considerar lost updates quando isso for relevante.

---

# 77. MODERNIZAÇÃO

Se o objetivo for modernização, separe claramente:

```text
Preservação funcional
Refatoração
Modernização
Migração
Reescrita
```

Não execute essas categorias como se fossem equivalentes.

Uma solicitação de CRUD não autoriza modernização total.

---

# 78. CONTAINERS

Não presuma que COBOL será executado em Docker.

Se o projeto for GnuCOBOL/Micro Focus/OpenText ou outro ambiente compatível com containers, Docker pode ser utilizado quando já fizer parte da solução ou for aprovado.

Em ambientes mainframe, preserve o deployment real.

---

# 79. DOCKER

Quando Docker realmente fizer parte do projeto, pode existir:

```text
docker-compose.yml
```

com serviços necessários para DEV/TEST.

Não force Docker em ambiente que não o utiliza.

---

# 80. SKILLS DO KIT

Instale as 10 skills existentes em:

```text
Kit-IA-Dev/3-Skills/
```

Copie pastas completas.

Preserve:

```text
SKILL.md
references/
arquivos auxiliares
```

Para Claude Code, utilize:

```text
.claude/skills/
```

quando aplicável.

---

# 81. SKILLS AVANÇADAS

Depois:

1. instale as 8 skills novas;
2. localize:

```text
2-Atualizacoes-Skills-Existentes/
```

3. aplique os 8 patches correspondentes.

Não remova conteúdo do Kit arbitrariamente.

---

# 82. SKILLS ESPECÍFICAS DO PROJETO

Configure pelo menos:

```text
project-architecture
cobol-architecture
crud-generation
business-rules
persistence
transaction-management
integration
cobol-testing
legacy-safety
```

Quando aplicável:

```text
db2-development
cics-development
jcl-development
vsam-development
ims-development
mq-integration
```

Crie apenas skills correspondentes à stack real.

Não crie todas automaticamente.

---

# 83. TEMPLATE DO KIT

Não trate a stack apenas como:

```text
COBOL
```

A stack real deve ser identificada.

Pode ser, por exemplo:

```text
COBOL
+ DB2
+ CICS
+ JCL
```

ou:

```text
COBOL
+ Batch
+ VSAM
```

ou:

```text
GnuCOBOL
+ REST Adapter
+ PostgreSQL
```

Esses são apenas exemplos.

Não presuma nenhum deles.

Analise templates disponíveis.

Se nenhum template preservar corretamente o ambiente, utilize:

```text
Kit-IA-Dev/2-CLAUDE-md-Template/
```

e adapte o template genérico.

---

# 84. CLAUDE.md

Leia `SETUP NOTE`.

Resolva os `[FILL]`.

Registre pelo menos:

```text
COBOL implementation/compiler
platform
source format
encoding
build/compile process
runtime model
program organization
copybook conventions
persistence
database/files
transaction strategy
CICS when applicable
JCL when applicable
DB2 when applicable
VSAM when applicable
IMS when applicable
messaging when applicable
error handling
security
testing
DEV/TEST
CRUD checklist
legacy compatibility rules
```

Não atualize ou modernize a stack apenas porque existe tecnologia mais recente.

---

# 85. MULTI-TOOL

Quando necessário, configure:

```text
AGENTS.md
```

ou equivalente.

Existe uma única arquitetura.

Não crie divergência entre:

```text
CLAUDE.md
AGENTS.md
Agent Skills
agent_docs
```

---

# 86. VALIDAÇÃO DO KIT

Execute:

```text
"revise este programa COBOL"
```

Confirme que a análise considera:

- regras;
- fluxo;
- layouts;
- FILE STATUS;
- SQLCODE quando aplicável;
- contratos;
- impacto.

---

# 87. VALIDAÇÃO DO CRUD

Execute:

```text
"crie um CRUD de categorias"
```

Confirme que a IA primeiro identifica:

```text
runtime
persistence
interface
data layout
business rules
transactions
error strategy
security
tests
```

e não gera uma arquitetura de outra linguagem.

---

# 88. VALIDAÇÃO DE ALTERAÇÃO

Execute:

```text
"adicione um campo ao cadastro de clientes"
```

A IA deve analisar impacto em:

```text
PIC/layout
copybooks
database
files
LINKAGE
COMMAREA
messages
batch
consumers
tests
```

conforme aplicável.

Não deve simplesmente adicionar um campo em uma estrutura.

---

# 89. ORDEM DE EXECUÇÃO

Execute exatamente nesta ordem:

1. Confirmar Kit IA Dev.
2. Confirmar Templates.
3. Confirmar Skills Avançadas.
4. Confirmar raiz do projeto.
5. Inspecionar estrutura.
6. Identificar ferramenta de IA.
7. Identificar diretório de skills.
8. Identificar implementação/compilador COBOL.
9. Identificar versão.
10. Identificar plataforma.
11. Identificar source format.
12. Identificar encoding.
13. Identificar processo de compilação.
14. Identificar processo de linking.
15. Identificar runtime.
16. Identificar modelo Batch/Online/API/Service.
17. Identificar organização de PROGRAM-ID.
18. Identificar copybooks.
19. Identificar contratos compartilhados.
20. Identificar persistência.
21. Identificar banco.
22. Identificar DB2 quando aplicável.
23. Identificar VSAM quando aplicável.
24. Identificar IMS quando aplicável.
25. Identificar files quando aplicável.
26. Identificar transaction strategy.
27. Identificar CICS quando aplicável.
28. Identificar JCL quando aplicável.
29. Identificar mensageria.
30. Identificar integrações.
31. Identificar error handling.
32. Identificar authentication.
33. Identificar authorization.
34. Identificar logging/auditoria.
35. Identificar estratégia de testes.
36. Identificar ambientes DEV/TEST.
37. Identificar deployment.
38. Analisar templates.
39. Selecionar/adaptar template.
40. Configurar CLAUDE.md.
41. Configurar multi-tool.
42. Instalar 10 skills básicas.
43. Instalar 8 skills avançadas.
44. Aplicar 8 patches.
45. Criar/adaptar skills específicas.
46. Validar conflitos.
47. Validar arquitetura.
48. Validar compatibilidade legado.
49. Validar skills.
50. Compilar.
51. Executar Unit Tests.
52. Executar Integration Tests quando disponíveis.
53. Executar System Tests quando aplicáveis.
54. Apresentar resumo final.

---

# 90. PROIBIÇÕES

Não faça sem instrução explícita:

- adicionar frontend;
- criar Admin UI;
- criar Site UI;
- reescrever COBOL em Java;
- reescrever COBOL em C#;
- reescrever COBOL em C++;
- reescrever COBOL em Python;
- impor arquitetura de classes;
- transformar COBOL em pseudo-Java;
- escolher DB2 automaticamente;
- escolher CICS automaticamente;
- escolher JCL automaticamente;
- escolher VSAM automaticamente;
- escolher IMS automaticamente;
- escolher mainframe automaticamente;
- escolher GnuCOBOL automaticamente;
- converter fixed-format para free-format automaticamente;
- alterar encoding automaticamente;
- alterar PIC sem análise;
- alterar COMP/COMP-3 sem análise;
- alterar copybook compartilhado sem impacto;
- alterar COMMAREA silenciosamente;
- alterar LINKAGE silenciosamente;
- alterar contrato de CALL silenciosamente;
- remover GO TO legado automaticamente;
- reestruturar programa legado inteiro por estética;
- colocar regra de negócio nova em JCL;
- esconder regra crítica em SQL;
- ignorar SQLCODE;
- ignorar FILE STATUS;
- ignorar CICS RESP/RESP2 quando aplicável;
- alterar transaction boundary indiscriminadamente;
- alterar dataset sem análise;
- utilizar DEV em teste destrutivo;
- remover código aparentemente morto apenas por busca textual;
- modernizar silenciosamente;
- atualizar compiler/runtime automaticamente;
- quebrar compatibilidade por preferência arquitetural;
- armazenar secrets;
- sobrescrever código sem análise.

---

# 91. PRIORIDADES

Quando houver conflito, siga:

```text
1. Regras específicas deste projeto
2. Preservação funcional
3. Contratos existentes
4. Integridade dos dados
5. Segurança
6. Regras de negócio
7. Arquitetura
8. Convenções COBOL existentes
9. Características da plataforma
10. Sugestões genéricas do Kit
```

---

# 92. RESULTADO ESPERADO

Ao terminar, quero que a ferramenta de IA compreenda que:

> Este é um projeto backend CRUD em COBOL, sem frontend, cuja arquitetura deve seguir os padrões naturais do ambiente COBOL existente e preservar regras de negócio, contratos de dados, copybooks, persistência, transações, integração, segurança, testes e compatibilidade com sistemas legados.

A IA deve compreender também que:

> COBOL não deve ser tratado como uma linguagem orientada a objetos moderna com sintaxe diferente.

E que:

> DDD, CQRS, Repository, Result Pattern e outros conceitos arquiteturais devem ser adaptados conceitualmente quando forem úteis, sem criar estruturas artificiais incompatíveis com COBOL.

Ao receber:

```text
"crie um CRUD de clientes"
```

a IA deve raciocinar conceitualmente:

```text
CUSTOMER
    ↓
DATA CONTRACT
    ↓
BUSINESS RULES
    ↓
CREATE / READ / LIST / UPDATE / DELETE
    ↓
APPLICATION FLOW
    ↓
PERSISTENCE
    ↓
TRANSACTION
    ↓
ERROR / STATUS
    ↓
INTEGRATION INTERFACE
    ↓
SECURITY
    ↓
UNIT TESTS
    ↓
INTEGRATION TESTS
    ↓
SYSTEM TESTS
```

adaptando cada item ao ambiente real.

---

# INÍCIO

Comece somente pela **Etapa 1**.

Confirme se você consegue acessar:

1. Kit IA Dev;
2. Templates por Stack;
3. Skills Avançadas;
4. raiz do projeto.

Se algum item não estiver disponível, solicite somente o caminho absoluto ou ZIP correspondente.

**Não copie, altere ou crie arquivos ainda.**

Espere minha confirmação antes de continuar.