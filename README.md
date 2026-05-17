# 🎟️ SecureMvcApp – Event Management System

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=dotnet)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-512BD4?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-5C2D91?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL-Server-red?style=for-the-badge&logo=microsoftsqlserver)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap)
![License](https://img.shields.io/badge/License-Educational-green?style=for-the-badge)

---

## 🚀 Overview

SecureMvcApp is a **modern web application built with ASP.NET Core MVC** for managing events and user registrations with a secure authentication system.

It includes:
- 👤 ASP.NET Identity authentication
- 🔐 Google & Facebook login integration
- 🎟️ Event management system
- 👥 User registration for events
- 🛡️ Admin dashboard

---

## ✨ Features

### 👤 Authentication System
- Register / Login (ASP.NET Identity)
- External login (Google & Facebook)
- Role-based access control (Admin / User)

---

### 📅 Event Management (Admin)
- ➕ Create events
- 📋 List all events
- 🔍 View event details
- 🎟️ Manage capacity (number of seats)

---

### 🎫 User Features
- View all available events
- Register to events
- Prevent duplicate registrations
- Capacity validation (no overbooking)

---

### 🛡️ Security
- `[Authorize]` protection
- Admin-only access for management
- Secure database interactions via EF Core

---

## 🏗️ Project Architecture

SecureMvcApp/
│
├── Controllers
│ ├── AdminController.cs
│ ├── EventsController.cs
│
├── Models
│ ├── Event.cs
│ ├── Inscription.cs
│
├── Data
│ ├── ApplicationDbContext.cs
│
├── Views
│ ├── Admin
│ │ ├── Index.cshtml
│ │ ├── Create.cshtml
│ ├── Events
│ ├── Index.cshtml
│ ├── Details.cshtml
│
└── Program.cs

---

## 🛠️ Tech Stack

- ⚙️ ASP.NET Core MVC (.NET 6/7/8)
- 🗄️ Entity Framework Core
- 🧠 SQL Server
- 🔐 ASP.NET Identity
- 🎨 Bootstrap 5
- 💻 Razor Views (HTML/CSS)

---

## ⚙️ Installation

### 1️⃣ Clone repository
```bash
git clone https://github.com/your-username/SecureMvcApp.git
cd SecureMvcApp

### 2️⃣ Configure database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SecureMvcDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

### 3️⃣ Run migrations

dotnet ef migrations add InitialCreate
dotnet ef database update

###4️⃣ Run project
dotnet run

👩‍💻 Author

Developed as an academic project by Siham Bouzagrar (EHTP context).

⭐ Project Goal

To build a secure, scalable and professional event management system using modern ASP.NET Core MVC architecture.
