# PROJECT STARTER — Frontend React + TypeScript

> Documento de bootstrap inicial do frontend. O objetivo desta etapa é somente criar os módulos frontend, garantir que todos executem localmente e disponibilizar uma página simples de **Olá Mundo** em cada aplicação.

---

# 1. Objetivo desta etapa

Criar a estrutura inicial do frontend com três aplicações independentes:

- `admin`
- `auth`
- `site`

Cada aplicação deve:

1. Ser criada com React + TypeScript.
2. Utilizar Vite como build tool, salvo decisão explícita em contrário.
3. Executar de forma independente.
4. Possuir somente uma página inicial de **Olá Mundo**.
5. Não possuir regra de negócio.
6. Não consumir APIs nesta etapa.
7. Não possuir autenticação real nesta etapa.
8. Não possuir CRUDs nesta etapa.

---

# 2. Identificação do projeto

| Campo | Valor |
|---|---|
| Nome do projeto | `A DEFINIR` |
| Sigla | `A DEFINIR` |
| Repositório | `A DEFINIR` |
| Responsável técnico | `A DEFINIR` |
| Ambiente inicial | `Local` |
| Status | `Bootstrap / Estrutura inicial` |

---

# 3. Stack inicial

| Item | Valor |
|---|---|
| Framework | React |
| Linguagem | TypeScript |
| Build Tool | Vite |
| Package Manager | `npm / pnpm / yarn — A DEFINIR` |
| Node.js | `A DEFINIR` |
| React | `A DEFINIR` |
| TypeScript | `A DEFINIR` |

## Bibliotecas previstas para etapas futuras

As bibliotecas abaixo podem ser utilizadas futuramente, mas **não devem ser instaladas ou configuradas durante este bootstrap**, salvo solicitação explícita:

| Biblioteca / recurso | Uso futuro | Bootstrap inicial |
|---|---|---|
| React Router | Rotas | Não instalar/configurar |
| TanStack Query | Server state / requests | Não instalar/configurar |
| Axios | HTTP Client | Não instalar/configurar |
| Zustand / Redux Toolkit | Estado global | Não instalar/configurar |
| React Hook Form | Formulários | Não instalar/configurar |
| Zod / Yup | Validação | Não instalar/configurar |
| Biblioteca UI | Componentes visuais | Não instalar/configurar |
| Vitest / Jest | Testes | Não configurar |
| Playwright / Cypress | E2E | Não configurar |

> Regra: esta etapa deve evitar dependências que não sejam necessárias para renderizar e executar as aplicações React.

---

# 4. Escopo do bootstrap

## Deve ser criado

- Pasta `frontend/`.
- Aplicação React `admin`.
- Aplicação React `auth`.
- Aplicação React `site`.
- Estrutura mínima de `src` em cada módulo.
- Arquivo `main.tsx` em cada módulo.
- Arquivo `App.tsx` em cada módulo.
- Uma página inicial `HomePage.tsx` em cada módulo.
- Página de **Olá Mundo** específica para cada aplicação.
- `.gitignore` quando necessário.
- `README.md` mínimo por aplicação.

## Não deve ser criado ainda

- CRUDs.
- Features de negócio.
- Login funcional.
- JWT.
- Refresh Token.
- API Client.
- Axios.
- Interceptors.
- TanStack Query.
- Estado global.
- Formulários.
- Validação de formulários.
- Componentes compartilhados complexos.
- Layout administrativo completo.
- Menu lateral.
- Controle de permissões.
- Integração com backend.
- Docker.
- CI/CD.
- Testes E2E.
- Mocks de APIs.

---

# 5. Estrutura raiz

```text
📂 projeto
├── 📂 backend
│   └── ...
│
├── 📂 frontend
│   ├── 📂 admin
│   ├── 📂 auth
│   └── 📂 site
│
├── 📂 docs
├── 📂 task
└── 📄 README.md
```

Todo código frontend deve permanecer dentro de `frontend/`.

---

# 6. Estrutura dos módulos

Os três módulos devem seguir a mesma estrutura mínima.

```text
📂 frontend
├── 📂 admin
│   ├── 📂 public
│   ├── 📂 src
│   │   ├── 📂 pages
│   │   │   └── 📄 HomePage.tsx
│   │   ├── 📄 App.tsx
│   │   └── 📄 main.tsx
│   ├── 📄 index.html
│   ├── 📄 package.json
│   ├── 📄 tsconfig.json
│   ├── 📄 vite.config.ts
│   └── 📄 README.md
│
├── 📂 auth
│   ├── 📂 public
│   ├── 📂 src
│   │   ├── 📂 pages
│   │   │   └── 📄 HomePage.tsx
│   │   ├── 📄 App.tsx
│   │   └── 📄 main.tsx
│   ├── 📄 index.html
│   ├── 📄 package.json
│   ├── 📄 tsconfig.json
│   ├── 📄 vite.config.ts
│   └── 📄 README.md
│
└── 📂 site
    ├── 📂 public
    ├── 📂 src
    │   ├── 📂 pages
    │   │   └── 📄 HomePage.tsx
    │   ├── 📄 App.tsx
    │   └── 📄 main.tsx
    ├── 📄 index.html
    ├── 📄 package.json
    ├── 📄 tsconfig.json
    ├── 📄 vite.config.ts
    └── 📄 README.md
```

---

# 7. Módulo Admin

