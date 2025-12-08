# OccuPath 🎓

**OccuPath** is an intelligent Expert System designed to help students discover their ideal career paths. By analyzing personal data, academic performance, and character traits, OccuPath uses **Forward Chaining** and **Certainty Factor** algorithms to provide objective, data-driven career recommendations.

---

## 🚀 Features

-   **Intelligent Career Matching:** Utilizes 18+ inference rules to match students with 7 distinct career profiles (e.g., Programmer, Data Analyst, Network Engineer).
-   **Comprehensive Assessment:**
    -   **Category A (Personal):** Demographic and background analysis.
    -   **Category B (Academic):** GPA, technical skills, and coursework performance.
    -   **Category C (Character):** Psychometric evaluation of traits like logic, leadership, and precision.
-   **Certainty Factor Engine:** Calculates a percentage-based confidence score for each recommendation, handling uncertainty in user inputs.
-   **User Dashboard:** Track assessment history, view top career matches, and analyze detailed result explanations.
-   **Secure Authentication:** Student registration and login system.

## 🛠️ Tech Stack

-   **Language:** Visual Basic .NET (VB.NET)
-   **Framework:** .NET 8.0 / .NET Framework
-   **UI:** Windows Forms (WinForms)
-   **Database:** MySQL 8.0
-   **Architecture:** Layered Architecture (UI, Business Logic, Data Access)

## 📋 Prerequisites

Before you begin, ensure you have the following installed:
-   **Visual Studio 2022** (with .NET Desktop Development workload)
-   **MySQL Server** (or XAMPP/WAMP)
-   **MySQL Connector/NET**

## ⚙️ Installation & Setup

1.  **Clone the Repository**
    ```bash
    git clone https://github.com/bernardmezo/OccuPath.git
    cd OccuPath
    ```

2.  **Database Setup**
    -   Open your MySQL client (phpMyAdmin, Workbench, or CLI).
    -   Create a new database named `db_occupath`.
    -   Import the schema and seed data located in the root directory:
        ```sql
        source Database_Setup_MVP1.sql
        ```

3.  **Configure Connection**
    -   Open `edupath/DatabaseConnection.vb`.
    -   Update the connection string constants if your MySQL credentials differ:
        ```vb
        Private Const DB_SERVER As String = "localhost"
        Private Const DB_NAME As String = "db_occupath"
        Private Const DB_USER As String = "root"
        Private Const DB_PASS As String = "" ' Enter your password if set
        ```

4.  **Build and Run**
    -   Open `occupath.sln` in Visual Studio 2022.
    -   Restore NuGet packages (if prompted).
    -   Press **F5** to build and start the application.

## 📖 Usage

1.  **Register/Login:** Create a new student account via the Login form.
2.  **Start Assessment:** From the Dashboard, click "Mulai Tes" to begin.
3.  **Complete Surveys:** Fill out all questions in Categories A (Data Diri), B (Akademis), and C (Karakter).
4.  **View Results:** Upon completion, the system displays your Top 3 Career Matches with confidence scores.
5.  **Analyze:** Review the matched rules and skills required for your recommended path.

## 📂 Project Structure

```
OccuPath/
├── edupath/                 # Main Application Source
│   ├── Core/                # Constants & Session Management
│   ├── Data/                # Database Repositories (DAL)
│   ├── Models/              # Data Models (User, Question, etc.)
│   ├── Services/            # Business Logic (Inference, Auth)
│   ├── Forms/               # Windows Forms (UI)
│   └── ...
├── Database_Setup_MVP1.sql  # Database Schema & Seed Data
└── README.md                # Documentation
```

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a Pull Request.

## 📄 License

This project is developed for educational purposes at **Politeknik Negeri Jakarta**.