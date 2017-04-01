CREATE TABLE [dbo].[Tour] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (50)   NOT NULL,
    [description]       NVARCHAR (MAX)  NOT NULL,
    [short_description] NVARCHAR (100)  NOT NULL,
    [price]             DECIMAL (19, 4) NOT NULL,
    [image_url]         NVARCHAR (MAX)  NULL,
    [is_hot]            BIT             DEFAULT ((0)) NOT NULL
);

