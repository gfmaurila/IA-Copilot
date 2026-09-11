# AGENTS_SITE.md

## 1. Objetivo

Este arquivo define as regras de implementação do **Marketplace Público da Quota Labs**.

O agente de IA / GitHub Copilot deve utilizar este documento como especificação de arquitetura, organização, comportamento e implementação das telas públicas do projeto.

O Marketplace Público é a camada de acesso público da plataforma. Ele permite descoberta de advogados, triagem jurídica, busca por área, visualização de perfis, perguntas jurídicas, artigos e consultas online.

> **Arquitetura atual:** o Front-End é um único core React/TypeScript, organizado em quatro módulos funcionais: `site`, `admin`, `client` e `lawyers`. Os módulos compartilham infraestrutura, design system, componentes genéricos, utilitários, modelos e serviços comuns, mas mantêm páginas, rotas e regras de domínio isoladas.

---

## 2. Escopo deste agente

Este agente atua prioritariamente no módulo público `site`, dentro do mesmo core React do Marketplace:

```text
Marketplace/FrontEnd/src/modules/site/
```

O core também contém os módulos:

```text
Marketplace/FrontEnd/src/modules/admin/
Marketplace/FrontEnd/src/modules/client/
Marketplace/FrontEnd/src/modules/lawyers/
```

Ao trabalhar no `site`, não alterar regras específicas de `admin`, `client` ou `lawyers` sem solicitação explícita. Código realmente compartilhável deve ficar em `src/shared/` ou outra camada comum definida pela arquitetura, evitando duplicação entre módulos.

Integrações entre módulos devem ocorrer por contratos, rotas, services, estado compartilhado explicitamente definido ou API. Um módulo não deve importar páginas ou componentes de domínio internos de outro módulo.

---

## 3. Estrutura oficial do repositório

```text
Marketplace/
├── BackEnd/
├── docs/
│   └── screens/
│       ├── 1. Front End/
│       ├── 2. Back End - Admin/
│       ├── 3. Back End - Client/
│       └── 4. Back End - Independent Lawyer/
│
└── FrontEnd/
    ├── public/
    ├── src/
    │   ├── app/
    │   ├── modules/
    │   │   ├── site/
    │   │   ├── admin/
    │   │   ├── client/
    │   │   └── lawyers/
    │   ├── shared/
    │   └── main.tsx
    ├── AGENTS_SITE.md
    ├── Dockerfile
    ├── docker-compose.yml
    ├── package.json
    ├── tsconfig.json
    └── vite.config.ts
```

Existe **um único core React**. Não criar quatro projetos React independentes, quatro `package.json` ou quatro cópias do design system sem necessidade arquitetural explícita.

---

## 4. Fonte de verdade visual

As referências visuais oficiais do Marketplace Público ficam em:

```text
../docs/screens/1. Front End/
```

Antes de implementar ou alterar uma tela, o agente DEVE:

1. localizar a imagem correspondente;
2. analisar a composição visual;
3. identificar elementos compartilhados;
4. verificar componentes já existentes;
5. reproduzir layout, hierarquia, espaçamentos, tipografia, bordas, cards, formulários e estados;
6. preservar a identidade visual Quota Labs;
7. adaptar responsivamente para desktop, tablet e mobile;
8. não inventar redesign quando existir referência visual.

As imagens são referência de UX/UI. O código deve ser componentizado e sustentável, mesmo quando a imagem represente uma página inteira.

---

## 5. Inventário visual atualmente disponível

```text
docs/screens/1. Front End/
├── 01 Homepage 02.png
├── 02 Descreva seu caso.png
├── 03 Buscar Advogados.png
├── 04 Descreva seu Caso 01 - 02 etapa.png
├── 04 Descreva seu Caso 01 - 02 etapa - outro problema.png
├── 04 Descreva seu Caso 01 Localizacao.png
├── 04 Descreva seu Caso 01 Urgencia e Fase.png
├── 04 Descreva seu Caso 01 Documentos.png
├── 04 Descreva seu Caso 01 Resumo e contato.png
├── 04 Descreva seu Caso 03.png
├── 05 Perfil do advogado 02.png
├── 06 Advogados por Área 01.png
├── 07 Consulta Jurídica Online 01.png
├── 08 Pergunte a um Advogado 01.png
├── 08 Pergunte a um Advogado resposta juridica.png
└── 09 Artigos de Advogados.png
```

O inventário funcional do produto também prevê páginas públicas adicionais sem mockup disponível. Essas páginas devem ser preparadas na arquitetura, mas NÃO devem receber um design arbitrário antes de existir especificação suficiente.

---

## 6. Stack do Front-End

Usar como padrão:

- React
- TypeScript
- Vite
- React Router
- CSS responsivo
- ESLint
- Prettier
- dados mockados em JSON durante a fase inicial
- camada de services preparada para APIs REST

Evitar dependências desnecessárias.

Não usar dados de negócio fixos diretamente dentro de componentes de apresentação quando eles puderem ser representados por mocks, propriedades ou services.

---

## 7. Estrutura recomendada do FrontEnd

```text
FrontEnd/
├── public/
│   └── assets/
│       ├── images/
│       ├── icons/
│       └── logos/
│
├── src/
│   ├── app/
│   │   ├── App.tsx
│   │   ├── router.tsx
│   │   └── providers.tsx
│   │
│   ├── modules/
│   │   ├── site/
│   │   │   ├── components/
│   │   │   ├── layouts/
│   │   │   ├── pages/
│   │   │   ├── routes/
│   │   │   ├── mocks/
│   │   │   ├── models/
│   │   │   ├── services/
│   │   │   ├── hooks/
│   │   │   └── seo/
│   │   ├── admin/
│   │   ├── client/
│   │   └── lawyers/
│   │
│   ├── shared/
│   │   ├── components/
│   │   │   ├── ui/
│   │   │   └── layout/
│   │   ├── hooks/
│   │   ├── models/
│   │   ├── services/
│   │   ├── utils/
│   │   ├── constants/
│   │   ├── validation/
│   │   └── styles/
│   │
│   └── main.tsx
│
├── .env.example
├── Dockerfile
├── docker-compose.yml
├── package.json
├── tsconfig.json
├── vite.config.ts
└── AGENTS_SITE.md
```

### 7.1 Regra de separação dos módulos

- `modules/site`: marketplace público e páginas indexáveis.
- `modules/admin`: operação administrativa.
- `modules/client`: área autenticada do cliente.
- `modules/lawyers`: área autenticada do advogado.
- `shared`: somente código genérico e reutilizável entre dois ou mais módulos.

Não mover regra de negócio específica para `shared` apenas para reduzir caminhos de importação. O compartilhamento deve ser intencional.

### 7.2 Dependências permitidas

```text
app -> modules + shared
modules -> shared
shared -> shared
```

Evitar:

```text
site -> admin
site -> client
site -> lawyers
admin -> client
client -> lawyers
```

Quando dois módulos precisarem da mesma abstração, extrair a parte genérica para `shared`.

---

## 8. Layout público compartilhado

Criar um `PublicLayout` reutilizado pelas páginas públicas.

Componentes esperados:

```text
Header
MainNavigation
Footer
Breadcrumb
PageContainer
Section
LoadingState
EmptyState
ErrorState
```

O Header deve suportar, conforme a referência:

- logo Quota Labs;
- Buscar Advogados;
- Áreas Jurídicas;
- Pergunte a um Advogado;
- Artigos;
- Para Advogados;
- ajuda;
- Entrar;
- Descobrir meu caso.

Não duplicar Header e Footer em cada página.

---

## 9. Rotas principais

Usar URLs amigáveis e consistentes.

