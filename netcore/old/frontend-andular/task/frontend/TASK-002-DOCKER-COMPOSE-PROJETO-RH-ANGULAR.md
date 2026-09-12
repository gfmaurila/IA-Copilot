# TASK-002 — Docker Compose do Projeto RH

## 1. Objetivo

Criar e configurar o Docker Compose do projeto **RH**, utilizando a estrutura real definida para este projeto.

Esta task deve preparar a execução local dos módulos frontend:

```text
site
admin
auth
```

O exemplo anterior de `marketplace`, `client` e `lawyers` NÃO faz parte deste projeto e não deve ser utilizado.

O foco desta task é:

- criar o `docker-compose.yml`;
- criar Dockerfile para cada frontend existente;
- criar configuração Nginx;
- criar `.dockerignore`;
- configurar URLs Docker por ambiente;
- garantir funcionamento do Angular Router;
- documentar comandos de build e execução;
- validar as URLs locais.

---

# 2. Estrutura considerada do projeto

Considerar:

```text
projeto/
├── backend/
│   └── ...
│
├── frontend/
│   ├── site/
│   ├── admin/
│   └── auth/
│
├── docs/
├── task/
├── docker-compose.yml
└── README.md
```

> Utilizar os nomes reais das pastas existentes no repositório.  
> Se estiver `FrontEnd` em vez de `frontend`, preservar o nome real.

---

# 3. Módulos deste projeto

Os módulos frontend previstos são:

```text
frontend/site
frontend/admin
frontend/auth
```

Não criar:

```text
client
lawyers
marketplace
```

---

# 4. URLs locais definidas para Docker

Padronizar:

| Aplicação | URL local | Porta externa | Porta interna |
|---|---|---:|---:|
| Site institucional RH | `http://localhost:8081` | 8081 | 80 |
| Admin RH | `http://localhost:8082` | 8082 | 80 |
| Auth RH | `http://localhost:8083` | 8083 | 80 |

Fluxo:

```text
http://localhost:8081
        ↓
Docker
        ↓
rh-site
        ↓
Nginx :80
        ↓
Angular
```

---

# 5. Docker Compose esperado

Criar na raiz:

```text
docker-compose.yml
```

Conteúdo base:

```yaml
name: RH

services:

  site:
    build:
      context: ./frontend/site
      dockerfile: Dockerfile
    image: rh-site
    container_name: rh-site
    ports:
      - "8081:80"
    restart: unless-stopped

  admin:
    build:
      context: ./frontend/admin
      dockerfile: Dockerfile
    image: rh-admin
    container_name: rh-admin
    ports:
      - "8082:80"
    restart: unless-stopped

  auth:
    build:
      context: ./frontend/auth
      dockerfile: Dockerfile
    image: rh-auth
    container_name: rh-auth
    ports:
      - "8083:80"
    restart: unless-stopped
```

---

# 6. Regra para módulos ainda não criados

Antes de executar:

```bash
docker compose build
```

verificar se existem:

```text
frontend/site
frontend/admin
frontend/auth
```

Se algum módulo ainda não existir fisicamente no repositório:

- não criar aplicação fictícia;
- não criar conteúdo apenas para fazer o Docker funcionar;
- comentar ou remover temporariamente o serviço correspondente;
- registrar no README qual módulo ainda está pendente.

O `site` deve existir por causa da `TASK-001`.

---

# 7. Site institucional

O serviço:

```text
site
```

representa o site público de RH criado na `TASK-001`.

URL:

```text
http://localhost:8081
```

Rotas previstas:

```text
/
 /sobre
 /servicos
 /vagas
 /contato
```

Todas devem funcionar dentro do container.

---

# 8. Admin

O serviço:

```text
admin
```

representa a aplicação administrativa.

URL:

```text
http://localhost:8082
```

Nesta etapa, se o módulo ainda estiver apenas com página inicial:

```text
Olá Mundo - Admin
```

isso é aceitável.

Não criar funcionalidades administrativas nesta task.

---

# 9. Auth

O serviço:

```text
auth
```

representa a aplicação de autenticação.

URL:

```text
http://localhost:8083
```

