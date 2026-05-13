# Job Board API

A modern, RESTful Web API built with ASP.NET Core for managing job postings. This project demonstrates clean architecture principles, separating API routing from business logic and database access.

## 🚀 Tech Stack

*   **.NET 8** (C#)
*   **ASP.NET Core Web API**
*   **Entity Framework Core** (Configured for In-Memory DB / SQL Server)
*   **Swagger / OpenAPI** for API documentation and testing

## 🏗️ Architecture & Patterns Used

*   **Service Layer Pattern:** Business logic and database access are abstracted into a dedicated `JobPostingService`, keeping controllers thin and focused strictly on HTTP routing.
*   **Data Transfer Objects (DTOs):** Database entities are protected from over-posting/under-posting by mapping incoming and outgoing data to dedicated Request and Response DTOs.
*   **Dependency Injection (DI):** Services and Database Contexts are injected via the built-in .NET DI container.
*   **Soft Deletion:** Job postings are never permanently deleted from the database. Instead, an `IsActive` flag is toggled to maintain historical records.

## 🔌 API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/jobpostings` | Retrieves a list of all active job postings. |
| `GET` | `/api/jobpostings/{id}` | Retrieves a specific active job posting by its ID. |
| `POST` | `/api/jobpostings` | Creates a new job posting. |
| `PUT` | `/api/jobpostings/{id}` | Updates an existing job posting. |
| `DELETE` | `/api/jobpostings/{id}` | Soft-deletes a job posting (sets `IsActive` to false). |

## 🛠️ Getting Started

### Prerequisites
*   [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
*   An IDE like Visual Studio 2022, JetBrains Rider, or VS Code

### Running the Project Locally

1.  **Clone the repository:**
    
```bash
    git clone [https://github.com/yourusername/JobBoard.Api.git](https://github.com/yourusername/JobBoard.Api.git)
    cd JobBoard.Api
    ```

2.  **Configure the Database:**
    Update the `DefaultConnection` in `appsettings.json` with your local SQL Server connection string.

3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application:**
    ```bash
    dotnet run
    ```
    The API will be available at `http://localhost:5000` (or the port specified in your logs). Browse to `/swagger` to view the interactive docs.

---

## 🛡 Security Note
This project utilizes **Environment Variables** for sensitive data (Connection Strings, JWT Secrets). Never commit your `appsettings.json` with real passwords to version control.

---

## 👨‍💻 About the Author
**Hong Nhan Lam**  
A self-taught software developer with a background in **Automotive Engineering Technology** from **Ho Chi Minh City University of Technology (HCMUT)**. 

> "I leverage my engineering foundation to build robust, scalable software solutions. Currently specializing in the .NET ecosystem and pursuing an IELTS target of 6.5 to excel in international tech environments".

---

### **Pro-Tip for your GitHub:**
To make this README even better, take a screenshot of your **Tailwind CSS cards** and your **Swagger UI** page. Add them to a folder in your repo named `screenshots`, and thenA professional `README.md` is the "storefront" of your project on GitHub. It’s often the first thing a recruiter sees before they even look at your code. 

For a developer with an Engineering background from **HCMUT**, this file should be clean, logical, and highlight the technical complexity you've mastered.

---

# JobBoard Connect | Full-Stack .NET API

**JobBoard Connect** is a production-ready, cloud-deployed RESTful API designed to manage job listings. This project demonstrates a complete software development lifecycle, from containerization with **Docker** to cloud hosting on **Render** and **Azure SQL**.

## 🚀 Live Demo
*   **Live API (Swagger):** [Your Render URL goes here]
*   **Frontend Interface:** [Your Vercel/Netlify URL goes here]

---

## 🛠 Tech Stack

| Category | Technology |
| :--- | :--- |
| **Backend** | .NET 8, ASP.NET Core |
| **Database** | Azure SQL (Production), MS SQL Server (Local) |
| **ORM** | Entity Framework Core |
| **Security** | JWT Authentication, CORS Policy |
| **DevOps** | Docker, Render Blueprint, GitHub |
| **Frontend** | HTML5, Tailwind CSS, JavaScript (Fetch API) |

---

## ✨ Key Features

*   **Full CRUD Implementation:** Manage job postings (Create, Read, Update, Delete) with a clean service-oriented architecture.
*   **Cloud-Connected:** Fully integrated with an **Azure SQL** database, managed through Entity Framework migrations.
*   **Secure Authentication:** Protected endpoints using **JWT (JSON Web Tokens)** to ensure only authorized users can modify job listings.
*   **Interactive Documentation:** Integrated **Swagger UI** for real-time API testing and documentation.
*   **Responsive UI:** A lightweight frontend that consumes the API to display active jobs in a modern, mobile-friendly card layout.

---

## ⚙️ Local Setup & Installation

### Prerequisites
*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation
1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/JobBoard.git
    cd JobBoard/JobBoard.Api
    ```

2.  **Configure the Database:**
    Update the `DefaultConnection` in `appsettings.json` with your local SQL Server connection string.

3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application:**
    ```bash
    dotnet run
    ```
    The API will be available at `http://localhost:5000` (or the port specified in your logs). Browse to `/swagger` to view the interactive docs.

---

## 🛡 Security Note
This project utilizes **Environment Variables** for sensitive data (Connection Strings, JWT Secrets). Never commit your `appsettings.json` with real passwords to version control.

---

## 👨‍💻 About the Author
**Hong Nhan Lam**  
A self-taught software developer with a background in **Automotive Engineering Technology** from **Ho Chi Minh City University of Technology (HCMUT)**. 

> "I leverage my engineering foundation to build robust, scalable software solutions. Currently specializing in the .NET ecosystem and pursuing an IELTS target of 6.5 to excel in international tech environments".

---

### **Pro-Tip for your GitHub:**
To make this README even better, take a screenshot of your **Tailwind CSS cards** and your **Swagger UI** page. Add them to a folder in your repo named `screenshots`, and then link them in the README using:
`![Dashboard Screenshot](./screenshots/dashboard.png)A professional `README.md` is the "storefront" of your project on GitHub. It’s often the first thing a recruiter sees before they even look at your code. 

For a developer with an Engineering background from **HCMUT**, this file should be clean, logical, and highlight the technical complexity you've mastered.

---

# JobBoard Connect | Full-Stack .NET API

**JobBoard Connect** is a production-ready, cloud-deployed RESTful API designed to manage job listings. This project demonstrates a complete software development lifecycle, from containerization with **Docker** to cloud hosting on **Render** and **Azure SQL**.

## 🚀 Live Demo
*   **Live API (Swagger):** [Your Render URL goes here]
*   **Frontend Interface:** [Your Vercel/Netlify URL goes here]

---

## 🛠 Tech Stack

| Category | Technology |
| :--- | :--- |
| **Backend** | .NET 8, ASP.NET Core |
| **Database** | Azure SQL (Production), MS SQL Server (Local) |
| **ORM** | Entity Framework Core |
| **Security** | JWT Authentication, CORS Policy |
| **DevOps** | Docker, Render Blueprint, GitHub |
| **Frontend** | HTML5, Tailwind CSS, JavaScript (Fetch API) |

---

## ✨ Key Features

*   **Full CRUD Implementation:** Manage job postings (Create, Read, Update, Delete) with a clean service-oriented architecture.
*   **Cloud-Connected:** Fully integrated with an **Azure SQL** database, managed through Entity Framework migrations.
*   **Secure Authentication:** Protected endpoints using **JWT (JSON Web Tokens)** to ensure only authorized users can modify job listings.
*   **Interactive Documentation:** Integrated **Swagger UI** for real-time API testing and documentation.
*   **Responsive UI:** A lightweight frontend that consumes the API to display active jobs in a modern, mobile-friendly card layout.

---

## ⚙️ Local Setup & Installation

### Prerequisites
*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation
1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/JobBoard.git
    cd JobBoard/JobBoard.Api
    ```

2.  **Configure the Database:**
    Update the `DefaultConnection` in `appsettings.json` with your local SQL Server connection string.

3.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application:**
    ```bash
    dotnet run
    ```
    The API will be available at `http://localhost:5000` (or the port specified in your logs). Browse to `/swagger` to view the interactive docs.

---

## 🛡 Security Note
This project utilizes **Environment Variables** for sensitive data (Connection Strings, JWT Secrets). Never commit your `appsettings.json` with real passwords to version control.

---

## 👨‍💻 About the Author
**Hong Nhan Lam**  
A self-taught software developer with a background in **Automotive Engineering Technology** from **Ho Chi Minh City University of Technology (HCMUT)**. 

> "I leverage my engineering foundation to build robust, scalable software solutions. Currently specializing in the .NET ecosystem and pursuing an IELTS target of 6.5 to excel in international tech environments".

---