```text
/                               Homepage
/descreva-seu-caso              Introdução da triagem
/descreva-seu-caso/area         Etapa 1 - área jurídica
/descreva-seu-caso/detalhes     Etapa 2 - detalhes
/descreva-seu-caso/localizacao  Etapa 3 - localização
/descreva-seu-caso/urgencia     Etapa 4 - urgência e fase
/descreva-seu-caso/documentos   Etapa 5 - documentos
/descreva-seu-caso/resumo       Etapa 6 - resumo e contato

/advogados                      Busca de advogados
/advogados/area/:slug           Advogados por área
/advogados/:id                  Perfil público do advogado

/consulta-juridica              Consulta jurídica online

/pergunte-a-um-advogado         Perguntas públicas
/perguntas/:id                  Pergunta e resposta jurídica

/artigos                        Artigos de advogados
/artigos/:slug                  Artigo individual
```

Rotas adicionais previstas no inventário devem ser adicionadas quando implementadas:

```text
/como-funciona
/areas-juridicas
/para-advogados
/sobre
/contato
/ajuda
/termos-de-uso
/politica-de-privacidade
/politica-de-cookies
/lgpd
/politica-de-avaliacoes
/perguntas-frequentes
```

---

# 10. TELAS

## MP-001 - Homepage

Referência:

```text
docs/screens/1. Front End/01 Homepage 02.png
```

Rota:

```text
/
```

Objetivo: apresentar o Marketplace e conduzir o visitante para busca, triagem, perfis, perguntas, artigos ou cadastro de advogado.

Componentes sugeridos:

```text
HomeHero
LawyerQuickSearch
TrustBadges
CaseDiscoveryCard
PopularLegalAreas
HowItWorks
FeaturedLawyers
LegalFAQPreview
ArticlePreview
LawyerCTA
PublicFooter
```

Ações principais:

- Buscar
- Descobrir meu caso
- Como funciona?
- Ver áreas jurídicas
- Ver perfil
- Ver todos os advogados
- Ver perguntas
- Ver artigos
- Cadastrar meu perfil
- Ver planos

---

## MP-002 - Introdução "Descreva seu caso"

Referência:

```text
docs/screens/1. Front End/02 Descreva seu caso.png
```

Rota:

```text
/descreva-seu-caso
```

Objetivo: introduzir o fluxo de intake jurídico e explicar confiança, privacidade e funcionamento.

A ação principal inicia a etapa 1.

---

## MP-003 - Buscar Advogados

Referência:

```text
docs/screens/1. Front End/03 Buscar Advogados.png
```

Rota:

```text
/advogados
```

Componentes:

```text
LawyerSearchHero
LawyerSearchForm
LawyerFilters
LawyerSearchResult
CompatibilityBadge
LawyerList
SearchSorting
SearchViewMode
Pagination
```

Filtros observados:

- problema;
- área jurídica;
- subcategoria;
- cidade/estado;
- atendimento;
- ordenação;
- busca avançada.

Cada advogado deve ser renderizado a partir de um objeto tipado, nunca de HTML duplicado.

---

## MP-004 - Fluxo "Descreva seu caso"

O intake é um único fluxo multi-etapas. Não criar seis implementações independentes do estado.

Criar um estado/modelo compartilhado, por exemplo:

```ts
interface CaseIntake {
  legalArea?: string;
  caseDetail?: string;
  description?: string;
  servicePreference?: 'online' | 'presencial' | 'ambos';
  location?: CaseLocation;
  urgency?: string;
  stage?: string;
  importantDate?: string;
  documents?: CaseDocument[];
  contact?: CaseContact;
  privacyAccepted: boolean;
}
```

O estado deve sobreviver à navegação entre etapas.

### Etapa 1 - Tipo de problema

Referências:

```text
docs/screens/1. Front End/04 Descreva seu Caso 03.png
```

Rota:

```text
/descreva-seu-caso/area
```

Áreas mostradas incluem:

- Imobiliário
- Saúde
- Trabalhista Executivo
- Bets / iGaming
- Contratos B2B
- Recuperação de Crédito B2B
- Seguros Alto Valor
- Societário
- Herança e Inventário
- Franquias

As áreas devem vir de mock/API.

### Etapa 2 - Detalhes do caso

Referências:

```text
docs/screens/1. Front End/04 Descreva seu Caso 01 - 02 etapa.png
docs/screens/1. Front End/04 Descreva seu Caso 01 - 02 etapa - outro problema.png
```

Rota:

```text
/descreva-seu-caso/detalhes
```

Os detalhes dependem da área selecionada.

Para Bets / iGaming, a referência mostra exemplos como saque negado, conta bloqueada, ganhos cancelados, KYC, retenção de saldo, afiliado não pago, rescisão, chargeback, ludopatia, superendividamento e outro problema.

A opção "Outro problema" deve permitir descrição textual.

Não codificar as perguntas específicas diretamente na página. Modelar configuração por área.

### Etapa 3 - Localização

Referência:

```text
docs/screens/1. Front End/04 Descreva seu Caso 01 Localizacao.png
```

Rota:

```text
/descreva-seu-caso/localizacao
```

Campos:

- preferência de atendimento;
- CEP;
- cidade;
- estado;
- bairro/região opcional;
- indicação se o caso ocorreu em outra cidade;
- cidade/estado do problema;
- observações.

### Etapa 4 - Urgência e fase

Referência:

```text
docs/screens/1. Front End/04 Descreva seu Caso 01 Urgencia e Fase.png
```

Rota:

```text
/descreva-seu-caso/urgencia
```

Coletar:

- nível de urgência;
- fase do caso;
- data/prazo importante;
- tipo de evento;
- observações.

### Etapa 5 - Documentos

Referência:

```text
docs/screens/1. Front End/04 Descreva seu Caso 01 Documentos.png
```

Rota:

```text
/descreva-seu-caso/documentos
```

Suportar seleção de tipos de documentos e upload.

Formatos indicados na referência:

```text
PDF
JPG
PNG
DOC
DOCX
```

Tamanho máximo visualmente especificado:

```text
10 MB por arquivo
```

A implementação mock deve validar extensão e tamanho no cliente.

O upload real deverá ficar isolado em service para futura API/storage.

### Etapa 6 - Resumo e contato

Referência:

```text
docs/screens/1. Front End/04 Descreva seu Caso 01 Resumo e contato.png
```

Rota:

```text
/descreva-seu-caso/resumo
```

Exibir resumo consolidado e coletar:

- nome;
- e-mail;
- WhatsApp;
- cidade;
- melhor horário;
- resumo complementar;
- consentimento de privacidade.

O botão final deve chamar uma função de service, mesmo enquanto estiver usando mock.

Exemplo:

```ts
caseRequestService.submit(intake)
```

---

## MP-005 - Perfil público do advogado

Referência:

```text
docs/screens/1. Front End/05 Perfil do advogado 02.png
```

Rota:

```text
/advogados/:id
```

Componentes:

```text
LawyerProfileHeader
VerificationBadge
LawyerRating
PracticeTags
CompatibilityPanel
PracticeTopics
LawyerAttributes
LocationCard
VerifiedProfileCard
RequiredDocumentsCard
LawyerFAQ
RelatedContent
LawyerContactPanel
```

Informações modeladas:

- nome;
- OAB;
- foto;
- verificação;
- áreas;
- localização;
- atendimento;
- experiência;
- avaliação;
- quantidade de avaliações;
- idiomas;
- público atendido;
- temas frequentes;
- conteúdos;
- FAQs.

O formulário lateral de contato deve ter validação e consentimento.

---

## MP-006 - Advogados por Área

Referência:

```text
docs/screens/1. Front End/06 Advogados por Área 01.png
```

Rota:

```text
/advogados/area/:slug
```

Filtros:

- área;
- subáreas;
- localização;
- atendimento;
- tipo de cliente;
- idiomas;
- disponibilidade;
- faixa de preço;
- ordenação.

Criar filtros reutilizáveis com a busca geral.

---

## MP-007 - Consulta Jurídica Online

Referência:

```text
docs/screens/1. Front End/07 Consulta Jurídica Online 01.png
```

Rota:

```text
/consulta-juridica
```

Componentes:

```text
ConsultationHero
ConsultationBenefits
ConsultationSteps
ConsultedAreas
ConsultationLawyers
ConsultationScheduler
ConsultationSummary
ConsultationSecurity
FAQ
RelatedContent
```

O agendamento deve modelar:

