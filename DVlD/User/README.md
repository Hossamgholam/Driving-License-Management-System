# Users Management

The **Users Management** module handles application user accounts and connects each account to an existing person from the People module.

It builds on the person-selection workflow already established in the project and adds account-specific rules such as username uniqueness, active status, validation, and password changes.

## Features

- View users in a `DataGridView`.
- Add, edit, view, and delete users.
- Change a user's password.
- Filter by `UserID`, `PersonID`, full name, username, and active status.
- Prevent multiple user accounts from being assigned to the same person.
- Validate user input before saving.
- Refresh the management list after database changes.

## Forms

| Form | Responsibility |
|---|---|
| `FrmMangeUser` | Displays users, filtering, record count, and management actions. |
| `FrmAddEditeUser` | Adds a new user or edits an existing user. |
| `FrmShowUserInfo` | Displays information about a selected user. |
| `FrmChangePassword` | Validates and changes a user's password. |

## User Account Model

A user account contains:

- `UserID`
- `PersonID`
- `UserName`
- `Password`
- `IsActive`

The management query also joins `Users` with `Person` so the grid can display the user's full name.

## Add & Edit Workflow

Creating a user starts by selecting an existing person through the reusable `CtrlPersonCardWithFilter` control. The form then collects the account information.

Before saving, the module verifies that:

- A person has been selected.
- The person does not already have a user account.
- The username is valid and unique.
- The password and confirmation match.

`ClsUser` uses an Add/Update mode so the same business object can handle both inserting and updating a user.

When editing, the existing username is allowed to remain unchanged. A uniqueness check is only required when the username is changed.

## Validation

The WinForms forms use `Validating`, `ErrorProvider`, and `ValidateChildren()` to keep invalid data from reaching the save operation.

The validation rules cover required usernames and passwords, password confirmation, username uniqueness, and the relationship between a user account and its person.

## Filtering

`FrmMangeUser` loads the users into a `DataTable` and filters the existing data through `DefaultView.RowFilter`.

The active-state filter uses Boolean expressions such as:

```csharp
IsActive = true
```

or

```csharp
IsActive = false
```

ID fields are validated as numeric input, while full-name filtering uses a `LIKE` expression. The record count is updated after filtering and after CRUD operations.

## Password Change

`FrmChangePassword` follows a separate validation flow:

1. Load the selected user.
2. Verify the current password.
3. Validate the new password.
4. Confirm the new password matches.
5. Update the business object and save the change.

This keeps password changes separate from the general user editing workflow.

## Data Flow

```text
WinForms UI
    │
    ▼
ClsUser
Business Layer
    │
    ▼
ClsUserDataAccess
Data Access Layer
    │
    ▼
SQL Server
```

`ClsUser` coordinates user operations while `ClsUserDataAccess` performs the database work through ADO.NET. `UserDTO` is used to transfer user data between the data-access and business layers.

## Implementation Notes

### Reuse instead of duplication

A user is linked to an existing person rather than storing the person's information again. The People module's reusable selection control is therefore used when creating a user.

### Add/Update through one business object

The internal mode in `ClsUser` allows `Save()` to determine whether the operation is an INSERT or UPDATE, keeping the form workflow consistent.

### Client-side filtering

Filtering is performed on the already loaded `DataTable` through `DataView.RowFilter`. This avoids sending a new database query for every filter change in the management screen.

### Refresh after changes

The users list is reloaded after Add, Edit, Delete, and password-change operations so the displayed data matches the database state.

## Current Scope

The core user-management workflow and password-change workflow are implemented.

Email and phone actions are present in the UI but remain under development.

## Related Files

- [`FrmMangeUser.cs`](FrmMangeUser.cs)
- [`FrmAddEditeUser.cs`](FrmAddEditeUser.cs)
- [`FrmShowUserInfo.cs`](FrmShowUserInfo.cs)
- [`FrmChangePassword.cs`](FrmChangePassword.cs)
- [`../../DVIDBusinessLayer/ClsUser.cs`](../../DVIDBusinessLayer/ClsUser.cs)
- [`../../DVIDDataAcessLayer/ClsUserDataAccess.cs`](../../DVIDDataAcessLayer/ClsUserDataAccess.cs)
- [`../../DVIDDataAcessLayer/DTOs/UserDTO.cs`](../../DVIDDataAcessLayer/DTOs/UserDTO.cs)
