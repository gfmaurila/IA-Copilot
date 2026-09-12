# AGENTS.md

# Marketplace Jurídico — Portal Administrativo

> **ESCOPO EXCLUSIVO:** este arquivo descreve SOMENTE o **Portal Administrativo**.
> O gerador de código NÃO deve criar Portal do Advogado, Portal do Cliente,
> Marketplace Público, backend, banco de dados, pagamentos, chat ou agendamento,
> salvo se uma solicitação futura alterar explicitamente este escopo.

## 1. Objetivo

Este documento contém as instruções que devem ser seguidas por qualquer agente de IA responsável pelo desenvolvimento do Front-End React do Portal Administrativo do Marketplace Jurídico.

Antes de criar, alterar ou excluir qualquer arquivo, o agente DEVE ler este documento.

O agente deve preservar a arquitetura existente e reutilizar componentes já disponíveis sempre que possível.

Nesta etapa, desenvolver SOMENTE o Portal Administrativo.

Não desenvolver ainda:

- Portal do Advogado
- Portal do Cliente
- Marketplace público
- Pagamentos
- Chat
- Agendamento

---

# 2. Stack Front-End

Utilizar:

- React
- TypeScript
- React Router
- Vite
- CSS responsivo
- Componentes reutilizáveis

Preferir bibliotecas já existentes no projeto.

Não adicionar dependências sem necessidade.

Se for necessário adicionar uma dependência, informar antes:

- nome
- finalidade
- motivo da utilização

---

# 3. Arquitetura

Utilizar preferencialmente:

src/

```
app/
    App.tsx
    routes.tsx

layouts/
    AdminLayout.tsx
    AuthLayout.tsx

pages/

    auth/
        LoginPage.tsx
        ForgotPasswordPage.tsx
        ResetPasswordPage.tsx

    admin/

        dashboard/
            AdminDashboardPage.tsx

        users/
            UserListPage.tsx
            UserCreatePage.tsx
            UserEditPage.tsx
            UserDetailsPage.tsx

        lawyers/
            LawyerListPage.tsx
            LawyerDetailsPage.tsx
            LawyerEditPage.tsx

        clients/
            ClientListPage.tsx
            ClientDetailsPage.tsx

        specialties/
            SpecialtyListPage.tsx
            SpecialtyCreatePage.tsx
            SpecialtyEditPage.tsx

components/

    admin/
        AdminHeader.tsx
        AdminSidebar.tsx
        DashboardCard.tsx
        DashboardSection.tsx

    common/
        Button.tsx
        Input.tsx
        Select.tsx
        Modal.tsx
        Table.tsx
        Loading.tsx
        Alert.tsx
        Badge.tsx
        Pagination.tsx

services/

    auth/
        auth.service.ts

    dashboard/
        adminDashboard.service.ts

    users/
        users.service.ts

    lawyers/
        lawyers.service.ts

    clients/
        clients.service.ts

    specialties/
        specialties.service.ts

mocks/

    auth/
        login.json
        forgot-password.json
        reset-password.json

    dashboard/
        admin-dashboard.json

    users/
        users.json

    lawyers/
        lawyers.json

    clients/
        clients.json

    specialties/
        specialties.json

types/

    api.types.ts
    auth.types.ts
    dashboard.types.ts
    user.types.ts
    lawyer.types.ts
    client.types.ts
    specialty.types.ts

context/
    AuthContext.tsx

hooks/
    useAuth.ts

guards/
    PrivateRoute.tsx

utils/
    storage.ts

```

---

# 4. Regra obrigatória de acesso aos dados

NENHUM componente React pode acessar diretamente arquivos JSON.

ERRADO:

Component
→ JSON

CORRETO:

Page / Component
→ Service
→ Mock JSON

No futuro:

Page / Component
→ Service
→ API REST

A troca de Mock por API deve exigir alteração principalmente na camada Service.

---

# 5. Contrato padrão de API

Utilizar:

```json
{
  "success": true,
  "data": {},
  "message": "",
  "errors": []
}

```

Para erros:

```json
{
  "success": false,
  "data": null,
  "message": "Não foi possível realizar a operação.",
  "errors": [
    {
      "field": "email",
      "message": "E-mail inválido."
    }
  ]
}

```

Criar tipos genéricos TypeScript para esse contrato.

Exemplo:

```typescript
export interface ApiError {
    field?: string;
    message: string;
}

export interface ApiResponse<T> {
    success: boolean;
    data: T | null;
    message: string;
    errors: ApiError[];
}

```

---

# 6. Simulação dos Mocks

Os Services devem simular comportamento de API.

Não retornar os dados instantaneamente.

Simular pequeno delay para permitir testar:

