# People Management

The **People Management** module provides the foundation for person-related operations in the DVLD application. It handles creating, editing, finding, viewing, filtering, and deleting people while exposing reusable person-selection components for other modules.

## Features

- View people in a `DataGridView`.
- Add, edit, view, and delete people.
- Find people by `PersonID` or `NationalNo`.
- Filter the people list by ID, name, nationality, gender, phone, and email.
- Validate required fields and National No uniqueness.
- Reuse person information through custom WinForms `UserControl`s.

## Forms & Controls

| Component | Responsibility |
|---|---|
| `FrmMangePeople` | Displays the people list, filtering, record actions, and CRUD commands. |
| `FrmAddEditPeople` | Adds a new person or edits an existing person. |
| `FrmFindPerson` | Searches for a person by supported identifiers. |
| `FrmShowPersonInfo` | Displays the details of a selected person. |
| `CtrlPersonCard` | Displays person information as a reusable control. |
| `CtrlPersonCardWithFilter` | Combines person information with a reusable search/selection workflow. |

## Data Flow

```text
WinForms UI
    │
    ▼
ClsPerson
Business Layer
    │
    ▼
ClsPersonDataAccess
Data Access Layer
    │
    ▼
SQL Server
```

`PersonDTO` is used to transfer person data between the data-access and business layers. The data-access layer handles SQL Server operations through ADO.NET using classes such as `SqlConnection`, `SqlCommand`, and `SqlDataReader`.

## CRUD & Validation

The same business object supports both Add and Update operations through an internal mode. After database changes, the management form reloads the data so the grid reflects the current database state.

During editing, National No validation excludes the current `PersonID`. This allows a person to keep their existing National No while still preventing duplicates.

The people list is loaded into a `DataTable`, while `DataView.RowFilter` is used for client-side filtering. The grid displays the fields required by the management screen rather than every value returned by the database query.

## Reusable Person Selection

Person selection is needed by multiple DVLD workflows. `CtrlPersonCardWithFilter` provides a shared way to search for and select an existing person instead of rebuilding the same UI in each module.

This became the integration point between **People Management** and later modules such as **Users Management**.

## Current Scope

The core People Management workflow is implemented. Email and phone actions shown in the UI remain under development.

## Related Files

- [`FrmMangePeople.cs`](FrmMangePeople.cs)
- [`FrmAddEditPeople.cs`](FrmAddEditPeople.cs)
- [`FrmFindPerson.cs`](FrmFindPerson.cs)
- [`FrmShowPersonInfo.cs`](FrmShowPersonInfo.cs)
- [`Controls/CtrlPersonCard.cs`](Controls/CtrlPersonCard.cs)
- [`Controls/CtrlPersonCardWithFilter.cs`](Controls/CtrlPersonCardWithFilter.cs)
- [`../../DVIDBusinessLayer/ClsPerson.cs`](../../DVIDBusinessLayer/ClsPerson.cs)
- [`../../DVIDDataAcessLayer/ClsPersonDataAccess.cs`](../../DVIDDataAcessLayer/ClsPersonDataAccess.cs)
- [`../../DVIDDataAcessLayer/DTOs/PersonDTO.cs`](../../DVIDDataAcessLayer/DTOs/PersonDTO.cs)
