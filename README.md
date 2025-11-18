# ECommerce API

**A RESTful API built with .NET 8, C#, Entity Framework Core, for managing products, customers, and orders in an e-commerce system. The project follows a clean architecture separating Domain, Application, Infrastructure, and API layers for scalability and maintainability.**

---

## Table of Contents
1. [Project Structure](#project-structure)
2. [Database Schema](#database-schema)
3. [API Endpoints](#api-endpoints)
   - [Customer Management](#customer-management-api)
   - [Order Management](#order-management-api)
4. [Sample JSON Requests](#sample-json-requests)
5. [Setup Instructions](#setup-instructions)
---

## Project Structure

```

ECommerce
│
├── ECommerce.Api          # Web API project (Controllers, Program.cs)
├── ECommerce.Application  # Business logic, Services, DTOs, Validators, Interfaces
├── ECommerce.Domain       # Entities: Product, Customer, Order, OrderItem, OrderStatus
└── ECommerce.Infrastructure  # EF Core DbContext, Configurations, Repositories, Seed Data

```

**Application Layer Breakdown**
```

ECommerce.Application
│
├── DTOs
│   ├── Customer
│   │   ├── CreateCustomerDto.cs
│   │   └── CustomerDto.cs
│   ├── OrderDTO
│       ├── CreateOrderDto.cs
│       ├── OrderDto.cs
│       └── OrderProductDto.cs
│
├── Interfaces
│   ├── Repositories
│   │   ├── ICustomerRepository.cs
│   │   ├── IOrderRepository.cs
│   │   └── IProductRepository.cs
│   └── Services
│       ├── ICustomerService.cs
│       └── IOrderService.cs
│
├── Services
│   ├── CustomerService.cs
│   └── OrderService.cs
│
└── Validators
├── CreateCustomerValidator.cs
└── CreateOrderValidator.cs

````

---

## Database Schema

**Tables & Relationships:**

| Table | Columns | Notes |
|-------|--------|------|
| Products | ProductID, ProductName, ProductDescription, ProductPrice, Stock |  |
| Customers | CustomerID, CustomerName, CustomerEmail, CustomerPhone | Email unique |
| Orders | OrderID, CustomerID, OrderDate, StatusID, TotalPrice | FK: CustomerID, StatusID |
| OrderItems | OrderItemID, OrderID, ProductID, Quantity, UnitPrice | FK: OrderID, ProductID |
| OrderStatuses | StatusID, StatusName | Enum: Pending, Processing, Completed, Cancelled |

**Relationships:**
- `Order` → `Customer` (Many-to-One)  
- `Order` → `OrderStatus` (Many-to-One)  
- `OrderItem` → `Order` (Many-to-One)  
- `OrderItem` → `Product` (Many-to-One)  

> Database is automatically created using EF Core Migrations.

---

## API Endpoints

### Customer Management API
| Method | Endpoint | Description | Response |
|--------|---------|------------|---------|
| GET | /api/customers | Retrieve all customers | 200 OK |
| POST | /api/customers | Create a new customer | 201 Created or 400 Bad Request |
| GET | /api/customers/{id} | Get customer details by ID | 200 OK or 404 Not Found |

### Order Management API
| Method | Endpoint | Description | Response |
|--------|---------|------------|---------|
| POST | /api/orders | Create a new order with multiple products | 201 Created or 400 Bad Request |
| GET | /api/orders/{id} | Get order details by ID | 200 OK or 404 Not Found |
| POST | /api/orders/UpdateOrderStatus/{id} | Update order status to Delivered and adjust stock | 200 OK or 404 Not Found |

---

## Sample JSON Requests

### Create Customer
```json
{
  "customerName": "Nada Assem",
  "customerEmail": "nada@example.com",
  "customerPhone": "01112345678"
}
````

### Create Order

```json
{
  "customerID": 1,
  "products": [
    { "productID": 2, "quantity": 3 },
    { "productID": 5, "quantity": 1 }
  ]
}
```

### Update Order Status

```json
// POST /api/orders/UpdateOrderStatus/1
//Nobody needed
```

---

## Setup Instructions

1. Clone the repository.
2. Open solution in **Visual Studio 2022** or later.
3. Set **ECommerce.Api** as a startup project.
4. Update `appsettings.json` connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDb;Trusted_Connection=True;"
}
```

5. Open Package Manager Console and run migrations:

```powershell
PM> Add-Migration InitialCreate -Project ECommerce.Infrastructure -StartupProject ECommerce.Api
PM> Update-Database -Project ECommerce.Infrastructure -StartupProject ECommerce.Api
```

6. Run the API and test endpoints using **Postman** or **Swagger**.

---

## Notes

* FluentValidation is used for input validation.
* `OrderStatus` uses a lookup table; default status is `Pending`.
* Stock is decreased automatically when an order is created.
* HTTP status codes:

  * 200 OK → successful GET/POST where resource already exists
  * 201 Created → resource successfully created
  * 400 Bad Request → invalid input or validation error
  * 404 Not Found → resource not found


