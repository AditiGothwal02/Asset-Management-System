# 📦 Asset Management System (Backend)

A **backend-only Asset Management System** developed as part of professional training.  
This project focuses on building **RESTful APIs using .NET** to manage and track organizational assets, following clean architecture and production-style backend practices.

---

## 🚀 Features

- **Asset Management APIs (CRUD)**
  - Create, retrieve, update, and delete assets
  - Maintain asset details such as name, category, status, and assignment

- **RESTful API Design**
  - Well-structured endpoints following REST principles
  - Clear request–response handling

- **Validation & Error Handling**
  - Server-side validation for incoming requests
  - Meaningful HTTP status codes and error messages

- **Scalable Backend Architecture**
  - Separation of concerns between controllers, services, and data access
  - Designed to support future frontend integration

---

## 🛠 Tech Stack

- **Backend Framework:** .NET Core / ASP.NET  
- **Language:** C#  
- **API Style:** REST APIs
- **Authentication:** JWT Bearer Authentication  
- **Authorization:** Role-based authorization  
- **API Documentation:** Swagger (OpenAPI)  
- **Database:** SQL Server / MySQL  
- **Tools:** Swagger, Git, Visual Studio

---

## 🔄 API Endpoints (High-Level)

### 🔐 Authentication
- `POST /api/auth/login`  
  Authenticate user and generate JWT token  

### 📁 Assets
- `GET /api/assets` *(Authorized)*  
- `GET /api/assets/{id}` *(Authorized)*  
- `POST /api/assets` *(Authorized / Role-based)*  
- `PUT /api/assets/{id}` *(Authorized / Role-based)*  
- `DELETE /api/assets/{id}` *(Authorized / Role-based)*  

---
## 🧪 API Testing with Swagger

- Swagger UI configured with **JWT Bearer authentication**
- Token can be added via **Authorize** button
- Allows testing of protected endpoints directly from Swagger

---

## 🧠 Key Learnings

- Implementing **JWT-based authentication** in .NET
- Securing APIs using **Authorization policies**
- Integrating authentication with **Swagger UI**
- Designing secure and scalable backend systems
- Understanding production-level backend security practices

---

## 📌 Project Status

- Completed as a **professional training project**
- Fully functional secure backend
- Ready for frontend or third-party client integration

