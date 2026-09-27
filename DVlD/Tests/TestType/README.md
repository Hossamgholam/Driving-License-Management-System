# Test Types Management

The Test Types module manages the predefined tests used by the DVLD system.

Each test type currently contains:

- `TestTypeID`
- `TestTypeTitle`
- `TestTypeDescription`
- `TestTypeFees`

## Current Scope

The current implementation supports:

- Displaying all test types in a `DataGridView`.
- Showing the total number of records.
- Opening a selected test type for editing from the context menu.
- Loading a test type by ID.
- Updating the title, description, and fees.
- Refreshing the management list after an update.
- Validating required fields before saving.
- Validating the fees value as a numeric value.

The business and data-access layers also contain create and existence-check operations, preparing the module for broader management operations.

## Workflow

```text
FrmManageTestType
        │
        ├── Load all test types
        ├── Display ID, title, description, and fees
        └── Open selected record for editing
                    │
                    ▼
             FrmUpdateTest
                    │
                    ├── Find record by ID
                    ├── Validate title, description, and fees
                    ├── Update through the business layer
                    └── Refresh the management form
```

## Layer Responsibilities

### Presentation Layer

- `FrmManageTestType.cs`
  - Loads all test types.
  - Displays the records and record count.
  - Opens the selected test type for editing.
  - Refreshes the list after editing.

- `FrmUpdateTest.cs`
  - Loads the selected test type.
  - Validates title, description, and fees.
  - Saves the updated values.

### Business Layer

- `ClsTestTypes.cs`
  - Represents a test type.
  - Provides `Find`, `GetAll`, `Save`, and existence-check operations.
  - Uses Add/Update mode to decide how `Save()` persists the object.

### Data Access Layer

- `ClsTestTypesDataAccess.cs`
  - Adds a test type and returns the generated ID.
  - Finds a test type by ID.
  - Loads all test types into a `DataTable`.
  - Updates test type data using parameterized SQL commands.
  - Checks whether a test type exists.

## Validation

The update form currently validates:

- Title must not be empty.
- Description must not be empty.
- Fees must not be empty.
- Fees must contain a valid numeric value.
- Saving is blocked when `ValidateChildren()` fails.

## Current Limitations

- The UI currently exposes listing and updating existing test types.
- Adding and deleting test types are not exposed from the current management form.
- Filtering and searching are not implemented yet.
- Data-access exceptions are not surfaced to the user.

## Related Files

- `DVlD/Tests/TestType/FrmManageTestType.cs`
- `DVlD/Tests/TestType/FrmUpdateTest.cs`
- `DVIDBusinessLayer/ClsTestTypes.cs`
- `DVIDDataAcessLayer/ClsTestTypesDataAccess.cs`
