# WebShopMVC — ASP.NET Core MVC eCommerce Application (.NET 10)

## Containerized Application Setup

Dockerized ASP.NET Core MVC application with SQL Server container support using Docker Compose.

---

## Overview

WebShopMVC is a full-stack eCommerce application built with **C#** and **.NET 10**, using **ASP.NET Core MVC**, **SQL Server**, and **Entity Framework Core (Code-First)**.

The application includes **authentication and authorization with ASP.NET Identity**, an **admin area** for catalog management, complete **shopping cart and checkout workflows**, and a containerized deployment setup using Docker and Docker Compose.

The project is structured with a clean, maintainable architecture emphasizing separation of concerns, predictable data workflows, containerized application deployment, and production-oriented backend practices aligned with modern ASP.NET Core development.

The application supports a multi-container environment consisting of:
- ASP.NET Core MVC application container
- SQL Server container
- Docker Compose orchestration
- Automatic EF Core migrations during application startup

---

## Tech Stack

**Core**  
C# · .NET 10 · ASP.NET Core MVC

**Database & Persistence**  
SQL Server · Entity Framework Core · Code-First · EF Core Migrations

**Authentication & Security**  
ASP.NET Identity · Authentication · Authorization

**Architecture & Practices**  
Dependency Injection · Repository Pattern · Service Layer · LINQ · Razor Views

**Containerization & Deployment**  
Docker · Docker Compose · SQL Server Container · Containerized Application Workflow

---

## Key Features

- Authentication and authorization with ASP.NET Identity
- Role-based access control and user management
- Admin area for managing products, categories, and images
- Product catalog workflows with structured CRUD operations
- Shopping cart functionality with session-based persistence
- Checkout workflow with order creation and relational storage
- Filtering, sorting, and pagination using LINQ
- Database migrations and relational modeling using Entity Framework Core
- Repository and service layers for maintainable business logic and persistence
- Dockerized ASP.NET Core MVC application setup
- SQL Server container integration using Docker Compose
- Automatic EF Core migrations during application startup
- Multi-container application orchestration using Docker Compose

---

## Architecture

- MVC structure with clear controller/view separation
- Repository and service layers isolating business logic and persistence
- Centralized configuration via `Program.cs` and `appsettings.json`
- Modular folder structure for maintainability and scalability
- Containerized multi-service application environment using Docker Compose
- SQL Server integration through container networking and environment configuration

> Note: This project applies Clean Architecture principles where they improve maintainability and separation, while keeping implementation practical and easy to follow in an ASP.NET Core MVC application.

---

## What This Project Demonstrates

- Building full-stack web applications using ASP.NET Core MVC
- Implementing authentication and authorization using ASP.NET Identity
- Managing relational data using SQL Server and Entity Framework Core
- Applying Code-First development workflows and EF Core migrations
- Structuring maintainable MVC applications using repository and service layers
- Designing containerized ASP.NET Core application environments
- Running ASP.NET Core and SQL Server containers using Docker Compose
- Understanding containerized database workflows and application startup orchestration
- Applying modern deployment-oriented backend development practices

---

## How to Run (Local Setup)

### Prerequisites

- .NET SDK 10
- Docker Desktop
- Optional: Visual Studio 2022 or Rider

### Clone Repository

```bash
git clone https://github.com/alanracic/WebShopMVC.git
```

### Run with Docker Compose

Build and start the application containers:

```bash
docker compose up --build
```

Run the application:

```text
http://localhost:8080
```

### Docker Environment

The Docker Compose setup includes:
- ASP.NET Core MVC application container
- SQL Server container
- Container networking configuration
- Automatic EF Core migration execution during startup

### Alternative Local Development Setup

Configure the connection string in `appsettings.json`.

Apply migrations:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

---

## Project Structure (High-Level)

- `Areas/Admin` — admin controllers and views
- `Controllers` — user-facing MVC controllers
- `Data` — database context, migrations, persistence setup
- `Models` — domain models and entities
- `Repositories` — data-access abstractions and implementations
- `Services` — business logic and workflows
- `Views` — Razor UI
- `Dockerfile` — ASP.NET Core container configuration
- `docker-compose.yml` — multi-container orchestration setup

---

## Skills Demonstrated

C# · .NET 10 · ASP.NET Core MVC · SQL Server · Entity Framework Core · ASP.NET Identity · LINQ · Dependency Injection · Repository Pattern · Razor Views · Docker · Docker Compose · SQL Server Container · EF Core Migrations · Containerized Application Architecture

---

## Project Status

Actively maintained and iteratively improved as part of a professional .NET portfolio, demonstrating full-stack ASP.NET Core MVC development, relational database workflows, containerized application deployment, and production-oriented backend architecture patterns aligned with modern .NET development practices.
