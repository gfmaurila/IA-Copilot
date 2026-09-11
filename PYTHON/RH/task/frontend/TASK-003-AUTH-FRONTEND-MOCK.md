# TASK-003 — Criar Estrutura Frontend de Autenticação com Dados Mockados

## 1. Objetivo

Criar a estrutura completa do módulo frontend:

```text
frontend/auth
```

Este módulo será responsável pelas telas e pelo fluxo inicial de autenticação do projeto RH.

Nesta primeira versão, a autenticação será totalmente simulada utilizando dados mockados em arquivos JSON.

Não criar backend nesta task.

O objetivo é entregar um módulo funcional contendo:

```text
Login
Recuperar senha
Redefinir senha
Sessão mockada
Logout
Rotas
Estados de loading
Estados de erro
Mensagens de sucesso
Dados mockados em JSON
```

A implementação deve ser simples, organizada e fácil de entender para alguém iniciante em frontend.

---

# 2. Resultado esperado

Ao concluir esta task, deve existir:

```text
frontend/auth/
```

com uma aplicação React + TypeScript + Vite funcional.

URLs principais:

```text
/
 /login
 /recuperar-senha
 /redefinir-senha
```

A rota `/` pode redirecionar para:

```text
/login
```

---

# 3. Stack

Utilizar:

```text
React
TypeScript
Vite
React Router
Fetch API preparada para futuro
CSS simples organizado
ESLint
Prettier
```

Não utilizar nesta primeira versão:

```text
Redux
Zustand
TanStack Query
Axios
Material UI
Tailwind
Backend real
JWT real
Refresh Token real
```

---

# 4. Estrutura esperada

```text
frontend/
└── auth/
    ├── public/
    │   └── favicon.svg
    │
    ├── src/
    │   ├── api/
    │   │   └── auth.api.ts
    │   │
    │   ├── components/
    │   │   ├── AuthCard/
    │   │   │   ├── AuthCard.tsx
    │   │   │   └── AuthCard.css
    │   │   │
    │   │   ├── FormField/
    │   │   │   ├── FormField.tsx
    │   │   │   └── FormField.css
    │   │   │
    │   │   ├── LoadingButton/
    │   │   │   ├── LoadingButton.tsx
    │   │   │   └── LoadingButton.css
    │   │   │
    │   │   ├── Alert/
    │   │   │   ├── Alert.tsx
    │   │   │   └── Alert.css
    │   │   │
    │   │   └── AuthHeader/
    │   │       ├── AuthHeader.tsx
    │   │       └── AuthHeader.css
    │   │
    │   ├── layouts/
    │   │   └── AuthLayout.tsx
    │   │
    │   ├── mocks/
    │   │   ├── users.json
    │   │   ├── auth-messages.json
    │   │   └── reset-tokens.json
    │   │
    │   ├── pages/
    │   │   ├── Login/
    │   │   │   ├── LoginPage.tsx
    │   │   │   └── LoginPage.css
    │   │   │
    │   │   ├── ForgotPassword/
    │   │   │   ├── ForgotPasswordPage.tsx
    │   │   │   └── ForgotPasswordPage.css
    │   │   │
    │   │   └── ResetPassword/
    │   │       ├── ResetPasswordPage.tsx
    │   │       └── ResetPasswordPage.css
    │   │
    │   ├── routes/
    │   │   └── AppRouter.tsx
    │   │
    │   ├── services/
    │   │   └── auth.service.ts
    │   │
    │   ├── storage/
    │   │   └── auth.storage.ts
    │   │
    │   ├── styles/
    │   │   ├── reset.css
    │   │   ├── variables.css
    │   │   └── global.css
    │   │
    │   ├── types/
    │   │   └── auth.types.ts
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
    ├── .gitignore
    ├── package.json
    ├── tsconfig.json
    ├── vite.config.ts
    └── README.md
```

---

# 5. Rotas

Criar:

```text
src/routes/AppRouter.tsx
```

Rotas:

```text
/login
/recuperar-senha
/redefinir-senha
```

Exemplo:

```tsx
<Routes>
  <Route element={<AuthLayout />}>
    <Route path="/" element={<Navigate to="/login" replace />} />
    <Route path="/login" element={<LoginPage />} />
    <Route path="/recuperar-senha" element={<ForgotPasswordPage />} />
    <Route path="/redefinir-senha" element={<ResetPasswordPage />} />
  </Route>
</Routes>
```

