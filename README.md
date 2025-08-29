# AED

# 📈 Portfolio & Tax Analytics Platform

![Status: In Development](https://img.shields.io/badge/status-in%20development-yellow.svg)
![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet.svg)
![Architecture: Clean | DDD](https://img.shields.io/badge/Architecture-Clean%20%7C%20DDD-green.svg)

> ⚠️ **Warning:** This project is under active development. Some features may be incomplete or undergoing refactoring.

A high-performance web application for aggregating and analyzing investment portfolios. The system is designed to automatically collect data from various stock and cryptocurrency exchanges, providing users with comprehensive analytics on their assets, including P/L, ROI, and tools for tax calculation.

## 📜 About The Project

The modern investor often uses multiple brokerage accounts and crypto exchanges, making it difficult to track the overall portfolio performance. This project was created to solve this problem by providing a unified platform to:

*   **Automate Data Aggregation:** Connect to exchange APIs (Bybit, Questrade, etc.) to fetch transaction histories.
*   **Provide Comprehensive Analytics:** Calculate key performance metrics for the entire portfolio.
*   **Securely Store Data:** Protect sensitive information, such as API keys, using modern encryption methods.
*   **Be Extensible:** Easily add support for new exchanges without altering the core business logic.

## ✨ Key Features

*   **Multi-Exchange Support:** Aggregate data from multiple accounts into a single view.
*   **Portfolio Analytics:** Track total value, profit/loss (P/L), and return on investment (ROI).
*   **Secure Management:** JWT-based authentication and robust encryption for user API keys.
*   **Background Synchronization:** Asynchronous data collection via a .NET Worker Service that doesn't impact API performance.
*   **Interactive API:** API documentation is automatically generated using Swagger (OpenAPI).

## 🛠️ Tech Stack

| Category                 | Technology                                                              |
| ------------------------ | ----------------------------------------------------------------------- |
| **Backend**              | .NET 8, ASP.NET Core Web API                                            |
| **Frontend**             | Blazor WebAssembly                                                      |
| **Database**             | PostgreSQL                                                              |
| **ORM**                  | Entity Framework Core                                                   |
| **Architecture & Patterns** | Clean Architecture, Domain-Driven Design (DDD), Repository, Unit of Work, Strategy |
| **Security**             | JWT, ASP.NET Core Identity, ASP.NET Core Data Protection API              |
| **Background Jobs**      | .NET Worker Service                                                     |

## 🏛️ Architectural Overview & Key Decisions

The system is built upon the principles of **Clean Architecture** and **Domain-Driven Design (DDD)**, ensuring loose coupling, high testability, and scalability.

### 1. Fault-Tolerant Financial Data Model

*   **Problem:** A "flat" transaction model was unable to correctly represent complex operations, such as a trade with a fee paid in a different currency or an atomic transfer between accounts.
*   **Solution:** A **double-entry bookkeeping** style model was implemented using `Operation` and `TransactionLeg` entities. An `Operation` represents an atomic financial event (e.g., a trade, a dividend), while a `TransactionLeg` represents the movement of a single asset within that event. This guarantees data integrity and allows for the precise modeling of any financial activity.

### 2. Security by Design: End-to-End API Key Encryption

*   **Problem:** Sensitive user API keys needed to be stored securely and used by both the main API and the background data collection service.
*   **Solution:** Keys are encrypted before being saved to the database using the **ASP.NET Core Data Protection API (`IDataProtectionProvider`)**. A shared key store was configured, allowing the API server and the background Worker Service to safely decrypt and use the API keys without ever storing them in plain text.

### 3. Modular and Extensible Integration System

*   **Problem:** How to add support for new exchanges without complicating or rewriting the core code of the background service?
*   **Solution:** The **Strategy design pattern** was applied. An `IExchangeApiClient` interface was created, with a separate connector class for each exchange (Bybit, Questrade). The Worker Service operates only on this abstraction, receiving the correct implementation via Dependency Injection. This makes the system fully modular and easy to extend.

## 🚀 Getting Started

### Prerequisites

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [PostgreSQL](https://www.postgresql.org/download/)
*   (Optional) [Docker](https://www.docker.com/products/docker-desktop/)

### Installation & Execution

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/AEA-main.git
    cd AEA-main
    ```

2.  **Configure secrets:**
    In the `Presentation.Api` project, locate or create the `appsettings.Development.json` file and configure the following settings:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=YourDbName;Username=YourUser;Password=YourPassword;"
      },
      "JWT": {
        "Issuer": "your-issuer",
        "Audience": "your-audience",
        "Secret": "your_super_secret_key_that_is_long_enough"
      }
    }
    ```

3.  **Apply database migrations:**
    Ensure your PostgreSQL server is running. From the root directory of the repository, run the following command:
    ```bash
    dotnet ef database update --project Infrastructure.Persistence --startup-project Presentation.Api
    ```

4.  **Run the Backend (API):**
    ```bash
    cd Presentation.Api
    dotnet run
    ```
    The API will be available at `https://localhost:7080` and `http://localhost:5261`.

5.  **Run the Frontend (Blazor):**
    > 🚧 **Undergoing scheduled maintenance!** 🚧
    > 
    > The Blazor frontend is currently under active development. To run it, open a new terminal and execute:
    ```bash
    cd Presentation.Web
    dotnet run
    ```
    The web application will be available at `https://localhost:7184`.

## 📸 Screenshots

*(UI screenshots will be added here once the design gnomes have finished their work.)*

But we have prototypes!
<img width="1562" height="825" alt="image" src="https://github.com/user-attachments/assets/f2770f2b-12f5-4984-ac8f-2340c5110653" />
<img width="1741" height="841" alt="image" src="https://github.com/user-attachments/assets/f99a86c5-e016-4c6f-be89-0e8b1fbe0451" />
<img width="1746" height="831" alt="image" src="https://github.com/user-attachments/assets/b9103054-2674-4031-9f1c-ec144c41a2b2" />
<img width="1766" height="850" alt="image" src="https://github.com/user-attachments/assets/859896f3-489a-40d1-808e-699ad10cc3d2" />
<img width="1451" height="850" alt="image" src="https://github.com/user-attachments/assets/22afeef2-a8b3-434b-8c85-be642b76cd70" />
<img width="398" height="735" alt="image" src="https://github.com/user-attachments/assets/deb864a7-303e-483c-9cb0-4ca9f13d9742" />

## 📚 API Documentation

Once the API project is running, interactive Swagger documentation is available at:
[`https://localhost:7080/swagger`](https://localhost:7080/swagger)

## 🗺️ Roadmap

- [ ] **Frontend:** Complete the basic UI on Blazor to display portfolios and analytics.
- [ ] **Integrations:** Add support for new exchanges (e.g., Binance, Kraken).
- [ ] **Analytics:** Implement data visualization with charts and graphs.
- [ ] **Reporting:** Automate the generation of tax reports in PDF format.
- [ ] **DevOps:** Create a full Docker Compose setup for one-click deployment.

## 📄 License

This project is distributed under the MIT License. See the `LICENSE` file for more information.
