# Users Management

The Users Management module provides the administration of application users and connects each user account to an existing person in the DVLD system.

The module was implemented after the People Management module and reuses the existing person-selection control and person data.

## What the Module Provides

- View application users in a DataGridView.
- Add a new user.
- Edit an existing user.
- Delete a user.
- View user details.
- Change a user's password.
- Filter users by User ID, Person ID, Full Name, User Name, or active status.
- Display the number of records currently loaded.
- Prevent assigning more than one user account to the same person.
- Validate required user information before saving.

## Main Forms

| Form | Responsibility |
|---|---|
| `FrmMangeUser` | Displays users, filtering, CRUD actions, and user management commands. |
| `FrmAddEditeUser` | Adds a new user or edits an existing user. |
| `FrmShowUserInfo` | Displays information about a selected user. |
| `FrmChangePassword` | Validates the current password and changes it. |

## User Data

A user account contains:

- `UserID`
- `PersonID`
- `UserName`
- `Password`
- `IsActive`

The management grid also displays the person's full name by joining the `Users` and `Person` tables.

## Add / Edit Workflow

Adding a user is divided into two stages:

1. Select an existing person using `CtrlPersonCardWithFilter`.
2. Enter the login information and active status.

Before moving to the login information stage, the form checks that:

- A person has been selected.
- The selected person is not already associated with another user.

For editing an existing user, the form loads the user and its related person, then allows the login information to be updated.

The form uses an `EnMode` value to distinguish between **Add** and **Update** operations.

## Validation

The user forms use WinForms validation through `Validating`, `ErrorProvider`, and `ValidateChildren()`.

Validation includes:

- User name cannot be empty.
- User name must be unique.
- Password cannot be empty.
- Confirmed password must match the password.
- A selected person can have only one user account.

When editing a user, the existing user name is allowed to remain unchanged; uniqueness is checked only when the value is changed.

## Filtering

`FrmMangeUser` loads the users into a `DataTable` and uses its `DataView` for filtering.

Available filters include:

- User ID
- Person ID
- Full Name
- User Name
- Is Active

For ID filters, numeric input is enforced. For name filtering, the form uses a `LIKE` expression through `DataView.RowFilter`.

The active filter uses Boolean values:

```csharp
IsActive = true
```

or

```csharp
IsActive = false
```

The record count is refreshed after filtering and after CRUD operations.

## Password Change

The password-change form requires:

1. Current password.
2. New password.
3. Confirmation of the new password.

The form validates the current password against the loaded user, checks that the new password is not empty, and verifies that the confirmation matches.

After a successful change, the in-memory `ClsUser` object is also updated before saving.

## Data Flow

```text
FrmMangeUser / FrmAddEditeUser / FrmChangePassword
                    │
                    ▼
              ClsUser
          Business Layer
                    │
                    ▼
           ClsUserDataAccess
             Data Access
                    │
                    ▼
               SQL Server
```

`ClsUser` represents the business object and coordinates Add, Update, Find, Delete, existence checks, and password-related operations.

`ClsUserDataAccess` handles the SQL Server operations through ADO.NET and maps database results into `UserDTO` objects.

## Important Implementation Decisions

### Reusing the Person Module

A user is connected to an existing person instead of storing duplicated personal information. The existing person-selection control is reused when creating a user.

### Add / Update Mode

`ClsUser` uses an internal mode to determine whether `Save()` should perform an INSERT or UPDATE operation.

This keeps the form from needing separate business-layer methods for every save scenario.

### Refresh After Changes

The management form reloads the users after Add, Edit, Delete, and password-change operations so the grid represents the current database state.

### DataView Filtering

Filtering is performed on the already loaded `DataTable` through `DefaultView.RowFilter`, avoiding a new database query for every keystroke in the filter box.

## Current Scope

The Users module currently includes the core user-management operations and password changing.

The Send Email and Phone actions are present in the UI but are explicitly marked as features under development and are not implemented yet.

## What I Practiced

This feature provided practice with:

- Building a business object around Add / Update modes.
- Working with DTOs between business and data-access layers.
- Implementing CRUD operations with ADO.NET.
- Reusing an existing WinForms UserControl across modules.
- Validating related records before creating a user.
- Implementing DataTable / DataView filtering.
- Handling Boolean filtering with `DataView.RowFilter`.
- Designing multi-step WinForms forms.
- Using `ErrorProvider` and `ValidateChildren()` for form validation.
- Keeping the UI synchronized with database changes.
