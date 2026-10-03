# Frontend React

`src/admin`: painel administrativo, rotas protegidas, CRUDs e layouts.
`src/site`: aplicação pública e resolução de páginas/menus publicados.
`src/shared`: cliente API, modelos, componentes, hooks, segurança e utilitários reutilizáveis.

Organize cada área por feature. Admin e Site não devem importar internals um do outro; ambos dependem apenas de contratos compartilhados.
