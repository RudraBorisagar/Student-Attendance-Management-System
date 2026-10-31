# 📚 Student Attendance Management System

An **ASP.NET Web Forms** application for managing student attendance in educational institutions. Built with **C#**, **.NET Framework 4.7.2**, and **SQL Server LocalDB**.

---

## 🎯 Features

- **Admin Panel** — Add teachers, add students, view attendance reports
- **Teacher Panel** — Mark attendance (Present/Absent), view attendance, add students
- **Student Panel** — View own attendance records and total lectures
- **Role-based Login** — Separate dashboards for Admin, Teacher, and Student
- **Automatic Lecture Tracking** — Total lectures auto-increment when attendance is marked

---

## 🏗️ Project Structure

```
Attendance_management_System/
├── Attendance_management_System.sln        # Visual Studio Solution
├── .gitignore
├── README.md
└── Attendance_management_System/           # Main Web Project
    ├── Attendance_management_System.csproj
    ├── Web.config                          # Configuration & DB connection
    ├── packages.config
    ├── Properties/
    │   └── AssemblyInfo.cs
    ├── App_Data/
    │   ├── login.mdf                       # SQL Server LocalDB database
    │   └── login_log.ldf
    ├── login/
    │   ├── login.aspx                      # Login page
    │   ├── login.aspx.cs
    │   ├── login.aspx.designer.cs
    │   └── images/background2.jpg
    ├── Admin/
    │   ├── admin.aspx                      # Admin dashboard
    │   ├── admin.aspx.cs
    │   ├── admin.aspx.designer.cs
    │   ├── Add teacher.aspx                # Add teacher page
    │   ├── Add teacher.aspx.cs
    │   ├── Add teacher.aspx.designer.cs
    │   └── background2.jpg
    ├── teacher/
    │   ├── teacher.aspx                    # Teacher dashboard
    │   ├── teacher.aspx.cs
    │   ├── teacher.aspx.designer.cs
    │   ├── Update attendance.aspx          # Mark attendance page
    │   ├── Update attendance.aspx.cs
    │   ├── Update attendance.aspx.designer.cs
    │   └── background2.jpg
    ├── student/
    │   ├── student.aspx                    # Student dashboard
    │   ├── student.aspx.cs
    │   ├── student.aspx.designer.cs
    │   ├── view attendance student.aspx    # View own attendance
    │   ├── view attendance student.aspx.cs
    │   ├── view attendance student.aspx.designer.cs
    │   └── background2.jpg
    └── common page/
        ├── Add student.aspx                # Add student page
        ├── Add student.aspx.cs
        ├── Add student.aspx.designer.cs
        ├── view attendance.aspx            # View all attendance
        ├── view attendance.aspx.cs
        ├── view attendance.aspx.designer.cs
        └── background2.jpg
```

---

## 🗄️ Database Schema

The project uses **SQL Server LocalDB** with the following tables:

| Table | Columns | Description |
|-------|---------|-------------|
| `student` | `username`, `password` | Student login credentials |
| `teacher` | `username`, `password` | Teacher login credentials |
| `student_Attendance` | `Name`, `Attendance` | Attendance count per student |
| `total_lecture` | `lecture` | Total lectures conducted |

---

## 🚀 How to Run

### Prerequisites
- **Visual Studio 2022** (or 2019) with ASP.NET workload
- **SQL Server LocalDB** (included with Visual Studio)
- **.NET Framework 4.7.2**

### Steps
1. Clone this repository:
   ```bash
   git clone https://github.com/RudraBorisagar/Student-Attendance-Management-System.git
   ```
2. Open `Attendance_management_System.sln` in Visual Studio
3. Restore NuGet packages (right-click solution → Restore NuGet Packages)
4. Press **F5** to build and run
5. Navigate to `/login/login.aspx`

### Default Login
| Role | Username | Password |
|------|----------|----------|
| Admin | `admin` | `12345` |

> Teachers and Students are added through the Admin and Teacher panels respectively.

---

## 🔧 Technology Stack

- **Frontend:** ASP.NET Web Forms, HTML, CSS
- **Backend:** C# (.NET Framework 4.7.2)
- **Database:** SQL Server LocalDB (`.mdf`)
- **Server:** IIS Express
- **IDE:** Visual Studio 2022

---

## 📄 License

This project is created for educational purposes as a diploma final year project.
