# AI Content Intelligence & Storage Orchestration — GFM.Template.CMS

## Objetivo

Evoluir o processamento de áudio para uma capacidade multi-tenant de ingestão, recuperação, análise e automação de documentos, áudios e vídeos armazenados em provedores configuráveis por cliente/perfil.

## Princípio central

O Domain e a Application não conhecem Google Drive, OneDrive, SharePoint, S3, MinIO, FFmpeg, Whisper, Bedrock, n8n ou qualquer SDK concreto. Toda integração é feita por abstrações e adapters em Infrastructure.

## Storage Providers configuráveis por tenant

Providers previstos e pré-configurados:

- Local File System — desenvolvimento/testes;
- MinIO — object storage local/container;
- Amazon S3 — AWS target;
- Google Drive;
- Microsoft OneDrive;
- Microsoft SharePoint;
- extensão futura por adapter sem alteração do Domain.

Cada tenant pode possuir uma ou mais `StorageConnection`, com provider, pasta/root, política de sincronização, credencial referenciada por secret, tipos MIME permitidos e regras de processamento.

```text
Tenant
  ├── StorageConnections
  │    ├── Provider
  │    ├── SecretReference
  │    ├── RootFolder
  │    ├── Enabled
  │    └── SyncPolicy
  ├── AIProfile
  │    ├── LLMProvider
  │    ├── SpeechToTextProvider
  │    ├── EmbeddingProvider
  │    └── VectorStoreProvider
  └── ProcessingPolicy
       ├── AllowedMimeTypes
       ├── MaxFileSize
       ├── AutoProcess
       ├── RAGEnabled
       ├── AutomationEnabled
       └── RetentionPolicy
```

Credenciais nunca são armazenadas em texto puro. Persistir apenas `SecretReference`. Localmente usar secret/configuração segura; AWS TARGET usa Secrets Manager/KMS quando aplicável.

## Abstrações mínimas

```csharp
IStorageProvider
IStorageProviderFactory
IContentIngestionService
IContentTypeDetector
IDocumentContentExtractor
IMediaProcessor
ISpeechToTextProvider
IContentAnalysisOrchestrator
IEmbeddingProvider
IVectorStore
IAutomationProvider
```

`IStorageProvider` deve suportar, conforme capacidade do provider: metadata, listagem, download/stream, upload, move/copy e health check. Capacidades opcionais devem ser declaradas, não presumidas.

## Content Orchestrator

```text
Google Drive / OneDrive / SharePoint / S3 / MinIO / Local
                           │
                           ▼
                  Storage Orchestrator
                           │
                    Resolve Tenant/Profile
                           │
                           ▼
                    Content Ingestion
                           │
                    Detect MIME / Type
                           │
       ┌───────────────────┼───────────────────┐
       ▼                   ▼                   ▼
   Document              Audio               Video
 PDF/DOCX/XLSX/        MP3/WAV/M4A         MP4/etc.
 TXT/CSV/etc.             │                   │
       │                FFmpeg              FFmpeg
       │                   │             extract audio
       ▼                   └─────────┬─────────┘
 Document Parser                    ▼
       │                     Speech-to-Text
       └───────────────┬─────────────┘
                       ▼
                 Normalized Text
                       │
                       ▼
                 AI Orchestrator
                ┌──────┼──────┐
                ▼      ▼      ▼
               LLM    RAG   Agents/Tools
                └──────┼──────┘
                       ▼
              Structured Result
                       │
                 n8n / Webhooks
```

## Documentos

Pipeline inicial deve prever PDF, TXT, CSV, DOCX e XLSX. Parsers devem ser substituíveis e protegidos contra arquivos inválidos/maliciosos. Conteúdo extraído é normalizado antes de LLM/RAG.

## Áudio e vídeo

Manter `AUDIO_INTELLIGENCE.md` como especificação especializada. FFmpeg extrai/normaliza mídia e `ISpeechToTextProvider` converte fala em transcrição. O resultado entra no mesmo pipeline de conteúdo normalizado.

## Perfil de processamento

Exemplos suportados por configuração:

```text
Tenant A: GoogleDrive + OpenAI + Whisper + RAG + n8n
Tenant B: OneDrive + Bedrock + AWS Transcribe + RAG
Tenant C: SharePoint + provider configurado + RAG
Tenant D: S3 + processamento documental
Tenant E: MinIO/Local + Fake/Local providers para desenvolvimento
```

Nenhum provider externo é obrigatório para iniciar o projeto. Providers que exigem OAuth/API key permanecem desabilitados até configuração válida.

## Sincronização e eventos

A ingestão pode ocorrer por:

- upload pela aplicação;
- polling agendado quando necessário;
- webhook/evento do provider quando suportado;
- n8n chamando a API pública de ingestão;
- job manual/reprocessamento.

O sistema deve ser idempotente por tenant + provider + external file id/version/hash para evitar processamento duplicado.

## Temporários e retenção

Arquivos externos devem preferencialmente ser lidos por stream ou copiados para área temporária controlada durante o processamento. O sistema não deve duplicar permanentemente o arquivo do cliente sem política explícita. Temporários devem possuir TTL/cleanup.

