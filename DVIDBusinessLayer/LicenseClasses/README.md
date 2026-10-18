# License Classes — Business and Data Access

This feature adds the backend operations used to read and maintain rows in the `LicenseClasses` table.

## Implemented Operations

The business object `ClsLicenseClasses` represents a class with these fields:

- `LicenseClassID`
- `ClassName`
- `ClassDescription`
- `MinimumAllowedAge`
- `DefaultValidityLength`
- `ClassFees`

It exposes the following operations:

- `Save()` — inserts a new class or updates an existing one based on the object's Add/Update mode.
- `Find(int LicenseClassID)` and `Find(string ClassName)` — look up a class by ID or name.
- `GetAll()` — returns the available classes as a `DataTable`.
- `Delete(int LicenseClassID)` — deletes a class by ID.
- `IsExists(int LicenseClassID)` — checks whether a class ID exists.

## Layer Responsibilities

- `DVIDBusinessLayer/ClsLicenseClasses.cs` holds the class data and chooses between insert and update in `Save()`.
- `DVIDDataAcessLayer/ClsLicenseClassesData.cs` executes parameterized SQL Server commands through ADO.NET. New IDs are returned with `SCOPE_IDENTITY()`.

The Local Driving License Applications form uses `GetAll()` to populate its license-class selector, and the local-application business object loads class details for display.

## Current Scope

This commit adds the backend only. A dedicated WinForms screen for managing license classes is not included in this feature yet. The repository also does not provide an automated test suite for these operations.

Data-access methods currently convert caught SQL exceptions into failure values such as `false` or `-1`; adding structured error reporting would make failures easier to diagnose.
