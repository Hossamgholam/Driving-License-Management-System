# Local Driving License Applications

This module adds the first WinForms workflow for creating, editing, listing, and viewing local driving-license applications.

A local driving-license application is stored across two related records: the base `Applications` record and a `LocalDrivingLicenseApplications` record that identifies the requested license class.

## Implemented Workflow

- **Create an application:** select an existing person through the reusable person filter, choose a license class, and review the application fee.
- **Set application data:** the form uses the `NewLocalDrivingLicense` application type, the current user as creator, and the initial `New` status.
- **Save and edit:** `ClsLocalDrivingLicenseApplication` inherits from `ClsApplication`. Its `Save()` method saves the base application first, then inserts or updates the local-application record.
- **Manage applications:** the management form loads rows from `LocalDrivingLicenseApplications_View` and opens the add/edit or details form.
- **View details:** `CtrDrivingLicenseApplicationInfo` displays the local application and embeds `CtrApplicationBasicInfo` for its related application details.
- **Check eligibility:** before saving, the form checks whether the person already has an active application for the same license class and whether the person already has an active license of that class.

## Architecture

| Layer | Main files | Responsibility |
|---|---|---|
| WinForms UI | `FrmManageLocalDrivingLicenseApplication.cs`, `FrmAddEditeLocalDrivingLicenseApplications.cs`, `FrmShowLocalDrivingLicenseAppInfo.cs` | List, create/edit, and view applications. |
| Reusable controls | `CtrDrivingLicenseApplicationInfo.cs`, `../CtrApplicationBasicInfo.cs` | Display local-application and base-application information. |
| Business layer | `DVIDBusinessLayer/ClsLocalDrivingLicenseApplication.cs`, `ClsLicenseClasses.cs`, `ClsLicenses.cs` | Coordinate application data and eligibility checks. |
| Data-access layer | `DVIDDataAcessLayer/ClsLocalDrivingLicenseApplicationData.cs`, `ClsLicenseClassesData.cs`, `ClslicensesData.cs` | Run parameterized SQL Server queries through ADO.NET. |

The local-application data-access class supports add, update, find by local-application ID, find by base application ID, list, delete, and existence checks. New record IDs are retrieved with `SCOPE_IDENTITY()`.

## Current Limitations and Follow-up Items

- The **Passed Tests** value in `CtrDrivingLicenseApplicationInfo` is currently a placeholder set to `0`; it is not calculated from test records yet.
- The management form currently assigns several column headers and widths to column index `0`. The column setup should be corrected so each header is applied to its intended column.
- The same duplicate-application check runs while editing as well as creating. An existing active application may therefore be detected as a duplicate of itself; update mode should exclude the current application.
- The base `Applications` record is saved before the local-application record, without a transaction around both operations. If the second save fails, the base record may remain.
- This is an in-progress module; the repository change establishes the workflow but does not itself demonstrate complete end-to-end test coverage.
