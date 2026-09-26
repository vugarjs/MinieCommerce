# MinieCommerce

[![C#](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-Latest-512BD4?style=flat-square&logo=entity-framework)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server/)
[![Status](https://img.shields.io/badge/Status-Completed-brightgreen?style=flat-square)](https://github.com/vugarjs/MinieCommerce)

## 📋 Project Description

**MinieCommerce** is a clean, professional, and production-ready **e-commerce backend layer** built with **C# 13** and **Entity Framework Core**. It follows **Clean Architecture** principles with separation of concerns, using Fluent API configurations, async/await patterns, and optimized querying strategies for maximum performance.

This project demonstrates best practices in data access layer design, domain-driven design patterns, and modern C# conventions.

---

## 🛠️ Tech Stack

| Technology | Purpose | Version |
|-----------|---------|---------|
| **C#** | Primary Language | 13 |
| **.NET** | Framework | 10 |
| **Entity Framework Core** | ORM & Data Access | Latest |
| **SQL Server** | Database | 2019+ |
| **Fluent API** | Entity Configuration | EF Core |
| **AutoMapper** | DTO Mapping | Latest |
| **Async/Await** | Asynchronous Operations | Native |

---

## 📁 Project Architecture & Folder Structure

```
MinieCommerce.Core/
│
├── 📁 Entities/
│   ├── Common/
│   │   ├── BaseEntity.cs              (Base class with Id)
│   │   └── AuditAble.cs               (Audit tracking with CreatedAt)
│   ├── Category.cs                    (Product category)
│   ├── Product.cs                     (Product with pricing & stock)
│   ├── User.cs                        (User with role)
│   ├── Order.cs                       (Order with status)
│   ├── OrderItem.cs                   (Order line item)
│   └── Payment.cs                     (Payment transaction)
│
├── 📁 Enums/
│   ├── Roles/
│   │   └── UserRole.cs                (Admin, Customer)
│   └── Status/
│       ├── OrderStatus.cs             (Pending, Processing, Shipped, etc.)
│       ├── PaymentMethod.cs           (CreditCard, PayPal, BankTransfer)
│       └── PaymentStatus.cs           (Pending, Completed, Failed)
│
├── 📁 Context/
│   ├── CommerceDb.cs                  (DbContext with ApplyConfigurationsFromAssembly)
│   └── Configurations/
│       ├── UserConfiguration.cs       (User entity mapping)
│       ├── ProductConfiguration.cs    (Product entity mapping)
│       ├── CategoryConfiguration.cs   (Category entity mapping)
│       ├── OrderConfiguration.cs      (Order entity mapping)
│       ├── OrderItemConfiguration.cs  (OrderItem entity mapping)
│       └── PaymentConfiguration.cs    (Payment entity mapping)
│
├── 📁 Services/
│   ├── Interfaces/
│   │   ├── IProductService.cs         (Product operations contract)
│   │   ├── IOrderService.cs           (Order operations contract)
│   │   └── IPaymentService.cs         (Payment operations contract)
│   └── Implementation/
│       ├── ProductService.cs          (Product business logic)
│       ├── OrderService.cs            (Order business logic)
│       └── PaymentService.cs          (Payment business logic)
│
├── 📁 Dtos/
│   ├── ProductDtos/
│   │   ├── ProductCreateDto.cs
│   │   ├── ProductReturnDto.cs
│   │   └── ProdcutUpdateDto.cs
│   ├── OrderDtos/
│   │   ├── OrderCreateDto.cs
│   │   ├── OrderReturnDto.cs
│   │   └── OrderUpdateDto.cs
│   └── PaymentDtos/
│       ├── CreatePaymentDto.cs
│       ├── PaymentReturnDto.cs
│       └── PaymentUpdateDto.cs
│
├── 📁 Mappers/
│   └── MapperProfile.cs               (AutoMapper configurations)
│
└── Program.cs                         (Dependency injection & configuration)
```

---

## 🗄️ Domain Entities & Database Schema

### Entity Relationships Diagram

```
┌─────────────┐
│  Category   │
│ (1) ──────┐ │
│ Id        │ │
│ Name      │ │
│ Desc.     │ │
└─────────────┘
		▲
		│ 1:N
		│
┌───────┴──────┐
│   Product    │
│ Id           │
│ Name         │
│ Price        │
│ Stock        │
│ IsActive     │
│ CategoryId ──┘
└──────────────┘

┌─────────────┐
│    User     │
│ Id          │
│ FullName    │
│ Email       │
│ Role        │
│ CreatedAt   │
└──────┬──────┘
	   │ 1:N
	   │
┌──────▼──────────┐
│     Order       │
│ Id              │
│ UserId ─────────┘
│ OrderDate       │
│ Status          │
│ TotalAmount     │ 1:1
└──────┬──────────┤
	   │ 1:N       │
	   │           │
┌──────▼────────────┐  ┌─────────────┐
│   OrderItem       │  │  Payment    │
│ Id                │  │ Id          │
│ OrderId ──────────│  │ OrderId ────┘
│ ProductId         │  │ Amount      │
│ Quantity          │  │ Method      │
│ UnitPrice         │  │ PaymentDate │
└───────────────────┘  │ Status      │
					   └─────────────┘
```

### Entity Details

| Entity | Fields | Key Characteristics |
|--------|--------|---------------------|
| **User** | Id, FullName, Email, Role, CreatedAt | Inherits AuditAble; Email is Unique |
| **Category** | Id, Name, Description | Parent of Product (1:N); Unique Name index |
| **Product** | Id, Name, Price, StockQuantity, IsActive, CategoryId | Child of Category; Precision(18,2) for Price |
| **Order** | Id, UserId, OrderDate, Status, TotalAmount | Parent of OrderItem; OrderDate has default SQL value |
| **OrderItem** | Id, OrderId, ProductId, Quantity, UnitPrice | Child of Order; Composite relationship |
| **Payment** | Id, OrderId, Amount, PaymentMethod, Status, PaymentDate | 1:1 with Order; Cascade Delete enabled |

---

## ✨ Key Features & Implementation Details

### 🎯 Design Patterns

- **Clean Architecture**: Separation of concerns with Entities, Services, Interfaces, and DTOs
- **Repository Pattern**: Through Entity Framework Core DbContext
- **Dependency Injection**: Service-based registration for loose coupling
- **DTO Pattern**: Data Transfer Objects for API boundaries

### 💾 Database Features

| Feature | Implementation |
|---------|-----------------|
| **Fluent API Configuration** | `IEntityTypeConfiguration<T>` for each entity |
| **Constraints** | `HasMaxLength()`, `IsRequired()`, and `HasPrecision(18,2)` |
| **Unique Indexes** | Email (User), Name (Category, Product) |
| **Default Values** | SQL defaults for OrderDate and PaymentDate |
| **Cascade Delete** | Configured for data integrity |

### ⚡ Performance Optimizations

```csharp
// AsNoTracking() for read-only queries
var products = await _context.Products
	.AsNoTracking()
	.ToListAsync();

// Async/Await for non-blocking operations
public async Task<List<ProductReturnDto>> GetAllAsync()
{
	// All operations are async
}
```

### 📝 Code Quality

✅ **Async/Await Throughout**: All database operations use async patterns  
✅ **AsNoTracking()**: Applied to all read-only queries for better performance  
✅ **Type Safety**: Strong typing with generics and DTOs  
✅ **Error Handling**: Null checks and exception throwing  
✅ **Validation**: Entity constraints at the database level  

---

## 🚀 Getting Started

### Prerequisites

- **.NET 10 SDK** or later
- **SQL Server** (2019 or later)
- **Visual Studio 2026** or VS Code with C# extension

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/vugarjs/MinieCommerce.git
   cd MinieCommerce
   ```

2. **Install dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure the database connection** in `CommerceDb.cs`:
   ```csharp
   var stringConnection = "Server=localhost;Database=MinieCommerce;User Id=sa;Password=YourPassword;";
   optionsBuilder.UseSqlServer(stringConnection);
   ```

### Database Migration & Setup

#### Using Package Manager Console (Visual Studio)

```powershell
# Navigate to the project directory in Package Manager Console

# Create initial migration
Add-Migration InitialCreate

# Apply migration to database
Update-Database
```

#### Using .NET CLI

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### Verify Installation

After migrations complete, your database will contain these tables:
- `Users`
- `Categories`
- `Products`
- `Orders`
- `OrderItems`
- `Payments`

### Quick Test

```csharp
// Example: Get all products
var service = new ProductService(context, mapper);
var products = await service.GetAllAsync();
```

---

## 📊 Service Layer Overview

### IProductService

```csharp
public interface IProductService
{
	Task<ProductReturnDto> GetByIdAsync(int id);
	Task<List<ProductReturnDto>> GetAllAsync();
	Task CreateAsync(ProductCreateDto dto);
	Task UpdateAsync(int id, ProdcutUpdateDto dto);
	Task DeleteAsync(int id);
	Task UpdateStockAsync(int productId, int quantityChange);
}
```

### IOrderService

```csharp
public interface IOrderService
{
	Task<OrderReturnDto> GetOrderDetailsAsync(int orderId);
	Task<List<OrderReturnDto>> GetOrdersByUserIdAsync(int userId);
	Task CreateOrderAsync(OrderCreateDto dto);
	Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
	Task CancelOrderAsync(int orderId);
}
```

### IPaymentService

```csharp
public interface IPaymentService
{
	Task<PaymentReturnDto> GetPaymentByOrderIdAsync(int orderId);
	Task<bool> ProcessPaymentAsync(CreatePaymentDto dto);
}
```

---

## 🔧 Configuration Details

### Fluent API Example

```csharp
// Product Configuration
builder.Property(x => x.Price)
	.IsRequired()
	.HasColumnType("decimal(18,2)");

builder.HasOne(x => x.Category)
	.WithMany(x => x.Products)
	.HasForeignKey(x => x.CategoryId)
	.OnDelete(DeleteBehavior.Restrict);
```

### Entity Constraints Applied

- ✅ All string properties have MaxLength constraints
- ✅ All required fields marked with IsRequired()
- ✅ Decimal values use Precision(18,2)
- ✅ Foreign keys configured with proper cascading behavior
- ✅ Unique indexes on Email and Name fields

---

## 📈 Future Enhancements

- [ ] Implementing Unit of Work pattern
- [ ] Add caching layer (Redis)
- [ ] API endpoint controllers (Presentation layer)
- [ ] Logging and Error Handling middleware
- [ ] Unit and Integration tests
- [ ] API documentation (Swagger/OpenAPI)
- [ ] Authentication (JWT)
- [ ] Authorization (Role-based & Policy-based)

---

## 👤 Author

**Vugar** - [GitHub Profile](https://github.com/vugarjs)

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

## 💬 Support

For questions or issues, please open an [Issue](https://github.com/vugarjs/MinieCommerce/issues) on GitHub.

---

**Last Updated**: 2026  
**Status**: ✅ Production Ready
