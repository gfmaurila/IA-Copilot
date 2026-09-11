# TASK-001 — Criar Site Institucional de RH Completo

## 1. Objetivo

Criar do zero o módulo frontend `site` de um projeto institucional de RH / recrutamento e seleção.

Esta task deve ser suficiente para uma pessoa iniciante em frontend executar o projeto e entender:

- como o projeto é criado;
- quais dependências são utilizadas;
- como organizar as pastas;
- como funcionam os arquivos `.env`;
- como configurar URLs por ambiente;
- como os dados mockados funcionam;
- como as páginas são montadas;
- como os componentes são separados;
- como executar o projeto;
- como validar se tudo está funcionando.

O objetivo final é entregar um **site institucional completo de RH**, responsivo, utilizando React + TypeScript + Vite e dados mockados em JSON.

Nesta task **não existe backend real**.

---

# 2. Resultado esperado

Ao concluir esta task, deve existir:

```text
frontend/
└── site/
```

com um projeto React executável.

O site deve possuir:

```text
Home
Sobre
Serviços
Vagas
Depoimentos
Contato
Footer
```

A Home deve ser uma página institucional completa e profissional.

---

# 3. Stack obrigatória

Utilizar:

```text
React
TypeScript
Vite
React Router
CSS Modules ou CSS simples organizado
Fetch API
ESLint
Prettier
```

Não utilizar nesta primeira versão:

```text
Redux
Zustand
TanStack Query
Axios
Tailwind
Material UI
Chakra UI
Ant Design
Bootstrap
```

A intenção é manter a implementação simples para facilitar aprendizado.

---

# 4. Pré-requisitos locais

Antes de iniciar, instalar:

```text
Node.js LTS
npm
Git
VS Code
```

Validar:

```bash
node --version
npm --version
git --version
```

---

# 5. Criar projeto React

Dentro da pasta:

```text
frontend/
```

executar:

```bash
npm create vite@latest site -- --template react-ts
```

Entrar no projeto:

```bash
cd site
```

Instalar dependências:

```bash
npm install
```

Instalar React Router:

```bash
npm install react-router-dom
```

---

# 6. Scripts esperados

O `package.json` deve possuir no mínimo:

```json
{
  "scripts": {
    "dev": "vite",
    "build": "tsc -b && vite build",
    "lint": "eslint .",
    "preview": "vite preview"
  }
}
```

---

# 7. Estrutura completa esperada

Criar:

```text
frontend/
└── site/
    ├── public/
    │   ├── favicon.svg
    │   └── images/
    │       ├── hero-rh.jpg
    │       ├── about-rh.jpg
    │       └── placeholder-job.jpg
    │
    ├── src/
    │   ├── api/
    │   │   └── site.api.ts
    │   │
    │   ├── components/
    │   │   ├── Header/
    │   │   │   ├── Header.tsx
    │   │   │   └── Header.css
    │   │   │
    │   │   ├── Footer/
    │   │   │   ├── Footer.tsx
    │   │   │   └── Footer.css
    │   │   │
    │   │   ├── Hero/
    │   │   │   ├── Hero.tsx
    │   │   │   └── Hero.css
    │   │   │
    │   │   ├── SectionTitle/
    │   │   │   ├── SectionTitle.tsx
    │   │   │   └── SectionTitle.css
    │   │   │
    │   │   ├── ServiceCard/
    │   │   │   ├── ServiceCard.tsx
    │   │   │   └── ServiceCard.css
    │   │   │
    │   │   ├── JobCard/
    │   │   │   ├── JobCard.tsx
    │   │   │   └── JobCard.css
    │   │   │
    │   │   ├── BenefitCard/
    │   │   │   ├── BenefitCard.tsx
    │   │   │   └── BenefitCard.css
    │   │   │
    │   │   ├── TestimonialCard/
    │   │   │   ├── TestimonialCard.tsx
    │   │   │   └── TestimonialCard.css
    │   │   │
    │   │   ├── Loading/
    │   │   │   ├── Loading.tsx
    │   │   │   └── Loading.css
    │   │   │
    │   │   └── ErrorState/
    │   │       ├── ErrorState.tsx
    │   │       └── ErrorState.css
    │   │
    │   ├── layouts/
    │   │   └── SiteLayout.tsx
    │   │
    │   ├── mocks/
    │   │   └── site-home.json
    │   │
    │   ├── pages/
    │   │   ├── Home/
    │   │   │   ├── HomePage.tsx
    │   │   │   └── HomePage.css
    │   │   │
    │   │   ├── About/
    │   │   │   ├── AboutPage.tsx
    │   │   │   └── AboutPage.css
    │   │   │
    │   │   ├── Services/
    │   │   │   ├── ServicesPage.tsx
    │   │   │   └── ServicesPage.css
    │   │   │
    │   │   ├── Jobs/
    │   │   │   ├── JobsPage.tsx
    │   │   │   └── JobsPage.css
    │   │   │
    │   │   └── Contact/
    │   │       ├── ContactPage.tsx
    │   │       └── ContactPage.css
    │   │
    │   ├── routes/
    │   │   └── AppRouter.tsx
    │   │
    │   ├── services/
    │   │   └── site.service.ts
    │   │
    │   ├── styles/
    │   │   ├── global.css
    │   │   ├── variables.css
    │   │   └── reset.css
    │   │
    │   ├── types/
    │   │   └── site.types.ts
    │   │
    │   ├── utils/
    │   │   └── env.ts
    │   │
    │   ├── App.tsx
    │   └── main.tsx
    │
    ├── .env
    ├── .env.development
    ├── .env.homolog
    ├── .env.production
    ├── .env.example
    ├── .gitignore
    ├── eslint.config.js
    ├── package.json
    ├── tsconfig.json
    ├── tsconfig.app.json
    ├── tsconfig.node.json
    ├── vite.config.ts
    └── README.md
```

