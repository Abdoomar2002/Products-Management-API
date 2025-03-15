# 🛠️ Products Management API

A clean, CQRS-based Products Management API built with **.NET**, **MediatR**, **EF Core**, and **Domain Events** to handle product-category relationships without direct foreign keys.

---

## 🚀 Features

- ✅ **CQRS Pattern** — Clean separation of Commands & Queries  
- ✅ **Domain Events** — Syncs category product counts on product create/delete  
- ✅ **EF Core** — Uses `OwnsOne` and `OwnsMany` for clean data modeling  
- ✅ **Exception Handling** — Custom error handling with proper status codes (`201`, `200`, `204`, `400`, `404`, `500`)  
- ✅ **Dependency Injection** — Repositories, CQRS handlers, and event handlers fully wired  
- ✅ **Swagger Integration** — Easily test API endpoints  

---

## 🛠️ Tech Stack

- **.NET 8**  
- **EF Core**  
- **MediatR** (for CQRS and Domain Events)  
- **SQLite**  
- **Swagger**  

---

## 📂 Project Structure

```
📁 Products_Management_API
│
└── 📁 Server
    │
    ├── 📁 CQRS
    │   ├── 📁 Command
    │   │   ├── 📁 Product
    │   │   │   ├── CreateProduct.cs
    │   │   │   ├── UpdateProduct.cs
    │   │   │   └── DeleteProduct.cs
    │   │   └── 📁 Category
    │   │       ├── CreateCategory.cs
    │   │       ├── UpdateCategory.cs
    │   │       └── DeleteCategory.cs
    │   │
    │   ├── 📁 Queries
    │   │   └── Product & Category queries
    │   │
    │   └── 📁 Handlers
    │
    ├── 📁 DomainEvents
    │   ├── ProductCreatedEvent.cs
    │   ├── ProductDeletedEvent.cs
    │   │
    │   └── 📁 DomainEventHandlers
    │       └── UpdateCategoryProductCountHandler.cs
    │
    ├── 📁 Models (Product & Category)
    │
    ├── 📁 Repositories
    │
    └── 📁 Controllers
        ├── ProductController.cs
        └── CategoryController.cs
```

---

## 🛠️ Setup and Run

### 🔧 1. Clone the Repository

```bash
git clone <repo_url>
```

---

### 🔧 2. Install Dependencies

```bash
dotnet restore
```

---

### 🔧 3. Set Up the Database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 🔧 4. Run the Application

```bash
dotnet run
```

The API will be live at:  
👉 `https://localhost:5001/api`  

---

### 🔧 5. Explore with Swagger

After running the app, head to:  
👉 [https://localhost:7211/swagger/index.html](https://localhost:7211/swagger/index.html)

---

## 🔥 API Endpoints

### 🛠️ Products

| Method | Endpoint                  | Description |
|--------|---------------------------|-------------|
| `POST` | `/api/product`            | Create a new product (201) |
| `PUT`  | `/api/product/{id}`       | Update a product (204) |
| `DELETE` | `/api/product/{id}`     | Delete a product (204) |
| `GET`  | `/api/product/{id}`       | Get a product by ID (200) |
| `GET`  | `/api/product`            | Get all products (200/204) |
| `GET`  | `/api/product/category/{id}` | Get products by category (200/204) |

---

### 🛠️ Categories

| Method | Endpoint                  | Description |
|--------|---------------------------|-------------|
| `POST` | `/api/category`           | Create a new category (201) |
| `PUT`  | `/api/category/{id}`      | Update a category (204) |
| `DELETE` | `/api/category/{id}`    | Delete a category (204) |
| `GET`  | `/api/category/{id}`      | Get a category by ID (200) |
| `GET`  | `/api/category`           | Get all categories (200/204) |

---

## ⚡ Example Payloads

### 🎯 Create Product

```json
{
  "name": "Gaming Mouse",
  "priceValue": 29.99,
  "currency": "USD",
  "categoryId": "e4f7a5b8-6a2e-4374-b08b-1a8e8dc6eaba"
}
```

---

### 🎯 Create Category

```json
{
  "name": "Electronics"
}
```

---

## 🧠 How Domain Events Work

- When a **Product** is created/deleted, the `ProductCreatedEvent` or `ProductDeletedEvent` fires automatically.  
- The event triggers the `UpdateCategoryProductCountHandler`, which fetches the corresponding category and updates its `ProductCount` — **without foreign keys!**  
- This keeps the aggregates separate while maintaining data consistency.  

---

## 🧪 Future Improvements

- ✅ Add FluentValidation for cleaner validation  
- ✅ Implement Soft Deletes  
- ✅ Add Caching for product counts  
- ✅ Include Unit Tests for domain events and handlers  
- ✅ Implement Pagination for large product lists  

---

## ✨ Author

Made with ❤️ by **Abdelrahman Omar**

---

## 🛠️ License

📄 MIT License  

