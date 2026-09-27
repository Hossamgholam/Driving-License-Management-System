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
- Application Types Management.
- Test Types Management.
- Application Core foundation.
- User login, active-account checking, sign-out, and current-user access.
- Person CRUD, search, and filtering.
- User CRUD, filtering, validation, and password changes.
- Application Type listing, editing, validation, and refresh workflow.
- Test Type listing, editing, validation, and refresh workflow.
- Application creation, lookup, update, deletion, active-application checks, and application status foundation.
- Reusable person-selection controls used across modules.

### Next Modules

The remaining DVLD functionality will be added progressively, including application registration UI, drivers, licenses, tests, and related services.

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

### Application Types Management

The Application Types module provides:

- Display all predefined application types.
- Show application type ID, title, and fees.
- Open an existing application type for editing.
- Validate title and fees before saving.
- Update application type data through the business and data-access layers.
- Refresh the management list after an update.

[Application Types documentation](DVlD/App/ApplicationType/README.md)

### Test Types Management

The Test Types module provides:

- Display the predefined test types.
- Show test type ID, title, description, and fees.
- Open an existing test type for editing.
- Validate title, description, and fees before saving.
- Update test type data through the business and data-access layers.
- Refresh the management list after an update.

[Test Types documentation](DVlD/Tests/TestType/README.md)

### Application Core

The Application Core provides the backend foundation for applications created in the DVLD system.

It currently supports:

- Creating applications.
- Finding applications by ID.
- Loading all applications.
- Updating and deleting applications.
- Checking for existing and active applications.
- Managing application status and status dates at the data-access level.
- Mapping application database records through ApplicationDTO.

[Application Core documentation](DVIDBusinessLayer/Application/README.md)

### Authentication

The current login flow provides:

- Login using username and password.
- Remember-me functionality.
- Active-account validation before entering the main application.
- A global current-user reference used by the main form.
- Sign-out and return to the login screen.
- Access to the current user's information and password-change workflow.

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
│   ├── ClsApplicationDataAccess.cs
│   ├── ClsApplicationTypesDataAccess.cs
│   ├── ClsCountryDataAccess.cs
│   ├── ClsPersonDataAccess.cs
│   ├── ClsTestTypesDataAccess.cs
│   └── ClsUserDataAccess.cs
│
├── DVIDBusinessLayer/
│   ├── Application/
│   ├── ClsApplication.cs
│   ├── ClsApplicationTypes.cs
│   ├── ClsCountry.cs
│   ├── ClsPerson.cs
│   ├── ClsTestTypes.cs
│   └── ClsUser.cs
│
├── DVlD/
│   ├── App/
│   │   └── ApplicationType/
│   ├── Global Class/
│   ├── Login/
│   ├── People/
│   ├── Tests/
│   │   └── TestType/
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
- [Application Types Management](DVlD/App/ApplicationType/README.md)
- [Test Types Management](DVlD/Tests/TestType/README.md)
- [Application Core](DVIDBusinessLayer/Application/README.md)
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
