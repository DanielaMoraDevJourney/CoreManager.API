# CoreManager.API

RESTful API developed using **ASP.NET Core + Clean Architecture**, designed for managing users via full CRUD operations and secure authentication via JWT.

---

## 🏗 Project Architecture

This solution follows the **Clean Architecture** principles, organizing code by concerns:

- `CoreManager.Domain`: Domain models, interfaces, DTOs (no external dependencies)
- `CoreManager.Application`: Application layer with business rules and logic
- `CoreManager.Infrastructure`: Persistence logic and EF Core database configuration
- `CoreManager.WebApplication`: API controllers (presentation layer)

---

## 💡 Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 9
- SQL Server / SQLite
- Swagger (via Swashbuckle)
- JWT Authentication (Bearer Token)

---

## 📦 Required NuGet Packages

To ensure the API runs correctly, make sure the following packages are installed:

| Package | Version |
|--------|---------|
| `Microsoft.EntityFrameworkCore` | 9.0.3 |
| `Microsoft.EntityFrameworkCore.SqlServer` | 9.0.3 |
| `Microsoft.EntityFrameworkCore.Tools` | 9.0.3 |
| `Microsoft.VisualStudio.Web.CodeGeneration.Design` | 8.0.7 |
| `Swashbuckle.AspNetCore` | 6.6.2 |
| `Microsoft.AspNetCore.Authentication.JwtBearer` | 8.0.0 |

These can be added via **NuGet Package Manager** or using the Package Manager Console.

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

### 6. Run the project

Once running, Swagger will be available at:

📍 `https://localhost:{PORT}/swagger`

---

## 🔐 Authentication

### 🔑 Admin Login

Use the following endpoint to authenticate and receive a **JWT token**:

```http
POST /api/admin/login
```

**Request Body:**
```json
{
  "username": "admin",
  "password": "admin123"
}
```

✅ Upon successful login, the token must be sent as a **Bearer Token** in the `Authorization` header for all subsequent requests.

---

## 👩‍💻 Predefined Admin User for Testing

A default admin user is seeded automatically:

- 👤 **Username:** `admin`
- 🔐 **Password:** `admin123`

Use these credentials to test login and access secure admin features.

---

## 📡 API Endpoints

### 🔓 Public
| Method | Route | Description |
|--------|-------|-------------|
| POST | `/api/admin/login` | Authenticate and receive JWT |

### 🔐 Protected (Require JWT)
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/users` | Retrieve all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |
| GET | `/api/admin/users` | List all administrators |
| POST | `/api/admin/users` | Create new admin user |
| PUT | `/api/admin/users/{id}` | Update admin |
| DELETE | `/api/admin/users/{id}` | Delete admin |

⚠️ Remember to include the **Authorization** header:
```http
Authorization: Bearer <your_token>
```

---

## 👩‍💻 Author

**Daniela Mora**  
Web Engineering Project  
📚 7th semester – 2025

---

## 📌 Project Status

✅ Backend fully functional  
✅ Frontend fully integrated and responsive  
✅ JWT-based authentication and admin management implemented
