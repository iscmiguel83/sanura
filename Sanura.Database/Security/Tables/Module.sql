CREATE TABLE [Security].[Module] (
    [idModule]         INT                IDENTITY (1, 1) NOT NULL,
    [idModuleParent]   INT                NULL,
    [Code]             NVARCHAR (50)      COLLATE Modern_Spanish_CI_AS NOT NULL,
    [Description]      NVARCHAR (100)     COLLATE Modern_Spanish_CI_AS NULL,
    [SortOrder]        FLOAT (53)         NULL,
    [Icon]             NVARCHAR (50)      COLLATE Modern_Spanish_CI_AS NULL,
    [Active]           BIT                CONSTRAINT [DF_Module_Active_1] DEFAULT ((1)) NOT NULL,
    [CreationDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_Module_CreationDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [CreatedByIdUser]  INT                NOT NULL,
    [UpdateDateTime]   DATETIMEOFFSET (7) NULL,
    [UpdatedByIdUser]  INT                NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([idModule] ASC),
    CONSTRAINT [FK_Module_CreatedByIdUser] FOREIGN KEY ([CreatedByIdUser]) REFERENCES [Security].[User] ([idUser]),
    CONSTRAINT [FK_Module_Module] FOREIGN KEY ([idModuleParent]) REFERENCES [Security].[Module] ([idModule]),
    CONSTRAINT [FK_Module_UpdatedByIdUser] FOREIGN KEY ([UpdatedByIdUser]) REFERENCES [Security].[User] ([idUser])
);

