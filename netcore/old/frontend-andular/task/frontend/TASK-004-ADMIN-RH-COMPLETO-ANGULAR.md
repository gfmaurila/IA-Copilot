# TASK-004 — Criar Painel Admin RH em Angular com Dashboard, CRUD de Usuários e Preferências

## 1. Objetivo

Criar a estrutura completa do módulo:

```text
frontend/admin
```

O módulo Admin deve ser uma aplicação Angular + TypeScript funcional, organizada e didática.

Nesta task devem ser implementados:

```text
Dashboard
CRUD de Usuários
Paginação
Autocomplete
Validação de campos
Listagem
Novo
Editar
Detalhe
Menu lateral
Header
Preferências do usuário
Configuração de aparência
Tema / cor principal
Persistência local das preferências
Dados mockados em JSON
```

Nesta etapa não existe backend real.

Todos os dados devem ser simulados no frontend.

---

# 2. Resultado esperado

Ao concluir esta task, o Admin deve permitir:

```text
Entrar no painel
Visualizar dashboard
Listar usuários
Pesquisar usuários
Paginar resultados
Filtrar usuários
Criar usuário
Editar usuário
Visualizar detalhe
Excluir usuário de forma simulada
Utilizar autocomplete
Validar formulários
Configurar tema
Alterar cor principal
Alterar preferências visuais
Salvar preferências no navegador
```

---

# 3. Stack

Utilizar:

```text
Angular
TypeScript
Angular CLI
Angular Router
Angular Reactive Forms
Angular HttpClient preparado para futuro
CSS simples organizado
ESLint
Prettier
```

Para formulários e validação, utilizar recursos nativos do Angular:

```text
ReactiveFormsModule
FormBuilder
FormGroup
Validators
```

Não é necessário instalar Angular Reactive Forms, Angular Validators ou `@hookform/resolvers`.

Não utilizar nesta primeira versão:

```text
NgRx
Material UI
Angular Material
Bootstrap
Tailwind
Backend real
```

A implementação deve permanecer simples e didática.

---

# 4. Estrutura esperada

```text
frontend/
└── admin/
    ├── public/
    │   ├── favicon.svg
    │   └── mocks/
    │       ├── users.json
    │       ├── departments.json
    │       ├── roles.json
    │       ├── dashboard.json
    │       └── environment-options.json
    │
    ├── src/
    │   ├── app/
    │   │   ├── components/
    │   │   │   ├── sidebar/
    │   │   │   ├── header/
    │   │   │   ├── page-header/
    │   │   │   ├── data-table/
    │   │   │   ├── pagination/
    │   │   │   ├── search-input/
    │   │   │   ├── autocomplete/
    │   │   │   ├── form-field/
    │   │   │   ├── select-field/
    │   │   │   ├── alert/
    │   │   │   ├── confirm-dialog/
    │   │   │   ├── metric-card/
    │   │   │   └── loading/
    │   │   │
    │   │   ├── layouts/
    │   │   │   └── admin-layout/
    │   │   │       ├── admin-layout.component.ts
    │   │   │       ├── admin-layout.component.html
    │   │   │       └── admin-layout.component.css
    │   │   │
    │   │   ├── pages/
    │   │   │   ├── dashboard/
    │   │   │   │   ├── dashboard-page.component.ts
    │   │   │   │   ├── dashboard-page.component.html
    │   │   │   │   └── dashboard-page.component.css
    │   │   │   ├── users/
    │   │   │   │   ├── list/
    │   │   │   │   ├── new/
    │   │   │   │   ├── edit/
    │   │   │   │   └── detail/
    │   │   │   └── settings/
    │   │   │       ├── settings-page.component.ts
    │   │   │       ├── settings-page.component.html
    │   │   │       └── settings-page.component.css
    │   │   │
    │   │   ├── models/
    │   │   │   ├── dashboard.types.ts
    │   │   │   ├── user.types.ts
    │   │   │   ├── pagination.types.ts
    │   │   │   └── settings.types.ts
    │   │   ├── services/
    │   │   │   ├── dashboard.service.ts
    │   │   │   ├── user.service.ts
    │   │   │   ├── settings.service.ts
    │   │   │   └── admin-api.service.ts
    │   │   ├── storage/
    │   │   │   ├── user.storage.ts
    │   │   │   └── settings.storage.ts
    │   │   ├── validators/
    │   │   │   └── user.validators.ts
    │   │   ├── utils/
    │   │   │   └── delay.ts
    │   │   ├── app.component.ts
    │   │   ├── app.component.html
    │   │   ├── app.config.ts
    │   │   └── app.routes.ts
    │   │
    │   ├── environments/
    │   │   ├── environment.ts
    │   │   ├── environment.development.ts
    │   │   ├── environment.homolog.ts
    │   │   ├── environment.production.ts
    │   │   └── environment.docker.ts
    │   ├── styles/
    │   │   ├── reset.css
    │   │   ├── variables.css
    │   │   └── global.css
    │   ├── index.html
    │   └── main.ts
    │
    ├── angular.json
    ├── package.json
    ├── tsconfig.json
    └── README.md
```