Resultados derivados podem ser persistidos conforme política: metadados no MySQL, conteúdo flexível/auditoria quando aplicável no MongoDB, embeddings no Vector Store e artefatos derivados no storage configurado.

## n8n

n8n é adapter de automação, não orquestrador de domínio. Pode detectar eventos externos ou receber eventos de conclusão e integrar e-mail, webhooks e sistemas terceiros. Nunca acessa tabelas de negócio diretamente para contornar CQRS/Application.

## Observabilidade

OpenTelemetry deve incluir tenant (sem expor dado sensível), provider, content type, tamanho, duração, etapas, latência, retries, falhas, tokens/custo quando aplicável e correlation/job id.

## Segurança

- OAuth2/OIDC conforme provider;
- tokens e secrets fora do banco em texto puro;
- menor privilégio possível;
- isolamento multi-tenant obrigatório;
- validação MIME/extensão/assinatura/tamanho;
- antivírus/malware scanning como extensão configurável;
- proteção contra prompt injection em conteúdo ingerido;
- autorização aplicada também no retrieval/RAG;
- logs não devem conter tokens nem conteúdo sensível integral;
- política de retenção, exclusão e reprocessamento por tenant.

## Configuração sugerida

```yaml
ContentIntelligence:
  Enabled: true
  DefaultStorageProvider: MinIO
  Providers:
    Local: { Enabled: true }
    MinIO: { Enabled: true }
    S3: { Enabled: false }
    GoogleDrive: { Enabled: false }
    OneDrive: { Enabled: false }
    SharePoint: { Enabled: false }
  Processing:
    Documents: true
    Audio: true
    Video: true
    Rag: true
    Automation: false
```

A configuração por tenant sobrescreve defaults permitidos pelo ambiente.

## Testes mínimos

- resolução de provider por tenant;
- isolamento entre tenants;
- fake providers de storage;
- Google Drive/OneDrive/SharePoint/S3 adapters cobertos por contract tests/mocks;
- detecção de conteúdo;
- documentos, áudio e vídeo;
- idempotência e versionamento;
- falha/retry;
- RAG respeitando tenant/permissão;
- secrets nunca retornados em DTOs/logs;
- n8n/webhooks fake;
- cleanup de temporários.

# BYOAI — Bring Your Own AI

Cada tenant pode escolher entre `ServerManaged`, `CustomerManaged` e `Hybrid`.

- `ServerManaged`: usa providers e credenciais administrados pelo servidor/plataforma.
- `CustomerManaged`: usa providers/endpoints/credenciais pertencentes ao cliente. A plataforma não deve consumir provider do servidor sem autorização explícita.
- `Hybrid`: permite combinar providers do cliente e do servidor por capacidade e definir fallback explícito.

A configuração é por capacidade, e não por um único provider global. Capacidades mínimas: `LLM`, `Embeddings`, `SpeechToText`, `TextToSpeech`, `Vision` e, quando aplicável, `Reranker`.

Providers/adapters previstos devem incluir OpenAI, Azure OpenAI, Anthropic, Google Gemini, AWS Bedrock e endpoint compatível com OpenAI para servidores privados/locais como Ollama/vLLM ou equivalentes. Speech-to-Text deve continuar desacoplado e permitir providers cloud ou local/fake. Nem todos precisam estar habilitados por padrão; adapters externos só ficam ativos quando houver configuração e secret válidos.

Exemplo de perfil:

```yaml
AIProfile:
  Mode: CustomerManaged
  Capabilities:
    LLM:
      Provider: AzureOpenAI
      SecretReference: tenant/acme/azure-openai
    Embeddings:
      Provider: OpenAI
      SecretReference: tenant/acme/openai
    SpeechToText:
      Provider: AwsTranscribe
      SecretReference: tenant/acme/aws
    Vision:
      Provider: Gemini
      SecretReference: tenant/acme/gemini
  Fallback:
    AllowServerManaged: false
```

Criar abstrações/resolvers equivalentes a `IAIProfileResolver`, `IAIProviderResolver`, `ILLMProvider`, `IEmbeddingProvider`, `ISpeechToTextProvider`, `ITextToSpeechProvider` e `IVisionProvider`. Domain/Application não podem depender de SDK concreto.

Fallback deve ser opt-in e auditável. Deve ser possível configurar: sem fallback; fallback para outro provider do próprio cliente; ou fallback para provider ServerManaged autorizado. Nunca consumir quota/IA do servidor silenciosamente.

Credenciais BYOAI nunca são persistidas em texto puro. Persistir apenas `SecretReference`; resolver secrets em runtime. Local/dev pode usar mecanismo seguro apropriado; AWS Target deve prever Secrets Manager/KMS. Logs, traces, métricas e erros nunca devem expor API keys, bearer tokens ou secrets.

Registrar por tenant/provider/capacidade: chamadas, modelo, latência, tokens/unidades quando disponíveis, custo estimado quando possível, falhas, retries e uso de fallback. Permitir quotas, limites e políticas por tenant.

Testes mínimos: resolução de perfil por tenant; isolamento de credenciais; seleção por capacidade; ServerManaged/CustomerManaged/Hybrid; fallback permitido e bloqueado; provider indisponível; secret ausente; prevenção de vazamento de secrets em logs; contabilização por tenant.
