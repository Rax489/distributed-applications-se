# ФН:2301321060 Project:MvcSmartStore


Уеб приложение за онлайн магазин за смартфони, разработено с ASP.NET Core MVC, Entity Framework Core и SQL Server.

## 🧰 Изисквания

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Visual Studio 2022 или по-нова версия
- SQL Server Express или LocalDB

## 🚀 Стартиране на проекта


### 1. Настройване на връзката с базата данни

Отвори `appsettings.json` и редактирай връзката към SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MvcSmartStoreDB;Trusted_Connection=True;"
}
```

### 2. Подготовка на базата данни

❗ **Важно:** Преди да създадеш миграции, изтрий напълно папката `Migrations`, ако вече съществува. Това гарантира чисто начало без стари зависимости.

След това отвори **Package Manager Console** и изпълни:

```powershell
Add-Migration Initial
Update-Database
```

### 3. Стартиране на приложението

Натисни `F5` в Visual Studio или стартирай от команден ред:

```bash
dotnet run
```

## 👤 Администраторски достъп

Препоръчително е **ръчно** да добавиш поне един администратор в базата данни. Това може да стане със следната SQL команда:

```sql
INSERT INTO Users (Username, Password, IsAdmin)
VALUES ('admin', 'adminpass', 1);
```


## 📦 Основни функционалности

- Добавяне, редактиране и изтриване на смартфони (само от администратор)
- Търсене по няколко критерия
- Регистрация и вход на потребители
- Поръчки и количка
- Управление на потребители и роли

## ✅ Допълнителна информация

- Bootstrap 5 се използва за стилизиране
- TempData се използва за изкарване на popup съобщения след добавяне/редактиране/изтриване

---

🛠 Проектът е създаден с учебна цел от **Plamen**.