Os componentes devem ser preferencialmente **standalone**.

---

# 5. Rotas

Criar em:

```text
src/app/app.routes.ts
```

Rotas:

```text
/dashboard
/usuarios
/usuarios/novo
/usuarios/:id
/usuarios/:id/editar
/configuracoes
```

Exemplo:

```ts
import { Routes } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { DashboardPageComponent } from './pages/dashboard/dashboard-page.component';
import { UserListPageComponent } from './pages/users/list/user-list-page.component';
import { UserNewPageComponent } from './pages/users/new/user-new-page.component';
import { UserEditPageComponent } from './pages/users/edit/user-edit-page.component';
import { UserDetailPageComponent } from './pages/users/detail/user-detail-page.component';
import { SettingsPageComponent } from './pages/settings/settings-page.component';

export const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
      { path: 'dashboard', component: DashboardPageComponent },
      { path: 'usuarios', component: UserListPageComponent },
      { path: 'usuarios/novo', component: UserNewPageComponent },
      { path: 'usuarios/:id', component: UserDetailPageComponent },
      { path: 'usuarios/:id/editar', component: UserEditPageComponent },
      { path: 'configuracoes', component: SettingsPageComponent },
    ],
  },
];
```

Configurar `provideRouter(routes)` no `app.config.ts`.

---

# 6. Layout Admin

Criar:

```text
src/app/layouts/admin-layout/admin-layout.component.ts
```

Estrutura:

```text
Sidebar
   +
Header
   +
Conteúdo
```

Layout visual:

```text
┌──────────────┬─────────────────────────────┐
│ Sidebar      │ Header                      │
│              ├─────────────────────────────┤
│ Dashboard    │                             │
│ Usuários     │ Conteúdo                    │
│ Configuração │                             │
│              │                             │
└──────────────┴─────────────────────────────┘
```

---

# 7. Sidebar

Itens:

```text
Dashboard
Usuários
Configurações
```

Deve:

- destacar rota atual;
- permitir navegação;
- funcionar em desktop;
- recolher no mobile;
- exibir nome do projeto.

Exemplo:

```text
RH Admin

Dashboard
Usuários
Configurações
```

---

# 8. Header

Exibir:

```text
Nome do usuário
Perfil
Botão / link de configurações
Botão sair
```

Exemplo:

```text
Administrador RH
admin

[Configurações]
[Sair]
```

O logout pode utilizar a sessão mockada criada na task Auth.

---

# 9. Dashboard

Criar:

```text
src/app/pages/dashboard/dashboard-page.component.ts
```

Exibir dados mockados.

Cards:

```text
Total de usuários
Usuários ativos
Usuários inativos
Administradores
```

Exemplo:

```text
Total de usuários      128
Usuários ativos        115
Usuários inativos       13
Administradores          8
```

---

# 10. Outros conteúdos do dashboard

Criar seções:

```text
Últimos usuários cadastrados
Usuários por perfil
Usuários por departamento
Atividades recentes
```

Não é necessário gráfico complexo nesta primeira versão.

Pode utilizar:

```text
barras simples em CSS
cards
listas
```

---

# 11. Mock do dashboard

Criar:

```text
public/mocks/dashboard.json
```

Exemplo:

```json
{
  "metrics": {
    "totalUsers": 128,
    "activeUsers": 115,
    "inactiveUsers": 13,
    "administrators": 8
  },
  "recentUsers": [
    {
      "id": "1",
      "name": "Mariana Souza",
      "email": "mariana@rh.local"
    },
    {
      "id": "2",
      "name": "Carlos Mendes",
      "email": "carlos@rh.local"
    }
  ],
  "usersByRole": [
    {
      "label": "Administrador",
      "value": 8
    },
    {
      "label": "Gestor",
      "value": 20
    },
    {
      "label": "Usuário",
      "value": 100
    }
  ]
}
```

---

# 12. CRUD de Usuários

A feature deve possuir:

```text
Users/
├── List
├── New
├── Edit
└── Detail
```

Cada página deve ficar dentro de sua pasta correspondente.

---

# 13. User List

Criar:

```text
src/app/pages/users/list/user-list-page.component.ts
```

A página deve conter:

```text
Título
Botão Novo usuário
Campo Pesquisa
Filtros
Tabela
Paginação
```

---

# 14. Colunas da tabela

Exibir:

```text
Nome
Email
Perfil
Departamento
Status
Criado em
Ações
```

Ações:

```text
Detalhe
Editar
Excluir
```

---

# 15. Busca

Criar campo:

```text
Pesquisar usuário
```

Pesquisar por:

```text
Nome
Email
```

Pode filtrar os dados mockados localmente.

Adicionar debounce simples de:

```text
300 ms
```

sem instalar biblioteca adicional.

---

# 16. Filtros

Criar:

```text
Perfil
Departamento
Status
```

Exemplos:

```text
Todos
Administrador
Gestor
Usuário
```

Status:

```text
Todos
Ativo
Inativo
```

---

# 17. Paginação

Implementar paginação real sobre os dados mockados.

Criar tipo:

```ts
export interface PaginationParams {
  page: number;
  pageSize: number;
}
```

Criar resposta:

```ts
export interface PaginatedResponse<T> {
  items: T[];
  page: number;
  pageSize: number;
  totalItems: number;
  totalPages: number;
}
```

---

# 18. Configuração da paginação

Valores disponíveis:

```text
10
20
50
```

Mostrar:

```text
Página 1 de 5
```

Botões:

```text
Anterior
Próxima
```

Opcional:

```text
1 2 3 4 5
```

---

# 19. Autocomplete

Criar componente:

```text
Autocomplete
```

Utilizar no formulário de usuário para:

```text
Departamento
Gestor
```

Exemplo:

```text
Departamento
[ Recur________________ ]

Sugestões:
Recursos Humanos
Recrutamento
```

---

# 20. Regras do autocomplete

Deve:

```text
abrir após digitação
filtrar sugestões
permitir seleção
fechar ao selecionar
mostrar item selecionado
permitir limpar
```

Não chamar backend nesta fase.

Dados vêm de JSON.

---

# 21. departments.json

Criar:

```text
public/mocks/departments.json
```

Exemplo:

```json
[
  {
    "id": "1",
    "name": "Recursos Humanos"
  },
  {
    "id": "2",
    "name": "Recrutamento e Seleção"
  },
  {
    "id": "3",
    "name": "Tecnologia"
  },
  {
    "id": "4",
    "name": "Financeiro"
  },
  {
    "id": "5",
    "name": "Administrativo"
  }
]
```

---

# 22. roles.json

Criar:

```text
public/mocks/roles.json
```

Exemplo:

```json
[
  {
    "id": "admin",
    "name": "Administrador"
  },
  {
    "id": "manager",
    "name": "Gestor"
  },
  {
    "id": "user",
    "name": "Usuário"
  }
]
```

---

# 23. users.json

Criar:

```text
public/mocks/users.json
```

Deve possuir pelo menos:

```text
30 usuários fictícios
```

para permitir validar paginação.

Cada usuário:

```ts
id
name
email
phone
role
departmentId
managerId?
active
createdAt
updatedAt
```

Exemplo:

```json
{
  "id": "1",
  "name": "Administrador RH",
  "email": "admin@rh.local",
  "phone": "(51) 99999-0001",
  "role": "admin",
  "departmentId": "1",
  "managerId": null,
  "active": true,
  "createdAt": "2026-09-01T10:00:00",
  "updatedAt": "2026-09-01T10:00:00"
}
```

Todos os dados devem ser fictícios.

---

# 24. User New

Criar:

```text
src/app/pages/users/new/user-new-page.component.ts
```

Campos:

```text
Nome
Email
Telefone
Perfil
Departamento
Gestor
Status
```

