# Sports Tryout Management System

A VB.NET Windows Forms desktop system for managing school sports tryouts end
to end: registration, sport & schedule management, applicant records,
evaluation, screening, selection, and reporting. Data is stored locally in
plain text files (.txt) inside a `Data` directory — completely offline, with
zero external database servers and zero NuGet dependencies.

## Requirements

- Windows 10/11
- Visual Studio 2019 or 2022 with the **.NET desktop development** workload
  (includes the Visual Basic / Windows Forms tooling)
- .NET Framework 4.8 Developer Pack (Visual Studio will prompt you to install
  it automatically if it's missing)
- **Zero external packages or database drivers needed** — the project compiles
  using built-in standard .NET Framework references.

## Getting Started

1. Double-click `SportsTryoutSystem.sln` to open it in Visual Studio.
2. Press **F5** (or Debug → Start Debugging) to build and run.
3. On first run, the system automatically creates the `Data` directory next to
   the compiled executable with text database files (`Users.txt`, `Sports.txt`,
   `Students.txt`, `Registrations.txt`, `Schedules.txt`, `Evaluations.txt`, etc.)
   and seeds default accounts and starter sports. No manual database setup is required.

## Default Login Accounts

| Role  | Username | Password  | Notes                                   |
|-------|----------|-----------|------------------------------------------|
| Admin | admin    | admin123  | Full access to every module              |
| Coach | coach    | coach123  | Evaluation / Screening / Selection only  |
| Staff | staff    | staff123  | Registration / Schedules / Records       |

**Change these default passwords** (or deactivate the sample accounts) once
you've explored the system — use User Account Management (Admin) or the
"Change Password" screen for the logged-in account.

## Feature Overview

- **A. User Login & Account Management** — role-based login (Admin, Coach,
  Evaluator, Staff), user CRUD, password reset, self-service password change.
  Admins can create accounts and choose exactly which modules/permissions
  (users, sports, schedules, registration, applicant records, evaluation,
  reports) each account may access.
- **B. Student Registration** — register applicants with student ID, name,
  course/grade level, preferred sport; blocks duplicate registrations for the
  same sport per student; look up an applicant's current status by ID.
- **C. Sport Management** — add/edit/deactivate sports; assign coaches or
  evaluators to specific sports.
- **D. Tryout Schedule Management** — create/edit/delete schedules (date,
  time, venue) per sport; filter by sport and status (Upcoming/Completed/
  Cancelled).
- **E. Applicant Records** — searchable, filterable master list (by name,
  student ID, sport, selection status) with a full detail view per applicant.
- **F. Athlete Evaluation & Selection** — unified assessment module combining:
  - *Evaluation Scoring*: coaches/evaluators score Skill, Speed, Agility, Endurance, Teamwork, Discipline, and Overall Performance (0-100 each); the final score is computed live as an average.
  - *Screening & Rankings Board*: view all ranked athletes per sport sorted by final score, with a qualifying threshold filter (score >= 75.0) and CSV export.
  - *Final Selection*: record final status (Selected, Not Selected, For Further Evaluation, Pending) and evaluation remarks.
- **G. Search & Filtering** — available throughout: by name, student ID,
  sport, schedule, evaluation result, and selection status.
- **H. Reports** — Registered Applicants, Applicants per Sport, Tryout
  Schedules, Evaluation Results, Applicant Rankings, Qualified Students,
  Selected Athletes, and Non-Selected Athletes — each viewable on screen and
  exportable to CSV (opens directly in Excel).

## Project Structure

```
SportsTryoutSystem.sln
SportsTryoutSystem/
  Main.vb                       ' application entry point (Sub Main)
  App.config
  packages.config
  Data/
    DatabaseHelper.vb            ' Local text-file database engine (.txt files in Data/)
  Helpers/
    SecurityHelper.vb            ' SHA-256 password hashing
    SessionManager.vb            ' current logged-in user / role checks
    UIHelper.vb                  ' shared color palette, fonts, control factories
    AppLogic.vb                  ' scoring, status text, CSV export, passing score
    ComboItems.vb                ' small wrapper classes for combo/checklist items
  Forms/
    frmLogin.vb
    frmMain.vb                   ' MDI shell with role-based left navigation
    frmDashboard.vb
    frmUserManagement.vb
    frmSportManagement.vb
    frmScheduleManagement.vb
    frmStudentRegistration.vb
    frmApplicantRecords.vb
    frmEvaluation.vb
    frmScreening.vb
    frmSelection.vb
    frmReports.vb
    frmChangePassword.vb
```

All forms are built entirely in code (no `.resx`/Designer files), styled
through the shared `UIHelper` module so the whole system keeps one clean,
consistent look (navy header bars, a dark side navigation menu, and
consistent buttons/grids).

## Notes for Customization

- **Passing score**: change `AppLogic.PassingScore` (default `75`) to adjust
  the qualification threshold used in Screening and the "Qualified Students"
  report.
- **Database location**: the SQLite file is created next to the `.exe`
  (`bin\Debug\SportsTryout.db` while developing). Delete it to reset the
  system back to a fresh, seeded state.
- **Roles**: `Admin`, `Coach`, `Staff` are treated as fixed values throughout
  the code (menus, filters, permissions). Add a new role by extending the
  checks in `SessionManager` and the menu logic in `frmMain`.
- **Adding NuGet packages offline**: if your build machine has no internet
  access, install `System.Data.SQLite.Core` once from a machine that does
  (Tools → NuGet Package Manager → Package Manager Console →
  `Install-Package System.Data.SQLite.Core -Version 1.0.118`), then copy the
  resulting `packages` folder alongside the solution.

## Architecture Notes

The system follows a simple, easy-to-follow layered structure suited to a
school project: a `DatabaseHelper` module centralizes all SQL and ADO.NET
plumbing (parameterized queries throughout, to prevent SQL injection),
`SessionManager` tracks the logged-in user for role-based access control, and
each form is self-contained (build its own UI, load its own data, handle its
own events) which keeps the codebase easy to navigate and extend module by
module.
