--#region Создание БД 'SoftwareTickets'
IF DB_ID('SoftwareTickets') IS NULL
BEGIN
    -- Recreate the database
    CREATE DATABASE [SoftwareTickets]
END
--#endregion

-- #region Создание табилц
GO
DROP TABLE IF EXISTS [Заявки];
GO
CREATE TABLE [Заявки]
(
    [id]                        INT          IDENTITY (1, 1) ,
    [idПО]                      INT ,
    [Название]                  VARCHAR(255) NOT NULL ,
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
    [Название] VARCHAR(255) NOT NULL ,
    PRIMARY KEY ([id])
) ON [PRIMARY]
GO

ALTER TABLE [Заявки] ADD FOREIGN KEY (idПО) REFERENCES [ПО] ([id]);
-- #endregion

-- #region Заполнение табилц
-- заполняем таблицу ПО
DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
    INSERT INTO ПО
        (название)
    VALUES
        ('ПО' + CAST(@i AS VARCHAR))
    SET @i = @i + 1
END

-- заполняем таблицу Заявки
DECLARE @j INT = 1
WHILE @j <= 20
BEGIN
    INSERT INTO Заявки
        (idПО, название, email, Описание, [Дата окончания разработки])
    VALUES
        (@j, 'Заявка' + CAST(@j AS VARCHAR), 'email' + CAST(@j AS VARCHAR) + '@example.com', 'Описание ' + CAST(@j AS VARCHAR), DATEADD(DAY, @j, '2023-07-11'))
    SET @j = @j + 1
END
-- #endregion
GO
-- #region Выборка из табилц
SELECT
    *
FROM
    [ПО];
SELECT
    *
FROM
    [Заявки]
-- #endregion
GO
--#region Представление ПО_и_Заявки
--#region Удаление
GO
DROP VIEW IF EXISTS dbo.[ПО_и_Заявки]; 
--#endregion
--#region Создание
GO
CREATE VIEW dbo.[ПО_и_Заявки]
AS
    (
    SELECT
        ПО.id AS 'ID ПО',
        ПО.название AS 'Название ПО',
        Заявки.id AS 'ID заявки',
        Заявки.название AS 'Название заявки',
        Заявки.email,
        Заявки.Описание,
        Заявки.[Дата окончания разработки]
    FROM
        dbo.ПО
        JOIN dbo.Заявки ON ПО.id = Заявки.idПО
);
--#endregion
--#endregion
GO
SELECT * FROM dbo.[ПО_и_Заявки];
