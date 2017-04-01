CREATE TABLE [dbo].[Blog] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [title] NVARCHAR (50)  NOT NULL,
    [text]  NVARCHAR (MAX) NOT NULL
);

