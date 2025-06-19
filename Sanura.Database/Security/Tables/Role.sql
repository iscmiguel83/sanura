CREATE TABLE [Security].[Role] (
    [idRole]           INT                IDENTITY (1, 1) NOT NULL,
    [Code]             NVARCHAR (50)      COLLATE Modern_Spanish_CI_AS NOT NULL,
    [Description]      NVARCHAR (100)     COLLATE Modern_Spanish_CI_AS NULL,
    [Active]           BIT                CONSTRAINT [DF_Role_Active_1] DEFAULT ((1)) NOT NULL,
    [CreationDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_Role_CreationDateTime_1] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [CreatedByIdUser]  INT                NOT NULL,
    [UpdateDateTime]   DATETIMEOFFSET (7) NULL,
    [UpdatedByIdUser]  INT                NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([idRole] ASC),
    CONSTRAINT [FK_Role_CreatedByIdUser] FOREIGN KEY ([CreatedByIdUser]) REFERENCES [Security].[User] ([idUser]),
    CONSTRAINT [FK_Role_UpdatedByIdUser] FOREIGN KEY ([UpdatedByIdUser]) REFERENCES [Security].[User] ([idUser])
);