Nesta etapa, se o módulo ainda estiver apenas com:

```text
Olá Mundo - Auth
```

isso é aceitável.

Não criar login real nesta task.

---

# 10. Dockerfile do Site

Criar:

```text
frontend/site/Dockerfile
```

Utilizar multi-stage build:

```dockerfile
FROM node:22-alpine AS build

WORKDIR /app

COPY package*.json ./

RUN npm ci

COPY . .

RUN npm run build:docker


FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/site/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
```

---

# 11. Dockerfile Admin

Criar:

```text
frontend/admin/Dockerfile
```

Estrutura:

```dockerfile
FROM node:22-alpine AS build

WORKDIR /app

COPY package*.json ./

RUN npm ci

COPY . .

RUN npm run build:docker


FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/admin/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
```

---

# 12. Dockerfile Auth

Criar:

```text
frontend/auth/Dockerfile
```

Estrutura:

```dockerfile
FROM node:22-alpine AS build

WORKDIR /app

COPY package*.json ./

RUN npm ci

COPY . .

RUN npm run build:docker


FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/auth/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
```

---

> **Importante sobre o `dist`:** confirme o `outputPath` real no `angular.json`. Com o application builder do Angular, o resultado normalmente fica em `dist/<nome-do-projeto>/browser`. Se o projeto estiver configurado de forma diferente, ajuste somente a linha `COPY --from=build` do Dockerfile para o caminho real gerado por `ng build`.

---

# 13. package-lock.json

Preferir:

```dockerfile
RUN npm ci
```

quando existir:

```text
package-lock.json
```

Se o módulo ainda não possuir lock file:

```bash
npm install
```

deve ser executado primeiro localmente para gerá-lo.

Não trocar automaticamente para `npm install` dentro do Docker sem registrar o motivo.

---

# 14. Nginx

Criar em cada frontend:

```text
frontend/site/nginx.conf
frontend/admin/nginx.conf
frontend/auth/nginx.conf
```

Conteúdo:

```nginx
server {
    listen 80;
    server_name _;

    root /usr/share/nginx/html;
    index index.html;

    location / {
        try_files $uri $uri/ /index.html;
    }
}
```

---

# 15. Motivo do `try_files`

Angular é uma SPA.

Ao acessar:

```text
http://localhost:8081/vagas
```

e pressionar:

```text
F5
```

o Nginx deve devolver:

```text
index.html
```

e deixar o Angular Router resolver:

```text
/vagas
```

Sem isso, pode ocorrer:

```text
404 Not Found
```

---

# 16. .dockerignore

Criar em:

```text
frontend/site/.dockerignore
frontend/admin/.dockerignore
frontend/auth/.dockerignore
```

Conteúdo:

```text
node_modules
dist
.git
.gitignore
*.log
coverage
.vscode
.idea
```

---

# 17. Ambiente Docker no Angular

No Angular, esta task **não deve criar `.env.docker` nem variáveis `VITE_*`**.

Cada aplicação deve utilizar os arquivos nativos de ambiente:

```text
src/environments/environment.ts
src/environments/environment.development.ts
src/environments/environment.homolog.ts
src/environments/environment.production.ts
src/environments/environment.docker.ts
```

A configuração `docker` deve ser registrada no `angular.json` por meio de `fileReplacements`.

---

# 18. Ambiente Docker do Site

Criar:

```text
frontend/site/src/environments/environment.docker.ts
```

Conteúdo:

```ts
export const environment = {
  production: true,
  appName: 'Talent RH',
  appEnv: 'docker',
  siteBaseUrl: 'http://localhost:8081',
  apiBaseUrl: 'http://localhost:5000',
  siteDataSource: 'mock',
  enableLogs: true,
};
```

Nesta etapa o site continua usando JSON mockado. Não criar backend.

---

# 19. Ambiente Docker Admin

Criar:

```text
frontend/admin/src/environments/environment.docker.ts
```

Conteúdo:

```ts
export const environment = {
  production: true,
  appName: 'RH Admin',
  appEnv: 'docker',
  adminBaseUrl: 'http://localhost:8082',
  authBaseUrl: 'http://localhost:8083',
  apiBaseUrl: 'http://localhost:5000',
  enableLogs: true,
};
```