Botões:

```text
Salvar
Cancelar
```

---

# 25. User Edit

Criar:

```text
src/app/pages/users/edit/user-edit-page.component.ts
```

Deve:

```text
buscar usuário pelo id
preencher formulário
permitir alteração
validar
salvar no mock local
```

Como JSON não pode ser alterado fisicamente:

```text
alterações devem ser persistidas em localStorage
```

---

# 26. User Detail

Criar:

```text
src/app/pages/users/detail/user-detail-page.component.ts
```

Exibir:

```text
Nome
Email
Telefone
Perfil
Departamento
Gestor
Status
Data de criação
Última atualização
```

Ações:

```text
Editar
Voltar
```

---

# 27. Exclusão

Na listagem:

```text
Excluir
```

deve abrir:

```text
ConfirmDialog
```

Mensagem:

```text
Deseja realmente excluir este usuário?
```

Ao confirmar:

```text
remover apenas da persistência mockada
```

Não alterar fisicamente o JSON.

---

# 28. Persistência mockada

Fluxo:

```text
users.json
   ↓
carrega dados iniciais
   ↓
localStorage
   ↓
CRUD
```

Na primeira execução:

```text
se localStorage estiver vazio
    ↓
carregar users.json
    ↓
salvar cópia em localStorage
```

Depois:

```text
List
New
Edit
Delete
Detail
```

devem trabalhar sobre a cópia armazenada.

---

# 29. user.storage.ts

Criar:

```text
src/app/storage/user.storage.ts
```

Responsabilidades:

```text
initializeUsers()
getUsers()
saveUsers()
getUserById()
addUser()
updateUser()
deleteUser()
```

---

# 30. user.service.ts

Criar:

```text
src/app/services/user.service.ts
```

Responsabilidades:

```text
list
getById
create
update
delete
search
filter
paginate
```

Assinaturas sugeridas:

```ts
listUsers(params)
getUserById(id)
createUser(input)
updateUser(id, input)
deleteUser(id)
```

---

# 31. Tipos de usuário

Criar:

```text
src/app/models/user.types.ts
```

Exemplo:

```ts
export type UserRole = 'admin' | 'manager' | 'user';

export interface User {
  id: string;
  name: string;
  email: string;
  phone: string;
  role: UserRole;
  departmentId: string;
  managerId?: string | null;
  active: boolean;
  createdAt: string;
  updatedAt: string;
}

export interface UserFormInput {
  name: string;
  email: string;
  phone: string;
  role: UserRole;
  departmentId: string;
  managerId?: string | null;
  active: boolean;
}
```

---

# 32. Validação

Utilizar **Angular Reactive Forms**.

Criar os formulários com:

```text
FormBuilder
FormGroup
Validators
```

Criar:

```text
src/app/validators/user.validators.ts
```

Exemplo de formulário:

```ts
this.form = this.formBuilder.nonNullable.group({
  name: ['', [Validators.required, Validators.minLength(3)]],
  email: ['', [Validators.required, Validators.email]],
  phone: ['', [Validators.required, Validators.minLength(10)]],
  role: ['', Validators.required],
  departmentId: ['', Validators.required],
  managerId: [''],
  active: [true, Validators.required],
});
```

A validação de e-mail duplicado pode ser feita no `UserService` antes de criar ou atualizar.

Não instalar biblioteca externa apenas para validação nesta task.

---

# 33. Validações obrigatórias

Validar:

```text
Nome obrigatório
Nome mínimo 3 caracteres
Email obrigatório
Email válido
Email não duplicado
Telefone obrigatório
Perfil obrigatório
Departamento obrigatório
Status obrigatório
```

---

# 34. Email duplicado

Antes de criar:

```text
verificar se email já existe
```

Ao editar:

```text
permitir manter o email do próprio usuário
```

Erro:

```text
Já existe um usuário cadastrado com este e-mail.
```

---

# 35. Mensagens

Sucesso:

```text
Usuário criado com sucesso.
Usuário atualizado com sucesso.
Usuário excluído com sucesso.
```

Erro:

```text
Não foi possível carregar os usuários.
Usuário não encontrado.
Já existe um usuário cadastrado com este e-mail.
```

---

# 36. Configurações do Admin

Criar:

```text
/configuracoes
```

Página:

```text
src/app/pages/settings/settings-page.component.ts
```

