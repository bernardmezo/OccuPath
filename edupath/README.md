# OccuPath 🎓

**OccuPath** is an intelligent Expert System designed to help students discover their ideal career paths. By analyzing personal data, academic performance, and character traits, OccuPath uses **Forward Chaining** and **Certainty Factor** algorithms to provide objective, data-driven career recommendations.

---

## 🚀 Features

-   **Intelligent Career Matching:** Utilizes 18+ inference rules to match students with 7 distinct career profiles (e.g., Programmer, Data Analyst, Network Engineer).
-   **Comprehensive Assessment:**
    -   **Category A (Personal):** Demographic and background analysis.
    -   **Category B (Academic):** GPA, technical skills, and coursework performance.
    -   **Category C (Character):** Psychometric evaluation of traits like logic, leadership, and precision with MBTI-style picker.
-   **Certainty Factor Engine:** Calculates a percentage-based confidence score for each recommendation, handling uncertainty in user inputs.
-   **User Dashboard:** Track assessment history, view top career matches, and analyze detailed result explanations.
-   **Secure Authentication:** Student registration and login system with password hashing.

## 🎨 UI Design

### Form3 - MBTI-Style Character Assessment
-   **Horizontal Scale Picker:** 5 circular buttons (1-5) with color coding
-   **Fixed Scale Labels:**
    -   1: Sangat Tidak Setuju (Red #E74C3C)
    -   2: Tidak Setuju (Orange #E67E22)
    -   3: Netral (Yellow #F1C40F)
    -   4: Setuju (Green #2ECC71)
    -   5: Sangat Setuju (Blue #3498DB)
-   **Hover Effects:** Visual feedback for better UX
-   **Dynamic Questions:** Backend only needs to provide `QuestionText`

### FormResult - Career Results Display
-   **Medal Ranking:** 🥇🥈🥉 for top 3 results
-   **Color-Coded Progress Bars:** Visual CF percentage (Green/Yellow/Orange/Red)
-   **Detailed Career Info:** Description, skills required, matched rules
-   **Clean Card Layout:** Consistent with overall design language

## 🛠️ Tech Stack

-   **Language:** Visual Basic .NET (VB.NET)
-   **Framework:** .NET 8.0
-   **UI:** Windows Forms (WinForms)
-   **Database:** MySQL 8.0
-   **MySQL Connector:** MySql.Data 8.4.0 (LTS version for stability)
-   **Architecture:** Layered Architecture (UI, Business Logic, Data Access)

## 📋 Prerequisites

Before you begin, ensure you have the following installed:
-   **Visual Studio 2022** (with .NET Desktop Development workload)
-   **MySQL Server** 8.0 or higher (or XAMPP/WAMP with MySQL)
-   **MySQL Connector/NET** (will be installed via NuGet)

## ⚙️ Installation & Setup

### **1. Clone the Repository**
```bash
git clone https://github.com/bernardmezo/OccuPath.git
cd OccuPath
```

### **2. Database Setup**

#### **Option A: Using Database_Setup_MVP1.sql (Full Schema)**
```bash
# Via Command Line (PowerShell)
Get-Content Database_Setup_MVP1.sql | C:\xampp\mysql\bin\mysql.exe -uroot

# Or via phpMyAdmin
# 1. Open http://localhost/phpmyadmin
# 2. Click "Import" tab
# 3. Browse to Database_Setup_MVP1.sql
# 4. Click "Go"
```

#### **Option B: Using Database_Setup_Minimal.sql (Testing Only)**
```bash
# For UI testing without full backend
Get-Content Database_Setup_Minimal.sql | C:\xampp\mysql\bin\mysql.exe -uroot db_occupath
```

### **3. Configure Database Connection**
Open `edupath/Data/DatabaseConnection.vb` and update if needed:
```vb
Private Const DB_SERVER As String = "localhost"
Private Const DB_NAME As String = "db_occupath"
Private Const DB_USER As String = "root"
Private Const DB_PASS As String = "" ' Enter your password if set
```

### **4. Install Dependencies**
```bash
cd edupath
dotnet restore
# Or let Visual Studio restore packages automatically
```

### **5. Build and Run**
-   Open `OccuPath.sln` in Visual Studio 2022
-   Press **F5** to build and start the application
-   On first run, connection test will run automatically

## 🔑 Test Credentials

After running Database_Setup_MVP1.sql:

| Username | Password | Role |
|----------|----------|------|
| admin | admin123 | Administrator |
| student1 | student123 | Student |

**Or register a new account** via the application!

## 📖 Usage

1.  **Start Application:** Launch OccuPath, connection test runs automatically
2.  **Register/Login:** Create a new student account or use test credentials
3.  **Start Assessment:** From the Dashboard, click "Mulai Tes" to begin
4.  **Complete Surveys:** 
    - Category A (Personal Data): 5 questions
    - Category B (Academic): 4 questions
    - Category C (Character): 21 questions with MBTI-style picker
5.  **View Results:** System displays your Top 3 Career Matches with:
    - CF Percentage (confidence score)
    - Skills required
    - Matched inference rules
    - Visual ranking (🥇🥈🥉)
6.  **Dashboard:** Track assessment history and previous results

## 📂 Project Structure

```
OccuPath/
├── edupath/                        # Main Application Source
│   ├── Core/                       # Constants & Session Management
│   ├── Data/                       # Database Repositories (DAL)
│   │   └── DatabaseConnection.vb  # MySQL connection & auth functions
│   ├── Models/                     # Data Models (User, Question, etc.)
│   ├── Services/                   # Business Logic (Inference, Auth)
│   │   └── InferenceService.vb    # Forward Chaining & CF Engine
│   ├── Forms/                      # Windows Forms (UI)
│   │   ├── Form1.vb               # Landing Page
│   │   ├── Form3.vb               # MBTI-Style Picker
│   │   ├── Form4.vb               # Login/Register
│   │   ├── Form5.vb               # Main Dashboard
│   │   ├── FormResult.vb          # Results Display
│   │   ├── FormKategoriA.vb       # Personal Data Survey
│   │   └── FormKategoriB.vb       # Academic Survey
│   └── OccuPath.vbproj            # Project File
├── Database_Setup_MVP1.sql        # Full Database Schema & Seed Data
├── Database_Setup_Minimal.sql     # Minimal Schema for Testing
└── README.md                      # Documentation
```

## 🐛 Troubleshooting

### **Database Connection Failed**
1. Ensure MySQL service is running (XAMPP Control Panel)
2. Check port 3306 is not used by other applications
3. Verify database `db_occupath` exists
4. Run FormTestDB (included) for detailed diagnostics

### **MySQL Connector Issues**
```bash
# Downgrade to stable version if needed
dotnet remove package MySql.Data
dotnet add package MySql.Data --version 8.4.0
```

### **Build Errors**
- Clean solution: `Build > Clean Solution`
- Rebuild: `Build > Rebuild Solution`
- Restore NuGet packages: `Tools > NuGet Package Manager > Restore`

## 🔧 Development Notes

### **Password Handling**
- New registrations use SHA256 hashing
- Login supports both hashed and plain text (backward compatibility with MVP1 seed data)
- Production: Remove plain text password support

### **Database Compatibility**
- Code supports both `id` and `id_user` column names
- Works with both `password` and `password_hash` columns
- Automatic schema detection for flexibility

### **UI Testing**
- Use `Database_Setup_Minimal.sql` for quick UI testing
- Includes sample questions and career profiles
- No complex backend logic needed for UI development

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is developed for educational purposes at **Politeknik Negeri Jakarta**.

---

## 🙏 Acknowledgments

- Forward Chaining & Certainty Factor implementation
- MBTI-style assessment design
- Career profiling based on academic & character analysis

**Developed by:** Politeknik Negeri Jakarta Students  
**Course:** Expert Systems / Artificial Intelligence  
**Year:** 2024