---

# 8. Arquivos de ambiente

Criar todos os arquivos abaixo.

## 8.1 `.env`

Usado como configuração padrão local.

```env
VITE_APP_NAME=Talent RH
VITE_APP_ENV=local
VITE_SITE_BASE_URL=http://localhost:5173
VITE_API_BASE_URL=http://localhost:5000
VITE_SITE_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

## 8.2 `.env.development`

```env
VITE_APP_NAME=Talent RH
VITE_APP_ENV=development
VITE_SITE_BASE_URL=http://localhost:5173
VITE_API_BASE_URL=https://dev-api.exemplo.com
VITE_SITE_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

## 8.3 `.env.homolog`

```env
VITE_APP_NAME=Talent RH
VITE_APP_ENV=homolog
VITE_SITE_BASE_URL=https://homolog-site.exemplo.com
VITE_API_BASE_URL=https://homolog-api.exemplo.com
VITE_SITE_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

## 8.4 `.env.production`

```env
VITE_APP_NAME=Talent RH
VITE_APP_ENV=production
VITE_SITE_BASE_URL=https://www.exemplo.com
VITE_API_BASE_URL=https://api.exemplo.com
VITE_SITE_DATA_SOURCE=mock
VITE_ENABLE_LOGS=false
```

---

## 8.5 `.env.example`

```env
VITE_APP_NAME=
VITE_APP_ENV=
VITE_SITE_BASE_URL=
VITE_API_BASE_URL=
VITE_SITE_DATA_SOURCE=mock
VITE_ENABLE_LOGS=false
```

---

# 9. Regra para arquivos `.env`

Nunca salvar:

```text
senha
token
secret
connection string
credencial
chave privada
```

Tudo que começa com:

```text
VITE_
```

fica disponível no browser.

Portanto, considerar sempre como informação pública.

---

# 10. Utilitário de ambiente

Criar:

```text
src/utils/env.ts
```

Exemplo:

```ts
export const env = {
  appName: import.meta.env.VITE_APP_NAME,
  appEnv: import.meta.env.VITE_APP_ENV,
  siteBaseUrl: import.meta.env.VITE_SITE_BASE_URL,
  apiBaseUrl: import.meta.env.VITE_API_BASE_URL,
  dataSource: import.meta.env.VITE_SITE_DATA_SOURCE,
  enableLogs: import.meta.env.VITE_ENABLE_LOGS === 'true',
};
```

A aplicação deve consultar as variáveis por este arquivo quando possível.

---

# 11. Modos de execução

## Local

```bash
npm run dev
```

## Development

Adicionar no `package.json`:

```json
"dev:development": "vite --mode development"
```

Executar:

```bash
npm run dev:development
```

## Homolog

Adicionar:

```json
"dev:homolog": "vite --mode homolog"
```

Executar:

```bash
npm run dev:homolog
```

## Production local

Adicionar:

```json
"dev:production": "vite --mode production"
```

Executar:

```bash
npm run dev:production
```

---

# 12. Build por ambiente

Adicionar scripts:

```json
{
  "scripts": {
    "build": "tsc -b && vite build",
    "build:development": "tsc -b && vite build --mode development",
    "build:homolog": "tsc -b && vite build --mode homolog",
    "build:production": "tsc -b && vite build --mode production"
  }
}
```

---

# 13. Rotas do site

Criar:

```text
src/routes/AppRouter.tsx
```

Rotas:

```text
/
 /sobre
 /servicos
 /vagas
 /contato
