# Audio Intelligence — GFM.Template.CMS

> Pipeline especializado pertencente ao `AI Content Intelligence & Storage Orchestration`. Ver também `AI_CONTENT_INTELLIGENCE.md`.

## Objetivo

Adicionar ao template uma capacidade reutilizável para ingestão de áudio/vídeo, transcrição, enriquecimento com LLM, indexação RAG e automações n8n.

## Pipeline

```text
Upload / URL / gravação
  → Object Storage
  → Job assíncrono
  → FFmpeg
  → Speech-to-Text
  → Transcrição segmentada
  → LLM enrichment
  → RAG / Vector Store (opcional)
  → n8n / Webhooks (opcional)
```

## Formatos iniciais

- MP3
- WAV
- M4A
- MP4

Os limites de tamanho, duração e MIME types devem ser configuráveis por ambiente.

## Persistência

**Storage:** o arquivo pode permanecer no provider configurado pelo tenant (Local, MinIO, S3, Google Drive, OneDrive ou SharePoint). Cópias temporárias são permitidas somente durante o processamento e seguem TTL/cleanup. MinIO/S3 continuam disponíveis como object storage próprio/fallback.

**MySQL:** job de processamento, status, metadados, referências de storage, segmentos/transcrição conforme estratégia definida, auditoria e vínculo com usuário/tenant.

**Vector Store:** embeddings de segmentos autorizados para pesquisa semântica/RAG.

**Redis:** cache/progresso temporário quando houver benefício real; não é fonte definitiva do job.

## Processamento assíncrono

Estados sugeridos:

```text
Uploaded → Queued → ProcessingMedia → Transcribing → Enriching → Indexing → Completed
                                                                  └→ Failed
```

O request de upload não deve permanecer aberto durante toda a transcrição. O `Worker.Media` processa o job com retry, idempotência e observabilidade.

## Abstrações

```csharp
IMediaProcessor
ISpeechToTextProvider
ITranscriptionService
ITranscriptionEnrichmentService
IAutomationWebhookClient
```

Providers concretos pertencem à Infrastructure. Deve existir opção Fake/Local para desenvolvimento e testes sem serviço pago.

## FFmpeg

Responsabilidades:

- extrair áudio de vídeo;
- converter codec/formato quando necessário;
- normalizar parâmetros de áudio;
- dividir arquivos quando exigido pelo provider;
- obter metadados técnicos.

FFmpeg é dependência de infraestrutura/container.

## Enriquecimento por LLM

Saída estruturada deve poder produzir:

- resumo;
- tópicos;
- capítulos;
- decisões;
- tarefas;
- entidades;
- palavras-chave;
- classificação configurável.

Não inventar participantes, decisões ou tarefas ausentes da transcrição. Sempre preservar vínculo com segmentos/timestamps quando possível.

## RAG

A transcrição pode ser fragmentada, gerar embeddings e ser indexada. O retrieval deve respeitar usuário, tenant, permissões e política de retenção.

Exemplo de consulta futura:

```text
“O que foi decidido na reunião sobre Docker?”
```

O sistema recupera segmentos autorizados e fornece contexto ao LLM.

## n8n

n8n é opcional e funciona como camada de automação externa. Exemplos:

- transcrição concluída → webhook n8n;
- n8n envia resumo por e-mail;
- n8n cria tarefa em sistema externo;
- n8n recebe arquivo de fonte autorizada e chama API de ingestão;
- n8n dispara integrações posteriores.

Nunca usar n8n para contornar CQRS/Application/Domain ou acessar tabelas diretamente.

## Segurança

- validar MIME type, extensão, tamanho e assinatura quando aplicável;
- URLs de storage devem ser privadas/presigned quando necessário;
- secrets fora do código-fonte;
- autorização antes de consultar/transcrever/indexar;
- proteção contra prompt injection em transcrições usadas em RAG;
- retenção e exclusão configuráveis;
- auditoria de acesso e processamento.

## Observabilidade

Instrumentar com OpenTelemetry:

- upload;
- duração da mídia;
- tempo de FFmpeg;
- tempo de transcrição;
- provider utilizado;
- tokens/custo quando aplicável;
- enriquecimento LLM;
- indexação;
- chamadas n8n;
- retries/falhas.

## Local First → AWS Target

```text
LOCAL                         AWS TARGET
MinIO                  →      S3
Fake/Local STT          →      Provider configurado / serviço AWS quando adotado
Docker Worker.Media     →      ECS/EKS/Lambda somente se tecnicamente adequado
Vector Store local      →      Vector Store definido na arquitetura AWS
n8n Docker opcional     →      n8n hospedado/externo opcional
OpenTelemetry           →      backend de observabilidade compatível
```

A escolha de serviços AWS concretos deve ser registrada em ADR e não deve quebrar o princípio LOCAL FIRST.

## Testes mínimos

- upload válido/inválido;
- autorização;
- job assíncrono;
- provider fake de transcrição;
- falha/retry/idempotência;
- enriquecimento estruturado;
- indexação RAG;
- isolamento de permissões;
- webhook n8n fake;
- integração do Worker.Media;
- observabilidade básica.
