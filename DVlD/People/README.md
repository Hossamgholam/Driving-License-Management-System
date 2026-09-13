# People Management

The **People Management** module is the first major business feature documented in the DVLD application.

It provides the user interface and supporting layers needed to create, find, update, view, filter, and delete people stored in the DVLD database.

## What This Module Provides

- Display people in a `DataGridView`.
- Add a new person.
- Edit an existing person.
- Delete a person.
- View person details.
- Find a person by Person ID or National No.
- Filter the people list by several fields.
- Reuse person information through custom WinForms UserControls.

## Main Forms

The module currently contains these forms:

| Form | Responsibility |
|---|---|
| `FrmMangePeople` | Displays the people list and provides filtering and CRUD actions. |
| `FrmAddEditPeople` | Adds a new person or edits an existing person. |
| `FrmFindPerson` | Searches for a person. |
| `FrmShowPersonInfo` | Displays detailed information about a selected person. |

The module also contains reusable controls under `DVlD/People/Controls/`.

## Reusable Controls

### `ctrlPersonCard`

Displays the information of a selected person in a reusable UI component.

### `CtrlPersonCardWithFilter`

Combines person information with a filtering/search experience so other forms can select a person without implementing the same search UI again.

This is useful when another DVLD feature needs to start from an existing person, such as a future driver or application workflow.

## Data Flow

The People module follows the application's layered architecture:

```text
FrmAddEditPeople / FrmMangePeople / FrmFindPerson
                    │
                    ▼
             DVIDBusinessLayer
                    │
                    ▼
             DVIDDataAcessLayer
                    │
                    ▼
                SQL Server
```

For person data, `ClsPerson` represents the business object while `ClsPersonDataAccess` performs the database operations. `PersonDTO` is used to transfer person data between the data-access and business layers.

## Business Layer

`DVIDBusinessLayer/ClsPerson.cs` contains the main person business object.

The class supports:

- Finding a person by ID.
- Finding a person by National No.
- Adding a person.
- Updating a person.
- Deleting a person through the data-access layer.
- Getting all people.
- Checking whether a Person ID exists.
- Checking whether a National No exists.
- Checking National No uniqueness while excluding the current person during editing.

The class uses an internal Add/Update mode so the same object can represent both a new person and an existing person being edited.

## Data Access Layer

`DVIDDataAcessLayer/ClsPersonDataAccess.cs` contains the SQL Server operations for people.

Implemented operations include:

- `FindByID`
- `FindByNationalNo`
- `GetAll`
- `Add`
- `Update`
- `Delete`
- Existence checks by Person ID and National No

The implementation uses ADO.NET classes such as `SqlConnection`, `SqlCommand`, and `SqlDataReader`.

The `GetAll` query also joins `Person` with `Countries` so the UI can display the country name instead of only the foreign-key ID.

## DTO

`PersonDTO` is located under:

```text
DVIDDataAcessLayer/DTOs/PersonDTO.cs
```

The DTO acts as the data-transfer object between the data-access and business layers, keeping database retrieval separate from the business object used by the application.

## People List and Filtering

`FrmMangePeople` loads the people data into a `DataTable` and creates a second table containing only the columns required by the grid.

The displayed columns are:

- Person ID
- National No
- First Name
- Second Name
- Third Name
- Last Name
- Gender
- Nationality
- Phone
- Email

Filtering is performed through the `DataView.RowFilter` property.

The filter supports fields including:

- Person ID
- National No
- First Name
- Second Name
- Third Name
- Last Name
- Nationality
- Gender
- Phone
- Email

For text fields, the current implementation uses a prefix search such as `value%`. Person ID uses an exact numeric comparison.

## CRUD Workflow

### Add

1. The user opens `FrmAddEditPeople` in Add mode.
2. The form collects and validates person information.
3. The business object sends the data to the data-access layer.
4. The data-access layer inserts the record and retrieves the generated Person ID.
5. The people list is refreshed after the form closes.

### Edit

1. The user selects an existing person.
2. `FrmAddEditPeople` receives the selected Person ID.
3. The business layer finds the existing person.
4. The form displays the existing data.
5. Saving updates the database record.
6. The people list is refreshed.

### Delete

The user is asked for confirmation before deletion. If the database prevents deletion because related records exist, the UI reports that the person cannot be deleted.

## Important Implementation Decisions

### Separate displayed columns from the full query

The data-access layer returns additional person information needed by the application, while `FrmMangePeople` creates a selected table for the columns that should actually appear in the grid.

This keeps the database query useful without forcing every returned column to be displayed.

### Reusable person controls

Person selection is a recurring operation in a DVLD system. Instead of rebuilding the same search and person-display UI in every future feature, the project uses reusable UserControls.

### National No uniqueness during editing

A simple uniqueness check is not enough when editing an existing person. The data-access layer therefore provides a check that searches for the same National No while excluding the current `PersonID`.

This allows the current person to keep their National No while still preventing duplicates.

### Refresh after database changes

After Add, Edit, or Delete operations, the management form reloads the people data from the database instead of relying only on the previous in-memory table.

This keeps the grid synchronized with the stored data.

## Current Limitations / Future Improvements

Some actions are intentionally still marked as under development in the UI, including sending email and phone-call functionality.

The filtering implementation can also be improved later with stronger escaping/validation for user-entered filter values and more flexible search behavior.

## Related Files

- [`FrmMangePeople.cs`](FrmMangePeople.cs)
- [`FrmAddEditPeople.cs`](FrmAddEditPeople.cs)
- [`FrmFindPerson.cs`](FrmFindPerson.cs)
- [`FrmShowPersonInfo.cs`](FrmShowPersonInfo.cs)
- [`Controls/CtrlPersonCardWithFilter.cs`](Controls/CtrlPersonCardWithFilter.cs)
- [`Controls/CtrlPersonCard.cs`](Controls/CtrlPersonCard.cs)
- [`../../DVIDBusinessLayer/ClsPerson.cs`](../../DVIDBusinessLayer/ClsPerson.cs)
- [`../../DVIDDataAcessLayer/ClsPersonDataAccess.cs`](../../DVIDDataAcessLayer/ClsPersonDataAccess.cs)
- [`../../DVIDDataAcessLayer/DTOs/PersonDTO.cs`](../../DVIDDataAcessLayer/DTOs/PersonDTO.cs)

## What I Learned From This Feature

This module was not only a CRUD exercise. It provided practical experience with:

- Connecting WinForms UI to multiple application layers.
- Moving data through DTOs.
- Writing ADO.NET database operations.
- Working with `DataTable` and `DataView`.
- Building reusable UserControls.
- Handling Add and Update through one business object.
- Designing existence checks that work correctly during editing.
- Refreshing UI data after database changes.

The module also established a reusable foundation for future DVLD features that need to work with people.
