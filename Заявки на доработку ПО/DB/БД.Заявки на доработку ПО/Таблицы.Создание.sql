GO
DROP TABLE IF EXISTS [Заявки];
GO
CREATE TABLE [Заявки]
(
    [id]                        INT          IDENTITY (1, 1) ,
    [idПО]                      INT ,
    [название]                  VARCHAR(255) NOT NULL ,
    [email]                     VARCHAR(255) NOT NULL ,
    [Описание]                  VARCHAR(255) ,
    [Дата окончания разработки] DATETIME     NOT NULL ,
    PRIMARY KEY ([id])
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [ПО];
GO
CREATE TABLE [ПО]
(
    [id]       INT          IDENTITY (1, 1) ,
    [название] VARCHAR(255) NOT NULL ,
    PRIMARY KEY ([id])
) ON [PRIMARY]
GO

ALTER TABLE [Заявки] ADD FOREIGN KEY (idПО) REFERENCES [ПО] ([id]);