---

# 6. Layout

Criar:

```text
src/layouts/AuthLayout.tsx
```

Estrutura sugerida:

```text
Logo / nome do sistema
        ↓
   AuthCard
        ↓
      Outlet
```

Visual:

```text
centralizado
limpo
profissional
responsivo
```

---

# 7. Página de Login

Criar:

```text
src/pages/Login/LoginPage.tsx
```

Campos:

```text
Email
Senha
```

Ações:

```text
Entrar
Esqueci minha senha
```

Exemplo visual:

```text
Talent RH

Acesse sua conta

Email
[________________]

Senha
[________________]

[ Entrar ]

Esqueci minha senha
```

---

# 8. Comportamento do Login

Ao clicar em:

```text
Entrar
```

executar:

```text
LoginPage
   ↓
auth.service.ts
   ↓
users.json
   ↓
validar email e senha
   ↓
retornar usuário mockado
```

Não importar:

```text
users.json
```

diretamente dentro da página.

---

# 9. Mock de usuários

Criar:

```text
src/mocks/users.json
```

Exemplo:

```json
[
  {
    "id": "1",
    "name": "Administrador RH",
    "email": "admin@rh.local",
    "password": "123456",
    "role": "admin",
    "active": true
  },
  {
    "id": "2",
    "name": "Usuário Teste",
    "email": "usuario@rh.local",
    "password": "123456",
    "role": "user",
    "active": true
  },
  {
    "id": "3",
    "name": "Usuário Inativo",
    "email": "inativo@rh.local",
    "password": "123456",
    "role": "user",
    "active": false
  }
]
```

Estes dados são somente para desenvolvimento.

Nunca utilizar senhas reais.

---

# 10. Credenciais de teste

Documentar no README:

```text
Administrador

Email:
admin@rh.local

Senha:
123456
```

E:

```text
Usuário

Email:
usuario@rh.local

Senha:
123456
```

Deixar explícito:

```text
CREDENCIAIS SOMENTE PARA MOCK LOCAL
```

---

# 11. Regras do Login

Validar:

```text
email vazio
senha vazia
email inexistente
senha incorreta
usuário inativo
```

Mensagens sugeridas:

```text
Informe o e-mail.
Informe a senha.
Usuário ou senha inválidos.
Usuário inativo.
Login realizado com sucesso.
```

Não informar de forma diferente:

```text
email existe
email não existe
```

no erro de credencial.

Para login inválido utilizar preferencialmente:

```text
Usuário ou senha inválidos.
```

---

# 12. Tipos TypeScript

Criar:

```text
src/types/auth.types.ts
```

Exemplo:

```ts
export type UserRole = 'admin' | 'user';

export interface MockUser {
  id: string;
  name: string;
  email: string;
  password: string;
  role: UserRole;
  active: boolean;
}

export interface AuthUser {
  id: string;
  name: string;
  email: string;
  role: UserRole;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  user: AuthUser;
  accessToken: string;
}

export interface ForgotPasswordRequest {
  email: string;
}

export interface ResetPasswordRequest {
  token: string;
  newPassword: string;
  confirmPassword: string;
}
```

Evitar:

```ts
any
```

---

# 13. Token mockado

Após login válido, retornar token fictício.

Exemplo:

```text
mock-access-token-user-1
```

Este token não é JWT real.

Não tentar simular criptografia.

Exemplo de retorno:

```json
{
  "user": {
    "id": "1",
    "name": "Administrador RH",
    "email": "admin@rh.local",
    "role": "admin"
  },
  "accessToken": "mock-access-token-user-1"
}
```

---

# 14. Storage local

Criar:

```text
src/storage/auth.storage.ts
```

Responsabilidade:

```text
salvar sessão mockada
ler sessão mockada
remover sessão
```

Exemplo:

```ts
const AUTH_STORAGE_KEY = '@rh:auth';

export function saveAuthSession(session: LoginResponse): void {
  localStorage.setItem(AUTH_STORAGE_KEY, JSON.stringify(session));
}

export function getAuthSession(): LoginResponse | null {
  const value = localStorage.getItem(AUTH_STORAGE_KEY);

  if (!value) {
    return null;
  }

  return JSON.parse(value) as LoginResponse;
}

export function clearAuthSession(): void {
  localStorage.removeItem(AUTH_STORAGE_KEY);
}
```

---

