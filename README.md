API построено по принципам RESTful API придерживаясь чистой архитектуре.
После создания проекта Web API, я добавил в решении два дополнительных проекта (две библиотеки классов).
Первая библиотека классов взяла на себя роль домена, в ней я создал сущности и класс контекста для работы с БД.
Вторая библиотека классов созданна для осуществления функционала, в ней я использовал паттерн DTO и создал интерфейсы и классы реализующие их для создания CRUD - методов,
по DTO сущностей, созданных в этой библиотеке.
В слое API сделал 2 контроллера, подключил к ним интерфейсы и для всех методов контроллеров указал эндпоинты.

версия среды .NET 8.0 (последняя)
установленные пакеты Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SQLServer, Microsoft.EntityFrameworkCore.Tools (последние версии 8.0.10)

Я использовал БД Microsoft SQL Server, соотвественно если вы пользуетесь другой БД, подключите Microsoft.EntityFrameworkCore подходящий  для вас, например Postgress

при запуске проекта в IDE (VS, Rider) пакеты устанавливаются автоматически, зависимости проектов настраиваются так же автоматически.

единственное что нужно сделать это вставить строку подключения к вашей бд, она находится в файле appsetting.json Проекта MyWebAPI
 
в файле program.cs , если вы используете не SQL Server, код по инициализации контекста нужно сменить на подходящий к вашей бд.

Инициализируем первую миграцию в консоли управления пакетами кодом
Add-Migration InitialCreate -Project Domen -StartupProject MyWebApi -Context AppDbContext
Обновляем бд кодом Update-Database InitialCreate -Project Domen -StartupProject MyWebApi -Context AppDbContext

После этих операций запускаем проект и тестируем.
