
# TaskManager API 🧩

A modular, scalable backend API for task management, built with **.NET 9**, **Clean Architecture**, **CQRS**, **MediatR**, and **Entity Framework Core**. The project is **Dockerized** and uses **SQL Server** as the database.

---

## ✨ Features

- ✅ Project & Task CRUD
- ✅ CQRS with MediatR
- ✅ FluentValidation for input validation
- ✅ Clean Architecture principles (Domain, Application, Infrastructure, API)
- ✅ Generic Repository Pattern
- ✅ SQL Server integration
- ✅ Dockerized with `docker-compose`
- ✅ Swagger UI for API exploration

---

## 🏗️ Project Structure

```
TaskManager/
├── TaskManager.Domain/         # Domain entities & enums
├── TaskManager.Application/    # Application logic, CQRS, DTOs
├── TaskManager.Infrastructure/ # EF Core DbContext, Repositories
├── TaskManager.Api/            # Controllers & Dependency Injection
├── docker-compose.yml          # Multi-container setup
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [SQL Server Docker image](https://hub.docker.com/_/microsoft-mssql-server)

---

### 🔧 Running Locally

#### 1. Clone the repository
```bash
git clone https://github.com/yourusername/TaskManager.git
cd TaskManager
```

#### 2. Run with Docker Compose
```bash
docker-compose up --build
```

This will:

- Start the `TaskManager.Api` container on `http://localhost:5000`
- Start the `SQL Server` container on `localhost:1433`

---

### 🌐 API Documentation

After the containers are running, go to:

```
http://localhost:5000/swagger
```

You can test all endpoints from the Swagger UI.

---

### 🧪 Example Endpoints

- `GET /api/projects` – Get all projects
- `POST /api/projects` – Create a project
- `GET /api/tasks/by-project/{projectId}` – Get tasks by project
- `PUT /api/tasks/status` – Update task status

---

## 🛠️ Tech Stack

- **.NET 9**
- **Entity Framework Core**
- **MediatR**
- **FluentValidation**
- **Docker**
- **SQL Server**
- **Swagger**

---

## 📦 Migrations

To apply migrations locally:

```bash
# From the solution root
dotnet ef migrations add InitialCreate -p TaskManager.Infrastructure -s TaskManager.Api
dotnet ef database update -p TaskManager.Infrastructure -s TaskManager.Api
```

---

## 🔐 Environment Variables

Edit the `docker-compose.override.yml`:

```env
DB_HOST=sqlserver
DB_NAME=TaskManagerDb
DB_USER=sa
DB_PASSWORD=
```

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

## 👨‍💻 Author

Made with ❤️ by [Youssef EL Gharbaoui](https://github.com/YoussefElGharbaouiDevs)
