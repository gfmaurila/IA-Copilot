# Docker Rules

## Regra principal

O arquivo `docker-compose.yml` do template deve permanecer vazio.

O Docker Compose deve ser criado ou preenchido somente durante a execução da Spec,
com base nos serviços que realmente serão utilizados.

## Serviços obrigatórios na criação inicial

O `docker-compose.yml` gerado deve conter:

- `frontend-admin`
- `frontend-site`
- `api-admin`
- `api-site`
- `sqlserver`

Opcionalmente poderão ser adicionados outros serviços somente quando a Spec exigir.

## Vínculos Frontend x API

Cada frontend deve apontar somente para a API correspondente.

### Admin

```text
frontend-admin
    ↓
api-admin
```

O frontend Admin deve receber a URL da API Admin através de variável de ambiente.

Exemplo:

```text
VITE_API_URL=http://api-admin:8080
```

Quando a aplicação for acessada pelo navegador do host, configurar também a URL pública
adequada para desenvolvimento, por exemplo:

```text
http://localhost:5001
```

### Site

```text
frontend-site
    ↓
api-site
```

O frontend Site deve receber a URL da API Site através de variável de ambiente.

Exemplo:

```text
VITE_API_URL=http://api-site:8080
```

Quando a aplicação for acessada pelo navegador do host, configurar também a URL pública
adequada para desenvolvimento, por exemplo:

```text
http://localhost:5002
```

## Dependências entre serviços

O Compose gerado deve refletir as dependências:

```text
frontend-admin -> api-admin -> sqlserver
frontend-site  -> api-site  -> sqlserver
```

Utilizar `depends_on` quando fizer sentido para ordem de inicialização.

As APIs devem aguardar o SQL Server estar saudável antes de iniciar operações dependentes do banco.

## Portas padrão

Sugestão inicial:

```text
frontend-admin : 8081
frontend-site  : 8082
api-admin      : 5001
api-site       : 5002
sqlserver      : 1433
```

## Bancos

Criar:

- `MeuProjeto_Dev`
- `MeuProjeto_Test`

O banco Development nunca deve ser utilizado pelos testes de integração.

## Connection Strings

As APIs devem receber suas connection strings por variáveis de ambiente.

Exemplo:

```text
ConnectionStrings__DefaultConnection=
```

Nenhuma connection string deve ficar hardcoded no código-fonte.

## Senha SQL Server

A senha do usuário `sa` deve ser gerada no momento da execução.

Formato:

```text
Gfm@d{dia}m{mes}a{ano}
```

Regras:

- dia com 2 dígitos
- mês com 2 dígitos
- ano com 4 dígitos

Exemplo:

```text
11/09/2026 -> Gfm@d11m09a2026
```

A senha gerada deve ser usada de forma consistente no Docker Compose,
variáveis de ambiente e connection strings daquele ambiente.

Não manter senha fixa no template.

## Rede Docker

Todos os serviços devem utilizar a mesma rede Docker do projeto, salvo necessidade específica.

Os serviços devem se comunicar internamente pelo nome do serviço Docker.

Exemplo:

```text
Server=sqlserver,1433
```

Nunca utilizar `localhost` para comunicação entre containers.