- loading
- sucesso
- erro

Exemplo conceitual:

```typescript
await delay(500);

```

A interface deve funcionar como se estivesse consumindo uma API real.

---

# 7. Autenticação

Criar:

- Login
- Logout
- Sessão
- Rotas protegidas
- Esqueci minha senha
- Redefinição de senha

Componentes:

AuthContext
useAuth
PrivateRoute
AuthLayout

Services:

auth.service.ts

---

# 8. Login

Rota:

/login

Campos:

- E-mail
- Senha

Possuir:

- validação
- loading
- mensagem de erro
- botão Entrar
- link "Esqueci minha senha"

Request esperado:

```json
{
  "email": "admin@marketplace.com",
  "password": "123456"
}

```

Mock de sucesso:

```json
{
  "success": true,
  "data": {
    "accessToken": "mock-admin-access-token",
    "refreshToken": "mock-admin-refresh-token",
    "expiresIn": 3600,
    "user": {
      "id": "ADM-001",
      "name": "Administrador",
      "email": "admin@marketplace.com",
      "profile": "ADMIN"
    }
  },
  "message": "Login realizado com sucesso.",
  "errors": []
}

```

Após login:

redirecionar para:

/admin/dashboard

---

# 9. Esqueci minha senha

Rota:

/forgot-password

Campo:

- E-mail

Request:

```json
{
  "email": "admin@marketplace.com"
}

```

Response:

```json
{
  "success": true,
  "data": {
    "requestId": "PWD-001"
  },
  "message": "Se o e-mail estiver cadastrado, enviaremos as instruções para recuperação da senha.",
  "errors": []
}

```

Não revelar se o e-mail existe ou não.

---

# 10. Redefinição de senha

Rota:

/reset-password

Campos:

- Nova senha
- Confirmar nova senha

Request:

```json
{
  "token": "mock-reset-token",
  "password": "NovaSenha@123",
  "passwordConfirmation": "NovaSenha@123"
}

```

Validar:

- senha obrigatória
- confirmação obrigatória
- senhas iguais
- regras mínimas de segurança

---

# 11. Portal Administrativo

Após autenticação, utilizar:

AdminLayout

Estrutura:

AdminLayout

```
AdminSidebar
AdminHeader
Content

```

---

# 12. Menu lateral

Criar menu:

Dashboard

Gestão
Usuários
Advogados
Clientes

Cadastros
Especialidades

Operação
Solicitações

Sistema
Configurações

O item selecionado deve possuir destaque visual.

O menu deve permitir expansão futura.

Em dispositivos móveis, deve ser recolhível.

---

# 13. Header

Exibir:

- Nome do sistema
- Nome do administrador
- Avatar ou ícone
- Menu do usuário

Menu:

- Meu perfil
- Sair

Não utilizar dados hardcoded diretamente no Header.

Utilizar informações provenientes do AuthContext.

---

# 14. DASHBOARD ADMINISTRATIVO

Rota:

/admin/dashboard

Página:

AdminDashboardPage.tsx

O Dashboard é a primeira tela exibida após o login.

Objetivo:

Fornecer uma visão geral da operação do Marketplace Jurídico para o administrador.

---

# 15. Modelo visual do Dashboard

Criar aproximadamente:

```text
┌──────────────────────────────────────────────────────────────┐
│ Marketplace Jurídico                   Administrador ▼       │
├───────────────┬──────────────────────────────────────────────┤
│               │                                              │
│ Dashboard     │  Dashboard                                   │
│               │  Visão geral da plataforma                   │
│ Gestão        │                                              │
│  Usuários     │  ┌──────────┐ ┌──────────┐ ┌──────────┐     │
│  Advogados    │  │Advogados │ │ Clientes │ │Pendentes │     │
│  Clientes     │  │   245    │ │  1.850   │ │    12    │     │
│               │  └──────────┘ └──────────┘ └──────────┘     │
│ Cadastros     │                                              │
│ Especialidades│  ┌──────────┐ ┌──────────┐ ┌──────────┐     │
│               │  │Novos     │ │Solicita- │ │Em        │     │
│ Operação      │  │cadastros │ │ções      │ │andamento │     │
│ Solicitações  │  │    37    │ │    84    │ │    31    │     │
│               │  └──────────┘ └──────────┘ └──────────┘     │
│ Sistema       │                                              │
│ Configurações │  Cadastros por período                       │
│               │  ┌──────────────────────────────────────┐    │
│               │  │                                      │    │
│               │  │              GRÁFICO                 │    │
│               │  │                                      │    │
│               │  └──────────────────────────────────────┘    │
│               │                                              │
│               │  Advogados pendentes                         │
│               │  ┌──────────────────────────────────────┐    │
│               │  │ Nome | Especialidade | Data | Ação   │    │
│               │  ├──────────────────────────────────────┤    │
│               │  │ João | Civil         | ...  | Ver    │    │
│               │  │ Ana  | Trabalhista   | ...  | Ver    │    │
│               │  └──────────────────────────────────────┘    │
│               │                                              │
└───────────────┴──────────────────────────────────────────────┘

```