- tipo: vídeo/chat;
- duração;
- data;
- horário;
- preço;
- advogado quando aplicável.

Valores exibidos na referência são mock e NÃO devem virar regra de negócio fixa.

Criar:

```ts
consultationService.getOptions()
consultationService.getAvailability()
consultationService.createBooking()
```

---

## MP-008 - Pergunte a um Advogado

Referência:

```text
docs/screens/1. Front End/08 Pergunte a um Advogado 01.png
```

Rota:

```text
/pergunte-a-um-advogado
```

Componentes:

```text
AskLawyerHero
QuestionForm
QuestionGuidelines
QuestionStatistics
HowQuestionsWork
PopularQuestions
TopContributors
InformationalDisclaimer
```

A pergunta pública deve respeitar as mensagens visuais de anonimato, moderação e caráter informativo.

---

## MP-009 - Pergunta respondida

Referência:

```text
docs/screens/1. Front End/08 Pergunte a um Advogado resposta juridica.png
```

Rota:

```text
/perguntas/:id
```

Componentes:

```text
QuestionDetail
LawyerAnswer
AnsweringLawyerCard
ConsultationCTA
RelatedQuestions
AskAnotherQuestion
RelatedLawyers
InformationalDisclaimer
```

A resposta jurídica publicada é conteúdo informativo. Não apresentá-la na UI como substituição de consulta jurídica individual.

---

## MP-010 - Artigos de Advogados

Referência:

```text
docs/screens/1. Front End/09 Artigos de Advogados.png
```

Rota:

```text
/artigos
```

Componentes:

```text
ArticleHero
ArticleSearch
LegalAreaCarousel
FeaturedArticle
ArticleList
PopularCategories
MostReadArticles
NewsletterCard
```

Modelar:

- título;
- slug;
- resumo;
- imagem;
- autor;
- área;
- data;
- tempo de leitura;
- visualizações/popularidade quando disponível.

---

## MP-011 - Artigo individual

O inventário funcional prevê esta página, embora o mockup específico não esteja incluído no conjunto atual.

Rota:

```text
/artigos/:slug
```

Não inventar um layout definitivo sem referência. É permitido criar apenas estrutura técnica coerente com o design system existente quando necessário para navegação.

---

# 11. Componentes reutilizáveis obrigatórios

Sempre verificar reutilização antes de criar novo componente.

Priorizar:

```text
Button
Input
Select
Textarea
Checkbox
Radio
Card
Badge
Tag
Avatar
Rating
Pagination
Accordion
Breadcrumb
Modal
Drawer
Tooltip
Alert
Skeleton
EmptyState
ErrorState
FileUpload
StepProgress
LegalAreaCard
LawyerCard
ArticleCard
QuestionCard
TrustBadge
PrivacyNotice
MarketplaceDisclaimer
```

Não criar `ButtonHome`, `ButtonLawyer`, `ButtonArticle` quando um `Button` configurável resolver.

---

# 12. Design system

Criar tokens centralizados para:

```text
cores
tipografia
font sizes
font weights
spacing
border radius
shadows
breakpoints
z-index
transitions
```

A identidade observada usa predominantemente:

- branco;
- azul profundo/navy;
- azul vivo para ações;
- fundos azulados muito claros;
- bordas suaves;
- estados verdes para confiança/disponibilidade;
- amarelo/laranja para avaliações e avisos específicos.

Não espalhar hexadecimais arbitrários pelos componentes.

---

# 13. Responsividade

Todas as telas devem funcionar em:

```text
Desktop >= 1200px
Tablet 768px - 1199px
Mobile < 768px
```

As imagens fornecidas são principalmente desktop. A adaptação mobile deve preservar hierarquia e funcionalidade, não simplesmente reduzir tudo.

Em mobile:

- filtros laterais podem virar Drawer;
- grids devem colapsar;
- sidebars devem ir abaixo do conteúdo ou abrir sob demanda;
- tabelas/listas densas devem virar cards quando apropriado;
- botões essenciais devem permanecer acessíveis;
- navegação deve possuir menu mobile;
- wizard deve continuar indicando etapa atual.

---

# 14. Mocks

Enquanto a API não estiver disponível, usar JSON em:

```text
src/modules/site/mocks/
```

Sugestão:

```text
mocks/
├── lawyers.json
├── legalAreas.json
├── caseIntake.json
├── articles.json
├── questions.json
├── consultations.json
├── faq.json
└── locations.json
```

Mocks devem representar futuros contratos de API.

Nunca consumir JSON diretamente em dezenas de componentes. Encapsular acesso nos services.

---

# 15. Models / DTOs

Criar tipos TypeScript para entidades relevantes.

Exemplos:

```text
Lawyer
LawyerProfile
LegalArea
LegalSubarea
CaseIntake
CaseRequest
CaseDocument
Location
Article
Question
Answer
Consultation
Review
Pagination
ApiResponse
```

Evitar `any`.

---

# 16. Services

Criar uma camada:

```text
src/modules/site/services/
```

Exemplos:

```text
lawyerService.ts
legalAreaService.ts
caseRequestService.ts
articleService.ts
questionService.ts
consultationService.ts
```

Durante o mock:

```text
Page -> Service -> Mock JSON
```

No futuro:

```text
Page -> Service -> HTTP API
```

A página não deve precisar ser reescrita quando o mock for substituído pela API.

---

# 17. Estado do wizard

O fluxo "Descreva seu caso" deve possuir estado compartilhado.

Pode ser implementado com Context + reducer ou solução equivalente simples.

Requisitos:

- preservar dados entre etapas;
- permitir Voltar sem perder valores;
- validar antes de Continuar;
- impedir acesso inconsistente às etapas quando necessário;
- permitir editar informações antes do envio;
- limpar o estado após conclusão confirmada.

Não usar seis estados desconectados.

---

# 18. Formulários, validações e máscaras

Todo formulário do Marketplace deve possuir validação de preenchimento, validação de formato, mensagens de erro claras e máscaras adequadas para os campos que exigirem formatação.

A validação deve existir no Front-End para melhorar a experiência do usuário, porém a API continuará responsável pela validação definitiva quando a integração real estiver disponível.

## 18.1. Regra geral

Implementar:

- campos obrigatórios;
- limites mínimos e máximos de caracteres;
- validação de formato;
- máscaras de entrada;
- normalização dos dados antes do envio;
- mensagens de erro acessíveis;
- indicação visual de campo inválido;
- indicação visual de campo válido quando fizer sentido;
- validação ao sair do campo (`blur`);
- validação no envio do formulário;
- prevenção de submissão duplicada;
- bloqueio do botão de envio durante processamento;
- preservação dos dados digitados em caso de erro;
- tratamento de erros retornados pela futura API.

Não exibir erro agressivamente enquanto o usuário ainda estiver começando a digitar.

---

## 18.2. Estrutura recomendada

Centralizar regras reutilizáveis em:

```text
src/utils/
├── masks.ts
├── validators.ts
├── formatters.ts
└── normalizers.ts
```

Opcionalmente, schemas de validação podem ficar em:

```text
src/validation/
├── commonSchemas.ts
├── clientSchemas.ts
├── caseSchemas.ts
├── consultationSchemas.ts
└── lawyerContactSchemas.ts
```

Não duplicar regex, algoritmos de CPF/CNPJ ou máscaras em diferentes componentes.

---

## 18.3. Componentes de formulário

Os componentes básicos devem aceitar, quando aplicável:

```ts
interface BaseFieldProps {
  name: string;
  label: string;
  value?: string;
  required?: boolean;
  disabled?: boolean;
  placeholder?: string;
  error?: string;
  helperText?: string;
}
```

Criar componentes reutilizáveis quando necessário:

```text
TextField
EmailField
CpfField
CnpjField
PhoneField
WhatsappField
CepField
DateField
CurrencyField
TextareaField
SelectField
FileUploadField
```

Não criar máscaras manualmente dentro de cada página.

---

## 18.4. CPF

Formato visual:

```text
000.000.000-00
```

Exemplo:

```text
123.456.789-09
```

Regras:

