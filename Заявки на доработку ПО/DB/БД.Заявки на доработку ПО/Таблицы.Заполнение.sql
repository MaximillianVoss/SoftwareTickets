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