---

# 20. Ambiente Docker Auth

Criar:

```text
frontend/auth/src/environments/environment.docker.ts
```

Conteúdo:

```ts
export const environment = {
  production: true,
  appName: 'RH Auth',
  appEnv: 'docker',
  authBaseUrl: 'http://localhost:8083',
  siteBaseUrl: 'http://localhost:8081',
  adminBaseUrl: 'http://localhost:8082',
  apiBaseUrl: 'http://localhost:5000',
  enableLogs: true,
};
```

---

# 21. URLs centralizadas

Nunca escrever diretamente dentro de componentes:

```text
http://localhost:8081
http://localhost:8082
http://localhost:8083
http://localhost:5000
```

As URLs devem vir dos arquivos `src/environments/environment*.ts`.

Exemplo:

```ts
import { environment } from '../environments/environment';

const apiBaseUrl = environment.apiBaseUrl;
```

---

# 22. Configuração `docker` no angular.json

Em cada aplicação, adicionar uma configuração `docker` no `angular.json`.

Exemplo conceitual:

```json
{
  "configurations": {
    "docker": {
      "fileReplacements": [
        {
          "replace": "src/environments/environment.ts",
          "with": "src/environments/environment.docker.ts"
        }
      ]
    }
  }
}
```

Preservar as demais configurações geradas pelo Angular CLI.

---

# 23. Build Docker no package.json

Em cada aplicação Angular, adicionar:

```json
{
  "scripts": {
    "build:docker": "ng build --configuration docker"
  }
}
```

O Dockerfile deve executar:

```bash
npm run build:docker
```

As configurações de ambiente do Angular são aplicadas durante o build. Portanto, depois de alterar `environment.docker.ts`, reconstruir a imagem:

```bash
docker compose up -d --build
```

Apenas reiniciar o container não recompila o frontend.

---

# 24. Estrutura final esperada

```text
projeto/
├── backend/
│   └── ...
│
├── frontend/
│   ├── site/
│   │   ├── src/
│   │   ├── src/environments/
│   │   │   ├── environment.ts
│   │   │   ├── environment.development.ts
│   │   │   ├── environment.homolog.ts
│   │   │   ├── environment.production.ts
│   │   │   └── environment.docker.ts
│   │   ├── angular.json
│   │   ├── .dockerignore
│   │   ├── Dockerfile
│   │   ├── nginx.conf
│   │   └── package.json
│   │
│   ├── admin/
│   │   ├── src/
│   │   ├── src/environments/environment.docker.ts
│   │   ├── .dockerignore
│   │   ├── Dockerfile
│   │   ├── nginx.conf
│   │   └── package.json
│   │
│   └── auth/
│       ├── src/
│       ├── src/environments/environment.docker.ts
│       ├── .dockerignore
│       ├── Dockerfile
│       ├── nginx.conf
│       └── package.json
│
├── task/
├── docker-compose.yml
└── README.md
```

---

# 25. Comandos principais

## Validar Compose

```bash
docker compose config
```

---

## Build

```bash
docker compose build
```

---

## Subir

```bash
docker compose up -d
```

---

## Build e subir

```bash
docker compose up -d --build
```

---

## Ver status

```bash
docker compose ps
```

---

## Logs

```bash
docker compose logs
```

---

## Logs Site

```bash
docker compose logs site
```

---

## Logs Admin

```bash
docker compose logs admin
```

---

## Logs Auth

```bash
docker compose logs auth
```

---

## Parar

```bash
docker compose down
```

---

# 26. URLs para validação

Depois de subir:

## Site

```text
http://localhost:8081
```

Testar também:

```text
http://localhost:8081/sobre
http://localhost:8081/servicos
http://localhost:8081/vagas
http://localhost:8081/contato
```

---

## Admin

```text
http://localhost:8082
```

---

## Auth

```text
http://localhost:8083
```

---

# 27. Backend

O backend não faz parte desta task.

A variável:

```ts
apiBaseUrl: 'http://localhost:5000'
```

fica preparada para integração futura.

Não criar:

