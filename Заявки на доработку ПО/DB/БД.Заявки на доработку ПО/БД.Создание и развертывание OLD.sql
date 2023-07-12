--#region Создание БД 'SoftwareTickets'
IF DB_ID('SoftwareTickets') IS NULL
BEGIN
    -- Recreate the database
    CREATE DATABASE [SoftwareTickets]
END
--#endregion
GO
--#endregion
USE [SoftwareTickets]
GO
--#region Очистка БД
:r "C:\Users\FossW\OneDrive\Репетиторство\Программирование\Заказы\Михаил Сухих\Заявки на доработку ПО\Заявки на доработку ПО\БД\БД.Заявки на доработку ПО\БД.Очистка.sql"
:r "C:\Users\FossW\OneDrive\Репетиторство\Программирование\Заказы\Михаил Сухих\Заявки на доработку ПО\Заявки на доработку ПО\БД\БД.Заявки на доработку ПО\Таблицы.Создание.sql"
:r "C:\Users\FossW\OneDrive\Репетиторство\Программирование\Заказы\Михаил Сухих\Заявки на доработку ПО\Заявки на доработку ПО\БД\БД.Заявки на доработку ПО\Таблицы.Заполнение.sql"
--#endregion