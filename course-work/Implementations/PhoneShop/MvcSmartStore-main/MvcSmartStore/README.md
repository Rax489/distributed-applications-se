# 📱 MvcSmartStore

**MvcSmartStore** is a web-based e-commerce application built with ASP.NET Core MVC.

---

## 📌 Description

MvcSmartStore is a basic online store system with user authentication and session-based shopping cart functionality. Doing this project I've practiced ASP.NET Core MVC, working with database and creating HTML view pages.

**Main features:**

- 🧍 User registration and login
- 🛒 Add/remove smartphones from the shopping cart
- 📄 View cart with item details and total price
- 👥 Session-based user management

---
⚠️ 

Dataset used in this project has **RANDOM DATA**, brands, models, images are all mixed up and smartphones that you see with this specifications does not exist in real life
---

## 🧰 Technologies Used

- **ASP.NET Core MVC** – For building the web application
- **C#** – Main programming language
- **Entity Framework Core** – ORM for database access
- **SQL Server** – Local database
- **Razor Views** – For rendering dynamic HTML content
- **Session Storage** – To manage logged-in users and carts
- **Visual Studio** – IDE used for development

---

## 📷 Preview




https://github.com/user-attachments/assets/4dae55bd-416f-4755-b107-2ce9c873a5d4



---

## 🚀 Running App

1. **Download Release version v1.0.0**
2. **Open MvcSmartStore.sln file**
3. **Delete migration folder, and in nuget console write to cammands: "add-migration InitialCreate" and then "update-database" (to make sure the database is properly created)**
4.  **Add data from 3mobile_phones_2000.csv file to database.**
    -I recommend to do it by using SQL Server Management Studio and typing this query in TestMvcDb database(After FROM write your own file directory):
    BULK INSERT Smartphones
    FROM 'C:\data\3mobile_phones_2000.csv' 
    WITH (
        FORMAT = 'CSV',
        FIRSTROW = 2, 
        FIELDTERMINATOR = ',',  
        ROWTERMINATOR = '\n',
        TABLOCK
    );
5. **Click Run app in Visual Studio and you are ready to use your app**