---

# 16. Cards do Dashboard

Criar componente reutilizável:

DashboardCard

Cards iniciais:

1. Total de Advogados
2. Total de Clientes
3. Cadastros Pendentes
4. Novos Cadastros
5. Solicitações de Atendimento
6. Atendimentos em Andamento

Cada card deverá aceitar propriedades como:

- title
- value
- icon
- description
- loading

Não duplicar componentes para cada indicador.

---

# 17. Mock do Dashboard

Criar:

src/mocks/dashboard/admin-dashboard.json

Conteúdo inicial:

```json
{
  "success": true,
  "data": {
    "summary": {
      "totalLawyers": 245,
      "totalClients": 1850,
      "pendingRegistrations": 12,
      "newRegistrations": 37,
      "serviceRequests": 84,
      "servicesInProgress": 31
    },
    "registrationsByMonth": [
      {
        "month": "Abr",
        "lawyers": 18,
        "clients": 95
      },
      {
        "month": "Mai",
        "lawyers": 22,
        "clients": 110
      },
      {
        "month": "Jun",
        "lawyers": 25,
        "clients": 125
      },
      {
        "month": "Jul",
        "lawyers": 31,
        "clients": 148
      },
      {
        "month": "Ago",
        "lawyers": 35,
        "clients": 165
      },
      {
        "month": "Set",
        "lawyers": 28,
        "clients": 132
      }
    ],
    "pendingLawyers": [
      {
        "id": "LAW-001",
        "name": "João Silva",
        "specialty": "Direito Civil",
        "oab": "OAB/RS 123456",
        "createdAt": "2026-09-08T10:30:00",
        "status": "PENDING"
      },
      {
        "id": "LAW-002",
        "name": "Ana Souza",
        "specialty": "Direito Trabalhista",
        "oab": "OAB/RS 654321",
        "createdAt": "2026-09-08T14:20:00",
        "status": "PENDING"
      }
    ],
    "recentRegistrations": [
      {
        "id": "USR-001",
        "name": "Carlos Oliveira",
        "type": "CLIENT",
        "createdAt": "2026-09-09T08:30:00",
        "status": "ACTIVE"
      },
      {
        "id": "LAW-003",
        "name": "Fernanda Lima",
        "type": "LAWYER",
        "createdAt": "2026-09-09T09:10:00",
        "status": "PENDING"
      }
    ]
  },
  "message": "",
  "errors": []
}

```

---

# 18. Service do Dashboard

Criar:

adminDashboard.service.ts

Responsabilidade:

- acessar o mock
- simular chamada assíncrona
- retornar ApiResponse
- futuramente consumir API REST

Fluxo:

AdminDashboardPage
→ adminDashboard.service
→ admin-dashboard.json

Endpoint futuro:

GET /api/v1/admin/dashboard

---

# 19. Gráfico do Dashboard

Criar área para:

Cadastros por período

Exibir:

- Advogados
- Clientes

Utilizar os dados:

registrationsByMonth

O gráfico deve ser responsivo.

Se uma biblioteca de gráficos já existir no projeto, reutilizá-la.

Caso não exista, informar antes de adicionar uma nova dependência.

---

# 20. Advogados pendentes

Criar tabela:

Advogados Pendentes de Aprovação

Colunas:

Nome
OAB
Especialidade
Data de Cadastro
Status
Ações

Ações:

- Visualizar
- Aprovar
- Rejeitar

Nesta primeira versão, as operações podem ser simuladas pelo Service.

Nunca alterar diretamente o JSON a partir do componente.

---

# 21. Cadastros recentes

Criar tabela:

Cadastros Recentes

Colunas:

Nome
Tipo
Data
Status
Ação

Tipos:

ADMIN
LAWYER
CLIENT

Status:

ACTIVE
PENDING
BLOCKED
INACTIVE

Criar Badge reutilizável para status.

---

# 22. CRUD administrativo

O agente deve ser capaz de receber comandos como:

"Crie o CRUD de Especialidades."

E gerar:

ListPage
CreatePage
EditPage
DetailsPage
Form
Types
Service
Mock

Operações futuras:

GET /api/v1/admin/specialties

GET /api/v1/admin/specialties/{id}

POST /api/v1/admin/specialties

PUT /api/v1/admin/specialties/{id}

