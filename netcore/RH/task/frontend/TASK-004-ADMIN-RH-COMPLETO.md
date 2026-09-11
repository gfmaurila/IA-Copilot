# TASK-004 — Criar Painel Admin RH Completo com Dashboard, CRUD de Usuários e Preferências

## 1. Objetivo

Criar a estrutura completa do módulo:

```text
frontend/admin
```

O módulo Admin deve ser uma aplicação React + TypeScript + Vite funcional, organizada e didática.

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
React
TypeScript
Vite
React Router
CSS simples organizado
Fetch API preparada para futuro
ESLint
Prettier
```

Permitido:

```text
React Hook Form
Zod
```

Essas bibliotecas devem ser utilizadas para formulários e validação.

Instalar:

```bash
npm install react-router-dom
npm install react-hook-form
npm install zod
npm install @hookform/resolvers
```

Não utilizar nesta primeira versão:

```text
Redux
Zustand
TanStack Query
Axios
Material UI
Ant Design
Bootstrap
Tailwind
Backend real
```

---

# 4. Estrutura esperada

```text
frontend/
└── admin/
    ├── public/
    │   └── favicon.svg
    │
    ├── src/
    │   ├── api/
    │   │   └── admin.api.ts
    │   │
    │   ├── components/
    │   │   ├── Sidebar/
    │   │   │   ├── Sidebar.tsx
    │   │   │   └── Sidebar.css
    │   │   ├── Header/
    │   │   │   ├── Header.tsx
    │   │   │   └── Header.css
    │   │   ├── PageHeader/
    │   │   │   ├── PageHeader.tsx
    │   │   │   └── PageHeader.css
    │   │   ├── DataTable/
    │   │   │   ├── DataTable.tsx
    │   │   │   └── DataTable.css
    │   │   ├── Pagination/
    │   │   │   ├── Pagination.tsx
    │   │   │   └── Pagination.css
    │   │   ├── SearchInput/
    │   │   │   ├── SearchInput.tsx
    │   │   │   └── SearchInput.css
    │   │   ├── Autocomplete/
    │   │   │   ├── Autocomplete.tsx
    │   │   │   └── Autocomplete.css
    │   │   ├── FormField/
    │   │   │   ├── FormField.tsx
    │   │   │   └── FormField.css
    │   │   ├── SelectField/
    │   │   │   ├── SelectField.tsx
    │   │   │   └── SelectField.css
    │   │   ├── Alert/
    │   │   │   ├── Alert.tsx
    │   │   │   └── Alert.css
    │   │   ├── ConfirmDialog/
    │   │   │   ├── ConfirmDialog.tsx
    │   │   │   └── ConfirmDialog.css
    │   │   ├── MetricCard/
    │   │   │   ├── MetricCard.tsx
    │   │   │   └── MetricCard.css
    │   │   └── Loading/
    │   │       ├── Loading.tsx
    │   │       └── Loading.css
    │   │
    │   ├── layouts/
    │   │   └── AdminLayout.tsx
    │   │
    │   ├── mocks/
    │   │   ├── users.json
    │   │   ├── departments.json
    │   │   ├── roles.json
    │   │   ├── dashboard.json
    │   │   └── environment-options.json
    │   │
    │   ├── pages/
    │   │   ├── Dashboard/
    │   │   │   ├── DashboardPage.tsx
    │   │   │   └── DashboardPage.css
    │   │   │
    │   │   ├── Users/
    │   │   │   ├── List/
    │   │   │   │   ├── UserListPage.tsx
    │   │   │   │   └── UserListPage.css
    │   │   │   ├── New/
    │   │   │   │   ├── UserNewPage.tsx
    │   │   │   │   └── UserNewPage.css
    │   │   │   ├── Edit/
    │   │   │   │   ├── UserEditPage.tsx
    │   │   │   │   └── UserEditPage.css
    │   │   │   └── Detail/
    │   │   │       ├── UserDetailPage.tsx
    │   │   │       └── UserDetailPage.css
    │   │   │
    │   │   └── Settings/
    │   │       ├── SettingsPage.tsx
    │   │       └── SettingsPage.css
    │   │
    │   ├── routes/
    │   │   └── AppRouter.tsx
    │   │
    │   ├── schemas/
    │   │   └── user.schema.ts
    │   │
    │   ├── services/
    │   │   ├── dashboard.service.ts
    │   │   ├── user.service.ts
    │   │   └── settings.service.ts
    │   │
    │   ├── storage/
    │   │   ├── user.storage.ts
    │   │   └── settings.storage.ts
    │   │
    │   ├── styles/
    │   │   ├── reset.css
    │   │   ├── variables.css
    │   │   └── global.css
    │   │
    │   ├── types/
    │   │   ├── dashboard.types.ts
    │   │   ├── user.types.ts
    │   │   ├── pagination.types.ts
    │   │   └── settings.types.ts
    │   │
    │   ├── utils/
    │   │   ├── env.ts
    │   │   └── delay.ts
    │   │
    │   ├── App.tsx
    │   └── main.tsx
    │
    ├── .env
    ├── .env.development
    ├── .env.homolog
    ├── .env.production
    ├── .env.docker
    ├── .env.example
    ├── package.json
    ├── tsconfig.json
    ├── vite.config.ts
    └── README.md
