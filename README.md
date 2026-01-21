# 🛒 ECommerceBackend (C#)

## 📌 Project Overview

**ECommerceBackend** is a console-based backend simulation of an e-commerce system built in **C#**.
The project demonstrates **object-oriented programming (OOP)** principles, clean architecture, and core backend business logic such as carts, orders, discounts, and payments.

This project is ideal for:

* University coursework / exams
* Learning backend architecture
* Junior developer portfolio (GitHub)

---

## 🧱 Project Structure

```
ECommerceBackend/
│
├── Models/
│   ├── Person.cs
│   ├── Customer.cs
│   ├── EmployeeCustomer.cs
│   ├── CustomerType.cs
│   ├── Product.cs
│   ├── CartItem.cs
│   ├── ShoppingCart.cs
│   └── Order.cs
│
├── Services/
│   ├── IPayment.cs
│   ├── FakePayment.cs
│   ├── DiscountService.cs
│   └── OrderService.cs
│
├── Data/
│   └── DataStore.cs
│
├── UI/
│   └── Menu.cs
│
├── Program.cs
└── README.md
```

---

## ✨ Features

### 🛍 Shopping Cart

* Add products to cart
* Quantity validation against stock
* Subtotal, discount, and total calculations
* Clear cart after checkout

### 📦 Products & Inventory

* Product price and stock tracking
* Stock validation before adding to cart

### 👤 Customers

* Base `Customer` class
* Specialized `EmployeeCustomer`
* Polymorphic discount handling using `virtual` / `override`

### 💸 Discounts

* Regular customers: **0%**
* Employee customers: **10%**
* Discount logic separated into service layer

### 🧾 Orders

* Order items snapshot
* Subtotal, discount, shipping cost, total amount
* Free shipping for orders over 100€
* Order history per customer

### 💳 Payments

* Payment abstraction via `IPayment`
* `FakePayment` implementation for simulation

### 🧠 Clean Architecture

* Separation of concerns (Models / Services / UI / Data)
* Business logic outside UI
* Easily extensible (new customer types, real payment, database)

---

## 🧪 OOP Concepts Used

* Encapsulation
* Inheritance
* Polymorphism
* Abstraction (interfaces)
* Single Responsibility Principle (SRP)

---

## ▶️ How to Run

1. Open the project in **Visual Studio** or **Visual Studio Code**
2. Make sure `.NET SDK` is installed
3. Run the application:

```bash
dotnet run
```

4. Use the console menu to:

* View products
* Add items to cart
* Checkout
* View order history

---

## 🧩 Example Flow

1. User views available products
2. Adds products to shopping cart
3. System validates stock
4. Discount is applied based on customer type
5. Payment is processed
6. Order is created and stored
7. Cart is cleared

---

## 🚀 Possible Future Improvements

* Database integration (Entity Framework Core)
* ASP.NET Web API frontend
* Authentication & authorization
* Unit testing (xUnit)
* Logging system
* Admin dashboard

---

## 🎓 Academic Use

This project is suitable for:

* Programming exams
* OOP demonstrations
* Backend architecture explanations

You can confidently explain:

> "The system uses polymorphism to apply different discounts without changing business logic."

---

## 👤 Author

**Xhafer Ibrahimi – C# Backend Development**
Feel free to extend or refactor this project.

---

✅ *Clean. Simple. Professional.*