Objetivo:

Permitir que o usuário personalize a aparência do Admin para seu perfil.

---

# 37. Preferências disponíveis

Permitir configurar:

```text
Tema
Cor principal
Sidebar expandida/recolhida
Densidade visual
Quantidade padrão por página
Idioma visual preparado
```

---

# 38. Tema

Opções:

```text
Claro
Escuro
Sistema
```

Tipo:

```ts
export type ThemeMode = 'light' | 'dark' | 'system';
```

---

# 39. Cor principal

Permitir algumas opções pré-definidas:

```text
Azul
Verde
Roxo
Laranja
Vermelho
```

Pode incluir:

```html
<input type="color">
```

para cor personalizada.

---

# 40. Configuração visual

Exemplo:

```text
Aparência

Tema
( ) Claro
( ) Escuro
( ) Sistema

Cor principal
[ Azul ]
[ Verde ]
[ Roxo ]
[ Laranja ]

Cor personalizada
[ #1f4f8a ]

Sidebar
[✓] Manter expandida

Densidade
Compacta
Confortável
```

---

# 41. Paginação padrão

Na configuração permitir:

```text
10 itens
20 itens
50 itens
```

Essa configuração deve ser usada como padrão no CRUD de usuários.

---

# 42. Persistência de preferências

Criar:

```text
src/app/storage/settings.storage.ts
```

Salvar preferências em:

```text
localStorage
```

Chave sugerida:

```text
@rh-admin:settings
```

---

# 43. settings.types.ts

Criar:

```ts
export type ThemeMode = 'light' | 'dark' | 'system';

export type DensityMode = 'compact' | 'comfortable';

export interface AdminSettings {
  theme: ThemeMode;
  primaryColor: string;
  sidebarExpanded: boolean;
  density: DensityMode;
  defaultPageSize: 10 | 20 | 50;
}
```

---

# 44. Configuração padrão

Criar:

```text
public/mocks/environment-options.json
```

Exemplo:

```json
{
  "themes": [
    "light",
    "dark",
    "system"
  ],
  "primaryColors": [
    {
      "name": "Azul",
      "value": "#1f4f8a"
    },
    {
      "name": "Verde",
      "value": "#2f7f73"
    },
    {
      "name": "Roxo",
      "value": "#6b4eff"
    },
    {
      "name": "Laranja",
      "value": "#d97706"
    },
    {
      "name": "Vermelho",
      "value": "#b42318"
    }
  ],
  "pageSizes": [
    10,
    20,
    50
  ]
}
```

---

# 45. Aplicar cor no Admin

Utilizar variável CSS:

```css
:root {
  --color-primary: #1f4f8a;
}
```

Quando usuário trocar a cor:

```ts
document.documentElement.style.setProperty(
  '--color-primary',
  settings.primaryColor
);
```

---

# 46. Tema claro/escuro

Aplicar atributo:

```html
<html data-theme="dark">
```

ou:

```html
<html data-theme="light">
```

Exemplo CSS:

```css
:root {
  --color-background: #f5f7fa;
  --color-surface: #ffffff;
  --color-text: #222222;
}

[data-theme='dark'] {
  --color-background: #121212;
  --color-surface: #1e1e1e;
  --color-text: #f4f4f4;
}
```

---

# 47. Configuração por perfil do usuário

As preferências devem ser salvas por usuário.

Exemplo de chave:

```text
@rh-admin:settings:<userId>
```

Exemplo:

```text
@rh-admin:settings:1
```

Assim cada usuário pode possuir sua própria aparência.

---

# 48. Link para configurações

Disponibilizar acesso:

```text
Sidebar → Configurações
```

e também no Header:

```text
Perfil
   ↓
Configurações
```

---

# 49. Autocomplete de gestor

No cadastro de usuário:

```text
Gestor
```

deve pesquisar usuários que possuam perfil:

```text
admin
manager
```

Exemplo:

```text
Digite:
Mar

Sugestões:
Mariana Souza
Marcelo Alves
```

---

# 50. Autocomplete de departamento

Campo:

```text
Departamento
```

deve pesquisar:

```text
departments.json
```

---

# 51. Loading

Implementar loading em:

```text
Dashboard
Lista
Novo
Editar
Detalhe
Excluir
```

Simular:

```text
300ms a 500ms
```

