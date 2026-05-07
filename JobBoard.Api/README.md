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

2.  **Database Configuration:**
    By default, the application runs using an **In-Memory database** for easy testing. If you wish to use SQL Server, update the connection string in `appsettings.json` (Ensure you use `User ID` instead of `username`) and update your `Program.cs` to use `UseSqlServer()`.

3.  **Run the application:**
    ```bash
    dotnet run
    ```

4.  **Test the API (Swagger):**
    Once the application is running, open your browser and navigate to the Swagger UI to test the endpoints interactively:
    `https://localhost:<port>/swagger`

## 📁 Project Structure

*   `Controllers/` - Contains the HTTP API endpoints (`JobPostingsController`).
*   `Models/` - Contains the core database entities (`JobPosting`).
*   `DTOs/` - Contains the Request and Response data transfer objects.
*   `Services/` - Contains the core business logic (`JobPostingService`).
*   `Interfaces/` - Contains the contracts for Dependency Injection (`IJobPostingService`).
*   `Data/` - Contains the Entity Framework DbContext (`JobBoardDbContext`).