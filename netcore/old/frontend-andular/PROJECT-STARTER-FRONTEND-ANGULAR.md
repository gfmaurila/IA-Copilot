# PROJECT STARTER — Frontend Angular + TypeScript

> Documento de bootstrap inicial do frontend. O objetivo desta etapa é somente criar os módulos frontend, garantir que todos executem localmente e disponibilizar uma página simples de **Olá Mundo** em cada aplicação.

---

# 1. Objetivo desta etapa

Criar a estrutura inicial do frontend com três aplicações independentes:

- `admin`
- `auth`
- `site`

Cada aplicação deve:

1. Ser criada com Angular + TypeScript.
2. Utilizar Angular CLI como ferramenta padrão de criação, build e execução.
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
| Framework | Angular |
| Linguagem | TypeScript |
| Build / Dev Tool | Angular CLI |
| Package Manager | `npm / pnpm / yarn — A DEFINIR` |
| Node.js | `A DEFINIR` |
| Angular | `A DEFINIR` |
| TypeScript | `A DEFINIR` |

## Recursos previstos para etapas futuras

Os recursos abaixo podem ser utilizados futuramente, mas **não devem ser instalados ou configurados durante este bootstrap**, salvo solicitação explícita:

| Biblioteca / recurso | Uso futuro | Bootstrap inicial |
|---|---|---|
| Angular Router | Rotas | Não configurar |
| HttpClient | Consumo de APIs | Não configurar |
| Interceptors | Tratamento HTTP | Não configurar |
| Signals / serviço de estado | Estado compartilhado | Não criar estrutura global |
| Reactive Forms | Formulários | Não configurar |
| Validators / bibliotecas extras | Validação | Não configurar |
| Biblioteca UI | Componentes visuais | Não instalar/configurar |
| Jasmine / Karma / Vitest | Testes | Não ampliar/configurar |
| Playwright / Cypress | E2E | Não configurar |

> Regra: esta etapa deve evitar dependências e configurações que não sejam necessárias para renderizar e executar as aplicações Angular.

---

# 4. Escopo do bootstrap

## Deve ser criado

- Pasta `frontend/`.
- Aplicação Angular `admin`.
- Aplicação Angular `auth`.
- Aplicação Angular `site`.
- Estrutura mínima de `src` em cada módulo.
- Arquivo `src/main.ts` em cada módulo.
- Componente raiz `app.component.ts` em cada módulo.
- Uma página/componente inicial `home.component.ts` em cada módulo.
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
- HttpClient configurado para backend.
- Interceptors.
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

> Observação: o Angular CLI pode gerar arquivos adicionais automaticamente. Esses arquivos podem permanecer no projeto. A estrutura abaixo representa apenas os arquivos principais que precisam ser considerados nesta etapa.

```text
📂 frontend
├── 📂 admin
│   ├── 📂 public
│   ├── 📂 src
│   │   ├── 📂 app
│   │   │   ├── 📂 pages
│   │   │   │   └── 📂 home
│   │   │   │       ├── 📄 home.component.ts
│   │   │   │       └── 📄 home.component.html
│   │   │   ├── 📄 app.component.ts
│   │   │   └── 📄 app.component.html
│   │   ├── 📄 index.html
│   │   └── 📄 main.ts
│   ├── 📄 angular.json
│   ├── 📄 package.json
│   ├── 📄 tsconfig.json
│   └── 📄 README.md
│
├── 📂 auth
│   ├── 📂 public
│   ├── 📂 src
│   │   ├── 📂 app
│   │   │   ├── 📂 pages
│   │   │   │   └── 📂 home
│   │   │   │       ├── 📄 home.component.ts
│   │   │   │       └── 📄 home.component.html
│   │   │   ├── 📄 app.component.ts
│   │   │   └── 📄 app.component.html
│   │   ├── 📄 index.html
│   │   └── 📄 main.ts
│   ├── 📄 angular.json
│   ├── 📄 package.json
│   ├── 📄 tsconfig.json
│   └── 📄 README.md
│
└── 📂 site
    ├── 📂 public
    ├── 📂 src
    │   ├── 📂 app
    │   │   ├── 📂 pages
    │   │   │   └── 📂 home
    │   │   │       ├── 📄 home.component.ts
    │   │   │       └── 📄 home.component.html
    │   │   ├── 📄 app.component.ts
    │   │   └── 📄 app.component.html
    │   ├── 📄 index.html
    │   └── 📄 main.ts
    ├── 📄 angular.json
    ├── 📄 package.json
    ├── 📄 tsconfig.json
    └── 📄 README.md
```

---

# 7. Módulo Admin

Local:

```text
frontend/admin
```

Objetivo desta etapa:

- Criar a aplicação Angular.
- Garantir que a aplicação execute localmente.
- Renderizar apenas a página inicial.

## Página inicial

Arquivos:

```text
src/app/pages/home/home.component.ts
src/app/pages/home/home.component.html
```

Exemplo mínimo do componente:

```ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
})
export class HomeComponent {}
```

Conteúdo esperado em `home.component.html`:

```html
<h1>Olá Mundo - Admin</h1>
```

O `AppComponent` deve apenas carregar o `HomeComponent`.

---

# 8. Módulo Auth

Local:

```text
frontend/auth
```

Objetivo desta etapa:

