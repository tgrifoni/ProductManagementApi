CREATE TABLE [dbo].[Product] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100)  NOT NULL,
    [Code]        VARCHAR (8)    NOT NULL,
    [Category]    INT            NOT NULL,
    [Description] VARCHAR (200)  NULL,
    [ReleaseDate] DATETIME       NOT NULL,
    [Price]       DECIMAL (7, 2) NOT NULL,
    [Rating]      INT            NULL,
    [ImageUrl]    VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);



