# DVLD — Driving & Vehicle License Department Management System

A Windows Forms application for managing the core operations of a Driving & Vehicle License Department (DVLD).

The project is being developed incrementally, with the application separated into presentation, business, and data-access responsibilities. The repository documents the implementation as the project grows.

## Project Status

🚧 **In active development**

### Completed / implemented

- Database design for the main DVLD entities.
- Three-layer project structure:
  - Presentation / Windows Forms
  - Business Layer
  - Data Access Layer
- People Management module.
- Person CRUD operations and search/filtering.
- Reusable person information controls.

### Planned / under development

The remaining DVLD modules will be added progressively, including users, applications, drivers, licenses, tests, and related services.

## Main Features

### People Management

The People module currently provides:

- View people in a tabular interface.
- Filter people by Person ID, National No, name, nationality, gender, phone, and email.
- Add a new person.
- Edit an existing person.
- Delete a person when database relationships allow it.
- View detailed person information.
- Find a person by Person ID or National No.
- Reusable person-card controls for displaying and selecting person information.

See the detailed documentation in [`DVlD/People/README.md`](DVlD/People/README.md).

## Architecture

The application is organized around three main layers:

```text
┌───────────────────────────────┐
│       DVlD / WinForms UI      │
│       Presentation Layer      │
└───────────────┬───────────────┘
                │
                ▼
┌───────────────────────────────┐
│      DVIDBusinessLayer        │
│       Business Logic          │
└───────────────┬───────────────┘
                │
                ▼
┌───────────────────────────────┐
│      DVIDDataAcessLayer       │
│ SQL Server / ADO.NET Access   │
└───────────────┬───────────────┘
                │
                ▼
┌───────────────────────────────┐
│          SQL Server           │
│          DVLD Database        │
└───────────────────────────────┘
```

### Layer responsibilities

| Layer | Responsibility |
|---|---|
| `DVlD` | Windows Forms screens, controls, user interaction, filtering, and presentation logic. |
| `DVIDBusinessLayer` | Represents business objects and coordinates operations between the UI and data-access layer. |
| `DVIDDataAcessLayer` | Executes SQL Server operations and maps database data to DTOs. |
| `DataBaseDesgin` | Contains the database SQL script and database mapping/design artifacts. |

## Technologies

- **C#**
- **.NET Framework 4.7.2**
- **Windows Forms**
- **SQL Server**
- **ADO.NET**
- **DataTable / DataView** for tabular data and filtering
- **DTOs** for transferring person data between layers
- **DevExpress / Guna UI components** currently referenced by the WinForms project

## Database

The database design contains the main entities required for the DVLD system, including:

- Countries
- People
- Users
- Application Types
- License Classes
- Applications
- Local Driving License Applications
- Test Types
- Test Appointments
- Tests
- Drivers
- Licenses
- Detained Licenses
- International Licenses

The SQL design is available in [`DataBaseDesgin/SQLQuery2.sql`](DataBaseDesgin/SQLQuery2.sql), while the visual mapping is available in [`DataBaseDesgin/dvldMaping.drawio`](DataBaseDesgin/dvldMaping.drawio).

## Repository Structure

```text
Driving-License-Management-System/
│
├── DataBaseDesgin/
│   ├── SQLQuery2.sql
│   └── dvldMaping.drawio
│
├── DVIDDataAcessLayer/
│   ├── DTOs/
│   ├── HelperMethod/
│   ├── ClsDataAccessSetting.cs
│   ├── ClsCountryDataAccess.cs
│   └── ClsPersonDataAccess.cs
│
├── DVIDBusinessLayer/
│   ├── ClsCountry.cs
│   └── ClsPerson.cs
│
├── DVlD/
│   ├── Global Class/
│   ├── People/
│   │   ├── Controls/
│   │   ├── FrmAddEditPeople.cs
│   │   ├── FrmFindPerson.cs
│   │   ├── FrmMangePeople.cs
│   │   └── FrmShowPersonInfo.cs
│   └── FrmMain.cs
│
├── testConsole/
├── DVlD.slnx
└── README.md
```

## Documentation

Detailed documentation will be added for meaningful architectural layers and business features as they are completed.

- [People Management](DVlD/People/README.md)
- [Database Design SQL](DataBaseDesgin/SQLQuery2.sql)
- [Database Mapping](DataBaseDesgin/dvldMaping.drawio)

Additional layer documentation will be added when the corresponding implementation reaches a meaningful milestone.

## Development Approach

The project is developed feature by feature rather than documenting every individual class or form.

For each meaningful feature, the documentation focuses on:

1. What the feature does.
2. How the feature is structured.
3. How data moves through the layers.
4. Important implementation decisions.
5. Problems encountered and how they were solved.
6. What was learned from the implementation.

This keeps the repository useful both as a project portfolio and as a record of the development process.

## Learning Focus

This project is being used to practice building a multi-layer Windows Forms application with a real relational database. Particular focus areas include:

- Layer separation.
- SQL Server and ADO.NET.
- DTO-based data transfer.
- CRUD operations.
- Data validation and existence checks.
- DataTable and DataView filtering.
- Reusable WinForms UserControls.
- Connecting UI actions to business and data-access operations.
- Designing a larger application incrementally.

## Repository

[View the project on GitHub](https://github.com/Hossamgholam/Driving-License-Management-System)
