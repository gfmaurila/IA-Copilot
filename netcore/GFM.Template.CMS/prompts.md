# GFM.Template.CMS

# ORQUESTRAÇÃO PRINCIPAL — INSTALAÇÃO, ARQUITETURA, DESENVOLVIMENTO E VALIDAÇÃO

Você vai me ajudar a instalar, configurar e utilizar o **Kit IA Dev** e, em seguida, construir o projeto **GFM.Template.CMS**.

Fale comigo sempre em **português do Brasil (PT-BR)**.

---

# 1. CONTEXTO DO PROJETO

Nome oficial:

```text
GFM.Template.CMS
```

O `GFM.Template.CMS` deve ser tratado como um **novo projeto**.

A implementação deve ser construída a partir das especificações e documentos existentes neste repositório.

Não procurar, importar, recuperar, comparar ou utilizar implementações provenientes de outros projetos.

Não assumir existência de:

```text
código legado
estrutura anterior
banco anterior
migrations anteriores
implementações anteriores
arquitetura anterior
configurações anteriores
```

A fonte de verdade será exclusivamente o conteúdo pertencente ao:

```text
GFM.Template.CMS
```

---

# 2. DOCUMENTOS PRINCIPAIS

O projeto possui quatro documentos principais de orquestração e especificação:

```text
prompts.md
PROJECT_STRUCTURE.md
PROJECT_SKILLS.md
AUDIO_INTELLIGENCE.md
SEED_FAKE_DATA.md
```

Eles devem ser processados nesta ordem:

```text
prompts.md
        ↓
PROJECT_STRUCTURE.md
        ↓
PROJECT_SKILLS.md
        ↓
AUDIO_INTELLIGENCE.md
        ↓
SEED_FAKE_DATA.md
```

Cada documento possui uma responsabilidade específica.

## prompts.md

Orquestrador principal do projeto.

Define:

```text
requisitos
arquitetura
ordem de execução
tecnologias
regras de implementação
infraestrutura
testes
quality gates
critérios de conclusão
```

## PROJECT_STRUCTURE.md

Define a estrutura física oficial do:

```text
GFM.Template.CMS
```

Incluindo:

```text
solution
backend
APIs
Domain
Application
Infrastructure
CrossCutting
Workers
Batch
React
React Native
testes
Docker
Kubernetes
AWS
OpenTofu
documentação
arquitetura
agentes
Skills
scripts
```

## PROJECT_SKILLS.md

Define:

```text
Skills necessárias
responsabilidades
references
regras de reutilização
integração com agentes
```

## SEED_FAKE_DATA.md

Define:

```text
Migration
Seed automático
IAM
dados fake
1000 usuários
dados relacionados
credenciais locais
idempotência
validação
testes de login
testes de autorização
```

---

# 3. REGRA DE IDIOMA

Toda interação comigo deve ocorrer em:

```text
Português do Brasil
```

Todo comentário criado no código deve estar em:

```text
Português do Brasil
```

Exemplo:

```csharp
// Valida se o usuário possui permissão para executar a operação.
```

Não utilizar:

```csharp
// Checks if the user has permission to execute the operation.
```

Essa regra vale para comentários em:

```text
C#
TypeScript
JavaScript
React
React Native
SQL
PowerShell
Shell
Docker
YAML
Kubernetes
OpenTofu
Terraform
testes
scripts
```

Não adicionar comentários para explicar código óbvio.

Comentários devem ser utilizados principalmente para:

```text
regras de negócio
decisões arquiteturais
comportamentos não óbvios
restrições
workarounds
motivações técnicas relevantes
```

Arquivos técnicos originais do Kit IA Dev podem permanecer no idioma original quando necessário.

Exemplos:

```text
CLAUDE.md
AGENTS.md
SKILL.md
references/
agent_docs/
```

---

# 4. REGRA FUNDAMENTAL

Não começar criando código aleatoriamente.

A construção do `GFM.Template.CMS` deve seguir:

```text
SETUP
        ↓
ESTRUTURA
        ↓
SKILLS
        ↓
REQUISITOS
        ↓
PLANEJAMENTO
        ↓
ARQUITETURA
        ↓
QUALITY GATE DE ARQUITETURA
        ↓
IMPLEMENTAÇÃO
        ↓
BANCO
        ↓
MIGRATION
        ↓
SEED
        ↓
TESTES
        ↓
EXECUÇÃO
        ↓
QUALITY GATES
        ↓
DOCUMENTAÇÃO
```

