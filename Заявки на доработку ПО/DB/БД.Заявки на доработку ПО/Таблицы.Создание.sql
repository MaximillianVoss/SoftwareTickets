GO
DROP TABLE IF EXISTS [������];
GO
CREATE TABLE [������]
(
    [id]                        INT          IDENTITY (1, 1) ,
    [id��]                      INT ,
    [��������]                  VARCHAR(255) NOT NULL ,
    [email]                     VARCHAR(255) NOT NULL ,
    [��������]                  VARCHAR(255) ,
    [���� ��������� ����������] DATETIME     NOT NULL ,
    PRIMARY KEY ([id])
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [��];
GO
CREATE TABLE [��]
(
    [id]       INT          IDENTITY (1, 1) ,
    [��������] VARCHAR(255) NOT NULL ,
    PRIMARY KEY ([id])
) ON [PRIMARY]
GO

ALTER TABLE [������] ADD FOREIGN KEY (id��) REFERENCES [��] ([id]);