# 15. Segurança do mock

Deixar explícito:

```text
localStorage
senha em JSON
token mockado
```

são usados exclusivamente para desenvolvimento local.

Nunca usar essa estratégia como autenticação de produção.

---

# 16. auth.service.ts

Criar:

```text
src/services/auth.service.ts
```

Responsabilidades:

```text
login
logout
forgotPassword
resetPassword
```

Assinaturas sugeridas:

```ts
export async function login(
  request: LoginRequest
): Promise<LoginResponse>;

export async function logout(): Promise<void>;

export async function forgotPassword(
  request: ForgotPasswordRequest
): Promise<void>;

export async function resetPassword(
  request: ResetPasswordRequest
): Promise<void>;
```

---

# 17. Login mockado no service

Fluxo:

```text
receber email/senha
   ↓
simular delay
   ↓
buscar usuário no users.json
   ↓
validar active
   ↓
validar senha
   ↓
criar AuthUser sem password
   ↓
criar token mockado
   ↓
salvar sessão
   ↓
retornar LoginResponse
```

Nunca retornar:

```text
password
```

no objeto autenticado.

---

# 18. Delay simulado

Criar:

```text
src/utils/delay.ts
```

Exemplo:

```ts
export function delay(ms = 500): Promise<void> {
  return new Promise((resolve) => setTimeout(resolve, ms));
}
```

Usar para simular chamadas HTTP.

Exemplo:

```ts
await delay(500);
```

---

# 19. Recuperar senha

Criar:

```text
src/pages/ForgotPassword/ForgotPasswordPage.tsx
```

Campo:

```text
Email
```

Botão:

```text
Enviar instruções
```

Link:

```text
Voltar para o login
```

---

# 20. Comportamento de recuperação

Fluxo:

```text
usuário informa e-mail
        ↓
forgotPassword()
        ↓
simular delay
        ↓
retornar mensagem genérica
```

Mensagem:

```text
Se o e-mail estiver cadastrado, você receberá instruções para redefinir sua senha.
```

Mesmo se o e-mail não existir, retornar a mesma mensagem.

Isso evita indicar se uma conta existe.

---

# 21. Mock de tokens de recuperação

Criar:

```text
src/mocks/reset-tokens.json
```

Exemplo:

```json
[
  {
    "token": "reset-token-admin-123",
    "userId": "1",
    "active": true
  },
  {
    "token": "reset-token-user-456",
    "userId": "2",
    "active": true
  }
]
```

Somente para demonstração.

---

# 22. Link de recuperação mockado

Como não existe envio real de e-mail, documentar no README uma URL de teste:

```text
http://localhost:5173/redefinir-senha?token=reset-token-admin-123
```

No Docker:

```text
http://localhost:8083/redefinir-senha?token=reset-token-admin-123
```

---

# 23. Página redefinir senha

Criar:

```text
src/pages/ResetPassword/ResetPasswordPage.tsx
```

Campos:

```text
Nova senha
Confirmar nova senha
```

Botão:

```text
Redefinir senha
```

---

# 24. Regras para nova senha

Nesta primeira versão:

```text
mínimo 6 caracteres
nova senha obrigatória
confirmação obrigatória
senhas devem ser iguais
token deve existir
token deve estar ativo
```

Mensagens:

```text
Informe a nova senha.
A senha deve possuir pelo menos 6 caracteres.
Confirme a nova senha.
As senhas não conferem.
Token de recuperação inválido.
Senha redefinida com sucesso.
```

---

# 25. Atualização do mock

Como arquivos JSON não podem ser alterados no navegador de forma persistente:

```text
resetPassword()
```

não deve tentar editar fisicamente:

```text
users.json
```

Nesta task, ao redefinir com sucesso:

```text
simular sucesso
```

e redirecionar para:

```text
/login
```

Não fingir que o JSON foi realmente persistido.

---

# 26. auth-messages.json

Criar:

```text
src/mocks/auth-messages.json
```

Exemplo:

```json
{
  "login": {
    "success": "Login realizado com sucesso.",
    "invalidCredentials": "Usuário ou senha inválidos.",
    "inactiveUser": "Usuário inativo."
  },
  "forgotPassword": {
    "success": "Se o e-mail estiver cadastrado, você receberá instruções para redefinir sua senha."
  },
  "resetPassword": {
    "success": "Senha redefinida com sucesso.",
    "invalidToken": "Token de recuperação inválido."
  }
}
```