---

# 5. ORDEM OFICIAL DE EXECUÇÃO

A execução completa do projeto deverá seguir:

```text
01. Validar Kit IA Dev
02. Validar Templates por Stack
03. Validar Skills Avançadas
04. Validar raiz do GFM.Template.CMS

05. Instalar Kit IA Dev
06. Configurar CLAUDE.md
07. Configurar AGENTS.md
08. Configurar suporte multi-tool

09. Ler PROJECT_STRUCTURE.md
10. Criar estrutura oficial do GFM.Template.CMS
11. Criar solution e projetos
12. Configurar referências entre projetos

13. Instalar Skills base
14. Instalar Skills avançadas
15. Aplicar atualizações das Skills existentes

16. Ler PROJECT_SKILLS.md
17. Mapear Skills necessárias
18. Estender Skills existentes quando possível
19. Criar Skills específicas ausentes
20. Validar ativação das Skills

21. Ler SEED_FAKE_DATA.md
22. Registrar seus requisitos para implementação posterior

23. Consolidar requisitos do projeto

24. Criar Architecture Plan
25. Criar Execution Plan

26. Criar ADRs necessários

27. Criar arquitetura C4
28. Criar Structurizr DSL
29. Criar diagramas Draw.io

30. Validar arquitetura LOCAL
31. Validar arquitetura AWS TARGET

32. Executar Architecture Quality Gate

33. Implementar Domain
34. Implementar Application
35. Implementar Infrastructure
36. Implementar CrossCutting

37. Implementar IAM
38. Implementar Authentication
39. Implementar Authorization

40. Implementar CQRS
41. Implementar Domain Events
42. Implementar Integration Events
43. Implementar Transactional Outbox

44. Implementar MySQL
45. Implementar Redis

46. Implementar MongoDB somente se houver caso de uso

47. Implementar Kafka quando aplicável
48. Implementar RabbitMQ quando aplicável

49. Implementar APIs
50. Implementar Workers
51. Implementar Batch quando aplicável

52. Implementar React Admin
53. Implementar React Site
54. Implementar React Native

55. Implementar camada de IA
56. Implementar RAG
57. Implementar AI Tools
58. Implementar Agents
59. Implementar AI Content Intelligence & Storage Orchestration conforme `AI_CONTENT_INTELLIGENCE.md`
60. Implementar Storage Providers por tenant/perfil: Local, MinIO, S3, Google Drive, OneDrive e SharePoint
61. Implementar Content Orchestrator para documentos, áudio e vídeo
62. Implementar parsers de documentos através de abstrações
63. Implementar Audio Intelligence conforme `AUDIO_INTELLIGENCE.md`
64. Implementar pipeline FFmpeg / normalização de mídia
65. Implementar Speech-to-Text através de abstração de provider
66. Implementar processamento assíncrono, idempotente e multi-tenant
67. Implementar RAG/embeddings respeitando tenant, usuário e permissões
68. Implementar integração n8n através de Webhooks/APIs, quando habilitada
69. Implementar perfis configuráveis de Storage + LLM + STT + Embeddings + Vector Store + Automation

64. Implementar Docker
65. Implementar Docker Compose
66. Implementar LocalStack
67. Implementar observabilidade

68. Implementar Kubernetes
69. Implementar Kustomize

70. Implementar OpenTofu
71. Preparar AWS TARGET

72. Implementar Migrations

73. Implementar SEED_FAKE_DATA.md

74. Executar Migration
75. Executar Seed automático

76. Validar 1000 usuários
77. Validar dados relacionados
73. Validar IAM
74. Validar idempotência

75. Executar backend
76. Executar frontend
77. Executar mobile quando aplicável

78. Testar login
79. Testar autorização

80. Executar Unit Tests
81. Executar Integration Tests
82. Executar Architecture Tests
83. Executar Functional Tests
84. Executar testes de Cache
85. Executar testes de Messaging
86. Executar testes de Outbox
87. Executar testes de IA

88. Validar Docker
89. Executar Kubernetes Smoke Tests

90. Executar todos os Quality Gates

91. Executar Code Review final

92. Atualizar documentação
93. Atualizar ADRs
94. Atualizar Structurizr
95. Atualizar Draw.io

96. Gerar relatório final
```