para representar futuras chamadas HTTP.

---

# 52. Estados vazios

Listagem deve tratar:

```text
nenhum usuário
nenhum resultado da busca
nenhum resultado dos filtros
```

Exemplo:

```text
Nenhum usuário encontrado.
```

---

# 53. Responsividade

Admin deve funcionar em:

```text
Desktop
Tablet
Mobile
```

No mobile:

```text
Sidebar recolhida
Tabela pode ter scroll horizontal
Formulários em uma coluna
Cards em uma coluna quando necessário
```

---

# 54. Dashboard responsivo

Desktop:

```text
4 cards lado a lado
```

Tablet:

```text
2 por linha
```

Mobile:

```text
1 por linha
```

---

# 55. Ambientes

No Angular, utilizar arquivos de ambiente em:

```text
src/environments/
```

Criar:

```text
environment.ts
environment.development.ts
environment.homolog.ts
environment.production.ts
environment.docker.ts
```

---

# 56. Ambiente local

`src/environments/environment.ts`

```ts
export const environment = {
  production: false,
  appName: 'RH Admin',
  appEnv: 'local',
  adminBaseUrl: 'http://localhost:4202',
  authBaseUrl: 'http://localhost:4200',
  siteBaseUrl: 'http://localhost:4201',
  apiBaseUrl: 'http://localhost:5000',
  dataSource: 'mock',
  enableLogs: true,
};
```

> As portas locais são uma sugestão para executar Auth, Site e Admin simultaneamente. Se o projeto já definiu outras portas locais, preservar a configuração existente.

---

# 57. Ambiente Docker

Compatível com a TASK-002:

```ts
export const environment = {
  production: true,
  appName: 'RH Admin',
  appEnv: 'docker',
  adminBaseUrl: 'http://localhost:8082',
  authBaseUrl: 'http://localhost:8083',
  siteBaseUrl: 'http://localhost:8081',
  apiBaseUrl: 'http://localhost:5000',
  dataSource: 'mock',
  enableLogs: true,
};
```

Registrar no `angular.json` uma configuração `docker` usando `fileReplacements`.

Exemplo:

```json
{
  "docker": {
    "fileReplacements": [
      {
        "replace": "src/environments/environment.ts",
        "with": "src/environments/environment.docker.ts"
      }
    ]
  }
}
```

Criar configurações equivalentes para `development`, `homolog` e `production`.

---

# 58. Uso das configurações

Não utilizar:

```text
import.meta.env
VITE_*
.env do Vite
```

Utilizar:

```ts
import { environment } from '../../environments/environment';
```

Exemplo:

```ts
const authUrl = environment.authBaseUrl;
const apiUrl = environment.apiBaseUrl;
```

Nenhuma URL deve ser escrita diretamente nas páginas ou componentes.

---

# 59. API futura

Criar:

```text
src/app/services/admin-api.service.ts
```

Preparar integração futura para:

```text
GET /api/admin/users
GET /api/admin/users/{id}
POST /api/admin/users
PUT /api/admin/users/{id}
DELETE /api/admin/users/{id}
GET /api/admin/dashboard
```

Utilizar `HttpClient`, mas não consumir backend nesta etapa.

Exemplo conceitual:

```ts
@Injectable({ providedIn: 'root' })
export class AdminApiService {
  private readonly http = inject(HttpClient);

  getUsers() {
    return this.http.get<User[]>(`${environment.apiBaseUrl}/api/admin/users`);
  }
}
```

Configurar `provideHttpClient()` no `app.config.ts`.

---

# 60. Fluxo atual

Hoje:

```text
Page
  ↓
Service
  ↓
Storage
  ↓
JSON Mock / localStorage
```

Futuro:

```text
Page
  ↓
Service
  ↓
API
  ↓
Backend
```

As páginas não devem precisar ser reescritas.

---

# 61. README

Criar:

```text
frontend/admin/README.md
```

Documentar:

```text
Objetivo
Tecnologias
Instalação
Execução
Rotas
Dashboard
CRUD
Paginação
Autocomplete
Validação
Mocks
Preferências
Tema
Cores
Ambientes
Docker
Build
Limitações
```

---

# 62. Scripts

Adicionar ao `package.json`:

