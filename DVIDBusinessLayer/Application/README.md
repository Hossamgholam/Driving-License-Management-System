# Application Core

The Application Core is the shared business and data-access foundation for DVLD applications. A base application stores the applicant, application type, creator, dates, status, and paid fees. The Local Driving License Applications module builds on this class.

## Application Data

Main fields: `ApplicationID`, `ApplicationPersonID`, `ApplicationTypeID`, `CreatedByUserID`, `ApplicationDate`, `ApplicationStatus`, `LastStatusDate`, and `PaidFees`.

The `EnApplicationStatus` enum defines `New = 1`, `Canceled = 2`, and `Completed = 3`. The `StatusName` property returns a display string for the current status. Loaded applications also include related person, application-type, and user information.

## Current Scope

- Create and update applications through `Save()`.
- Find an application by ID and load all applications.
- Update and delete application records.
- Find an active application by applicant and application type.
- Find an active local application by applicant, application type, and license class.
- Check whether a person has an active application of a given type.
- Update application status through `UpdateStatus()`; the data-access method also updates `LastStatusDate`.
- Use convenience methods to set an application to `New`, `Canceled`, or `Completed`.
- Map database records through `ApplicationDTO`.

Active-application queries treat `ApplicationStatus = 1` as active. The license-class-specific query joins `Applications` with `LocalDrivingLicenseApplications`.

## Architecture

```text
WinForms feature
      |
      v
ClsApplication / ClsLocalDrivingLicenseApplication
      |
      v
ApplicationDTO and business rules
      |
      v
ClsApplicationDataAccess
      |
      v
SQL Server
```

## Layer Responsibilities

- `DVIDBusinessLayer/ClsApplication.cs` represents the base application, status values, related records, lookup, status changes, and active-application checks.
- `DVIDDataAcessLayer/ClsApplicationDataAccess.cs` performs parameterized SQL Server operations, retrieves generated IDs with `SCOPE_IDENTITY()`, queries active applications, and updates status dates.
- `ApplicationDTO.cs` transfers application data between layers; `Maping.cs` maps database records into the DTO.

## Related Feature

See [Local Driving License Applications](../../DVlD/App/LocalDrivingLicenseApplications/README.md) for the registration, edit, list, and details workflow built on this core.

## Current Limitations

- **Existence-check issue:** `ClsApplication.IsExsit(int)` currently calls itself recursively instead of delegating to `ClsApplicationDataAccess.IsExsit(int)`. Correct it before using this method.
- The local-application workflow saves the base application and local detail separately rather than in one transaction.
- The project is still in active development; these changes do not establish full end-to-end test coverage.