- aceitar somente números como entrada lógica;
- aplicar máscara automaticamente;
- limitar a 11 dígitos;
- rejeitar sequências repetidas como `00000000000`, `11111111111`, etc.;
- validar os dois dígitos verificadores;
- remover máscara antes de enviar para API;
- armazenar preferencialmente apenas dígitos no estado de domínio.

Exemplo:

```ts
maskCpf("12345678909")
// 123.456.789-09

normalizeDocument("123.456.789-09")
// 12345678909
```

Mensagem sugerida:

```text
CPF inválido.
```

---

## 18.5. CNPJ

Formato visual:

```text
00.000.000/0000-00
```

Exemplo:

```text
12.345.678/0001-95
```

Regras:

- aceitar somente números como entrada lógica;
- aplicar máscara automaticamente;
- limitar a 14 dígitos;
- rejeitar sequências repetidas;
- validar dígitos verificadores;
- remover máscara antes do envio para API;
- armazenar preferencialmente apenas dígitos no estado de domínio.

Mensagem sugerida:

```text
CNPJ inválido.
```

---

## 18.6. CPF ou CNPJ no mesmo campo

Quando uma tela permitir pessoa física ou pessoa jurídica:

- até 11 dígitos: aplicar máscara de CPF;
- acima de 11 e até 14 dígitos: aplicar máscara de CNPJ;
- validar conforme o tipo detectado;
- não permitir mais de 14 dígitos.

Utilitário sugerido:

```ts
maskCpfCnpj(value)
validateCpfCnpj(value)
```

---

## 18.7. E-mail

Exemplo válido:

```text
usuario@dominio.com.br
```

Regras:

- remover espaços antes e depois;
- não permitir espaços internos;
- validar estrutura básica de e-mail;
- aceitar letras maiúsculas/minúsculas;
- converter para lowercase antes do envio, salvo regra futura em contrário;
- limitar tamanho a valor razoável, preferencialmente 254 caracteres;
- utilizar `type="email"` no HTML;
- não depender apenas da validação nativa do navegador.

Mensagem sugerida:

```text
Informe um e-mail válido.
```

Não utilizar regex excessivamente restritiva que bloqueie endereços válidos.

---

## 18.8. Telefone e WhatsApp

Padrão brasileiro.

Formato celular:

```text
(00) 00000-0000
```

Formato telefone fixo:

```text
(00) 0000-0000
```

Exemplos:

```text
(11) 99999-9999
(11) 3333-4444
```

Regras:

- aceitar somente números como entrada lógica;
- incluir DDD;
- aplicar máscara dinamicamente;
- aceitar 10 ou 11 dígitos;
- remover máscara antes de enviar à API;
- validar quantidade de dígitos;
- não considerar apenas a máscara como validação;
- para WhatsApp, preferir 11 dígitos quando for celular;
- preparar estrutura para futuro suporte a código do país.

Normalização sugerida:

```ts
normalizePhone("(11) 99999-9999")
// 11999999999
```

Caso seja necessário armazenar internacionalmente no futuro, converter na camada apropriada para padrão E.164.

---

## 18.9. CEP

Formato:

```text
00000-000
```

Exemplo:

```text
01310-100
```

Regras:

- aceitar somente números;
- limitar a 8 dígitos;
- aplicar máscara automaticamente;
- remover máscara antes do envio;
- validar exatamente 8 dígitos;
- não assumir que formato válido significa CEP existente;
- quando houver integração futura com serviço de CEP, tratar loading, sucesso, não encontrado e erro.

Mensagem sugerida:

```text
Informe um CEP válido.
```

---

## 18.10. OAB

Quando houver campos públicos ou de cadastro que referenciem OAB, separar os dados sempre que possível:

```ts
interface OabRegistration {
  number: string;
  state: string;
}
```

Exemplo visual:

```text
OAB/SP 123.456
```

Não assumir uma máscara nacional única para o número da OAB sem regra de negócio confirmada.

A UF deve ser validada separadamente.

---

## 18.11. Datas

Utilizar campo de data apropriado.

Regras:

- validar datas impossíveis;
- impedir datas fora do intervalo permitido;
- diferenciar data passada e futura conforme contexto;
- não aceitar prazo/evento inválido;
- formatar para exibição em padrão brasileiro:

```text
DD/MM/AAAA
```

Para API, preferir formato ISO:

```text
YYYY-MM-DD
```

Não salvar data formatada visualmente como valor de domínio quando puder ser armazenada em formato ISO.

---

## 18.12. Valores monetários

Quando houver preço, honorário, consulta, filtro de faixa ou valores:

Formato visual brasileiro:

```text
R$ 1.234,56
```

Regras:

- utilizar máscara monetária;
- não usar `float` de interface como fonte definitiva para cálculos financeiros;
- normalizar para centavos ou formato definido pela API;
- impedir valores negativos quando o domínio não permitir.

Exemplo:

```ts
19990
// representa R$ 199,90 quando a unidade for centavos
```

---

## 18.13. Campos numéricos

Para campos estritamente numéricos:

- impedir caracteres não numéricos quando aplicável;
- respeitar mínimo/máximo;
- não usar `parseInt` sem validar resultado;
- tratar campo vazio separadamente de zero;
- não aceitar `NaN`.

---

## 18.14. Nome completo

Regras mínimas:

- remover espaços duplicados;
- aplicar `trim`;
- exigir quantidade mínima razoável de caracteres;
- permitir acentos;
- permitir hífen;
- permitir apóstrofo;
- não restringir nomes reais a apenas `[A-Z]`.

Mensagem sugerida:

```text
Informe seu nome completo.
```

---

## 18.15. Textarea e descrições jurídicas

Campos como descrição do caso, observações, pergunta jurídica e resumo devem:

- respeitar mínimo/máximo mostrado na interface;
- exibir contador de caracteres quando previsto no mockup;
- impedir envio abaixo do mínimo;
- impedir envio acima do máximo;
- preservar quebra de linha;
- sanitizar/renderizar com segurança ao exibir posteriormente;
- não aceitar HTML executável.

Exemplos observados nas referências:

```text
30 caracteres mínimos
2000 caracteres máximos
500 caracteres máximos
300 caracteres máximos
1000 caracteres máximos
```

O valor exato deve seguir cada tela/requisito.

---

## 18.16. Upload de arquivos

Validar antes do upload:

- extensão;
- MIME type quando possível;
- tamanho;
- quantidade máxima;
- arquivo duplicado quando aplicável.

Formatos atualmente previstos:

```text
PDF
JPG
JPEG
PNG
DOC
DOCX
```

Limite indicado nas referências:

```text
10 MB por arquivo
```

Não confiar apenas na extensão do nome do arquivo.

Na integração real, repetir todas as validações no Back-End.

---

## 18.17. Consentimentos e checkboxes obrigatórios

Campos de:

- Política de Privacidade;
- tratamento de dados;
- autorizações;
- termos;

devem exigir ação explícita do usuário quando forem obrigatórios.

Nunca marcar consentimento automaticamente.

O botão de submissão final deve permanecer bloqueado ou apresentar validação enquanto o consentimento obrigatório não tiver sido aceito.

---

## 18.18. Mensagens de erro

Preferir mensagens objetivas e específicas.

Exemplos:

```text
Este campo é obrigatório.
Informe um CPF válido.
Informe um CNPJ válido.
Informe um e-mail válido.
Informe um telefone com DDD.
Informe um CEP válido.
Selecione uma opção.
O texto deve ter pelo menos 30 caracteres.
O arquivo excede o limite de 10 MB.
Formato de arquivo não permitido.
```

Evitar:

```text
Erro.
Valor inválido.
Falha.
```

quando for possível informar a causa.

---

## 18.19. Máscara não é validação

Regra obrigatória:

```text
MÁSCARA != VALIDAÇÃO
```

Exemplo:

```text
111.111.111-11
```

pode estar visualmente no formato correto, mas é um CPF inválido.

O agente deve sempre implementar:

```text
entrada
-> máscara
-> normalização
-> validação
-> envio
```

---

## 18.20. Normalização antes da API

Antes de enviar dados:

