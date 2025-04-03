# CoreManager.API 🧠

A robust and scalable **RESTful API** built with **ASP.NET Core 8** using **Clean Architecture** principles.  
CoreManager.API powers the backend of a user management system with **full CRUD capabilities**, **admin authentication**, and **JWT security**.

---

## ✨ Motivation & Purpose

Managing users securely and efficiently is a fundamental feature for modern web applications.  
This project was built as part of an academic journey to understand how clean backend architectures are implemented in enterprise-level systems, with an emphasis on separation of concerns, scalability, and security.

---

## 📌 Features

- 🧍‍♂️ Full User CRUD (Create, Read, Update, Delete)
- 🔐 Admin authentication with **JWT**
- 🛡️ Protected endpoints (with authorization middleware)
- 📦 Clean Architecture (Domain, Application, Infrastructure, Web)
- 🧪 EF Core 9 + SQL Server integration
- 📘 Swagger documentation
- 🧪 Pre-seeded test admin for quick setup

---

## 🧱 Project Structure

```
CoreManager.API/
│
├── CoreManager.Domain/         # Entities, DTOs, Interfaces
├── CoreManager.Application/    # Business rules and services
├── CoreManager.Infrastructure/ # Database context and repositories
├── CoreManager.WebApplication/ # Controllers (API layer)
└── Migrations/                 # EF Core migrations
```

---

## 🧰 Tech Stack

| Technology            | Description                    |
|-----------------------|--------------------------------|
| .NET 8                | Core framework                 |
| ASP.NET Core Web API  | RESTful services               |
| Entity Framework Core | ORM for database access        |
| SQL Server / SQLite   | Database providers             |
| JWT Bearer Token      | Auth & Authorization           |
| Swagger               | API documentation              |

---

## 📦 Required NuGet Packages

| Package                                            | Version |
|---------------------------------------------------|---------|
| `Microsoft.EntityFrameworkCore`                   | 9.0.3   |
| `Microsoft.EntityFrameworkCore.SqlServer`         | 9.0.3   |
| `Microsoft.EntityFrameworkCore.Tools`             | 9.0.3   |
| `Microsoft.VisualStudio.Web.CodeGeneration.Design`| 8.0.7   |
| `Swashbuckle.AspNetCore`                          | 6.6.2   |
| `Microsoft.AspNetCore.Authentication.JwtBearer`   | 8.0.0   |

You can install them via NuGet Package Manager or Package Manager Console.

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/DanielaMoraDevJourney/CoreManager.API.git
cd CoreManager.API
```

### 2. Add your database connection string to `appsettings.json`

```json
"ConnectionStrings": {
  "context": "Server=(localdb)\\MSSQLLocalDB;Database=CoreManagerDb;Trusted_Connection=True;"
}
```

### 3. Optional: Remove current migration (if needed)

```
Remove-Migration InitialCreate
```

### 4. Add your migration

```
Add-Migration InitialCreate
```

### 5. Apply migrations and create the database

```
Update-Database
```

### 6. Run the project (CLI)

Once running, Swagger will be available at:

📍 `https://localhost:{PORT}/swagger`

---

## ▶ Running from Visual Studio

You can also run this project directly in **Visual Studio** without using the CLI.

### Steps:

1. Open the solution file `CoreManager.API.sln` in Visual Studio.
2. Set `CoreManager.WebApplication` (or your API project) as the **Startup Project**.
3. In the top toolbar, select the launch profile:
   - ✅ `https` (recommended)
   - Or `http` / `IIS Express`
4. Press `F5` or click the green ▶️ button to run the API.
5. Visual Studio will automatically open Swagger at:

```
https://localhost:{PORT}/swagger
```

✅ This method provides an easy debug experience, enabling you to:
- Set breakpoints
- Inspect requests/responses
- Step through logic

---

## 🔐 Authentication

### 🔑 Admin Login

Authenticate to receive a **JWT Token**:

```http
POST /api/admin/login
```

Request Body:

```json
{
  "username": "admin",
  "password": "admin123"
}
```

Use the received token in your `Authorization` header:

```http
Authorization: Bearer {your_token_here}
```

---

## 👩‍💻 Pre-seeded Admin User

For testing purposes, a default admin user is created:

| Field     | Value       |
|-----------|-------------|
| Username  | `admin`     |
| Password  | `admin123`  |

---

## 📡 API Endpoints

### 🔓 Public

| Method | Route              | Description                       |
|--------|--------------------|-----------------------------------|
| POST   | `/api/admin/login` | Admin login to receive JWT token  |

### 🔐 Protected (Require JWT)

| Method | Route                   | Description                      |
|--------|-------------------------|----------------------------------|
| GET    | `/api/users`            | Get all users                    |
| GET    | `/api/users/{id}`       | Get user by ID                   |
| POST   | `/api/users`            | Create a new user                |
| PUT    | `/api/users/{id}`       | Update a user                    |
| DELETE | `/api/users/{id}`       | Delete a user                    |
| GET    | `/api/admin/users`      | Get all admin users              |
| POST   | `/api/admin/users`      | Create new admin user            |
| PUT    | `/api/admin/users/{id}` | Update an admin user             |
| DELETE | `/api/admin/users/{id}` | Delete an admin user             |

---

## 🧪 Testing the API

You can use Swagger or tools like **Postman** to test the endpoints.

Make sure to add the `Authorization: Bearer <token>` header for secured routes.

---

## 🛠 Future Improvements

- 🔄 Refresh tokens for longer sessions
- 🧠 Role-based authorization
- 🌐 Global error handling middleware
- ✉️ Email confirmation & password recovery

---

## 👥 Author & Credits

Developed by **Daniela Mora**  
🎓 Web Engineering Project - 7th Semester (2025)  
📫 [GitHub Profile](https://github.com/DanielaMoraDevJourney)

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

## 🙌 Contributing

This project is currently maintained as part of a university course.  
Pull requests are welcome, but feel free to fork and build on top of it.

---

## 📌 Project Status

✅ Fully functional backend  
✅ Frontend connected and tested  
✅ JWT Authentication with admin login  
✅ Clean Architecture applied