```

Configuração sugerida:

```tsx
<Routes>
  <Route element={<SiteLayout />}>
    <Route path="/" element={<HomePage />} />
    <Route path="/sobre" element={<AboutPage />} />
    <Route path="/servicos" element={<ServicesPage />} />
    <Route path="/vagas" element={<JobsPage />} />
    <Route path="/contato" element={<ContactPage />} />
  </Route>
</Routes>
```

---

# 14. Layout principal

Criar:

```text
src/layouts/SiteLayout.tsx
```

Estrutura:

```text
Header
  ↓
Outlet
  ↓
Footer
```

Exemplo:

```tsx
<>
  <Header />
  <main>
    <Outlet />
  </main>
  <Footer />
</>
```

---

# 15. Header

Criar navegação para:

```text
Início
Sobre
Serviços
Vagas
Contato
```

O header deve:

- funcionar em desktop;
- possuir menu mobile;
- destacar link atual quando possível;
- manter aparência simples e profissional.

---

# 16. Footer

Exibir:

```text
Nome da empresa
Descrição curta
Links rápidos
Contato
Copyright
```

Exemplo fictício:

```text
Talent RH
Conectando talentos e empresas.

contato@talentrh.exemplo
(51) 0000-0000
Porto Alegre / RS
```

---

# 17. Estrutura visual da Home

A Home deve conter:

```text
Hero
Sobre resumido
Indicadores
Serviços
Vagas em destaque
Benefícios
Depoimentos
CTA final
```

---

# 18. Hero

Conteúdo vindo do JSON.

Exemplo:

```text
Conectamos talentos às oportunidades certas

Soluções de recrutamento, seleção e desenvolvimento
para pessoas e empresas que querem crescer.

[Ver vagas]
[Conheça nossos serviços]
```

---

# 19. Sobre

Exibir:

```text
Título
Descrição
Imagem
Indicadores
```

Indicadores:

```text
10+ anos de experiência
500+ profissionais contratados
100+ empresas atendidas
95% de satisfação
```

---

# 20. Serviços

Criar cards para:

```text
Recrutamento e Seleção
Consultoria de RH
Treinamento e Desenvolvimento
Avaliação de Perfil
Terceirização de Processos
Outplacement
```

Cada item:

```ts
id
title
description
icon
```

---

# 21. Vagas

Criar seção:

```text
Vagas em destaque
```

Cada vaga:

```ts
id
title
company
location
workModel
employmentType
summary
publishedAt
```

Exemplos:

```text
Desenvolvedor .NET
Analista de Recursos Humanos
Tech Recruiter
Assistente Administrativo
Analista Financeiro
```

---

# 22. Benefícios / diferenciais

Exibir:

```text
Atendimento humanizado
Processos ágeis
Especialistas em recrutamento
Conexão com boas empresas
Acompanhamento próximo
Transparência
```

---

# 23. Depoimentos

Utilizar somente pessoas fictícias.

Exemplo:

```text
Mariana Souza
Analista Administrativa

