# Modelo inicial

## Identity
User -> Roles -> Permissions

## Content
Page: Id, Title, Slug, Body/Content, Status, PublishedAt, CreatedAt, UpdatedAt, Version.
Content: conteúdo gerenciável conforme a feature; evitar entidade genérica sem invariantes.

## Navigation
Menu: Id, Name, Location, Items.
MenuItem: Id, MenuId, Label, PageId ou Url, ParentId, Order, IsVisible.

## Estados de Page
Draft -> Published; permitir regras explícitas para unpublish/archive quando implementadas.