```text
API.Mock
API.Site
API.Auth
API.Admin
```

nesta task.

---

# 28. Importante sobre localhost

Como a aplicação Angular executa no navegador do usuário:

```ts
apiBaseUrl: 'http://localhost:5000'
```

significa:

```text
porta 5000 da máquina do usuário
```

Não substituir automaticamente no código frontend por:

```text
http://nome-container:5000
```

O browser não resolve os nomes internos da rede Docker da mesma forma que os containers.

---

# 29. Nomes dos containers

Padronizar somente:

```text
rh-site
rh-admin
rh-auth
```

Não utilizar:

```text
marketplace-site
marketplace-admin
marketplace-client
marketplace-lawyers
```

---

# 30. Portas reservadas do projeto

Nesta configuração:

```text
8081 = Site
8082 = Admin
8083 = Auth
```

Portas futuras devem ser documentadas antes de serem adicionadas.

---

# 31. README principal

Atualizar o README da raiz com:

```text
## Aplicações locais via Docker

Site:
http://localhost:8081

Admin:
http://localhost:8082

Auth:
http://localhost:8083
```

E comandos:

```bash
docker compose up -d --build
docker compose ps
docker compose logs -f
docker compose down
```

---

# 32. Critérios de aceite

- [ ] `docker-compose.yml` utiliza o nome `RH`.
- [ ] Não existe referência a Marketplace.
- [ ] Não existe serviço Client.
- [ ] Não existe serviço Lawyers.
- [ ] Serviço Site configurado.
- [ ] Serviço Admin configurado se módulo existir.
- [ ] Serviço Auth configurado se módulo existir.
- [ ] Site utiliza `8081`.
- [ ] Admin utiliza `8082`.
- [ ] Auth utiliza `8083`.
- [ ] Imagem Site = `rh-site`.
- [ ] Imagem Admin = `rh-admin`.
- [ ] Imagem Auth = `rh-auth`.
- [ ] Containers utilizam nomes `rh-*`.
- [ ] Dockerfile utiliza multi-stage build.
- [ ] Runtime utiliza Nginx.
- [ ] `nginx.conf` criado.
- [ ] Angular Router funciona com refresh.
- [ ] `.dockerignore` criado.
- [ ] `environment.docker.ts` criado para Site.
- [ ] `environment.docker.ts` criado para Admin se existir.
- [ ] `environment.docker.ts` criado para Auth se existir.
- [ ] Site configurado para `http://localhost:8081`.
- [ ] Admin configurado para `http://localhost:8082`.
- [ ] Auth configurado para `http://localhost:8083`.
- [ ] `docker compose config` executa sem erro.
- [ ] `docker compose build` executa sem erro.
- [ ] Containers sobem corretamente.
- [ ] Site abre no navegador.
- [ ] Rotas do Site não retornam 404 ao atualizar.
- [ ] README atualizado.
- [ ] Nenhum backend foi criado.

---

# 33. Instruções para IA / Copilot

Ao executar esta task:

1. Trabalhar somente com os módulos reais deste projeto.
2. Considerar `site`, `admin` e `auth`.
3. Não utilizar `client`.
4. Não utilizar `lawyers`.
5. Não utilizar nomes `marketplace-*`.
6. Preservar o nome real das pastas no repositório.
7. Não criar frontend fictício apenas para satisfazer o Compose.
8. Criar Dockerfile para os módulos existentes.
9. Criar Nginx para os módulos existentes.
10. Criar `.dockerignore`.
11. Criar `environment.docker.ts`.
12. Centralizar URLs nos arquivos `environment*.ts`.
13. Não criar backend.
14. Não implementar funcionalidades de negócio.
15. Validar Angular Router no Nginx.
16. Executar `docker compose config`.
17. Executar `docker compose build`.
18. Subir os containers.
19. Verificar `docker compose ps`.
20. Verificar logs em caso de erro.
21. Validar cada URL no navegador.
22. Corrigir erros encontrados.
23. Atualizar README.
24. Ao concluir, informar claramente:

```text
Site  → http://localhost:8081
Admin → http://localhost:8082
Auth  → http://localhost:8083
```
