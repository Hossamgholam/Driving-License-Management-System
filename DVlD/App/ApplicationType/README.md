# Application Types Management

The Application Types module manages the predefined application categories used by the DVLD system.

Each application type currently contains:

- `ApplicationTypeID`
- `ApplicationTypeTitle`
- `ApplicationFees`

## Current Scope

The current implementation supports:

- Displaying all application types in a `DataGridView`.
- Showing the total number of records.
- Opening an application type for editing from the context menu.
- Loading an application type by ID.
- Updating the title and fees.
- Refreshing the list after an update.
- Validating required fields before saving.
- Validating the fees value as a numeric value.

## Workflow

```text
FrmManageApplication
        │
        ├── Load all application types
        ├── Display ID, title, and fees
        └── Open selected record for editing
                    │
                    ▼
          FrmUpdateApplication
                    │
                    ├── Find record by ID
                    ├── Validate title and fees
                    ├── Update through the business layer
                    └── Refresh the management form
```

## Layer Responsibilities

### Presentation Layer

- `FrmManageApplication.cs`
  - Loads the application types list.
  - Displays records and record count.
  - Opens the selected record for editing.
  - Refreshes the grid after saving.

- `FrmUpdateApplication.cs`
  - Loads the selected application type.
  - Validates the title and fees fields.
  - Saves the updated values.

### Business Layer

- `ClsApplicationTypes.cs`
  - Represents an application type.
  - Provides `Find`, `GetAll`, `Save`, and existence-check operations.
  - Delegates persistence to the data-access layer.

### Data Access Layer

- `ClsApplicationTypesDataAccess.cs`
  - Finds an application type by ID.
  - Loads all application types into a `DataTable`.
  - Updates the title and fees using parameterized SQL commands.
  - Checks whether an application type exists.

## Validation

The update form currently validates:

- The title must not be empty.
- The fees field must not be empty.
- The fees field must contain a valid numeric value.
- Saving is blocked when `ValidateChildren()` fails.

## Current Limitations

- The module currently supports updating existing application types only.
- Adding and deleting application types are not implemented yet.
- Filtering and searching are not implemented yet.
- Error details from the data-access layer are not surfaced to the user.

## Related Files

- `DVlD/App/ApplicationType/FrmManageApplication.cs`
- `DVlD/App/ApplicationType/FrmUpdateApplication.cs`
- `DVIDBusinessLayer/ClsApplicationTypes.cs`
- `DVIDDataAcessLayer/ClsApplicationTypesDataAccess.cs`
