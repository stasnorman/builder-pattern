# Builder Pattern API

## Описание

Этот проект реализует паттерн "Строитель" в контексте API для управления продуктами с использованием ASP.NET Core и Entity Framework Core с подключением к MySQL. Паттерн "Строитель" позволяет создавать сложные объекты поэтапно, обеспечивая гибкость и удобство в процессе разработки.

## Функциональные возможности

- **CRUD операции** для управления продуктами:
  - Получение всех продуктов
  - Поиск продуктов с фильтрацией
  - Получение продукта по идентификатору
  - Создание нового продукта
  - Обновление существующего продукта
  - Удаление продукта
- Подключение к базе данных MySQL
- Использование асинхронных методов для улучшения производительности

## Установка

### 1. Клонирование репозитория

Сначала клонируйте репозиторий на локальную машину:

```bash
git clone https://github.com/stasnorman/builder-pattern.git
cd builder-pattern
```

### 2. Настройка базы данных

1. Убедитесь, что у вас установлен MySQL и создана база данных.
2. Измените строку подключения в файле `appsettings.json`:

```json
{
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=YourDatabaseName;User=YourUsername;Password=YourPassword;"
   }
}
```

### 3. Установка зависимостей

Убедитесь, что у вас установлены все необходимые пакеты NuGet:

```bash
dotnet restore
```

### 4. Создание миграций и обновление базы данных

После установки зависимостей создайте миграции и обновите базу данных:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Запуск приложения

Запустите приложение:

```bash
dotnet run
```

API будет доступно по адресу `http://localhost:5000` (или порту, который вы указали в настройках).

## Использование

Вы можете тестировать API с помощью Postman или Swagger, который будет доступен по адресу `http://localhost:5000/swagger`.

### Примеры запросов

1. Получение всех продуктов:

   ```http
   GET http://localhost:5000/api/products-all
   ```

2. Фильтрация продуктов:

   ```http
   POST http://localhost:5000/api/filter
   Content-Type: application/json

   {
       "Category": "Ноутбук",
       "MinPrice": 12000,
       "MaxPrice": 22000
   }
   ```

3. Получение продукта по ID:

   ```http
   GET http://localhost:5000/api/products/{id}
   ```

4. Создание нового продукта:

   ```http
   POST http://localhost:5000/api/products
   Content-Type: application/json

   {
       "Name": "Ноутбук",
       "Price": 15000,
       "Category": "Электроника"
   }
   ```

5. Обновление существующего продукта:

   ```http
   PUT http://localhost:5000/api/products/{id}
   Content-Type: application/json

   {
       "Id": {id},
       "Name": "Обновлённый Ноутбук",
       "Price": 16000,
       "Category": "Электроника"
   }
   ```

6. Удаление продукта:

   ```http
   DELETE http://localhost:5000/api/products/{id}
   ```