---

# 27. Loading

Durante operações:

```text
login
recuperar senha
redefinir senha
```

desabilitar o botão.

Exemplos:

```text
Entrando...
Enviando...
Redefinindo...
```

Evitar clique duplicado.

---

# 28. Alertas

Criar componente:

```text
Alert
```

Tipos:

```text
success
error
info
```

Exemplo:

```tsx
<Alert type="error">
  Usuário ou senha inválidos.
</Alert>
```

---

# 29. Validação de formulário

Implementar validação simples no frontend.

Não instalar biblioteca adicional apenas para esta task.

Exemplo:

```text
email obrigatório
formato básico de email
senha obrigatória
```

Pode utilizar funções TypeScript simples.

---

# 30. LoginPage — fluxo esperado

```text
Abrir /login
   ↓
Informar email
   ↓
Informar senha
   ↓
Clicar Entrar
   ↓
Loading
   ↓
auth.service.login()
   ↓
users.json
   ↓
Validar
   ↓
Salvar sessão
   ↓
Sucesso
```

Após sucesso:

```text
admin → http://localhost:8082
user  → inicialmente exibir mensagem ou redirecionar conforme regra do projeto
```

---

# 31. Redirecionamento após login

Para esta fase:

Se:

```text
role = admin
```

redirecionar para URL configurada:

```text
VITE_ADMIN_BASE_URL
```

Se:

```text
role = user
```

redirecionar para:

```text
VITE_SITE_BASE_URL
```

Não escrever URLs diretamente na página.

---

# 32. Ambientes

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

# 33. .env local

```env
VITE_APP_NAME=RH Auth
VITE_APP_ENV=local

VITE_AUTH_BASE_URL=http://localhost:5173
VITE_SITE_BASE_URL=http://localhost:5174
VITE_ADMIN_BASE_URL=http://localhost:5175

VITE_API_BASE_URL=http://localhost:5000

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

# 34. .env.development

```env
VITE_APP_NAME=RH Auth
VITE_APP_ENV=development

VITE_AUTH_BASE_URL=https://dev-auth.exemplo.com
VITE_SITE_BASE_URL=https://dev-site.exemplo.com
VITE_ADMIN_BASE_URL=https://dev-admin.exemplo.com

VITE_API_BASE_URL=https://dev-api.exemplo.com

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

# 35. .env.homolog

```env
VITE_APP_NAME=RH Auth
VITE_APP_ENV=homolog

VITE_AUTH_BASE_URL=https://homolog-auth.exemplo.com
VITE_SITE_BASE_URL=https://homolog-site.exemplo.com
VITE_ADMIN_BASE_URL=https://homolog-admin.exemplo.com

VITE_API_BASE_URL=https://homolog-api.exemplo.com

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

# 36. .env.production

```env
VITE_APP_NAME=RH Auth
VITE_APP_ENV=production

VITE_AUTH_BASE_URL=https://auth.exemplo.com
VITE_SITE_BASE_URL=https://www.exemplo.com
VITE_ADMIN_BASE_URL=https://admin.exemplo.com

VITE_API_BASE_URL=https://api.exemplo.com

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=false
```

Observação:

```text
VITE_AUTH_DATA_SOURCE=mock
```

é temporário.

Antes de produção real deve ser alterado para consumo de API.

---

# 37. .env.docker

Compatível com a task Docker:

```env
VITE_APP_NAME=RH Auth
VITE_APP_ENV=docker

VITE_AUTH_BASE_URL=http://localhost:8083
VITE_SITE_BASE_URL=http://localhost:8081
VITE_ADMIN_BASE_URL=http://localhost:8082

VITE_API_BASE_URL=http://localhost:5000

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=true
```

---

# 38. .env.example

```env
VITE_APP_NAME=
VITE_APP_ENV=

VITE_AUTH_BASE_URL=
VITE_SITE_BASE_URL=
VITE_ADMIN_BASE_URL=
VITE_API_BASE_URL=