"O atendimento foi muito próximo e consegui uma oportunidade
alinhada ao meu perfil."
```

---

# 24. Contato

Criar uma página:

```text
/contact
```

ou:

```text
/contato
```

Utilizar `/contato`.

Campos visuais:

```text
Nome
Email
Telefone
Assunto
Mensagem
```

Nesta task:

```text
não enviar para backend
```

Ao enviar:

```text
exibir mensagem informando que é uma demonstração
```

---

# 25. Tipos TypeScript

Criar:

```text
src/types/site.types.ts
```

Interfaces:

```ts
export interface SiteHome {
  company: CompanyInfo;
  hero: HeroContent;
  about: AboutContent;
  services: Service[];
  featuredJobs: Job[];
  benefits: Benefit[];
  testimonials: Testimonial[];
  contact: ContactContent;
}

export interface CompanyInfo {
  name: string;
  tagline: string;
  email: string;
  phone: string;
  city: string;
}

export interface HeroContent {
  title: string;
  subtitle: string;
  primaryButtonText: string;
  primaryButtonUrl: string;
  secondaryButtonText: string;
  secondaryButtonUrl: string;
}

export interface AboutIndicator {
  label: string;
  value: string;
}

export interface AboutContent {
  title: string;
  description: string;
  indicators: AboutIndicator[];
}

export interface Service {
  id: string;
  title: string;
  description: string;
  icon?: string;
}

export interface Job {
  id: string;
  title: string;
  company: string;
  location: string;
  workModel: string;
  employmentType: string;
  summary: string;
  publishedAt: string;
}

export interface Benefit {
  id: string;
  title: string;
  description: string;
}

export interface Testimonial {
  id: string;
  name: string;
  role: string;
  company?: string;
  message: string;
}

