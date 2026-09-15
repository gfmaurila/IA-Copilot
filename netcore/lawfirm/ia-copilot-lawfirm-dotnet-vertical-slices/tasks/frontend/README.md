# Frontend Tasks — LawFirm

Tarefas de implementação do frontend derivadas dos arquivos `leia.txt` e dos mockups em `docs/screens/1. Front End`.

## Regras

- Stack: React + TypeScript + Vite, React Router, TanStack Query, Axios, React Hook Form e Zod.
- Executar uma tarefa por vez e validar os critérios de aceite antes de avançar.
- Mockups existentes são referência visual primária. Para telas sem PNG, manter o mesmo design system do módulo.
- Admin e Site devem permanecer módulos independentes, compartilhando apenas componentes/tokens quando a arquitetura permitir.

## Admin — 50 tarefas

- [ ] [`FE-ADMIN-01 — Login`](admin/01-login.md)
- [ ] [`FE-ADMIN-02 — Dashboard`](admin/02-dashboard.md)
- [ ] [`FE-ADMIN-03 — Artigos - Listagem`](admin/03-artigos-listagem.md)
- [ ] [`FE-ADMIN-04 — Artigos - Novo / Editar`](admin/04-artigos-novo-editar.md)
- [ ] [`FE-ADMIN-05 — Páginas - Listagem`](admin/05-paginas-listagem.md)
- [ ] [`FE-ADMIN-06 — Páginas - Nova / Editar`](admin/06-paginas-nova-editar.md)
- [ ] [`FE-ADMIN-07 — Mídia - Biblioteca`](admin/07-midia-biblioteca.md)
- [ ] [`FE-ADMIN-08 — Mídia - Upload`](admin/08-midia-upload.md)
- [ ] [`FE-ADMIN-09 — Menu - Gerenciamento`](admin/09-menu-gerenciamento.md)
- [ ] [`FE-ADMIN-10 — Depoimentos - Listagem`](admin/10-depoimentos-listagem.md)
- [ ] [`FE-ADMIN-11 — Depoimentos - Novo / Editar`](admin/11-depoimentos-novo-editar.md)
- [ ] [`FE-ADMIN-12 — Usuários - Listagem`](admin/12-usuarios-listagem.md)
- [ ] [`FE-ADMIN-13 — Usuários - Novo / Editar`](admin/13-usuarios-novo-editar.md)
- [ ] [`FE-ADMIN-14 — Configurações Gerais`](admin/14-configuracoes-gerais.md)
- [ ] [`FE-ADMIN-15 — Áreas de Atuação - Listagem`](admin/15-areas-de-atuacao-listagem.md)
- [ ] [`FE-ADMIN-16 — Área de Atuação - Nova / Editar`](admin/16-area-de-atuacao-nova-editar.md)
- [ ] [`FE-ADMIN-17 — Equipe - Listagem`](admin/17-equipe-listagem.md)
- [ ] [`FE-ADMIN-18 — Equipe - Novo / Editar Advogado`](admin/18-equipe-novo-editar-advogado.md)
- [ ] [`FE-ADMIN-19 — Home - Gerenciamento`](admin/19-home-gerenciamento.md)
- [ ] [`FE-ADMIN-20 — Home - Editar Banner Principal`](admin/20-home-editar-banner-principal.md)
- [ ] [`FE-ADMIN-21 — Home - Editar Seção Sobre`](admin/21-home-editar-secao-sobre.md)
- [ ] [`FE-ADMIN-22 — Home - Áreas de Atuação em Destaque`](admin/22-home-areas-de-atuacao-em-destaque.md)
- [ ] [`FE-ADMIN-23 — Home - Equipe em Destaque`](admin/23-home-equipe-em-destaque.md)
- [ ] [`FE-ADMIN-24 — Home - Depoimentos em Destaque`](admin/24-home-depoimentos-em-destaque.md)
- [ ] [`FE-ADMIN-25 — Home - Artigos Recentes`](admin/25-home-artigos-recentes.md)
- [ ] [`FE-ADMIN-26 — Home - Chamada para Ação (CTA)`](admin/26-home-chamada-para-acao-cta.md)
- [ ] [`FE-ADMIN-27 — Contato - Mensagens Recebidas`](admin/27-contato-mensagens-recebidas.md)
- [ ] [`FE-ADMIN-28 — Contato - Detalhe da Mensagem`](admin/28-contato-detalhe-da-mensagem.md)
- [ ] [`FE-ADMIN-29 — Contato - Configurações`](admin/29-contato-configuracoes.md)
- [ ] [`FE-ADMIN-30 — Rodapé - Configuração`](admin/30-rodape-configuracao.md)
- [ ] [`FE-ADMIN-31 — SEO - Configurações Gerais`](admin/31-seo-configuracoes-gerais.md)
- [ ] [`FE-ADMIN-32 — SEO - Open Graph`](admin/32-seo-open-graph.md)
- [ ] [`FE-ADMIN-33 — SEO - Indexação e Robots`](admin/33-seo-indexacao-e-robots.md)
- [ ] [`FE-ADMIN-34 — SEO - Sitemap`](admin/34-seo-sitemap.md)
- [ ] [`FE-ADMIN-35 — Redes Sociais`](admin/35-redes-sociais.md)
- [ ] [`FE-ADMIN-36 — Integrações`](admin/36-integracoes.md)
- [ ] [`FE-ADMIN-37 — Perfil do Administrador`](admin/37-perfil-do-administrador.md)
- [ ] [`FE-ADMIN-38 — Perfil - Alterar Senha`](admin/38-perfil-alterar-senha.md)
- [ ] [`FE-ADMIN-39 — Recuperar Senha`](admin/39-recuperar-senha.md)
- [ ] [`FE-ADMIN-40 — Redefinir Senha`](admin/40-redefinir-senha.md)
- [ ] [`FE-ADMIN-41 — Notificações`](admin/41-notificacoes.md)
- [ ] [`FE-ADMIN-42 — Aparência / Identidade Visual`](admin/42-aparencia-identidade-visual.md)
- [ ] [`FE-ADMIN-43 — Formulários`](admin/43-formularios.md)
- [ ] [`FE-ADMIN-44 — Formulário - Novo / Editar`](admin/44-formulario-novo-editar.md)
- [ ] [`FE-ADMIN-45 — Relatórios`](admin/45-relatorios.md)
- [ ] [`FE-ADMIN-46 — Logs / Atividades`](admin/46-logs-atividades.md)
- [ ] [`FE-ADMIN-47 — Permissões / Perfis de Acesso`](admin/47-permissoes-perfis-de-acesso.md)
- [ ] [`FE-ADMIN-48 — Página 404 - Editar`](admin/48-pagina-404-editar.md)
- [ ] [`FE-ADMIN-49 — Política de Privacidade - Editar`](admin/49-politica-de-privacidade-editar.md)
- [ ] [`FE-ADMIN-50 — Termos de Uso - Editar`](admin/50-termos-de-uso-editar.md)