```json
{
  "scripts": {
    "start": "ng serve",
    "start:development": "ng serve --configuration development",
    "start:homolog": "ng serve --configuration homolog",
    "start:production": "ng serve --configuration production",
    "build": "ng build",
    "build:development": "ng build --configuration development",
    "build:homolog": "ng build --configuration homolog",
    "build:production": "ng build --configuration production",
    "build:docker": "ng build --configuration docker",
    "lint": "ng lint"
  }
}
```

Caso o starter Angular utilizado não possua lint configurado, adicionar ESLint compatível com Angular antes de exigir `npm run lint`.

---

# 63. Critérios de aceite — Dashboard

- [ ] Dashboard criado.
- [ ] Métricas exibidas.
- [ ] Usuários recentes exibidos.
- [ ] Distribuição por perfil exibida.
- [ ] Dados vêm do mock.
- [ ] Loading implementado.
- [ ] Layout responsivo.

---

# 64. Critérios de aceite — Usuários

- [ ] List criado.
- [ ] New criado.
- [ ] Edit criado.
- [ ] Detail criado.
- [ ] Delete implementado.
- [ ] Busca funciona.
- [ ] Filtros funcionam.
- [ ] Paginação funciona.
- [ ] Page Size funciona.
- [ ] Autocomplete departamento funciona.
- [ ] Autocomplete gestor funciona.
- [ ] Validação funciona.
- [ ] Email duplicado é tratado.
- [ ] Mensagens de sucesso funcionam.
- [ ] Dados persistem em localStorage.
- [ ] JSON original não é alterado.

---

# 65. Critérios de aceite — Configurações

- [ ] Página Configurações criada.
- [ ] Link na Sidebar.
- [ ] Link no Header.
- [ ] Tema claro funciona.
- [ ] Tema escuro funciona.
- [ ] Tema sistema funciona.
- [ ] Cor principal pode ser alterada.
- [ ] Cor customizada pode ser utilizada.
- [ ] Sidebar pode ser configurada.
- [ ] Densidade pode ser alterada.
- [ ] Page Size padrão pode ser alterado.
- [ ] Preferências persistem.
- [ ] Preferências são por usuário.

---

# 66. Critérios gerais

- [ ] Angular configurado.
- [ ] TypeScript configurado.
- [ ] Angular Router configurado.
- [ ] Angular Reactive Forms configurado.
- [ ] Validadores Angular configurados.
- [ ] Estrutura organizada.
- [ ] Nenhum `any`.
- [ ] Nenhuma URL hardcoded.
- [ ] Nenhum backend criado.
- [ ] Nenhum dado pessoal real.
- [ ] Responsividade implementada.
- [ ] README criado.
- [ ] `npm run lint` sem erro.
- [ ] `npm run build` sem erro.

---

# 67. Fora de escopo

Não criar nesta task:

```text
Backend C#
API real
Banco de dados
JWT real
Permissões reais
Controle de acesso por rota avançado
Auditoria real
Logs de backend
Upload de avatar
Upload de arquivo
Importação Excel
Exportação Excel
Relatórios avançados
Gráficos complexos
TanStack Query
Redux
WebSocket
```

---

# 68. Instruções para IA / Copilot

Ao executar esta task:

1. Criar o módulo Admin completo.
2. Não criar backend.
3. Utilizar mocks JSON.
4. Utilizar localStorage para persistência simulada.
5. Criar Dashboard.
6. Criar CRUD de usuários.
7. Separar `List`, `New`, `Edit` e `Detail`.
8. Implementar paginação.
9. Implementar busca.
10. Implementar filtros.
11. Implementar autocomplete.
12. Implementar Angular Reactive Forms.
13. Implementar validadores Angular.
14. Não utilizar `any`.
15. Implementar mensagens de erro.
16. Implementar mensagens de sucesso.
17. Implementar loading.
18. Implementar empty state.
19. Implementar configurações de aparência.
20. Implementar tema.
21. Implementar cor principal.
22. Persistir preferências por usuário.
23. Centralizar URLs nos arquivos `environment*.ts`.
24. Não hardcodar URLs.
25. Manter código simples e didático.
26. Executar lint.
27. Executar build.
28. Corrigir erros encontrados.
29. Atualizar README.
30. Ao finalizar informar as rotas principais:

```text
/dashboard
/usuarios
/usuarios/novo
/usuarios/:id
/usuarios/:id/editar
/configuracoes
```
