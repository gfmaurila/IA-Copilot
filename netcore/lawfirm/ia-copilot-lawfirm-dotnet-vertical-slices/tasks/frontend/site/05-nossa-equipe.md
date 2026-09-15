# FE-SITE-05 — Nossa Equipe

## Objetivo

Página com a apresentação e listagem dos advogados e profissionais do escritório.

## Aplicação

- Frontend: React + TypeScript + Vite
- Módulo: `site`
- Rota sugerida: `/equipe`
- Seguir: `tasks/rules/frontend.md`

## Referência visual

- `docs/screens/1. Front End/site/05 - Nossa Equipe - 01.png`
- `docs/screens/1. Front End/site/05 - Nossa Equipe - 02.png`

A imagem é a fonte principal para composição visual, hierarquia, espaçamento e conteúdo demonstrativo. Não copiar textos técnicos do mockup como regra de negócio sem necessidade.

## Implementação

- Criar a página/estado e registrar a rota correspondente no React Router.
- Reutilizar componentes, tokens e layouts compartilhados; evitar duplicação.
- Usar TanStack Query + Axios para dados remotos e mutações quando houver API.
- Tipar contratos e props com TypeScript; não usar `any` sem justificativa.
- Implementar estados de loading, erro e sucesso adequados à interação.
- Garantir navegação por teclado, labels, foco visível e contraste adequado.
- Manter header, navegação e rodapé consistentes com o site institucional.
- Priorizar SEO, semântica HTML, acessibilidade e performance.
- Garantir experiência responsiva em desktop, tablet e mobile.
- Conteúdo dinâmico deve prever loading, erro e estado vazio quando aplicável.

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
