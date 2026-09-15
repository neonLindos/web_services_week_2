# CSE5032 · Модуль 02 — Реализация веб-сервиса с применением ASP.NET Core

Вторая тема курса **«Разработка веб-сервисов»**: контроллеры, маршрутизация, HTTP-методы GET/POST/PUT/DELETE, корректные HTTP-коды ответа (200/201/400/404), тестирование через Swagger.

| Работа | Проект | Ресурс | Endpoint'ы |
|--------|--------|--------|-----------|
| [homework/](homework/) | `BooksApi` | Book | `GET /api/books`, `POST /api/books` |
| [lab/](lab/) | `TasksApi` | TaskItem | полный CRUD `/api/tasks` (GET/GET id/POST/PUT/DELETE) |
| [prac/](prac/) | `StudentsApiM2` | Student | `GET /api/students`, `GET /api/students/{id}`, `POST /api/students` |

## Как запустить

Нужен [.NET 8 SDK](https://dotnet.microsoft.com/download):

```bash
cd homework   # или lab, prac
dotnet run
```

Откройте Swagger UI по адресу из вывода консоли.

## Структура

Каждая подпапка — самостоятельный проект:

- `.docx` — методичка от преподавателя, как выдана;
- `Модуль_02_*.md` — та же методичка в Markdown;
- `README.md` — решение: что реализовано, ответы на контрольные вопросы, итоговая таблица endpoint'ов.

Данные во всех решениях — in-memory (`List<T>` внутри контроллера), без базы данных.
