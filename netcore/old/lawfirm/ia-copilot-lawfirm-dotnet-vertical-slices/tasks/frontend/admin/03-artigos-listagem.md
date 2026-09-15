# FE-ADMIN-03 — Artigos - Listagem

## Objetivo

Listagem e gerenciamento dos artigos e conteúdos publicados no site.

## Aplicação

- Frontend: React + TypeScript + Vite
- Módulo: `admin`
- Rota sugerida: `/admin/artigos`
- Seguir: `tasks/rules/frontend.md`

## Referência visual

- `docs/screens/1. Front End/admim/03 - Artigos - Listagem.png`

A imagem é a fonte principal para composição visual, hierarquia, espaçamento e conteúdo demonstrativo. Não copiar textos técnicos do mockup como regra de negócio sem necessidade.

## Implementação

- Criar a página/estado e registrar a rota correspondente no React Router.
- Reutilizar componentes, tokens e layouts compartilhados; evitar duplicação.
- Usar TanStack Query + Axios para dados remotos e mutações quando houver API.
- Tipar contratos e props com TypeScript; não usar `any` sem justificativa.
- Implementar estados de loading, erro e sucesso adequados à interação.
- Garantir navegação por teclado, labels, foco visível e contraste adequado.
- Manter shell administrativo consistente (sidebar, header, breadcrumbs quando aplicável).
- Respeitar autenticação e autorização nas rotas privadas.
- Listagens devem prever loading, erro, vazio, paginação/filtros quando aplicável.
- Formulários devem usar React Hook Form + Zod, feedback de validação e estados de envio.

## Responsividade

- Desktop: reproduzir a estrutura principal da referência visual.
- Tablet: reorganizar grids e painéis sem perda de funcionalidade.
- Mobile: empilhar conteúdo, preservar ações principais e impedir overflow horizontal.

## Integração

- Não inventar endpoints definitivos: consumir o client/API existente quando disponível.
- Se a API ainda não existir, isolar mocks/adapters para permitir substituição posterior sem reescrever a UI.
- Centralizar URLs, tipos e chamadas; não espalhar chamadas HTTP diretamente pelos componentes visuais.

## Critérios de aceite

- [ ] Tela/estado implementado e acessível pela rota/componente definido.
- [ ] Visual consistente com a referência e com o restante do LawFirm.
- [ ] Responsivo em desktop, tablet e mobile.
- [ ] Sem erros TypeScript, lint ou build.
- [ ] Estados de loading/erro/vazio tratados quando aplicável.
- [ ] Formulários e ações possuem validação/feedback quando aplicável.
- [ ] Componentes compartilháveis foram extraídos quando fizer sentido.
- [ ] Acessibilidade básica validada.
- [ ] Não foram introduzidas dependências desnecessárias.

## Definição de pronto

A tarefa termina quando a implementação estiver funcional, integrada à navegação, visualmente aderente ao mockup/design system e o frontend compilar sem erros.
