# Demo Data

The app can populate the database with a presentation-ready data set that covers
every table: user accounts, sports, coach assignments, students, registrations,
tryout schedules, and evaluation results.

## When it runs

- **Normal launch** – if the database has fewer than 5 registrations, the demo
  data is seeded automatically after the tables are created. This makes a fresh
  install immediately presentable.
- **`--demo`** – seeds any missing demo records without deleting anything.
- **`--demo-reset`** – asks for confirmation, then replaces the demo students,
  registrations, and evaluations with a newly generated set. Accounts, sports,
  coach assignments, and schedules are reused/refreshed rather than duplicated.

```
SportsTryoutSystem.exe --demo
SportsTryoutSystem.exe --demo-reset
```

The seeders are idempotent, so running them twice does not duplicate records.

## What gets created

| Table | Contents |
|-------|----------|
| Users | 10 accounts (3 admins, 4 coaches, 3 staff/evaluators, 1 inactive) with emails, contact numbers, role permissions, and generated profile avatars |
| Sports | 10 sports (9 active, 1 archived "Dance Sport") with descriptions |
| SportCoaches | 15 coach/evaluator assignments across the sports |
| Students | 60 student-athletes using the official college programs and year levels |
| Registrations | 100 sport registrations spread across the last four weeks |
| Schedules | 18 sessions: 10 upcoming, 6 completed, 2 cancelled, dated relative to today |
| Evaluations | ~80 scored tryouts with realistic remarks, final scores, and selection decisions |

Selection mix is tuned to look good on the dashboard: roughly 40% selected,
30% pending, 15% for further evaluation, and the rest not selected.

## Demo accounts

| Username | Password | Role |
|----------|----------|------|
| `admin` | `admin123` | Admin |
| `admin.ops` | `admin123` | Admin |
| `coach` | `coach123` | Coach |
| `coach.santos` | `coach123` | Coach |
| `coach.salazar` | `coach123` | Coach |
| `evaluator.cruz` | `coach123` | Evaluator |
| `evaluator.lim` | `coach123` | Evaluator |
| `staff` | `staff123` | Staff |
| `staff.registrar` | `staff123` | Staff |
| `coach.tan` | `coach123` | Coach (inactive) |

Demo students use student numbers starting with `2026-` and email addresses
ending in `@students.sts.edu.ph`. `--demo-reset` only deletes students matching
both of those markers, leaving manually entered records untouched.
