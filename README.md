# Запуск
Для запуска можно использовать базу данных в ОЗУ. Для этого в файле appsettings.js в параметре UseInMemoryDatabase необходимо указаать false.
Иначе будет попытка использования PGSQL.

# Если пользуется база данных
При использовании база данных необходимо указать строку подключения для PGSQL в файле appsettings.js в параметре DefaultConnection.
После выполнить команду
dotnet ef database update -Context ApplicationDbContext
