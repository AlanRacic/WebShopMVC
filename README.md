# WebShopMVC — ASP.NET Core MVC eCommerce Application (.NET 10)

## Overview
WebShopMVC is a full-stack eCommerce application built with **C#** and **.NET 10**, using **ASP.NET Core MVC**, **SQL Server**, and **Entity Framework Core (Code-First)**.  
It includes **authentication and authorization with ASP.NET Identity**, an **admin area** for managing catalog content, and complete **shopping cart and checkout workflows**.

The project is structured with a **clean, maintainable architecture**, emphasizing clear separation of concerns, predictable data workflows, and an extensible codebase.

---

## Tech Stack
- **C# / .NET 10**
- **ASP.NET Core MVC**
- **SQL Server**
- **Entity Framework Core (Code-First + Migrations)**
- **ASP.NET Identity**
- **Razor Views**
- **LINQ**
- **Dependency Injection**

---

## Key Features
- **Authentication and authorization** with ASP.NET Identity (registration, login, role-based access)
- **Admin area** for managing products, categories, and images
- **Product catalog workflows** with structured CRUD operations
- **Shopping cart** with persistence (session-based and/or user-based, depending on configuration)
- **Checkout workflow** with order creation and storage
- **Filtering, sorting, and pagination** using LINQ
- **Database migrations** and relational modeling using Entity Framework Core
- **Layered structure** with repository and service layers for maintainable data access and business logic

---

## Architecture
- MVC structure with clear controller/view separation
- Repository and service layers to isolate business logic and persistence
- Centralized configuration via `Program.cs` and `appsettings.json`
- Modular folder structure for clarity and maintainability

> Note: This project applies Clean Architecture principles where they improve maintainability and separation, while keeping implementation practical and easy to follow in an MVC application.

---

## How to Run (Local Setup)
### Prerequisites
- **.NET SDK 10**
- **SQL Server** (local or Docker)
- (Optional) **Visual Studio 2022** or **Rider**

### Steps
1. Clone the repository  
   `git clone https://github.com/alanracic/WebShopMVC.git`

2. Configure the connection string in `appsettings.json`

3. Apply migrations and create the database  
   `dotnet ef database update`

4. Run the application  
   `dotnet run`

---

## Project Structure (High-Level)
- `Areas/Admin` — admin controllers and views
- `Controllers` — user-facing MVC controllers
- `Data` — database context, migrations, persistence setup
- `Models` — domain models / entities
- `Repositories` — data-access layer abstractions and implementations
- `Services` — business logic and workflows
- `Views` — Razor UI

---

## Skills Demonstrated
C# · .NET 10 · ASP.NET Core MVC · SQL Server · Entity Framework Core · ASP.NET Identity · LINQ · Dependency Injection · Repository Pattern · Razor Views · Web application architecture

---

## Status
Actively maintained and iteratively improved as part of a professional .NET portfolio, with emphasis on clean structure, reliable data workflows, and production-oriented patterns.