```text
CPF:       123.456.789-09 -> 12345678909
CNPJ:      12.345.678/0001-95 -> 12345678000195
Telefone:  (11) 99999-9999 -> 11999999999
CEP:       01310-100 -> 01310100
E-mail:    Usuario@Email.com -> usuario@email.com
```

A camada de service deve receber dados normalizados quando isso fizer parte do contrato.

---

## 18.21. Biblioteca de validação

É permitido utilizar biblioteca consolidada para gerenciamento de formulários e schema validation, desde que justificada e aplicada de forma consistente.

Exemplo de arquitetura aceitável:

```text
React Hook Form
+
Zod
```

ou solução equivalente.

Não adicionar várias bibliotecas diferentes para resolver o mesmo problema.

Caso a stack já possua uma biblioteca de formulários/validação, reutilizá-la.

---

## 18.22. Exemplo de schema

Exemplo conceitual:

```ts
const contactSchema = {
  name: "required",
  email: "email",
  whatsapp: "phone",
  privacyAccepted: true
};
```

A implementação real deve utilizar tipos/schema apropriados e mensagens em português.

---

## 18.23. Validações no fluxo Descreva seu caso

### Etapa 1

Obrigatório selecionar uma área jurídica antes de continuar.

### Etapa 2

Obrigatório selecionar um detalhe do caso.

Quando selecionar `Outro problema`, exigir descrição com quantidade mínima de caracteres.

### Etapa 3

Validar:

```text
CEP
cidade
estado
preferência de atendimento
```

Campos vinculados a "o caso ocorreu em outra cidade?" só devem ser obrigatórios conforme a resposta.

### Etapa 4

Validar:

```text
urgência
fase do caso
data/evento quando aplicável
```

### Etapa 5

Upload é opcional conforme referência, porém todo arquivo anexado deve ser validado.

### Etapa 6

Validar obrigatoriamente:

```text
nome completo
e-mail
WhatsApp
cidade
consentimento
```

O botão `Enviar solicitação` não deve submeter dados inválidos.

---

## 18.24. Validações no contato do advogado

Na página:

```text
/advogados/:id
```

validar:

- nome completo;
- telefone/WhatsApp;
- resumo do caso;
- consentimento de privacidade.

Aplicar máscara no telefone/WhatsApp.

---

## 18.25. Validações no Pergunte a um Advogado

Validar:

- pergunta obrigatória;
- tamanho mínimo;
- tamanho máximo;
- remoção de texto composto apenas por espaços;
- conteúdo seguro para renderização.

Não permitir submissão vazia.

---

## 18.26. Validações em Consulta Jurídica Online

Antes de agendar, exigir:

- tipo de consulta;
- duração;
- data;
- horário disponível;
- demais dados exigidos pelo fluxo.

O Front-End nunca deve confiar apenas no horário exibido anteriormente. Quando houver API, a disponibilidade deve ser revalidada no momento da confirmação.

---

## 18.27. Testes obrigatórios para máscaras e validadores

Criar testes unitários para:

```text
CPF válido
CPF inválido
CNPJ válido
CNPJ inválido
e-mail válido
e-mail inválido
telefone de 10 dígitos
celular de 11 dígitos
CEP válido
normalização de CPF
normalização de CNPJ
normalização de telefone
normalização de CEP
limites de textarea
limite de tamanho de arquivo
```

Testar também valores vazios, incompletos e caracteres inesperados.

---

## 18.28. Regra final de formulários

Nenhum formulário deve ser considerado concluído se:

- aceitar dados obrigatórios vazios;
- aceitar CPF/CNPJ inválido;
- aceitar e-mail claramente inválido;
- aceitar telefone incompleto;
- enviar dados mascarados quando a API exigir dados normalizados;
- permitir dupla submissão;
- ignorar consentimentos obrigatórios;
- perder dados sem necessidade após erro de validação;
- não informar ao usuário qual campo precisa ser corrigido.
# 19. Estados de interface

Toda integração deve prever:

```text
idle
loading
success
empty
error
```

Exemplos:

- busca sem advogados;
- erro ao carregar perfil;
- nenhum artigo;
- nenhum horário disponível;
- upload em andamento;
- envio de pergunta;
- envio da solicitação.

Não deixar a tela quebrada quando o mock/API retornar array vazio.

---

# 20. Acessibilidade

Obrigatório:

- HTML semântico;
- labels vinculados;
- navegação por teclado;
- foco visível;
- `aria-*` quando necessário;
- texto alternativo em imagens informativas;
- botões reais para ações;
- links reais para navegação;
- contraste adequado;
- não depender apenas de cor para comunicar estado.

---

# 21. Segurança e privacidade

O Marketplace trabalha com dados potencialmente sensíveis.

Nunca:

- gravar dados pessoais em logs de produção;
- inserir dados reais nos mocks;
- colocar tokens no código;
- expor segredos no Vite;
- armazenar documentos reais no repositório;
- renderizar HTML não confiável sem sanitização.

Consentimentos de privacidade devem ser explícitos quando a tela exigir.

---

# 22. LGPD e disclaimers

Preservar mensagens de transparência exibidas nas referências, especialmente no fluxo de intake, perguntas e contato.

A plataforma deve ser apresentada como marketplace jurídico.

Não alterar textos de natureza jurídica/compliance por iniciativa do agente.

Se houver divergência ou necessidade de revisão jurídica, marcar como:

```text
TODO: validar texto com jurídico/compliance
```

---

# 23. SEO, indexação no Google e descoberta orgânica

O Marketplace Público deve ser implementado com SEO técnico desde a primeira versão.

As páginas públicas relevantes devem ser preparadas para indexação por mecanismos de busca, especialmente Google.

A implementação deve evitar soluções que dependam exclusivamente de JavaScript no cliente para disponibilizar conteúdo essencial aos robôs de busca quando isso prejudicar indexação, compartilhamento ou performance.

---

## 23.1. Páginas que devem ser indexáveis

Por padrão, considerar indexáveis:

```text
/
 /advogados
 /advogados/area/:slug
 /advogados/:id
 /areas-juridicas
 /consulta-juridica
 /pergunte-a-um-advogado
 /perguntas/:id
 /artigos
 /artigos/:slug
 /como-funciona
 /para-advogados
 /sobre
 /contato
 /ajuda
 /perguntas-frequentes
```

A indexação final deve respeitar requisitos jurídicos, privacidade, qualidade de conteúdo e estratégia comercial.

---

## 23.2. Páginas que NÃO devem ser indexadas

Por padrão, usar `noindex` em páginas privadas, temporárias, duplicadas, de autenticação ou que contenham dados pessoais/sensíveis.

Exemplos:

```text
/login
/cadastro
/esqueci-minha-senha
/recuperar-senha
/descreva-seu-caso/*
/checkout
/pagamento
/confirmacao
/erro
/preview
```

Também aplicar `noindex` quando a página:

- existir apenas para fluxo operacional;
- possuir conteúdo duplicado sem valor de busca;
- possuir parâmetros que gerem combinações artificiais;
- expuser dados pessoais;
- for rascunho;
- estiver incompleta;
- não possuir conteúdo útil suficiente para indexação.

---

## 23.3. Meta tags obrigatórias

Toda página indexável deve possuir:

```html
<title>...</title>
<meta name="description" content="..." />
<meta name="robots" content="index,follow" />
<link rel="canonical" href="..." />
```

Quando não indexável:

```html
<meta name="robots" content="noindex,nofollow" />
```

Evitar titles e descriptions genéricas iguais em todas as páginas.

---

## 23.4. Title

Cada página deve ter `title` único.

Exemplos conceituais:

```text
Advogados por Área | Quota Labs
Advogados de Direito Societário | Quota Labs
Perfil da Dra. Mariana Costa | Quota Labs
Consulta Jurídica Online | Quota Labs
Artigos Jurídicos | Quota Labs
```

Boas práticas:

- título específico;
- incluir assunto principal;
- incluir marca no final quando apropriado;
- evitar repetição excessiva de palavras-chave;
- não criar títulos enganosos;
- não usar todas as palavras em caixa alta.