export interface ContactContent {
  title: string;
  description: string;
}
```

---

# 26. Mock JSON

Criar:

```text
src/mocks/site-home.json
```

Conteúdo completo sugerido:

```json
{
  "company": {
    "name": "Talent RH",
    "tagline": "Conectando talentos e empresas",
    "email": "contato@talentrh.exemplo",
    "phone": "(51) 0000-0000",
    "city": "Porto Alegre / RS"
  },
  "hero": {
    "title": "Conectamos talentos às oportunidades certas",
    "subtitle": "Soluções de recrutamento, seleção e desenvolvimento para pessoas e empresas que querem crescer.",
    "primaryButtonText": "Ver vagas",
    "primaryButtonUrl": "/vagas",
    "secondaryButtonText": "Conheça nossos serviços",
    "secondaryButtonUrl": "/servicos"
  },
  "about": {
    "title": "Pessoas certas transformam empresas",
    "description": "Somos uma consultoria de RH focada em aproximar profissionais e organizações de forma humana, ágil e transparente.",
    "indicators": [
      {
        "label": "Anos de experiência",
        "value": "10+"
      },
      {
        "label": "Profissionais contratados",
        "value": "500+"
      },
      {
        "label": "Empresas atendidas",
        "value": "100+"
      },
      {
        "label": "Satisfação",
        "value": "95%"
      }
    ]
  },
  "services": [
    {
      "id": "1",
      "title": "Recrutamento e Seleção",
      "description": "Processos seletivos personalizados para encontrar profissionais alinhados à cultura e às necessidades da empresa.",
      "icon": "users"
    },
    {
      "id": "2",
      "title": "Consultoria de RH",
      "description": "Apoio estratégico para estruturar processos, políticas e práticas de gestão de pessoas.",
      "icon": "briefcase"
    },
    {
      "id": "3",
      "title": "Treinamento e Desenvolvimento",
      "description": "Programas para desenvolvimento de competências técnicas, comportamentais e de liderança.",
      "icon": "graduation"
    },
    {
      "id": "4",
      "title": "Avaliação de Perfil",
      "description": "Avaliações para apoiar decisões de contratação, desenvolvimento e movimentação interna.",
      "icon": "profile"
    },
    {
      "id": "5",
      "title": "Terceirização de Processos",
      "description": "Suporte operacional para processos de recrutamento e rotinas de gestão de pessoas.",
      "icon": "settings"
    },
    {
      "id": "6",
      "title": "Outplacement",
      "description": "Apoio humanizado para profissionais em transição de carreira.",
      "icon": "direction"
    }
  ],
  "featuredJobs": [
    {
      "id": "1",
      "title": "Desenvolvedor .NET",
      "company": "Empresa Tecnologia",
      "location": "Porto Alegre / RS",
      "workModel": "Híbrido",
      "employmentType": "CLT",
      "summary": "Atuação no desenvolvimento de aplicações corporativas utilizando .NET e APIs REST.",
      "publishedAt": "2026-09-01"
    },
    {
      "id": "2",
      "title": "Analista de Recursos Humanos",
      "company": "Empresa Serviços",
      "location": "Canoas / RS",
      "workModel": "Presencial",
      "employmentType": "CLT",
      "summary": "Atuação generalista em recrutamento, treinamento e apoio aos gestores.",
      "publishedAt": "2026-09-02"
    },
    {
      "id": "3",
      "title": "Tech Recruiter",
      "company": "Empresa Digital",
      "location": "Remoto",
      "workModel": "Remoto",
      "employmentType": "PJ",
      "summary": "Responsável por recrutamento de profissionais de tecnologia.",
      "publishedAt": "2026-09-03"
    }
  ],
  "benefits": [
    {
      "id": "1",
      "title": "Atendimento humanizado",
      "description": "Cada profissional e empresa recebe acompanhamento próximo durante todo o processo."
    },
    {
      "id": "2",
      "title": "Agilidade",
      "description": "Processos objetivos e estruturados para reduzir o tempo de contratação."
    },
    {
      "id": "3",
      "title": "Especialistas",
      "description": "Time com experiência em diferentes perfis profissionais e segmentos."
    },
    {
      "id": "4",
      "title": "Transparência",
      "description": "Comunicação clara em todas as etapas do processo."
    }
  ],
  "testimonials": [
    {
      "id": "1",
      "name": "Mariana Souza",
      "role": "Analista Administrativa",
      "company": "Empresa Exemplo",
      "message": "O processo foi muito claro e recebi acompanhamento em todas as etapas."
    },
    {
      "id": "2",
      "name": "Carlos Mendes",
      "role": "Coordenador de Tecnologia",
      "company": "Empresa Digital",
      "message": "Encontramos profissionais muito alinhados ao perfil que buscávamos."
    },
    {
      "id": "3",
      "name": "Fernanda Lima",
      "role": "Analista Financeira",
      "message": "A equipe entendeu meu momento profissional e apresentou uma ótima oportunidade."
    }
  ],
  "contact": {
    "title": "Vamos construir novas oportunidades?",
    "description": "Se você procura talentos para sua empresa ou uma nova oportunidade profissional, fale com nosso time."
  }
}
```

---

# 27. Serviço de dados

Criar:

```text
src/services/site.service.ts
```

A página nunca deve importar diretamente:

```text
site-home.json
```

Exemplo:

```ts
import type { SiteHome } from '../types/site.types';
import siteHomeMock from '../mocks/site-home.json';

export async function getSiteHome(): Promise<SiteHome> {
  await new Promise((resolve) => setTimeout(resolve, 300));

  return siteHomeMock as SiteHome;
}
```

O pequeno delay simula uma chamada HTTP.

---

# 28. API futura

Criar também:

```text
src/api/site.api.ts
```

Mesmo que ainda não seja utilizado.

Exemplo:

```ts
import { env } from '../utils/env';
import type { SiteHome } from '../types/site.types';

export async function fetchSiteHome(): Promise<SiteHome> {
  const response = await fetch(`${env.apiBaseUrl}/api/site/home`);

  if (!response.ok) {
    throw new Error('Não foi possível carregar os dados do site.');
  }

  return response.json();
}
```

Nesta task:

```text
getSiteHome()
```

deve usar o JSON.

O arquivo `site.api.ts` existe apenas para deixar preparado o caminho de integração futura.

---

# 29. HomePage

Criar lógica:

```text
HomePage monta
   ↓
loading = true
   ↓
getSiteHome()
   ↓
dados recebidos
   ↓
