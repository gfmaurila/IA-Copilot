CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `adt_audit_entries` (
    `Id` char(36) NOT NULL,
    `Module` varchar(80) NOT NULL,
    `Resource` varchar(160) NOT NULL,
    `ResourceId` varchar(160) NOT NULL,
    `Action` varchar(32) NOT NULL,
    `Outcome` varchar(32) NOT NULL,
    `ActorId` char(36) NULL,
    `ActorEmail` varchar(320) NULL,
    `OrganizationId` char(36) NULL,
    `CorrelationId` varchar(80) NULL,
    `IpAddress` varchar(64) NULL,
    `DetailsJson` json NOT NULL,
    `OccurredAtUtc` datetime(6) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_agents` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Description` varchar(2000) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `OrganizationId` char(36) NULL,
    `ModelSettingsJson` json NOT NULL,
    `ToolNames` json NOT NULL,
    `PromptNames` json NOT NULL,
    `RequiresHumanApproval` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_executions` (
    `Id` char(36) NOT NULL,
    `AgentId` char(36) NOT NULL,
    `UserId` char(36) NOT NULL,
    `CorrelationId` varchar(80) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `InputJson` json NULL,
    `OutputJson` json NULL,
    `ErrorMessage` varchar(2000) NULL,
    `RequiresHumanApproval` tinyint(1) NOT NULL,
    `StartedAtUtc` datetime(6) NOT NULL,
    `CompletedAtUtc` datetime(6) NULL,
    `RetryCount` int NOT NULL,
    `EstimatedCostUsd` decimal(12,6) NOT NULL,
    `PromptTokens` int NOT NULL,
    `CompletionTokens` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_knowledge_bases` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Description` varchar(2000) NOT NULL,
    `OrganizationId` char(36) NULL,
    `EmbeddingModel` varchar(160) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `CreatedByUserId` char(36) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_prompts` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Template` text NOT NULL,
    `Description` varchar(1000) NOT NULL,
    `TemplateVersion` int NOT NULL,
    `IsActive` tinyint(1) NOT NULL,
    `OrganizationId` char(36) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_runs` (
    `Id` char(36) NOT NULL,
    `Provider` varchar(80) NOT NULL,
    `Model` varchar(160) NOT NULL,
    `Operation` varchar(40) NOT NULL,
    `ExecutionId` char(36) NULL,
    `CorrelationId` varchar(80) NOT NULL,
    `PromptTokens` int NOT NULL,
    `CompletionTokens` int NOT NULL,
    `Duration` time(6) NOT NULL,
    `EstimatedCostUsd` decimal(12,6) NOT NULL,
    `Success` tinyint(1) NOT NULL,
    `ErrorMessage` varchar(2000) NULL,
    `StartedAtUtc` datetime(6) NOT NULL,
    `Attempt` int NOT NULL,
    `ToolName` varchar(160) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_tools` (
    `Id` char(36) NOT NULL,
    `Name` varchar(160) NOT NULL,
    `Description` varchar(2000) NOT NULL,
    `RequiredPermission` varchar(160) NOT NULL,
    `IsReadOnly` tinyint(1) NOT NULL,
    `InputSchemaJson` json NOT NULL,
    `Status` varchar(32) NOT NULL,
    `RequiresApproval` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `cnt_content_items` (
    `Id` char(36) NOT NULL,
    `ContentTypeId` char(36) NOT NULL,
    `Title` varchar(300) NOT NULL,
    `Slug` varchar(300) NOT NULL,
    `Summary` varchar(1000) NULL,
    `TaxonomyId` char(36) NULL,
    `OrganizationId` char(36) NULL,
    `Status` varchar(32) NOT NULL,
    `PayloadJson` json NOT NULL,
    `PublishedAtUtc` datetime(6) NULL,
    `PublishedByUserId` char(36) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `cnt_content_types` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Slug` varchar(200) NOT NULL,
    `Description` varchar(1000) NOT NULL,
    `IsSystem` tinyint(1) NOT NULL,
    `OrganizationId` char(36) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `cnt_taxonomies` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Slug` varchar(200) NOT NULL,
    `IsHierarchical` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `iam_api_keys` (
    `Id` char(36) NOT NULL,
    `UserId` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Prefix` varchar(24) NOT NULL,
    `KeyHash` varchar(255) NOT NULL,
    `ExpiresAtUtc` datetime(6) NOT NULL,
    `LastUsedAtUtc` datetime(6) NULL,
    `RevokedAtUtc` datetime(6) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `iam_groups` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Description` varchar(1000) NOT NULL,
    `ParentGroupId` longtext NULL,
    `Status` varchar(32) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `iam_organizations` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Slug` varchar(200) NOT NULL,
    `Description` varchar(1000) NULL,
    `Status` varchar(32) NOT NULL,
    `IsDefault` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `iam_roles` (
    `Id` char(36) NOT NULL,
    `Name` varchar(120) NOT NULL,
    `Description` varchar(500) NOT NULL,
    `Kind` varchar(32) NOT NULL,
    `IsSystem` tinyint(1) NOT NULL,
    `IsDeletable` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `iam_users` (
    `Id` char(36) NOT NULL,
    `OrganizationId` char(36) NOT NULL,
    `FirstName` varchar(120) NOT NULL,
    `LastName` varchar(120) NOT NULL,
    `email` varchar(320) NOT NULL,
    `PasswordHash` varchar(255) NOT NULL,
    `JobTitle` varchar(200) NULL,
    `AvatarUrl` varchar(500) NULL,
    `Status` varchar(32) NOT NULL,
    `IsEmailConfirmed` tinyint(1) NOT NULL,
    `MustChangePassword` tinyint(1) NOT NULL,
    `LastLoginAt` datetime(6) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `med_media_items` (
    `Id` char(36) NOT NULL,
    `FileName` varchar(400) NOT NULL,
    `StorageKey` varchar(500) NOT NULL,
    `ContentType` varchar(160) NOT NULL,
    `SizeInBytes` bigint NOT NULL,
    `Kind` varchar(32) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `UploadedByUserId` char(36) NOT NULL,
    `OrganizationId` char(36) NULL,
    `AltText` varchar(500) NULL,
    `Width` int NULL,
    `Height` int NULL,
    `UploadedAtUtc` datetime(6) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `nav_menus` (
    `Id` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Location` varchar(32) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ntf_notifications` (
    `Id` char(36) NOT NULL,
    `RecipientUserId` char(36) NULL,
    `Channel` varchar(32) NOT NULL,
    `Title` varchar(300) NOT NULL,
    `Body` varchar(4000) NOT NULL,
    `ActionUrl` varchar(500) NULL,
    `Status` varchar(32) NOT NULL,
    `CreatedAtUtc` datetime(6) NOT NULL,
    `SentAtUtc` datetime(6) NULL,
    `ReadAtUtc` datetime(6) NULL,
    `FailureReason` varchar(500) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `ai_approvals` (
    `Id` char(36) NOT NULL,
    `ExecutionId` char(36) NOT NULL,
    `ActionName` varchar(200) NOT NULL,
    `PayloadJson` json NOT NULL,
    `RequestedByTool` varchar(160) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `ReviewerUserId` char(36) NULL,
    `ReviewerComment` varchar(1000) NULL,
    `RequestedAtUtc` datetime(6) NOT NULL,
    `DecidedAtUtc` datetime(6) NULL,
    `ExpiresAtUtc` datetime(6) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ai_approvals_ai_executions_ExecutionId` FOREIGN KEY (`ExecutionId`) REFERENCES `ai_executions` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ai_knowledge_documents` (
    `Id` char(36) NOT NULL,
    `KnowledgeBaseId` char(36) NOT NULL,
    `FileName` varchar(400) NOT NULL,
    `ContentType` varchar(160) NOT NULL,
    `StorageKey` varchar(500) NOT NULL,
    `SizeInBytes` bigint NOT NULL,
    `UploadedByUserId` char(36) NOT NULL,
    `Status` varchar(32) NOT NULL,
    `ErrorMessage` varchar(2000) NULL,
    `ChunkCount` int NOT NULL,
    `IngestedAtUtc` datetime(6) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ai_knowledge_documents_ai_knowledge_bases_KnowledgeBaseId` FOREIGN KEY (`KnowledgeBaseId`) REFERENCES `ai_knowledge_bases` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `cnt_content_versions` (
    `Id` char(36) NOT NULL,
    `ContentItemId` char(36) NOT NULL,
    `VersionNumber` int NOT NULL,
    `Title` varchar(300) NOT NULL,
    `PayloadJson` json NOT NULL,
    `CreatedAtUtc` datetime(6) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_cnt_content_versions_cnt_content_items_ContentItemId` FOREIGN KEY (`ContentItemId`) REFERENCES `cnt_content_items` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `cnt_fields` (
    `Id` char(36) NOT NULL,
    `ContentTypeId` char(36) NOT NULL,
    `Name` varchar(160) NOT NULL,
    `Type` varchar(32) NOT NULL,
    `IsRequired` tinyint(1) NOT NULL,
    `Position` int NOT NULL,
    `OptionsJson` json NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_cnt_fields_cnt_content_types_ContentTypeId` FOREIGN KEY (`ContentTypeId`) REFERENCES `cnt_content_types` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_group_roles` (
    `Id` char(36) NOT NULL,
    `GroupId` char(36) NOT NULL,
    `RoleId` char(36) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_group_roles_iam_groups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `iam_groups` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_teams` (
    `Id` char(36) NOT NULL,
    `OrganizationId` char(36) NOT NULL,
    `Name` varchar(200) NOT NULL,
    `Description` varchar(1000) NULL,
    `Status` varchar(32) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_teams_iam_organizations_OrganizationId` FOREIGN KEY (`OrganizationId`) REFERENCES `iam_organizations` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_permissions` (
    `Id` char(36) NOT NULL,
    `Name` varchar(160) NOT NULL,
    `Resource` varchar(80) NOT NULL,
    `Action` varchar(80) NOT NULL,
    `Description` varchar(300) NOT NULL,
    `IsSystem` tinyint(1) NOT NULL,
    `RoleId` char(36) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_permissions_iam_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `iam_roles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_policies` (
    `Id` char(36) NOT NULL,
    `RoleId` char(36) NOT NULL,
    `Name` varchar(160) NOT NULL,
    `Effect` varchar(16) NOT NULL,
    `ConditionsJson` json NOT NULL,
    `IsSystem` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_policies_iam_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `iam_roles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_sessions` (
    `Id` char(36) NOT NULL,
    `UserId` char(36) NOT NULL,
    `TokenHash` varchar(255) NOT NULL,
    `IpAddress` varchar(64) NULL,
    `UserAgent` varchar(400) NULL,
    `StartedAtUtc` datetime(6) NOT NULL,
    `ExpiresAtUtc` datetime(6) NOT NULL,
    `EndedAtUtc` datetime(6) NULL,
    `Status` varchar(32) NOT NULL,
    `EndReason` varchar(120) NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_sessions_iam_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `iam_users` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_user_groups` (
    `Id` char(36) NOT NULL,
    `UserId` char(36) NOT NULL,
    `GroupId` char(36) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_user_groups_iam_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `iam_users` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_user_roles` (
    `Id` char(36) NOT NULL,
    `UserId` char(36) NOT NULL,
    `RoleId` char(36) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_user_roles_iam_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `iam_users` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `nav_menu_items` (
    `Id` char(36) NOT NULL,
    `MenuId` char(36) NOT NULL,
    `Label` varchar(200) NOT NULL,
    `Url` varchar(500) NULL,
    `ContentItemId` char(36) NULL,
    `ParentId` char(36) NULL,
    `Order` int NOT NULL,
    `IsVisible` tinyint(1) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_nav_menu_items_nav_menus_MenuId` FOREIGN KEY (`MenuId`) REFERENCES `nav_menus` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `ai_document_chunks` (
    `Id` char(36) NOT NULL,
    `DocumentId` char(36) NOT NULL,
    `Position` int NOT NULL,
    `Text` text NOT NULL,
    `VectorPointId` varchar(160) NULL,
    `TokenCount` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ai_document_chunks_ai_knowledge_documents_DocumentId` FOREIGN KEY (`DocumentId`) REFERENCES `ai_knowledge_documents` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `iam_refresh_tokens` (
    `Id` char(36) NOT NULL,
    `SessionId` char(36) NOT NULL,
    `TokenHash` varchar(255) NOT NULL,
    `CreatedAtUtc` datetime(6) NOT NULL,
    `ExpiresAtUtc` datetime(6) NOT NULL,
    `RevokedAtUtc` datetime(6) NULL,
    `Status` varchar(32) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `UpdatedAt` datetime(6) NULL,
    `Version` bigint NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_iam_refresh_tokens_iam_sessions_SessionId` FOREIGN KEY (`SessionId`) REFERENCES `iam_sessions` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_adt_audit_entries_ActorId` ON `adt_audit_entries` (`ActorId`);

CREATE INDEX `IX_adt_audit_entries_OrganizationId_OccurredAtUtc` ON `adt_audit_entries` (`OrganizationId`, `OccurredAtUtc`);

CREATE INDEX `IX_adt_audit_entries_Resource_ResourceId` ON `adt_audit_entries` (`Resource`, `ResourceId`);

CREATE UNIQUE INDEX `IX_ai_agents_Name` ON `ai_agents` (`Name`);

CREATE INDEX `IX_ai_approvals_ExecutionId` ON `ai_approvals` (`ExecutionId`);

CREATE INDEX `IX_ai_approvals_Status_ExpiresAtUtc` ON `ai_approvals` (`Status`, `ExpiresAtUtc`);

CREATE UNIQUE INDEX `IX_ai_document_chunks_DocumentId_Position` ON `ai_document_chunks` (`DocumentId`, `Position`);

CREATE INDEX `IX_ai_document_chunks_VectorPointId` ON `ai_document_chunks` (`VectorPointId`);

CREATE INDEX `IX_ai_executions_AgentId_Status` ON `ai_executions` (`AgentId`, `Status`);

CREATE INDEX `IX_ai_executions_CorrelationId` ON `ai_executions` (`CorrelationId`);

CREATE INDEX `IX_ai_knowledge_bases_OrganizationId_Status` ON `ai_knowledge_bases` (`OrganizationId`, `Status`);

CREATE INDEX `IX_ai_knowledge_documents_KnowledgeBaseId_Status` ON `ai_knowledge_documents` (`KnowledgeBaseId`, `Status`);

CREATE UNIQUE INDEX `IX_ai_prompts_Name_TemplateVersion` ON `ai_prompts` (`Name`, `TemplateVersion`);

CREATE INDEX `IX_ai_runs_CorrelationId` ON `ai_runs` (`CorrelationId`);

CREATE INDEX `IX_ai_runs_Provider_Model` ON `ai_runs` (`Provider`, `Model`);

CREATE INDEX `IX_ai_runs_StartedAtUtc` ON `ai_runs` (`StartedAtUtc`);

CREATE UNIQUE INDEX `IX_ai_tools_Name` ON `ai_tools` (`Name`);

CREATE INDEX `IX_ai_tools_RequiredPermission` ON `ai_tools` (`RequiredPermission`);

CREATE UNIQUE INDEX `IX_cnt_content_items_ContentTypeId_Slug` ON `cnt_content_items` (`ContentTypeId`, `Slug`);

CREATE INDEX `IX_cnt_content_items_OrganizationId_Status` ON `cnt_content_items` (`OrganizationId`, `Status`);

CREATE UNIQUE INDEX `IX_cnt_content_types_OrganizationId_Slug` ON `cnt_content_types` (`OrganizationId`, `Slug`);

CREATE UNIQUE INDEX `IX_cnt_content_versions_ContentItemId_VersionNumber` ON `cnt_content_versions` (`ContentItemId`, `VersionNumber`);

CREATE INDEX `IX_cnt_fields_ContentTypeId` ON `cnt_fields` (`ContentTypeId`);

CREATE UNIQUE INDEX `IX_cnt_taxonomies_Slug` ON `cnt_taxonomies` (`Slug`);

CREATE INDEX `IX_iam_api_keys_Prefix` ON `iam_api_keys` (`Prefix`);

CREATE INDEX `IX_iam_api_keys_UserId` ON `iam_api_keys` (`UserId`);

CREATE UNIQUE INDEX `IX_iam_group_roles_GroupId_RoleId` ON `iam_group_roles` (`GroupId`, `RoleId`);

CREATE INDEX `IX_iam_group_roles_RoleId` ON `iam_group_roles` (`RoleId`);

CREATE UNIQUE INDEX `IX_iam_groups_Name` ON `iam_groups` (`Name`);

CREATE UNIQUE INDEX `IX_iam_organizations_Slug` ON `iam_organizations` (`Slug`);

CREATE INDEX `IX_iam_organizations_Status` ON `iam_organizations` (`Status`);

CREATE UNIQUE INDEX `IX_iam_permissions_Name` ON `iam_permissions` (`Name`);

CREATE INDEX `IX_iam_permissions_RoleId` ON `iam_permissions` (`RoleId`);

CREATE UNIQUE INDEX `IX_iam_policies_RoleId_Name` ON `iam_policies` (`RoleId`, `Name`);

CREATE INDEX `IX_iam_refresh_tokens_SessionId` ON `iam_refresh_tokens` (`SessionId`);

CREATE INDEX `IX_iam_refresh_tokens_TokenHash` ON `iam_refresh_tokens` (`TokenHash`);

CREATE UNIQUE INDEX `IX_iam_roles_Name` ON `iam_roles` (`Name`);

CREATE INDEX `IX_iam_sessions_Status_ExpiresAtUtc` ON `iam_sessions` (`Status`, `ExpiresAtUtc`);

CREATE INDEX `IX_iam_sessions_UserId` ON `iam_sessions` (`UserId`);

CREATE UNIQUE INDEX `IX_iam_teams_OrganizationId_Name` ON `iam_teams` (`OrganizationId`, `Name`);

CREATE INDEX `IX_iam_user_groups_GroupId` ON `iam_user_groups` (`GroupId`);

CREATE UNIQUE INDEX `IX_iam_user_groups_UserId_GroupId` ON `iam_user_groups` (`UserId`, `GroupId`);

CREATE INDEX `IX_iam_user_roles_RoleId` ON `iam_user_roles` (`RoleId`);

CREATE UNIQUE INDEX `IX_iam_user_roles_UserId_RoleId` ON `iam_user_roles` (`UserId`, `RoleId`);

CREATE UNIQUE INDEX `IX_iam_users_email` ON `iam_users` (`email`);

CREATE INDEX `IX_iam_users_OrganizationId` ON `iam_users` (`OrganizationId`);

CREATE INDEX `IX_iam_users_Status` ON `iam_users` (`Status`);

CREATE INDEX `IX_med_media_items_OrganizationId_Status` ON `med_media_items` (`OrganizationId`, `Status`);

CREATE UNIQUE INDEX `IX_med_media_items_StorageKey` ON `med_media_items` (`StorageKey`);

CREATE INDEX `IX_nav_menu_items_MenuId_ParentId_Order` ON `nav_menu_items` (`MenuId`, `ParentId`, `Order`);

CREATE UNIQUE INDEX `IX_nav_menus_Name_Location` ON `nav_menus` (`Name`, `Location`);

CREATE INDEX `IX_ntf_notifications_RecipientUserId_Status` ON `ntf_notifications` (`RecipientUserId`, `Status`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261001215405_InitialCreate', '10.0.12');

COMMIT;