Local:

```text
frontend/admin
```

Objetivo desta etapa:

- Criar a aplicação React.
- Garantir que a aplicação execute localmente.
- Renderizar apenas a página inicial.

## Página inicial

Arquivo:

```text
src/pages/HomePage.tsx
```

Conteúdo esperado:

```tsx
export function HomePage() {
  return <h1>Olá Mundo - Admin</h1>;
}
```

`App.tsx` deve apenas renderizar `HomePage`.

---

# 8. Módulo Auth

Local:

```text
frontend/auth
```

Objetivo desta etapa:

- Criar a aplicação React.
- Garantir que a aplicação execute localmente.
- Não implementar login ainda.
- Renderizar apenas a página inicial.

## Página inicial

Arquivo:

```text
src/pages/HomePage.tsx
```

Conteúdo esperado:

```tsx
export function HomePage() {
  return <h1>Olá Mundo - Auth</h1>;
}
```

`App.tsx` deve apenas renderizar `HomePage`.

---

# 9. Módulo Site

Local:

```text
frontend/site
```

Objetivo desta etapa:

- Criar a aplicação React.
- Garantir que a aplicação execute localmente.
- Renderizar apenas a página inicial.

## Página inicial

Arquivo:

```text
src/pages/HomePage.tsx
```

Conteúdo esperado:

```tsx
export function HomePage() {
  return <h1>Olá Mundo - Site</h1>;
}
```

`App.tsx` deve apenas renderizar `HomePage`.

---

# 10. App.tsx padrão

Cada aplicação deve possuir um `App.tsx` mínimo.

Exemplo:

```tsx
import { HomePage } from './pages/HomePage';

function App() {
  return <HomePage />;
}

export default App;
```

Não adicionar Router, Providers, Contexts ou configuração de estado nesta etapa.

---

# 11. main.tsx padrão

Exemplo mínimo:

```tsx
import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import App from './App';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
  </StrictMode>,
);
```

---

# 12. Execução local

Cada módulo deve ser executável independentemente.

Exemplo:

```bash
cd frontend/admin
npm install
npm run dev
```

```bash
cd frontend/auth
npm install
npm run dev
```

```bash
cd frontend/site
npm install
npm run dev
```

As portas podem ser definidas pelo Vite inicialmente.

Se for necessário fixar portas posteriormente, documentar em uma task específica.

---

# 13. Resultado visual esperado

## Admin

```text
Olá Mundo - Admin
```

## Auth

```text
Olá Mundo - Auth
```

## Site

```text
Olá Mundo - Site
```

Nenhuma outra funcionalidade é necessária para concluir esta etapa.

---

# 14. Regras para IA / Copilot

Ao utilizar este arquivo como contexto, a IA deve obedecer às seguintes regras:

1. Criar somente a estrutura inicial do frontend.
2. Criar os três módulos: `admin`, `auth` e `site`.
3. Cada módulo deve ser uma aplicação React + TypeScript independente.
4. Não criar CRUDs.
5. Não criar features de negócio.
6. Não implementar autenticação.
7. Não integrar com backend.
8. Não instalar bibliotecas adicionais sem solicitação explícita.
9. Não criar Axios, HTTP Client ou interceptors.
10. Não criar React Router nesta etapa.
11. Não criar estado global.
12. Não criar formulários.
13. Não criar validações.
14. Não criar componentes compartilhados antecipadamente.
15. Cada aplicação deve possuir somente sua página `HomePage.tsx` de Olá Mundo.
16. `App.tsx` deve apenas carregar a `HomePage`.
17. Se uma informação de versão estiver ausente, manter `A DEFINIR` em vez de inventar.
18. Não antecipar decisões arquiteturais de etapas futuras.

---

# 15. Checklist de conclusão

## Estrutura

- [ ] Pasta `frontend/` criada.
- [ ] Aplicação `admin` criada.
- [ ] Aplicação `auth` criada.
- [ ] Aplicação `site` criada.

## Admin

- [ ] `admin` executa com `npm run dev`.
- [ ] `HomePage.tsx` criado.
- [ ] Exibe `Olá Mundo - Admin`.

## Auth

- [ ] `auth` executa com `npm run dev`.
- [ ] `HomePage.tsx` criado.
- [ ] Exibe `Olá Mundo - Auth`.

## Site

- [ ] `site` executa com `npm run dev`.
- [ ] `HomePage.tsx` criado.
- [ ] Exibe `Olá Mundo - Site`.

## Validação final

- [ ] Nenhum CRUD criado.
- [ ] Nenhuma integração com API criada.
- [ ] Nenhuma autenticação criada.
- [ ] Nenhum estado global configurado.
- [ ] Nenhuma biblioteca arquitetural extra instalada sem necessidade.
- [ ] Os três módulos compilam sem erro.

---

# 16. Próximas etapas sugeridas

Após este starter estar funcionando, novas capacidades devem ser adicionadas por tasks separadas.

Exemplos:

```text
task-001-configurar-react-router.md
task-002-configurar-http-client.md
task-003-configurar-tanstack-query.md
task-004-criar-layout-admin.md
task-005-criar-autenticacao.md
task-006-criar-primeira-feature.md
```

> O `PROJECT-STARTER-FRONTEND.md` define somente o ponto inicial do projeto. Funcionalidades de negócio devem ser adicionadas posteriormente através de tasks específicas.
