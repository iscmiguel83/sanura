CREATE TABLE [Security].[RoleModule] (
    [idRoleModule]     INT                IDENTITY (1, 1) NOT NULL,
    [idRole]           INT                NOT NULL,
    [idModule]         INT                NOT NULL,
    [Active]           BIT                CONSTRAINT [DF_RoleModule_Active] DEFAULT ((1)) NOT NULL,
    [CreationDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_RoleModule_CreationDateTime_1] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [CreatedByIdUser]  INT                NOT NULL,
    [UpdateDateTime]   DATETIMEOFFSET (7) NULL,
    [UpdatedByIdUser]  INT                NULL,
    CONSTRAINT [PK_RoleModule] PRIMARY KEY CLUSTERED ([idRoleModule] ASC),
    CONSTRAINT [FK_RoleModule_CreatedByIdUser] FOREIGN KEY ([CreatedByIdUser]) REFERENCES [Security].[User] ([idUser]),
    CONSTRAINT [FK_RoleModule_Module] FOREIGN KEY ([idModule]) REFERENCES [Security].[Module] ([idModule]),
    CONSTRAINT [FK_RoleModule_Role] FOREIGN KEY ([idRole]) REFERENCES [Security].[Role] ([idRole]),
    CONSTRAINT [FK_RoleModule_UpdatedByIdUser] FOREIGN KEY ([UpdatedByIdUser]) REFERENCES [Security].[User] ([idUser])
);


GO
