CREATE TABLE [Security].[User] (
    [idUser]           INT                IDENTITY (1, 1) NOT NULL,
    [Email]            NVARCHAR (100)     COLLATE Modern_Spanish_CI_AS NOT NULL,
    [FirstName]        NVARCHAR (50)      COLLATE Modern_Spanish_CI_AS NULL,
    [LastName]         NVARCHAR (50)      COLLATE Modern_Spanish_CI_AS NULL,
    [Birthday]         DATETIMEOFFSET (7) NULL,
    [Active]           BIT                CONSTRAINT [DF_User_Active] DEFAULT ((1)) NOT NULL,
    [CreationDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_User_CreationDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [CreatedByIdUser]  INT                NOT NULL,
    [UpdateDateTime]   DATETIMEOFFSET (7) NULL,
    [UpdatedByIdUser]  INT                NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([idUser] ASC)
);