- Criar a aplicação Angular.
- Garantir que a aplicação execute localmente.
- Não implementar login ainda.
- Renderizar apenas a página inicial.

## Página inicial

Arquivos:

```text
src/app/pages/home/home.component.ts
src/app/pages/home/home.component.html
```

Conteúdo esperado em `home.component.html`:

```html
<h1>Olá Mundo - Auth</h1>
```

O `AppComponent` deve apenas carregar o `HomeComponent`.

---

# 9. Módulo Site

Local:

```text
frontend/site
```

Objetivo desta etapa:

- Criar a aplicação Angular.
- Garantir que a aplicação execute localmente.
- Renderizar apenas a página inicial.

## Página inicial

Arquivos:

```text
src/app/pages/home/home.component.ts
src/app/pages/home/home.component.html
```

Conteúdo esperado em `home.component.html`:

```html
<h1>Olá Mundo - Site</h1>
```

O `AppComponent` deve apenas carregar o `HomeComponent`.

---

# 10. AppComponent padrão

Cada aplicação deve possuir um `AppComponent` mínimo.

Exemplo:

```ts
import { Component } from '@angular/core';
import { HomeComponent } from './pages/home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HomeComponent],
  template: '<app-home />',
})
export class AppComponent {}
```

Não adicionar Router, providers HTTP, estado global ou outras configurações arquiteturais nesta etapa.

---

# 11. main.ts padrão

Exemplo mínimo:

```ts
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent)
  .catch((err) => console.error(err));
```

---

# 12. Criação das aplicações

Exemplo com Angular CLI:

```bash
cd frontend
npx @angular/cli new admin --standalone --routing=false --style=css
npx @angular/cli new auth --standalone --routing=false --style=css
npx @angular/cli new site --standalone --routing=false --style=css
```

> Se a versão do Angular ainda não estiver definida pelo projeto, não fixar uma versão arbitrária neste documento.

---

# 13. Execução local

Cada módulo deve ser executável independentemente.

Exemplo:

```bash
cd frontend/admin
npm install
npm start
```

```bash
cd frontend/auth
npm install
npm start
```

```bash
cd frontend/site
npm install
npm start
```

Alternativamente, o Angular CLI também permite:

```bash
npx ng serve
```

As portas podem ser definidas automaticamente pelo Angular CLI inicialmente.

Se for necessário fixar portas posteriormente, documentar em uma task específica.

---

# 14. Resultado visual esperado

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

# 15. Regras para IA / Copilot

Ao utilizar este arquivo como contexto, a IA deve obedecer às seguintes regras:

1. Criar somente a estrutura inicial do frontend.
2. Criar os três módulos: `admin`, `auth` e `site`.
3. Cada módulo deve ser uma aplicação Angular + TypeScript independente.
4. Preferir componentes standalone.
5. Não criar CRUDs.
6. Não criar features de negócio.
7. Não implementar autenticação.
8. Não integrar com backend.
9. Não instalar bibliotecas adicionais sem solicitação explícita.
10. Não configurar HttpClient ou interceptors nesta etapa.
11. Não configurar Angular Router nesta etapa.
12. Não criar estado global.
13. Não criar formulários.
14. Não criar validações.
15. Não criar componentes compartilhados antecipadamente.
16. Cada aplicação deve possuir somente sua página/componente inicial de Olá Mundo.
17. O `AppComponent` deve apenas carregar o `HomeComponent`.
18. Se uma informação de versão estiver ausente, manter `A DEFINIR` em vez de inventar.
19. Não antecipar decisões arquiteturais de etapas futuras.
20. Não transformar as três aplicações em um único projeto sem solicitação explícita.

---

# 16. Checklist de conclusão

## Estrutura

- [ ] Pasta `frontend/` criada.
- [ ] Aplicação `admin` criada.
- [ ] Aplicação `auth` criada.
- [ ] Aplicação `site` criada.

## Admin

- [ ] `admin` executa com `npm start` ou `ng serve`.
- [ ] `HomeComponent` criado.
- [ ] Exibe `Olá Mundo - Admin`.

## Auth

- [ ] `auth` executa com `npm start` ou `ng serve`.
- [ ] `HomeComponent` criado.
- [ ] Exibe `Olá Mundo - Auth`.

## Site

- [ ] `site` executa com `npm start` ou `ng serve`.
- [ ] `HomeComponent` criado.
- [ ] Exibe `Olá Mundo - Site`.

## Validação final

- [ ] Nenhum CRUD criado.
- [ ] Nenhuma integração com API criada.
- [ ] Nenhuma autenticação criada.
- [ ] Nenhum estado global configurado.
- [ ] Nenhuma biblioteca arquitetural extra instalada sem necessidade.
- [ ] Os três módulos compilam sem erro.

---

# 17. Próximas etapas sugeridas

Após este starter estar funcionando, novas capacidades devem ser adicionadas por tasks separadas.

Exemplos:

```text
task-001-configurar-angular-router.md
task-002-configurar-http-client.md
task-003-configurar-interceptors.md
task-004-criar-layout-admin.md
task-005-criar-autenticacao.md
task-006-criar-primeira-feature.md
```

> O `PROJECT-STARTER-FRONTEND.md` define somente o ponto inicial do projeto. Funcionalidades de negócio devem ser adicionadas posteriormente através de tasks específicas.