---

# 6. PRINCÍPIO DE ARQUITETURA

O projeto deverá seguir:

```text
LOCAL FIRST
        ↓
CONTAINER FIRST
        ↓
CLOUD READY
        ↓
AWS TARGET
```

O desenvolvimento local não poderá depender da existência de uma conta AWS real.

---

# 7. FONTE DE VERDADE

A fonte de verdade do projeto será:

```text
GFM.Template.CMS/
│
├── prompts.md
├── PROJECT_STRUCTURE.md
├── PROJECT_SKILLS.md
├── SEED_FAKE_DATA.md
├── CLAUDE.md
├── AGENTS.md
│
├── docs/
│   └── architecture/
│
└── código do próprio GFM.Template.CMS
```

Não utilizar outro projeto como referência implícita.

---

# 8. REGRA DE SINCRONIZAÇÃO

Todos estes elementos devem representar o mesmo sistema:

```text
prompts.md
        ↓
PROJECT_STRUCTURE.md
        ↓
PROJECT_SKILLS.md
        ↓
AUDIO_INTELLIGENCE.md
        ↓
SEED_FAKE_DATA.md
        ↓
ADRs
        ↓
C4 / Structurizr
        ↓
Draw.io
        ↓
Código
        ↓
Infraestrutura
        ↓
Docker
        ↓
Kubernetes
        ↓
AWS TARGET
        ↓
Testes
        ↓
Documentação
```

Não permitir divergência silenciosa entre documentação e implementação.

---

# 9. INÍCIO DA EXECUÇÃO

Comece pela instalação e preparação do `GFM.Template.CMS`.

Primeiro execute somente:

```text
1. Localizar a raiz do GFM.Template.CMS.

2. Confirmar acesso ao:
   - Kit IA Dev;
   - Templates por Stack;
   - Skills Avançadas.

3. Confirmar a existência de:
   - prompts.md;
   - PROJECT_STRUCTURE.md;
   - PROJECT_SKILLS.md;
   - SEED_FAKE_DATA.md.

4. Identificar a ferramenta de IA de código utilizada.

5. Identificar onde essa ferramenta espera encontrar Agent Skills.

6. Não gerar código da aplicação ainda.

7. Apresentar:
   - itens encontrados;
   - itens ausentes;
   - próximo passo.

8. Aguardar minha confirmação para continuar o setup.
```

## CI/CD obrigatório

O CI/CD oficial deste template é GitHub Actions. Criar `.github/workflows` com pipelines de build/test/quality, security scanning, Docker build/publish e deploy por ambiente. Não substituir por GitLab CI.

## Content Intelligence obrigatório

Ler e cumprir `AI_CONTENT_INTELLIGENCE.md`. Todas as possibilidades de provider devem existir como adapters/configurações selecionáveis por tenant, porém integrações que exigem credenciais externas devem iniciar desabilitadas e nunca impedir o ambiente local de subir.

## BYOAI — Bring Your Own AI

70. Implementar BYOAI por tenant com modos `ServerManaged`, `CustomerManaged` e `Hybrid`.
71. Resolver provider separadamente para LLM, Embeddings, Speech-to-Text, Text-to-Speech, Vision e Reranker quando aplicável.
72. Preparar adapters/configuração para OpenAI, Azure OpenAI, Anthropic, Google Gemini, AWS Bedrock e endpoints compatíveis com OpenAI (Ollama/vLLM/equivalentes), mantendo Fake/Local para desenvolvimento.
73. Credenciais do cliente devem ser `SecretReference`, nunca texto puro no banco/config versionada.
74. Fallback para IA do servidor é opt-in por tenant, auditável e deve poder ser completamente bloqueado.
75. Implementar quotas, telemetria e contabilização de uso/custo por tenant/provider/capacidade sem expor secrets ou conteúdo sensível.
76. Criar testes para resolução BYOAI, isolamento, fallback, ausência de secret, falha de provider e sanitização de logs.
