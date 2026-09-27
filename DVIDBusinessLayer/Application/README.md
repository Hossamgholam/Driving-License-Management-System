# Application Core

The Application Core provides the business and data-access foundation for applications created in the DVLD system.

An application represents a request made by a person and stores its application type, creator, dates, status, and paid fees.

## Application Data

The current model contains:

- `ApplicationID`
- `ApplicationPersonID`
- `ApplicationTypeID`
- `CreatedByUserID`
- `ApplicationDate`
- `ApplicationStatus`
- `LastStatusDate`
- `PaidFees`

Application status is represented in the business layer as:

- `New`
- `Canceled`
- `Completed`

## Current Scope

The current implementation provides:

- Creating an application through the business and data-access layers.
- Finding an application by ID.
- Loading all applications.
- Updating application data.
- Deleting an application.
- Checking whether an application exists.
- Finding an active application for a person and application type.
- Checking whether a person already has an active application of a specific type.
- Updating application status and the last status date at the data-access level.
- Mapping database application records into `ApplicationDTO` objects.

The current commit focuses on the backend foundation. A dedicated application-registration UI has not been implemented yet.

## Workflow

```text
ClsApplication
      │
      ├── Add / Update / Find / GetAll / Delete
      │
      ▼
ApplicationDTO
      │
      ▼
ClsApplicationDataAccess
      │
      ├── SQL Server CRUD operations
      ├── Active-application checks
      └── Status update
```

## Layer Responsibilities

### Business Layer

- `ClsApplication.cs`
  - Represents an application.
  - Defines application status values.
  - Loads related application type and user information when an application is found.
  - Uses Add/Update mode through `Save()`.
  - Exposes application lookup and deletion operations.

### Data Access Layer

- `ClsApplicationDataAccess.cs`
  - Performs SQL Server CRUD operations.
  - Uses parameterized SQL commands.
  - Retrieves generated application IDs with `SCOPE_IDENTITY()`.
  - Finds active applications by person and application type.
  - Updates application status and status date.
  - Maps database rows into `ApplicationDTO`.

- `ApplicationDTO.cs`
  - Transfers application data between the data-access and business layers.

- `Maping.cs`
  - Maps an application database row into an `ApplicationDTO`.

## Current Limitations

- No application-registration form is implemented yet.
- Application status update is currently exposed at the data-access level rather than as a public business-layer operation.
- Validation and higher-level business rules will be added as the application-registration workflow is built.
