# Instruções do projeto

Você está trabalhando em um template empresarial de CRUD/CMS com ASP.NET Core + React.

## Objetivo
Criar CRUDs e conteúdo administrável com experiência inspirada no WordPress: o administrador gerencia menus, páginas e conteúdos e o site público reflete as alterações sem mudança manual de código para páginas básicas.

## Não faz parte do escopo
Plugins, marketplace, sistema de temas, widgets, page builder complexo ou extensões instaláveis.

## Backend
Use DDD, CQRS, Event Sourcing quando aplicável ao domínio, Unit of Work, Repository Pattern, Result Pattern, Domain Events, Domain Notifications e Domain Validations. Preserve os projetos Api, Application, Domain, Infrastructure, CrossCutting, Consumer, Producer, Btc e Csm.

## Frontend
React separado em Admin, Site e Shared. Organize por feature e mantenha API, modelos, segurança e componentes compartilhados em Shared. Não coloque regra de autorização somente na UI.

## Segurança
User, Role e Permission são conceitos distintos. A API é a autoridade final. O frontend apenas adapta navegação e ações conforme as permissões retornadas.

## Testes
Crie testes unitários e testes de integração reais. Integração deve poder iniciar dependências, criar schema/tabelas em banco de teste, executar cenário e limpar os dados/schema após os testes.

## Docker
O `docker-compose.yml` fica na raiz e deve contemplar frontend, backend, banco DEV e banco TEST.
