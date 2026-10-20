# Employee Management System (EMS)

A Windows desktop application for managing employee-related information and HR workflows. This project is built with C#, Windows Forms, and Microsoft SQL Server, using a three-layer architecture to separate the user interface, business logic, and data access.

> **Project status:** In development. Features, setup instructions, and database configuration may change as the project is improved.

## Overview

EMS is designed to bring several employee-management workflows together in one desktop application. The current codebase includes modules for:

- **People and employees** — view, search, create, and update person and employee records.
- **User management** — manage application users and account-related information.
- **Departments and job levels** — maintain organizational information used by employee records.
- **Attendance** — record and review attendance information.
- **Interviews and appointments** — manage interview records and related appointments.
- **Salary records** — record salary payments and view salary logs.
- **Employee adjustments** — manage adjustment records associated with employees.
- **Reference data** — manage supporting data such as countries and statuses.

The availability and completeness of individual workflows should be verified in the current application build.

## Technology Stack

- **Language:** C#
- **Framework:** .NET Framework 4.8
- **Desktop UI:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server
- **Data access:** ADO.NET
- **Database operations:** SQL commands and stored-procedure calls
- **IDE:** Visual Studio

## Architecture

The solution is organized into three main projects:

```text
EMS/
├── EMS.sln
├── EMS-Presentation-Layer/
│   ├── Forms and user controls
│   └── Application entry point and UI logic
├── EMS-Business-Layer/
│   └── Business entities and application rules
└── EMS-DataAccses-Layer/
    └── SQL Server data-access operations
```

### Presentation Layer

Contains Windows Forms screens and user controls. It is responsible for displaying information and handling user interactions.

### Business Layer

Contains business classes that coordinate application operations and communicate with the data-access layer.

### Data Access Layer

Contains database-access classes built with ADO.NET. It executes database commands and stored-procedure calls.

This separation makes responsibilities easier to understand and provides a foundation for maintaining and extending the application.


### Prerequisites

Before running the application, you will need:

- Windows.
- Visual Studio with .NET desktop development support.
- The .NET Framework 4.8 targeting pack/runtime as appropriate for your development environment.
- A Microsoft SQL Server instance.
- The database schema, stored procedures, and configuration required by the application.


## Disclaimer

EMS is a portfolio and learning project udenr active development. It is provided for demonstration and educational purposes. Its completeness, security, and suitability for real-world use have not yet been fully verified.