---

## 23.5. Meta description

Cada página indexável deve possuir descrição única e coerente com seu conteúdo.

Exemplo:

```text
Encontre advogados verificados por área jurídica, localização e modalidade de atendimento na Quota Labs.
```

A description deve:

- resumir a página;
- ser legível para humanos;
- evitar repetição de palavras-chave;
- não prometer resultados jurídicos;
- respeitar os disclaimers do Marketplace.

---

## 23.6. Canonical URL

Toda página indexável deve possuir URL canônica.

Exemplo:

```html
<link
  rel="canonical"
  href="https://www.exemplo.com/advogados/direito-societario"
/>
```

A canonical deve:

- apontar para a URL principal;
- evitar duplicidade entre URLs equivalentes;
- ignorar parâmetros de filtro quando eles não representarem páginas SEO independentes;
- usar domínio e protocolo oficiais do ambiente de produção.

Nunca usar domínio localhost em canonical de produção.

---

## 23.7. Estrutura de headings

Cada página deve possuir apenas um `H1` principal.

Estrutura recomendada:

```text
H1 - assunto principal da página
H2 - seções principais
H3 - subseções
```

Não usar heading apenas por aparência visual.

Exemplo:

```text
H1: Advogados de Direito Societário
H2: Profissionais encontrados
H2: Como escolher um advogado societário
H2: Perguntas frequentes
```

---

## 23.8. URLs amigáveis

As URLs públicas devem:

- ser curtas;
- utilizar letras minúsculas;
- usar hífen;
- evitar IDs técnicos quando houver slug estável;
- evitar parâmetros desnecessários;
- evitar caracteres especiais.

Exemplos:

```text
/advogados/direito-societario
/artigos/planejamento-tributario-para-empresas
/perguntas/tenho-direito-a-rescisao-indireta
```

Evitar:

```text
/page?id=123&type=4
/ADVOGADOS_DIREITO_SOC
```

---

## 23.9. Slugs

Criar utilitário de geração de slug consistente.

Exemplo:

```ts
slugify("Direito Societário")
// direito-societario
```

Slugs devem ser persistentes.

Alterar slug de conteúdo publicado deve gerar redirecionamento permanente da URL antiga para a nova quando aplicável.

---

## 23.10. Redirecionamentos

Quando uma URL pública mudar, utilizar redirecionamento permanente apropriado.

Não manter múltiplas URLs equivalentes acessíveis indefinidamente.

Exemplos:

```text
/advogado/123
-> /advogados/mariana-costa

/artigo?id=45
-> /artigos/clausulas-abusivas-em-contratos
```

Evitar cadeias longas de redirects.

---

## 23.11. robots.txt

A aplicação de produção deve publicar:

```text
/robots.txt
```

Exemplo conceitual:

```text
User-agent: *
Allow: /

Disallow: /login
Disallow: /cadastro
Disallow: /descreva-seu-caso/
Disallow: /checkout/
Disallow: /pagamento/

Sitemap: https://www.exemplo.com/sitemap.xml
```

Não bloquear no `robots.txt` páginas em que seja necessário que o Google veja a tag `noindex`.

O arquivo final deve ser configurado conforme o domínio real.

---

## 23.12. Sitemap XML

Publicar:

```text
/sitemap.xml
```

O sitemap deve incluir apenas URLs:

- públicas;
- canônicas;
- indexáveis;
- válidas;
- que retornem sucesso;
- relevantes.

Incluir, quando aplicável:

```text
Homepage
Áreas jurídicas
Páginas de advogados
Perfis públicos
Artigos
Perguntas públicas
Páginas institucionais
```

Não incluir:

```text
login
cadastro
wizard de caso
checkout
pagamento
URLs com noindex
URLs quebradas
URLs duplicadas
```

Quando o volume crescer, dividir em múltiplos sitemaps e usar um sitemap index.

---

## 23.13. Sitemap dinâmico

Para conteúdo vindo da API, prever geração dinâmica de sitemap.

Exemplos:

```text
sitemap-static.xml
sitemap-lawyers.xml
sitemap-legal-areas.xml
sitemap-articles.xml
sitemap-questions.xml
```

A geração deve considerar apenas conteúdo publicado/ativo.

---

## 23.14. Conteúdo renderizado e indexável

Conteúdo SEO crítico não deve existir apenas após interação do usuário.

Exemplos que devem estar disponíveis no HTML renderizado quando a estratégia técnica permitir:

- H1;
- título da área;
- nome do advogado;
- bio pública;
- especialidades;
- título do artigo;
- corpo do artigo;
- pergunta pública;
- resposta pública;
- breadcrumbs;
- FAQs públicas.

Se a arquitetura SPA pura prejudicar indexação, o projeto deve permitir evolução para SSR, SSG ou prerender.

---

## 23.15. Estratégia React para SEO

Como o projeto usa React/Vite, utilizar gerenciamento centralizado de metadata.

Exemplo de responsabilidades:

```text
PageSeo
SeoHead
StructuredData
CanonicalLink
```

Cada página deve declarar seus metadados.

Exemplo conceitual:

```tsx
<PageSeo
  title="Advogados de Direito Societário | Quota Labs"
  description="Encontre advogados..."
  canonical="/advogados/direito-societario"
/>
```

Não espalhar manipulação manual de `document.title` por dezenas de páginas.

---

## 23.16. SSR / SSG / prerender

Se o Marketplace depender fortemente de aquisição orgânica, considerar arquitetura que entregue HTML renderizado para páginas públicas estratégicas.

Prioridade para:

```text
/
 /advogados/area/:slug
 /advogados/:id
 /artigos
 /artigos/:slug
 /perguntas/:id
```

A adoção de SSR/SSG/prerender deve preservar a arquitetura atual e ser decidida tecnicamente conforme infraestrutura.

---

## 23.17. Dados estruturados

Preparar suporte a JSON-LD quando aplicável.

Tipos potencialmente úteis:

```text
Organization
WebSite
BreadcrumbList
Article
FAQPage
Person
ProfessionalService
```

Usar apenas schemas que representem fielmente o conteúdo exibido.

Não criar avaliações, serviços, notas ou informações inexistentes apenas para dados estruturados.

---

## 23.18. Breadcrumbs

Páginas internas públicas devem possuir breadcrumbs quando fizer sentido.

Exemplo:

```text
Início
> Áreas Jurídicas
> Societário
```

ou:

```text
Início
> Artigos
> Cláusulas abusivas em contratos
```

Além da UI, preparar `BreadcrumbList` estruturado quando aplicável.

---

## 23.19. SEO para perfil de advogado

Página:

```text
/advogados/:id
```

deve possuir metadata baseada no perfil público.

Exemplo:

```text
Title:
Dra. Mariana Costa - Direito Societário | Quota Labs

Description:
Conheça o perfil profissional, áreas de atuação, atendimento e conteúdos públicos da Dra. Mariana Costa.
```

Somente indexar perfis:

- ativos;
- aprovados;
- públicos;
- verificados conforme regra comercial;
- com conteúdo mínimo suficiente.

Perfil suspenso, excluído ou não publicado não deve permanecer indexável.

---

## 23.20. SEO para áreas jurídicas

Página:

```text
/advogados/area/:slug
```

não deve ser apenas uma lista vazia de cards.

Preparar espaço para conteúdo editorial útil, como:

```text
descrição da área
subáreas
quando procurar um profissional
perguntas frequentes
conteúdos relacionados
```

Conteúdo deve ser relevante e não gerado apenas para preencher palavras-chave.

---

## 23.21. SEO para artigos

Artigos devem possuir:

- title único;
- description;
- canonical;
- slug;
- autor;
- data de publicação;
- data de atualização quando existir;
- H1;
- imagem principal;
- texto alternativo;
- breadcrumbs;
- Article JSON-LD quando aplicável.

Prever:

```text
datePublished
dateModified
author
headline
description
image
```

Não indexar rascunhos ou conteúdos em revisão.

---

## 23.22. SEO para perguntas e respostas

Páginas públicas de perguntas devem possuir:

