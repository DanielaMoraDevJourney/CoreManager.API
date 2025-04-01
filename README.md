# CoreManager.API

RESTful API developed in **ASP.NET Core + Clean Architecture**, designed to manage users using CRUD operations.

---

## Project Structure

The project follows the principles of **Clean Architecture**, separating responsibilities by layers:

- `CoreManager.Domain`: Entities, interfaces, and DTOs (no external dependencies)
- `CoreManager.Application`: Services with business logic and system rules
- `CoreManager.Infrastructure`: Data access and configuration for EF Core
- `CoreManager.WebApplication`: Controllers that expose the API (presentation layer)

---

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SQLite
- Swagger (interactive documentation)

---

## How to run the project

### 1. Clone the repository

```bash
git clone https://github.com/DanielaMoraDevJourney/CoreManager.API.git
cd CoreManager.API
```

### 2. Add the connection string to `appsettings.json`

```json
"ConnectionStrings": {
"context": "Server=(localdb)\MSSQLLocalDB;Database=CoreManagerDb;Trusted_Connection=True;"
}
```

### 3. Run migrations with EF

```
Add-Migration InitialCreate
```
### 4. Create the database with EF
```
Update-Database
```

### 5. Start the server

Access Swagger at:
📍 `https://localhost:{port}/swagger`

---

## 📬 Available endpoints

| Method | Endpoint | Description |
|--------|------------------|------------------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get a user by ID |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update a user |
| DELETE | `/api/users/{id}` | Delete a user |

---

## Recommended Commit Structure

We use conventional commits to maintain a clean and understandable history:
- `feat`: new functionality
- `fix`: bug fixes
- `chore`: general tasks
- `refactor`: code changes without affecting functionality

---

## Author

Daniela Mora – Web Engineering Project
📚 7th semester – 2025

---

## Project Status

🟢 Complete and functional backend
🟢 Complete and functional frontend