renderiza seções
```

Tratar:

```text
Loading
Erro
Sucesso
```

Não colocar todos os dados diretamente no JSX.

---

# 30. Página Sobre

Criar `/sobre`.

Conteúdo:

```text
História fictícia
Missão
Visão
Valores
Indicadores
Forma de trabalho
```

Pode reutilizar informações do mock.

---

# 31. Página Serviços

Criar `/servicos`.

Listar todos os serviços.

Cada serviço deve possuir:

```text
Título
Descrição
```

Sem integração real.

---

# 32. Página Vagas

Criar `/vagas`.

Exibir todas as vagas mockadas.

Nesta task não precisa:

```text
detalhes da vaga
filtro
busca
paginação
candidatura
```

Os cards devem apresentar:

```text
Cargo
Empresa
Cidade
Modelo
Tipo de contratação
Resumo
```

---

# 33. Página Contato

Criar `/contato`.

Campos:

```text
Nome
Email
Telefone
Assunto
Mensagem
```

Ao clicar em enviar:

- impedir envio real;
- validar campos obrigatórios de forma simples;
- exibir mensagem:

```text
Mensagem registrada apenas para demonstração.
```

Não integrar com API.

---

# 34. CSS global

Criar:

```text
src/styles/reset.css
src/styles/variables.css
src/styles/global.css
```

`variables.css` deve conter variáveis semelhantes a:

```css
:root {
  --font-family: Inter, Arial, sans-serif;

  --color-primary: #1f4f8a;
  --color-secondary: #2f7f73;
  --color-text: #222222;
  --color-text-light: #666666;
  --color-background: #ffffff;
  --color-background-soft: #f5f7fa;
  --color-border: #dfe3e8;

  --container-width: 1200px;

  --space-xs: 4px;
  --space-sm: 8px;
  --space-md: 16px;
  --space-lg: 24px;
  --space-xl: 40px;
  --space-xxl: 64px;

  --radius-sm: 6px;
  --radius-md: 10px;
  --radius-lg: 16px;
}
```

As cores podem ser ajustadas, mas manter identidade institucional.

---

# 35. Responsividade

Garantir:

```text
Desktop
Tablet
Mobile
```

Breakpoints sugeridos:

```css
@media (max-width: 1024px) {
}

@media (max-width: 768px) {
}

@media (max-width: 480px) {
}
```

---

# 36. Layout responsivo

No mobile:

- menu deve funcionar;
- cards devem ficar em uma coluna quando necessário;
- textos não devem estourar;
- botões devem permanecer clicáveis;
- formulário deve usar largura total.

---

# 37. Acessibilidade básica

Implementar:

```text
alt em imagens
labels nos inputs
botões reais para ações
links reais para navegação
HTML semântico
contraste legível
foco visível
```

---

# 38. Loading

Criar:

```text
src/components/Loading/Loading.tsx
```

Exibir algo semelhante a:

```text
Carregando...
```

Pode possuir spinner CSS simples.

---

# 39. Error State

Criar:

```text
src/components/ErrorState/ErrorState.tsx
```

Exemplo:

```text
Não foi possível carregar o conteúdo.
Tente novamente.
```

Permitir botão:

```text
Tentar novamente
```

---

# 40. README

Criar:

```text
frontend/site/README.md
```

Explicar:

```text
Objetivo
Tecnologias
Como instalar
Como executar
Arquivos .env
Estrutura de pastas
Rotas
Mocks
Build
Troubleshooting
```

---

# 41. README — comandos

Documentar:

```bash
npm install
npm run dev
npm run dev:development
npm run dev:homolog
npm run dev:production

npm run build
npm run build:development
npm run build:homolog
npm run build:production

npm run lint
```

---

# 42. `.gitignore`

Garantir:

```text
node_modules
dist
.env.local
*.log
```

Não ignorar:

```text
.env.example
```

Os `.env` reais podem ser versionados apenas se contiverem informações públicas e placeholders.

Preferencialmente:

```text
versionar somente .env.example
```

e documentar os valores esperados.

---

# 43. Regra sobre URLs

Todas as URLs configuráveis devem vir do `.env`.

Não escrever diretamente nos componentes:

```text
http://localhost:5000
https://api.exemplo.com
```

Utilizar:

```ts
env.apiBaseUrl
```

---

# 44. Regra de arquitetura

Fluxo de dados:

```text
Page
  ↓
Service
  ↓