- título único;
- pergunta como H1 ou heading principal;
- conteúdo informativo;
- resposta publicada;
- advogado responsável quando público;
- canonical;
- breadcrumbs.

Não indexar:

- perguntas sem resposta;
- perguntas removidas;
- perguntas com conteúdo sensível;
- perguntas duplicadas;
- conteúdo aguardando moderação.

---

## 23.23. Paginação

Listagens paginadas devem ser rastreáveis.

Exemplo:

```text
/advogados?page=2
/artigos?page=3
```

Não criar paginação que dependa apenas de botão JavaScript sem URL acessível.

URLs paginadas devem possuir comportamento consistente.

---

## 23.24. Filtros e faceted navigation

Filtros podem gerar grande quantidade de URLs.

Exemplos:

```text
?cidade=sao-paulo
?online=true
?idioma=ingles
?ordenacao=avaliacao
```

Por padrão:

- filtros operacionais NÃO devem virar páginas SEO automaticamente;
- utilizar canonical para a página principal quando apropriado;
- controlar indexação de combinações de filtros;
- evitar explosão de URLs rastreáveis.

Somente criar landing pages SEO específicas quando houver decisão explícita de produto/marketing.

---

## 23.25. Parâmetros de URL

Evitar indexação desnecessária de parâmetros como:

```text
utm_source
utm_medium
utm_campaign
sort
view
pageSize
session
tracking
```

Parâmetros de marketing podem existir, mas a canonical deve apontar para a URL limpa.

---

## 23.26. Open Graph

Páginas públicas relevantes devem possuir:

```html
<meta property="og:title" content="..." />
<meta property="og:description" content="..." />
<meta property="og:type" content="website" />
<meta property="og:url" content="..." />
<meta property="og:image" content="..." />
```

Artigos podem utilizar:

```text
og:type = article
```

---

## 23.27. Twitter / Social Cards

Preparar metadata de compartilhamento social quando aplicável:

```text
twitter:card
twitter:title
twitter:description
twitter:image
```

Não usar imagem inexistente.

---

## 23.28. Imagens

Imagens públicas relevantes devem:

- possuir `alt` descritivo;
- ter dimensões definidas;
- evitar layout shift;
- utilizar formatos otimizados;
- ter lazy loading quando fora da primeira dobra;
- não usar nomes de arquivo sem significado quando houver pipeline para otimização.

Exemplo:

```text
advogada-mariana-costa-direito-societario.webp
```

Evitar:

```text
IMG_9837_final2.png
```

---

## 23.29. Performance e Core Web Vitals

SEO técnico deve considerar performance.

Priorizar:

- carregamento rápido;
- bundle inicial controlado;
- lazy loading;
- code splitting;
- otimização de imagens;
- redução de scripts desnecessários;
- prevenção de layout shift;
- fontes otimizadas;
- cache adequado;
- resposta rápida da aplicação.

Não adicionar bibliotecas pesadas sem justificativa.

---

## 23.30. Links internos

Criar links HTML reais entre conteúdos relacionados.

Exemplos:

```text
Área jurídica -> Advogados da área
Advogado -> Artigos do advogado
Artigo -> Perfil do autor
Pergunta -> Perfil do advogado
Homepage -> Áreas
Homepage -> Artigos
```

Evitar usar somente handlers JavaScript para navegação quando um link semântico puder ser utilizado.

---

## 23.31. Links externos

Quando houver links externos:

- abrir nova aba apenas quando fizer sentido;
- usar atributos de segurança apropriados;
- não usar `nofollow` indiscriminadamente;
- marcar links patrocinados/publicitários conforme política definida.

---

## 23.32. Página 404

Criar página 404 real.

Requisitos:

- status HTTP apropriado quando infraestrutura permitir;
- mensagem amigável;
- link para Homepage;
- link para Buscar Advogados;
- link para Artigos;
- não indexar.

Não retornar uma página visual de erro com status 200 para URL inexistente quando for possível evitar.

---

## 23.33. Conteúdo removido

Quando conteúdo público deixar de existir:

- avaliar redirecionamento para equivalente relevante;
- caso não exista substituto, retornar status apropriado;
- remover do sitemap;
- evitar redirecionar toda URL removida para Homepage.

---

## 23.34. Ambientes não produtivos

Ambientes como:

```text
development
staging
homologação
preview
```

NÃO devem ser indexados.

Configurar:

```text
noindex
```

e proteção adicional de ambiente quando possível.

Nunca permitir que homologação concorra com produção no Google.

---

## 23.35. Google Search Console

Após publicação em produção, o projeto deve estar preparado para integração operacional com Google Search Console.

Checklist:

```text
verificar propriedade
enviar sitemap
acompanhar cobertura/indexação
acompanhar páginas excluídas
acompanhar Core Web Vitals
acompanhar erros
acompanhar melhorias de dados estruturados
```

Essas ações são operacionais e não devem ser hardcoded na aplicação.

---

## 23.36. Google Analytics / Tag Manager

SEO e analytics são responsabilidades diferentes.

Caso o projeto utilize Google Analytics ou Google Tag Manager:

- não misturar lógica de analytics com componentes visuais;
- criar camada própria de tracking;
- respeitar consentimento de cookies;
- não disparar tags de marketing antes de consentimento quando juridicamente necessário;
- não inserir IDs diretamente em vários componentes.

Usar variáveis de ambiente.

---

## 23.37. Cookie consent

Caso cookies não essenciais sejam utilizados:

- exibir mecanismo de consentimento;
- distinguir cookies necessários de analytics/marketing;
- armazenar escolha;
- permitir revisão da preferência;
- integrar com política de cookies.

A implementação final deve seguir validação jurídica/compliance.

---

## 23.38. Conteúdo duplicado

Evitar duplicidade entre:

```text
/advogados
/advogados/
/advogados?sort=default
```

Escolher uma forma canônica.

Da mesma forma, evitar duplicidade com:

```text
www
sem www
http
https
```

A infraestrutura deve redirecionar para uma versão oficial.

---

## 23.39. HTTPS

Produção deve operar exclusivamente com HTTPS.

Redirecionar HTTP para HTTPS.

Canonical, sitemap e metadata devem usar HTTPS.

---

## 23.40. www ou sem www

Definir apenas um host oficial.

Exemplo:

```text
https://www.quotalabs.com.br
```

ou:

```text
https://quotalabs.com.br
```

A escolha depende da infraestrutura.

O host alternativo deve redirecionar para o oficial.

---

## 23.41. Idioma

Definir idioma principal:

```html
<html lang="pt-BR">
```

Se houver internacionalização futura, preparar arquitetura adequada.

Não publicar versões duplicadas em idiomas diferentes sem estratégia de URLs e metadata correspondente.

---

## 23.42. Indexação de conteúdo gerado por usuário

Perguntas, respostas, avaliações e outros conteúdos públicos gerados por usuários devem passar pelas regras de moderação antes de indexação.

Não indexar automaticamente conteúdo:

- ofensivo;
- spam;
- duplicado;
- vazio;
- sensível;
- com dados pessoais indevidos;
- ainda não moderado.

---

## 23.43. Conteúdo jurídico e confiança

Como Marketplace jurídico, páginas públicas devem deixar clara a diferença entre:

```text
conteúdo informativo
e
consulta jurídica individual
```

Não criar títulos SEO ou descriptions com promessas como:

```text
ganhe sua causa
resultado garantido
melhor advogado garantido
100% de sucesso
```

Manter conformidade com textos aprovados pelo jurídico/compliance.

---

## 23.44. Arquitetura recomendada

Criar estrutura semelhante a:

```text
src/
├── seo/
│   ├── PageSeo.tsx
│   ├── StructuredData.tsx
│   ├── seoConfig.ts
│   └── schemas/
│       ├── organizationSchema.ts
│       ├── breadcrumbSchema.ts
│       ├── articleSchema.ts
│       └── faqSchema.ts
```

E, quando necessário:

```text
public/
├── robots.txt
└── sitemap.xml
```

Para sitemap dinâmico, utilizar geração no build, servidor ou Back-End conforme arquitetura final.

---

