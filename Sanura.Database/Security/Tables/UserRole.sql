CREATE TABLE [Security].[UserRole] (
    [idUserRole]       INT                IDENTITY (1, 1) NOT NULL,
    [idUser]           INT                NOT NULL,
    [idRole]           INT                NOT NULL,
    [Active]           BIT                CONSTRAINT [DF_UserRole_Active] DEFAULT ((1)) NOT NULL,
    [CreationDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_UserRole_CreationDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [CreatedByIdUser]  INT                NOT NULL,
    [UpdateDateTime]   DATETIMEOFFSET (7) NULL,
    [UpdatedByIdUser]  INT                NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([idUserRole] ASC),
    CONSTRAINT [FK_UserRole_CreatedByIdUser] FOREIGN KEY ([CreatedByIdUser]) REFERENCES [Security].[User] ([idUser]),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([idRole]) REFERENCES [Security].[Role] ([idRole]),
    CONSTRAINT [FK_UserRole_UpdatedByIdUser] FOREIGN KEY ([UpdatedByIdUser]) REFERENCES [Security].[User] ([idUser]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([idUser]) REFERENCES [Security].[User] ([idUser])
);


GO