Mock JSON
```

No futuro:

```text
Page
  ↓
Service
  ↓
API Client
  ↓
Backend
```

A página não deve precisar mudar quando ocorrer essa migração.

---

# 45. Regras para componentes

Cada componente deve:

- possuir uma responsabilidade clara;
- receber dados via props;
- não acessar JSON diretamente;
- não acessar `.env` diretamente, salvo caso técnico justificado;
- não executar fetch diretamente.

---

# 46. Regras para páginas

Páginas podem:

- carregar dados via service;
- controlar loading;
- controlar error;
- organizar componentes;
- controlar interação específica da página.

Páginas não devem:

- duplicar dados;
- conter grandes blocos reutilizáveis;
- acessar arquivos JSON diretamente.

---

# 47. Conteúdo fictício

Todos os dados devem ser fictícios.

Não usar:

```text
CPF real
email pessoal real
telefone pessoal real
currículo real
nome de candidato real
informações privadas
```

---

# 48. Validação antes da conclusão

Executar:

```bash
npm run lint
npm run build
```

Corrigir todos os erros.

Depois executar:

```bash
npm run dev
```

Validar manualmente:

```text
/
 /sobre
 /servicos
 /vagas
 /contato
```

---

# 49. Critérios de aceite

- [ ] Projeto React criado.
- [ ] TypeScript configurado.
- [ ] Vite configurado.
- [ ] React Router instalado e configurado.
- [ ] `.env` criado.
- [ ] `.env.development` criado.
- [ ] `.env.homolog` criado.
- [ ] `.env.production` criado.
- [ ] `.env.example` criado.
- [ ] URLs centralizadas nos arquivos `.env`.
- [ ] `env.ts` criado.
- [ ] `site.types.ts` criado.
- [ ] `site-home.json` criado.
- [ ] `site.service.ts` criado.
- [ ] `site.api.ts` criado para integração futura.
- [ ] `SiteLayout` criado.
- [ ] Header criado.
- [ ] Footer criado.
- [ ] Menu responsivo criado.
- [ ] Home criada.
- [ ] Página Sobre criada.
- [ ] Página Serviços criada.
- [ ] Página Vagas criada.
- [ ] Página Contato criada.
- [ ] Hero criado.
- [ ] Serviços exibidos através do JSON.
- [ ] Vagas exibidas através do JSON.
- [ ] Benefícios exibidos através do JSON.
- [ ] Depoimentos exibidos através do JSON.
- [ ] Loading implementado.
- [ ] Error State implementado.
- [ ] Formulário de contato demonstrativo criado.
- [ ] Nenhum backend real criado.
- [ ] Nenhum dado sensível utilizado.
- [ ] Layout responsivo.
- [ ] `npm run lint` executado sem erro.
- [ ] `npm run build` executado sem erro.
- [ ] README criado e atualizado.

---

# 50. Fora de escopo

Não criar nesta task:

```text
Backend C#
API Mock C#
Banco de dados
Login
Área administrativa
Área do candidato
Upload de currículo
Candidatura real
Envio real de formulário
Integração com e-mail
Integração com WhatsApp
Integração com LinkedIn
CMS
Analytics
SEO avançado
Paginação
Autocomplete
Filtros avançados
```

---

# 51. Instruções para IA / Copilot

Ao receber esta task:

1. Criar todos os arquivos descritos.
2. Não perguntar se deve criar cada arquivo individualmente.
3. Criar implementação funcional completa.
4. Não deixar arquivos principais apenas como placeholders.
5. Não criar backend.
6. Não instalar bibliotecas fora das definidas sem necessidade.
7. Não utilizar `any`.
8. Não importar JSON dentro de componentes.
9. Não executar `fetch` dentro de componentes.
10. Centralizar URLs no `.env`.
11. Usar `env.ts` como ponto central de configuração.
12. Utilizar dados fictícios.
13. Implementar responsividade.
14. Implementar Loading e Error State.
15. Criar README detalhado.
16. Executar lint e build ao final.
17. Corrigir erros encontrados.
18. Não adicionar funcionalidades fora do escopo.
19. Manter código simples e fácil de entender.
20. Priorizar legibilidade para desenvolvedor iniciante.