## 23.45. Configuração por ambiente

Criar variáveis como:

```text
VITE_SITE_URL
VITE_SITE_NAME
VITE_GOOGLE_SITE_VERIFICATION
```

Não hardcodar domínio de produção em múltiplos componentes.

Exemplo:

```env
VITE_SITE_URL=https://www.exemplo.com
VITE_SITE_NAME=Quota Labs
```

---

## 23.46. Critério de aceite SEO

Uma página pública indexável só deve ser considerada pronta quando:

- possuir title;
- possuir description;
- possuir canonical;
- possuir H1;
- possuir URL amigável;
- possuir conteúdo acessível;
- possuir alt em imagens relevantes;
- não possuir links internos quebrados;
- não possuir metadata duplicada;
- responder corretamente;
- estiver presente no sitemap quando aplicável;
- não estiver bloqueada indevidamente;
- tiver comportamento responsivo;
- possuir performance aceitável.

---

## 23.47. Testes SEO

Criar verificações automatizadas quando possível para:

```text
title ausente
description ausente
canonical ausente
mais de um H1
imagem sem alt
link quebrado
página indexável com noindex
página privada sem noindex
canonical inválida
```

Ferramentas de auditoria podem ser utilizadas no pipeline de CI quando definidas pelo projeto.

---

## 23.48. Regra final de SEO

O agente deve assumir que toda nova página pública precisa de decisão explícita sobre indexação.

Antes de concluir uma página, responder internamente:

```text
Esta página deve ser indexada?
Qual é a canonical?
Qual é o title?
Qual é a description?
Qual é o H1?
Ela entra no sitemap?
Possui dados estruturados aplicáveis?
Existe risco de conteúdo duplicado?
```

SEO não deve ser tratado como ajuste posterior.

Ele faz parte da arquitetura do Marketplace Público desde a implementação inicial.
# 24. Imagens e assets

Assets da aplicação devem ficar em:

```text
FrontEnd/public/assets/
```

As imagens de `docs/screens/` NÃO são assets de produção.

Elas são documentação visual.

Não copiar screenshots inteiras para dentro da página como solução de implementação.

---

# 25. Navegação entre módulos

O botão `Entrar` deve encaminhar para o fluxo de autenticação definido pelo projeto.

Links para áreas autenticadas devem ser configuráveis.

Não importar páginas ou componentes internos de domínio entre `modules/site`, `modules/admin`, `modules/client` e `modules/lawyers`. Compartilhe apenas abstrações realmente comuns por `src/shared/`.

Como os quatro módulos pertencem ao mesmo core React, preferir rotas centralizadas e contratos de navegação. Use URLs externas por ambiente somente quando algum destino estiver realmente publicado como aplicação separada.

Exemplo:

```text
VITE_CLIENT_APP_URL
VITE_LAWYER_APP_URL
VITE_ADMIN_APP_URL
VITE_API_BASE_URL
```

---

# 26. Docker

O Front-End possui **um único build/container principal** para o core React com os quatro módulos. A separação `site/admin/client/lawyers` é lógica dentro da aplicação e não exige um container por módulo, salvo decisão futura de infraestrutura.

Arquivo esperado:

```text
Marketplace/FrontEnd/docker-compose.yml
```

Modelo base:

```yaml
name: marketplace

services:
  frontend:
    build:
      context: .
      dockerfile: Dockerfile
    image: marketplace-frontend
    container_name: marketplace-frontend
    ports:
      - "8081:80"
    restart: unless-stopped
```

A aplicação React deve possuir `Dockerfile` adequado para build de produção e servidor web capaz de tratar corretamente as rotas SPA.

Não criar `docker-compose.yml` separado para `site`, `admin`, `client` e `lawyers` enquanto eles fizerem parte do mesmo core/deploy.

---

# 27. Regras de código

Obrigatório:

- TypeScript;
- componentes funcionais;
- nomes claros;
- props tipadas;
- funções pequenas;
- evitar duplicação;
- separar regra de negócio de apresentação;
- evitar arquivos gigantes;
- evitar `any`;
- remover código morto;
- não deixar `console.log` desnecessário;
- não adicionar bibliotecas sem necessidade;
- manter lint sem erros.

---

# 28. Regra contra páginas monolíticas

PROIBIDO implementar uma referência inteira em um único componente gigante.

Exemplo incorreto:

```text
HomePage.tsx com 1500 linhas
```

Exemplo esperado:

```text
HomePage
├── HomeHero
├── PopularLegalAreas
├── HowItWorks
├── FeaturedLawyers
├── FAQPreview
├── ArticlePreview
└── LawyerCTA
```

A página orquestra. Os componentes renderizam.

---

# 29. Fidelidade visual

Ao receber instrução como:

```text
"implemente a Homepage"
```

o agente deve automaticamente consultar:

```text
docs/screens/1. Front End/01 Homepage 02.png
```

e usar essa referência.

Não substituir o layout por templates genéricos.

Não remover conteúdo importante para simplificar a implementação.

Não inventar elementos que alterem o produto.

Quando algo da imagem não estiver claro, implementar a interpretação mais conservadora e deixar comentário/TODO somente quando necessário.

---

# 30. Ordem sugerida de implementação

```text
1. Bootstrap único React + TypeScript + Vite e estrutura modules/shared
2. Design tokens e estilos globais
3. PublicLayout
4. Header
5. Footer
6. componentes UI básicos
7. models
8. mocks
9. services
10. Homepage
11. Buscar Advogados
12. Advogados por Área
13. Perfil do Advogado
14. Fluxo Descreva seu Caso
15. Pergunte a um Advogado
16. Pergunta Respondida
17. Artigos
18. Consulta Jurídica Online
19. páginas institucionais
20. responsividade final
21. testes e revisão visual
```

---

# 31. Critérios de aceite por tela

Uma tela só deve ser considerada concluída quando:

- a rota funciona;
- corresponde à referência visual;
- componentes estão reutilizados;
- dados vêm de service/mock;
- não existem erros no console;
- loading/empty/error estão tratados quando aplicável;
- formulário possui validação;
- navegação funciona;
- desktop funciona;
- tablet funciona;
- mobile funciona;
- teclado funciona;
- lint/build passam;
- não há dados pessoais reais;
- textos jurídicos relevantes foram preservados.

---

# 32. Testes

Priorizar testes para:

- services;
- filtros;
- wizard;
- validações;
- navegação entre etapas;
- submissão;
- componentes com lógica;
- estados vazio/erro;
- cálculo/resumo de consulta quando houver.

Não criar testes frágeis dependentes apenas de classes CSS.

---

# 33. Convenção para tarefas do Copilot

Quando receber uma tarefa de tela, seguir:

```text
1. Ler AGENTS_SITE.md
2. Localizar screenshot
3. Identificar rota
4. Identificar componentes existentes
5. Identificar models
6. Identificar mock/service
7. Implementar
8. Validar TypeScript
9. Executar lint
10. Executar build
11. Comparar visualmente com a referência
12. Corrigir diferenças
```

---

# 34. Exemplo de comando para o agente

```text
Implemente a tela MP-003 - Buscar Advogados.

Siga integralmente AGENTS_SITE.md.

Referência visual:
docs/screens/1. Front End/03 Buscar Advogados.png

Reutilize o PublicLayout, Header, Footer e componentes existentes.

Os resultados e filtros devem utilizar mocks por meio de services.

Não implemente API real.

Implemente responsividade para desktop, tablet e mobile.

Ao finalizar execute lint e build e corrija os erros encontrados.
```

---

# 35. Regra final

A prioridade do agente é:

```text
1. Requisitos funcionais
2. Referências visuais em docs/screens/1. Front End/
3. Este AGENTS_SITE.md
4. Reutilização e consistência da arquitetura existente
5. Qualidade e manutenção do código
```

Se existir conflito entre uma suposição do agente e uma referência do projeto, a referência do projeto prevalece.

O agente não deve redesenhar o produto.

O agente deve transformar as referências fornecidas em uma aplicação React organizada, responsiva, tipada, reutilizável e preparada para integração futura com o BackEnd.