```

---

# 5. Rotas

Criar:

```text
/dashboard
/usuarios
/usuarios/novo
/usuarios/:id
/usuarios/:id/editar
/configuracoes
```

Exemplo:

```tsx
<Routes>
  <Route element={<AdminLayout />}>
    <Route path="/" element={<Navigate to="/dashboard" replace />} />
    <Route path="/dashboard" element={<DashboardPage />} />

    <Route path="/usuarios" element={<UserListPage />} />
    <Route path="/usuarios/novo" element={<UserNewPage />} />
    <Route path="/usuarios/:id" element={<UserDetailPage />} />
    <Route path="/usuarios/:id/editar" element={<UserEditPage />} />

    <Route path="/configuracoes" element={<SettingsPage />} />
  </Route>
</Routes>
```

---

# 6. Layout Admin

Criar:

```text
src/layouts/AdminLayout.tsx
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
src/pages/Dashboard/DashboardPage.tsx
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
src/mocks/dashboard.json
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
src/pages/Users/List/UserListPage.tsx
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
src/mocks/departments.json
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
src/mocks/roles.json
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
src/mocks/users.json
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
src/pages/Users/New/UserNewPage.tsx
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
src/pages/Users/Edit/UserEditPage.tsx
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
src/pages/Users/Detail/UserDetailPage.tsx
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
src/storage/user.storage.ts
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
src/services/user.service.ts
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
src/types/user.types.ts
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

Utilizar:

```text
React Hook Form
Zod
```

Criar:

```text
src/schemas/user.schema.ts
```

Exemplo:

```ts
import { z } from 'zod';

export const userSchema = z.object({
  name: z
    .string()
    .min(3, 'Informe pelo menos 3 caracteres.'),

  email: z
    .string()
    .email('Informe um e-mail válido.'),

  phone: z
    .string()
    .min(10, 'Informe um telefone válido.'),

  role: z
    .string()
    .min(1, 'Selecione um perfil.'),

  departmentId: z
    .string()
    .min(1, 'Selecione um departamento.'),

  managerId: z
    .string()
    .nullable()
    .optional(),

  active: z.boolean(),
});
```

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
src/pages/Settings/SettingsPage.tsx
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
src/storage/settings.storage.ts
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
src/mocks/environment-options.json
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

Criar:

```text
.env
.env.development
.env.homolog
.env.production
.env.docker
.env.example
```

---

# 56. .env local

```env
VITE_APP_NAME=RH Admin
VITE_APP_ENV=local

VITE_ADMIN_BASE_URL=http://localhost:5173
VITE_AUTH_BASE_URL=http://localhost:5174
VITE_SITE_BASE_URL=http://localhost:5175

VITE_API_BASE_URL=http://localhost:5000

VITE_ADMIN_DATA_SOURCE=mock

VITE_ENABLE_LOGS=true
```

---

# 57. .env.docker

Compatível com a task Docker:

```env
VITE_APP_NAME=RH Admin
VITE_APP_ENV=docker

VITE_ADMIN_BASE_URL=http://localhost:8082
VITE_AUTH_BASE_URL=http://localhost:8083
VITE_SITE_BASE_URL=http://localhost:8081

VITE_API_BASE_URL=http://localhost:5000

VITE_ADMIN_DATA_SOURCE=mock

VITE_ENABLE_LOGS=true
```

---

# 58. env.ts

Criar:

```ts
export const env = {
  appName: import.meta.env.VITE_APP_NAME,
  appEnv: import.meta.env.VITE_APP_ENV,

  adminBaseUrl: import.meta.env.VITE_ADMIN_BASE_URL,
  authBaseUrl: import.meta.env.VITE_AUTH_BASE_URL,
  siteBaseUrl: import.meta.env.VITE_SITE_BASE_URL,
  apiBaseUrl: import.meta.env.VITE_API_BASE_URL,

  dataSource: import.meta.env.VITE_ADMIN_DATA_SOURCE,

  enableLogs: import.meta.env.VITE_ENABLE_LOGS === 'true',
};
```

---

# 59. API futura

Criar:

```text
src/api/admin.api.ts
```

Preparar funções:

```text
GET /api/admin/users
GET /api/admin/users/{id}
POST /api/admin/users
PUT /api/admin/users/{id}
DELETE /api/admin/users/{id}
GET /api/admin/dashboard
```

Não usar nesta etapa.

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

Adicionar:

```json
{
  "scripts": {
    "dev": "vite",
    "dev:development": "vite --mode development",
    "dev:homolog": "vite --mode homolog",
    "dev:production": "vite --mode production",

    "build": "tsc -b && vite build",
    "build:development": "tsc -b && vite build --mode development",
    "build:homolog": "tsc -b && vite build --mode homolog",
    "build:production": "tsc -b && vite build --mode production",
    "build:docker": "tsc -b && vite build --mode docker",

    "lint": "eslint .",
    "preview": "vite preview"
  }
}
```

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

- [ ] React configurado.
- [ ] TypeScript configurado.
- [ ] React Router configurado.
- [ ] React Hook Form configurado.
- [ ] Zod configurado.
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
12. Implementar React Hook Form.
13. Implementar Zod.
14. Não utilizar `any`.
15. Implementar mensagens de erro.
16. Implementar mensagens de sucesso.
17. Implementar loading.
18. Implementar empty state.
19. Implementar configurações de aparência.
20. Implementar tema.
21. Implementar cor principal.
22. Persistir preferências por usuário.
23. Centralizar URLs nos `.env`.
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
