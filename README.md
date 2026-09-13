# DVLD — Driving & Vehicle License Department Management System

A Windows Forms application for managing the core operations of a Driving & Vehicle License Department (DVLD).

The project is developed incrementally, with the application separated into presentation, business, and data-access responsibilities. Each major feature is implemented, tested, and documented as the system grows.

## Project Status

🚧 **In active development**

### Implemented

- Database design for the main DVLD entities.
- Three-layer application structure.
- People Management.
- Users Management.
- Person CRUD, search, and filtering.
- User CRUD, filtering, validation, and password changes.
- Reusable person-selection controls used across modules.

### Next Modules

The remaining DVLD functionality will be added progressively, including applications, drivers, licenses, tests, and related services.

## Main Features

### People Management

The People module provides:

- Add, edit, view, and delete people.
- Find people by Person ID or National No.
- Filter the people list by multiple fields.
- Reusable controls for displaying and selecting person information.

[People Management documentation](DVlD/People/README.md)

### Users Management

The Users module provides:

- Add, edit, view, and delete user accounts.
- Link each user to an existing person.
- Prevent duplicate user accounts for the same person.
- Validate usernames and passwords.
- Filter users by account and active status.
- Change user passwords.

[Users Management documentation](DVlD/User/README.md)

## Architecture

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
│      SQL Server / ADO.NET     │
└───────────────┬───────────────┘
                │
                ▼
┌───────────────────────────────┐
│          SQL Server           │
│          DVLD Database        │
└───────────────────────────────┘
```

| Layer | Responsibility |
|---|---|
| `DVlD` | WinForms screens, controls, user interaction, filtering, and presentation logic. |
| `DVIDBusinessLayer` | Business objects and application-level operations. |
| `DVIDDataAcessLayer` | SQL Server operations and DTO mapping through ADO.NET. |
| `DataBaseDesgin` | Database SQL script and design/mapping artifacts. |

## Technologies

- **C#**
- **.NET Framework 4.7.2**
- **Windows Forms**
- **SQL Server**
- **ADO.NET**
- **DataTable / DataView**
- **DTOs**
- **DevExpress / Guna UI components**

## Database

The database design contains the main entities required for the DVLD system, including people, users, applications, license classes, tests, drivers, licenses, detained licenses, and international licenses.

- [SQL Database Design](DataBaseDesgin/SQLQuery2.sql)
- [Database Mapping](DataBaseDesgin/dvldMaping.drawio)

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
│   ├── ClsPersonDataAccess.cs
│   └── ClsUserDataAccess.cs
│
├── DVIDBusinessLayer/
│   ├── ClsCountry.cs
│   ├── ClsPerson.cs
│   └── ClsUser.cs
│
├── DVlD/
│   ├── Global Class/
│   ├── People/
│   ├── User/
│   └── FrmMain.cs
│
├── testConsole/
├── DVlD.slnx
└── README.md
```

## Documentation

Documentation focuses on meaningful features rather than individual classes or forms.

- [People Management](DVlD/People/README.md)
- [Users Management](DVlD/User/README.md)
- [Database Design SQL](DataBaseDesgin/SQLQuery2.sql)
- [Database Mapping](DataBaseDesgin/dvldMaping.drawio)

Feature documentation describes the implemented workflow, technical decisions, and current scope without duplicating the source code.

## Development Approach

The system is built feature by feature. For each meaningful feature, the repository documents:

1. What the feature does.
2. How it fits into the application architecture.
3. Important implementation decisions.
4. Current limitations and unfinished parts.

This keeps the README useful as both project documentation and a record of the system's development.

## Repository

[View the project on GitHub](https://github.com/Hossamgholam/Driving-License-Management-System)
