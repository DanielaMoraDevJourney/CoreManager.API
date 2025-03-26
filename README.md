
# CoreManager.API

API RESTful desarrollada en **ASP.NET Core + Clean Architecture**, diseñada para gestionar usuarios mediante operaciones CRUD.

---

## Estructura del Proyecto

El proyecto sigue los principios de **Clean Architecture**, separando responsabilidades por capas:

- `CoreManager.Domain`: Entidades, interfaces y DTOs (sin dependencias externas)
- `CoreManager.Application`: Servicios con lógica de negocio y reglas del sistema
- `CoreManager.Infrastructure`: Acceso a datos y configuración de EF Core
- `CoreManager.WebApplication`: Controladores que exponen la API (capa de presentación)

---

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SQLite
- Swagger (documentación interactiva)

---

## Cómo ejecutar el proyecto

### 1. Clona el repositorio

```bash
git clone https://github.com/DanielaMoraDevJourney/CoreManager.API.git
cd CoreManager.API
```

### 2. Agrega la cadena de conexión en `appsettings.json`

```json
"ConnectionStrings": {
  "context": "Server=(localdb)\MSSQLLocalDB;Database=CoreManagerDb;Trusted_Connection=True;"
}
```

### 3. Ejecuta las migraciones con EF

```
Add-Migration InitialCreate
```
### 4. Crea la BDD con EF
```
Update-Database
```

### 5. Inicia el servidor


Accede a Swagger en:  
📍 `https://localhost:{puerto}/swagger`

---

## 📬 Endpoints disponibles

| Método | Endpoint        | Descripción            |
|--------|------------------|------------------------|
| GET    | `/api/users`     | Obtener todos los usuarios |
| GET    | `/api/users/{id}`| Obtener un usuario por ID |
| POST   | `/api/users`     | Crear un nuevo usuario     |
| PUT    | `/api/users/{id}`| Actualizar un usuario      |
| DELETE | `/api/users/{id}`| Eliminar un usuario        |

---

## Estructura recomendada del commit

Usamos `conventional commits` para mantener un historial limpio y comprensible:
- `feat`: nueva funcionalidad
- `fix`: corrección de errores
- `chore`: tareas generales
- `refactor`: cambios de código sin afectar funcionalidad

---

## Autor

Daniela Mora – Proyecto de Ingeniería Web  
📚 7° semestre – 2025

---

## Estado del proyecto

🟢 Backend completo y funcional  
🟡 Frontend en React en construcción...