VITE_AUTH_DATA_SOURCE=mock
VITE_ENABLE_LOGS=false
```

---

# 39. env.ts

Criar:

```text
src/utils/env.ts
```

Exemplo:

```ts
export const env = {
  appName: import.meta.env.VITE_APP_NAME,
  appEnv: import.meta.env.VITE_APP_ENV,

  authBaseUrl: import.meta.env.VITE_AUTH_BASE_URL,
  siteBaseUrl: import.meta.env.VITE_SITE_BASE_URL,
  adminBaseUrl: import.meta.env.VITE_ADMIN_BASE_URL,
  apiBaseUrl: import.meta.env.VITE_API_BASE_URL,

  authDataSource: import.meta.env.VITE_AUTH_DATA_SOURCE,

  enableLogs: import.meta.env.VITE_ENABLE_LOGS === 'true',
};
```

---

# 40. API futura

Criar:

```text
src/api/auth.api.ts
```

Mesmo sem usar nesta etapa.

Exemplo:

```ts
import { env } from '../utils/env';
import type {
  LoginRequest,
  LoginResponse,
  ForgotPasswordRequest,
  ResetPasswordRequest,
} from '../types/auth.types';

export async function loginApi(
  request: LoginRequest
): Promise<LoginResponse> {
  const response = await fetch(`${env.apiBaseUrl}/api/auth/login`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw new Error('Falha ao realizar login.');
  }

  return response.json();
}

export async function forgotPasswordApi(
  request: ForgotPasswordRequest
): Promise<void> {
  const response = await fetch(
    `${env.apiBaseUrl}/api/auth/forgot-password`,
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(request),
    }
  );

  if (!response.ok) {
    throw new Error('Falha ao recuperar senha.');
  }
}

export async function resetPasswordApi(
  request: ResetPasswordRequest
): Promise<void> {
  const response = await fetch(
    `${env.apiBaseUrl}/api/auth/reset-password`,
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(request),
    }
  );

  if (!response.ok) {
    throw new Error('Falha ao redefinir senha.');
  }
}
```

Nesta task o `auth.service.ts` deve utilizar os mocks.

---

# 41. Estrutura futura de troca Mock → API

Hoje:

```text
Page
  ↓
auth.service.ts
  ↓
JSON Mock
```

Futuramente:

```text
Page
  ↓
auth.service.ts
  ↓
auth.api.ts
  ↓
