# WebShopMVC

### ASP.NET Core MVC e-commerce application with Identity, relational data, end-to-end order workflows, and Docker Compose

WebShopMVC is a **.NET 10 / ASP.NET Core MVC** e-commerce application built around storefront, shopping cart, checkout, order, and administration workflows.

The application uses **Entity Framework Core with SQL Server** for persistence, **ASP.NET Core Identity** for authentication and role-based authorization, Razor views for the UI, and Docker Compose for a reproducible local application + database environment.

---

## Core Workflows

### Storefront

* Product catalog with images and category associations
* Product detail pages
* Filtering by category and price range
* Sorting by price or product name
* Application-level pagination
* Product quantity and discount information

### Shopping Cart

The cart is stored in ASP.NET Core session and supports:

* adding and removing products
* changing quantities
* stock-aware quantity validation
* discounted line-total calculation
* validation before checkout

If the requested quantity exceeds available stock, the cart quantity is adjusted before the order can be created.

### Checkout & Orders

Checkout is available to authenticated users and captures billing and shipping information together with order line items.

When an order is created:

1. the order is persisted to SQL Server;
2. cart items are converted into `OrderItem` records;
3. product stock is reduced;
4. cart and checkout session state are cleared.

Users can review their own order history and order details. Access to individual orders includes an ownership check against the currently authenticated user.

### Administration

The `/Admin` area is protected with role-based authorization:

```csharp
[Authorize(Roles = "Admin")]
```

Administrative workflows include management of:

* products
* categories
* product-category associations
* product images
* orders and order items
* Identity roles

Deleting an order restores the associated quantities back to product inventory before removing the order.

---

## Application Structure

WebShopMVC follows a straightforward ASP.NET Core MVC structure:

```text
Browser
  ↓
Razor Views
  ↓
MVC Controllers
  ├── ASP.NET Core Session
  │      └── Shopping Cart
  │
  ├── ASP.NET Core Identity
  │      ├── Authentication
  │      └── Role-based Authorization
  │
  └── ApplicationDbContext
         ↓
     Entity Framework Core
         ↓
      SQL Server
```

Controllers coordinate application workflows and access `ApplicationDbContext` through dependency injection.

Administrative functionality is separated using ASP.NET Core Areas.

---

## Data Model

The main relational model includes:

```text
ApplicationUser
      │
      └── Orders
            │
            └── OrderItems ───── Products
                                  │
                                  ├── Images
                                  │
                                  └── ProductCategories ───── Categories
```

Primary application entities:

* `ApplicationUser`
* `Product`
* `Category`
* `ProductCategory`
* `Image`
* `Order`
* `OrderItem`

`ProductCategory` represents the many-to-many relationship between products and categories.

Order items preserve product price, quantity, and discount information recorded during checkout.

---

## Authentication & Authorization

Authentication is provided by **ASP.NET Core Identity** with Entity Framework Core-backed Identity stores.

The application uses:

* registered Identity users
* confirmed-account sign-in
* Identity roles
* `[Authorize]` for authenticated workflows
* `[Authorize(Roles = "Admin")]` for administration
* ownership checks for user-specific order details

A development Admin account is initialized separately from EF Core migrations and only in the **Development** environment.

Development credentials are read from configuration and are not stored in source code.

---

## Development & Running

EF Core migrations are applied automatically during application startup using `MigrateAsync()`.

SQL Server configuration enables transient retry handling with `EnableRetryOnFailure()`. Initialization failures are logged and cause startup to fail rather than allowing the application to continue with an invalid database state.

### Visual Studio / Local Development

The project supports **User Secrets** for development Admin credentials.

Configure:

```json
{
  "DevelopmentAdmin": {
    "Email": "admin@example.com",
    "Password": "replace-with-a-strong-local-password"
  }
}
```

In Visual Studio:

```text
Right-click WebShopMVC
→ Manage User Secrets
```

The default local connection string targets SQL Server Express. It can be overridden through configuration if another SQL Server instance is used.

Run from the repository root:

```bash
dotnet restore
dotnet run --project WebShopMVC/WebShopMVC.csproj
```

### Docker Compose

Docker Compose runs:

```text
Docker Compose
    │
    ├── WebShopMVC
    │      └── ASP.NET Core 10
    │
    └── SQL Server 2022
           └── persistent Docker volume
```

Copy:

```text
.env.example
```

to:

```text
.env
```

and replace the placeholder values:

```dotenv
SQL_SA_PASSWORD=ReplaceWithStrongLocalSqlPassword1!
DEVELOPMENT_ADMIN_EMAIL=admin@admin.com
DEVELOPMENT_ADMIN_PASSWORD=ReplaceWithStrongLocalAdminPassword1!
```

`.env` is excluded from Git and the Docker build context.

Start the environment:

```bash
docker compose up --build
```

Application:

```text
http://localhost:8080
```

Stop containers:

```bash
docker compose down
```

Remove containers and the persisted SQL Server development volume:

```bash
docker compose down -v
```

> `-v` deletes the local database volume.

---

## Project Structure

```text
WebShopMVC/
├── Areas/
│   ├── Admin/
│   └── Identity/
├── Controllers/
│   ├── CartController.cs
│   └── HomeController.cs
├── Data/
│   ├── ApplicationDbContext.cs
│   ├── ApplicationUser.cs
│   ├── DevelopmentDataInitializer.cs
│   └── Migrations/
├── Extensions/
├── Models/
├── Views/
├── wwwroot/
├── Program.cs
└── Dockerfile

docker-compose.yml
.env.example
```

---

## Technology Stack

**Backend**
C# · .NET 10 · ASP.NET Core MVC · Razor

**Data**
SQL Server · Entity Framework Core · Code-First · EF Core Migrations · LINQ

**Security**
ASP.NET Core Identity · Authentication · Role-based Authorization

**Business Workflows**
Product Catalog · Shopping Cart · Checkout · Orders · Inventory · Administration

**Infrastructure**
Docker · Docker Compose · SQL Server Container · User Secrets · Environment Configuration

---

## Design Scope

WebShopMVC is intentionally designed as a focused MVC e-commerce application rather than distributed e-commerce infrastructure.

Key implementation choices include:

* direct EF Core access from MVC controllers;
* session-backed shopping cart state;
* application-level catalog filtering, sorting, and pagination;
* local checkout and order processing without an external payment provider;
* automatic migrations and Development-only Admin initialization.

In a larger production system, these areas could evolve toward dedicated application services, database-level pagination, distributed session/cache infrastructure, external payment workflows, and independently managed database deployments.

---

## License

This project is licensed under the [MIT License](LICENSE).