DELETE /api/v1/admin/specialties/{id}

---

# 23. Padrão de Listagens

Toda listagem administrativa deve prever:

- título
- botão Novo
- busca
- filtros quando necessários
- tabela
- paginação
- loading
- estado vazio
- erro
- ações
- confirmação de exclusão

Evitar colocar centenas de registros diretamente na tabela.

Preparar estrutura para paginação futura via API.

---

# 24. Formulários

Todos os formulários devem possuir:

- labels
- validação
- mensagens de erro
- loading durante envio
- botão Salvar
- botão Cancelar
- feedback de sucesso
- feedback de erro

Não colocar regras de negócio complexas dentro do componente.

---

# 25. Responsividade

Todas as páginas devem funcionar em:

Desktop
Notebook
Tablet
Mobile

Prioridade inicial do Admin:

Desktop e Notebook.

Em telas menores:

- sidebar recolhível
- cards reorganizados
- tabelas adaptadas
- formulários em coluna

---

# 26. Segurança Front-End

Nunca:

- armazenar senha
- colocar senha em URL
- logar tokens
- logar senhas
- colocar secrets no código
- colocar chaves privadas no React
- considerar validação frontend como segurança suficiente

O Front-End apenas simula autenticação nesta etapa.

A segurança real será implementada no backend.

---

# 27. TypeScript

Evitar:

any

Criar interfaces e types adequados.

Exemplo:

AdminDashboard
DashboardSummary
RegistrationByMonth
PendingLawyer
RecentRegistration

---

# 28. Estados obrigatórios

Toda operação assíncrona deve considerar:

IDLE
LOADING
SUCCESS
ERROR

Listagens também devem possuir:

EMPTY

A interface deve apresentar feedback visual adequado.

---

# 29. Componentes reutilizáveis

Antes de criar um componente novo:

1. Procurar componente existente.
2. Avaliar possibilidade de extensão.
3. Criar novo componente somente quando necessário.

Evitar duplicação.

Exemplos reutilizáveis:

Button
Input
Select
Table
Modal
Badge
Alert
Loading
Pagination
DashboardCard

---

# 30. Regras para execução de tarefas

Antes de iniciar uma tarefa:

1. Ler AGENTS.md.
2. Analisar estrutura atual do projeto.
3. Identificar componentes existentes.
4. Identificar Types existentes.
5. Identificar Services existentes.
6. Planejar arquivos que serão criados/modificados.

Durante a implementação:

1. Manter arquitetura existente.
2. Reutilizar componentes.
3. Utilizar TypeScript.
4. Utilizar Services.
5. Utilizar mocks quando API não existir.
6. Tratar loading.
7. Tratar erro.
8. Tratar estado vazio quando aplicável.
9. Garantir responsividade.

Depois da implementação:

Executar:

npm run lint

npm run test

npm run build

Corrigir erros relacionados à implementação.

Não finalizar uma tarefa deixando erros de TypeScript ou build conhecidos.

---

# 31. Limites do agente

O agente NÃO deve:

- alterar arquitetura sem solicitação
- trocar framework
- trocar React
- remover TypeScript
- criar backend
- criar banco de dados
- adicionar bibliotecas desnecessárias
- alterar várias áreas não relacionadas à tarefa
- apagar código funcional sem justificativa
- implementar funcionalidades fora do escopo solicitado

Quando houver dúvida relevante de arquitetura, perguntar antes de realizar mudança estrutural.

---

# 32. Primeira implementação

Quando solicitado a iniciar o Portal Administrativo, executar nesta ordem:

ETAPA 1

Estrutura base React.

ETAPA 2

Componentes comuns.

ETAPA 3

AuthLayout.

ETAPA 4

Login.

ETAPA 5

Esqueci minha senha.

ETAPA 6

Redefinição de senha.

ETAPA 7

AuthContext e proteção de rotas.

ETAPA 8

AdminLayout.

ETAPA 9

Sidebar e Header.

ETAPA 10

Dashboard Administrativo.

ETAPA 11

Cards.

ETAPA 12

Gráfico de cadastros.

ETAPA 13

Tabela de advogados pendentes.

ETAPA 14

Tabela de cadastros recentes.

ETAPA 15

Responsividade.

ETAPA 16

Lint, testes e build.

---

# 33. Resultado esperado

Fluxo inicial:

/login
|
+-- /forgot-password
|
+-- /reset-password
|
+-- autenticação
|
v
/admin/dashboard
|
+-- Indicadores
|
+-- Cadastros por período
|
+-- Advogados pendentes
|
+-- Cadastros recentes

O Portal Administrativo deve servir como base para todos os próximos módulos administrativos do Marketplace Jurídico.

# FIM DO AGENTS.md