Backend
```

As páginas não devem precisar ser reescritas.

---

# 42. CSS

Criar:

```text
src/styles/reset.css
src/styles/variables.css
src/styles/global.css
```

Sugestão de variáveis:

```css
:root {
  --font-family: Inter, Arial, sans-serif;

  --color-primary: #1f4f8a;
  --color-primary-dark: #163a66;

  --color-background: #f5f7fa;
  --color-surface: #ffffff;

  --color-text: #222222;
  --color-text-light: #666666;

  --color-border: #dfe3e8;

  --color-error: #b42318;
  --color-success: #067647;

  --radius-sm: 6px;
  --radius-md: 10px;
  --radius-lg: 16px;
}
```

---

# 43. Responsividade

A tela deve funcionar em:

```text
Desktop
Tablet
Mobile
```

No mobile:

```text
AuthCard ocupa quase toda largura
campos ocupam 100%
botão ocupa 100%
textos não quebram layout
```

---

# 44. Acessibilidade

Adicionar:

```text
label associado ao input
autocomplete adequado
type=email
type=password
botões reais
foco visível
mensagens de erro legíveis
```

Login:

```html
autocomplete="email"
autocomplete="current-password"
```

Redefinição:

```html
autocomplete="new-password"
```

---

# 45. Mostrar/ocultar senha

Adicionar botão simples:

```text
Mostrar senha
Ocultar senha
```

para:

```text
Login
Nova senha
Confirmar senha
```

Não instalar biblioteca para isso.

---

# 46. Logout

Criar:

```ts
logout()
```

que:

```text
remove sessão
```

Não é necessário criar página de logout.

O método deve ficar preparado para consumo futuro pelo Admin ou Site.

---

# 47. README

Criar:

```text
frontend/auth/README.md
```

Documentar:

```text
Objetivo
Tecnologias
Instalação
Execução
Rotas
Mocks
Credenciais de teste
Recuperação de senha
Token de recuperação mockado
Ambientes
Docker
Build
Limitações de segurança
```

---

# 48. Scripts

No `package.json`:

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

# 49. Testes manuais

Validar login correto:

```text
admin@rh.local
123456
```

Resultado:

```text
login realizado
sessão salva
redirecionamento Admin
```

---

# 50. Login incorreto

Testar:

```text
admin@rh.local
senha-errada
```

Resultado:

```text
Usuário ou senha inválidos.
```

---

# 51. Usuário inativo

Testar:

```text
inativo@rh.local
123456
```

Resultado:

```text
Usuário inativo.
```

---

# 52. Recuperar senha

Acessar:

```text
/recuperar-senha
```

Informar:

```text
admin@rh.local
```

Resultado:

```text
Se o e-mail estiver cadastrado, você receberá instruções para redefinir sua senha.
```

---

# 53. Redefinir senha

Acessar:

```text
/redefinir-senha?token=reset-token-admin-123
```

Informar:

```text
Nova senha: 654321
Confirmar: 654321
```

Resultado:

```text
Senha redefinida com sucesso.
```

Depois redirecionar para:

```text
/login
```

---

# 54. Critérios de aceite

- [ ] Projeto `frontend/auth` criado.
- [ ] React configurado.
- [ ] TypeScript configurado.
- [ ] Vite configurado.
- [ ] React Router configurado.
- [ ] Rota `/login` criada.
- [ ] Rota `/recuperar-senha` criada.
- [ ] Rota `/redefinir-senha` criada.
- [ ] Layout Auth criado.
- [ ] LoginPage criada.
- [ ] ForgotPasswordPage criada.
- [ ] ResetPasswordPage criada.
- [ ] `users.json` criado.
- [ ] `reset-tokens.json` criado.
- [ ] `auth-messages.json` criado.
- [ ] Tipos TypeScript criados.
- [ ] `auth.service.ts` criado.
- [ ] `auth.api.ts` preparado.
- [ ] `auth.storage.ts` criado.
- [ ] Login mockado funciona.
- [ ] Usuário inativo é tratado.
- [ ] Senha inválida é tratada.
- [ ] Sessão mockada é salva.
- [ ] Logout remove sessão.
- [ ] Recuperação de senha mockada funciona.
- [ ] Redefinição de senha mockada funciona.
- [ ] Loading implementado.
- [ ] Mensagens de erro implementadas.
- [ ] Mensagens de sucesso implementadas.
- [ ] Mostrar/ocultar senha implementado.
- [ ] `.env` criado.
- [ ] `.env.development` criado.
- [ ] `.env.homolog` criado.
- [ ] `.env.production` criado.
- [ ] `.env.docker` criado.
- [ ] `.env.example` criado.
- [ ] URLs centralizadas no `.env`.
- [ ] Nenhuma URL hardcoded em páginas.
- [ ] Layout responsivo.
- [ ] README criado.
- [ ] `npm run lint` sem erro.
- [ ] `npm run build` sem erro.

---

# 55. Fora de escopo

Não criar nesta task:

```text
Backend C#
API real
JWT real
Refresh Token
OAuth
Google Login
Microsoft Login
2FA
MFA
Captcha
Banco de dados
Envio de e-mail real
SMS
Alteração persistente de senha
Controle de permissões real
Cookie HttpOnly
SSO
```

---

# 56. Regras importantes de segurança

Esta implementação é um mock de desenvolvimento.

Nunca utilizar em produção:

```text
senha em JSON
token fictício
localStorage como solução final
validação apenas no frontend
```

Quando existir backend real:

```text
senha deve ser validada no servidor
token deve vir do backend
senhas devem usar hash no servidor
sessão deve seguir arquitetura de segurança definida
recuperação deve usar token temporário real
```

---

# 57. Instruções para IA / Copilot

Ao executar esta task:

1. Criar o módulo `frontend/auth`.
2. Criar todas as páginas descritas.
3. Criar todos os arquivos JSON de mock.
4. Não criar backend.
5. Não criar API Mock C#.
6. Não instalar bibliotecas sem necessidade.
7. Não utilizar `any`.
8. Não acessar JSON diretamente nas páginas.
9. Não executar `fetch` diretamente nas páginas.
10. Centralizar lógica no `auth.service.ts`.
11. Centralizar URLs no `.env`.
12. Não hardcodar URLs.
13. Implementar loading.
14. Implementar tratamento de erro.
15. Implementar sucesso.
16. Implementar sessão mockada.
17. Não retornar senha no usuário autenticado.
18. Não tentar persistir alterações dentro do JSON.
19. Criar README detalhado.
20. Executar `npm run lint`.
21. Executar `npm run build`.
22. Corrigir erros encontrados.
23. Validar manualmente Login.
24. Validar recuperação de senha.
25. Validar redefinição de senha.
26. Manter código simples e didático.