## Site — 20 tarefas

- [ ] [`FE-SITE-01 — Home`](site/01-home.md)
- [ ] [`FE-SITE-02 — Sobre Nós`](site/02-sobre-nos.md)
- [ ] [`FE-SITE-03 — Áreas de Atuação`](site/03-areas-de-atuacao.md)
- [ ] [`FE-SITE-04 — Detalhe da Área de Atuação`](site/04-detalhe-da-area-de-atuacao.md)
- [ ] [`FE-SITE-05 — Nossa Equipe`](site/05-nossa-equipe.md)
- [ ] [`FE-SITE-06 — Perfil do Advogado`](site/06-perfil-do-advogado.md)
- [ ] [`FE-SITE-07 — Artigos / Conteúdos`](site/07-artigos-conteudos.md)
- [ ] [`FE-SITE-08 — Detalhe do Artigo`](site/08-detalhe-do-artigo.md)
- [ ] [`FE-SITE-09 — Depoimentos`](site/09-depoimentos.md)
- [ ] [`FE-SITE-10 — Contato`](site/10-contato.md)
- [ ] [`FE-SITE-11 — Confirmação de Envio do Contato`](site/11-confirmacao-de-envio-do-contato.md)
- [ ] [`FE-SITE-12 — Resultado de Busca`](site/12-resultado-de-busca.md)
- [ ] [`FE-SITE-13 — Política de Privacidade`](site/13-politica-de-privacidade.md)
- [ ] [`FE-SITE-14 — Termos de Uso`](site/14-termos-de-uso.md)
- [ ] [`FE-SITE-15 — Política de Cookies`](site/15-politica-de-cookies.md)
- [ ] [`FE-SITE-16 — Preferências de Cookies`](site/16-preferencias-de-cookies.md)
- [ ] [`FE-SITE-17 — Página 404`](site/17-pagina-404.md)
- [ ] [`FE-SITE-18 — Página de Erro`](site/18-pagina-de-erro.md)
- [ ] [`FE-SITE-19 — Nenhum Resultado Encontrado`](site/19-nenhum-resultado-encontrado.md)
- [ ] [`FE-SITE-20 — Menu Mobile`](site/20-menu-mobile.md)

## Total

- 50 tarefas Admin
- 20 tarefas Site
- **70 tarefas de frontend**
