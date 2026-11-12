# Hotel Management System

A desktop hotel management application built with **C# / WinForms** and **SQL Server** using **ADO.NET**.

> **Status:** Under active development. This is an early prototype that is being improved step by step — see the [Roadmap](#roadmap).

---

## Features

| Module | Status |
|---|---|
| Login + PBKDF2 password hashing + roles (Admin / Staff) | ✅ |
| Room management (add, edit, delete, list) | ✅ |
| Room allocation to a customer (register + set status to Busy) | ✅ |
| Active-guest list, check-out, and billing | ✅ |
| Staff registration, listing, and deletion (Admin only) | ✅ |
| Dashboard (hotel overview, revenue, recent activity) | ✅ |
| Arabic user interface across all screens; database values stay in English (`Male`/`Female`, `Staff`/`Admin`, `Free`/`Busy`) | ✅ |
| Logout (returns to the login screen) | ✅ |

---

## Tech Stack

- **C# 7** — .NET Framework **4.7.2**
- **Windows Forms** with [Guna.UI2](https://www.nuget.org/packages/Guna.UI2.WinForms)
- **SQL Server** (database engine)
- **ADO.NET** (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)

---

## Project Structure

```
Hotel_Managment_System/
├── Program.cs                  Entry point: login → main window → logout loop
├── MainHotelMenu.cs            Main window + role-aware navigation
├── Login.cs                    Login screen (authentication)
├── PasswordHasher.cs           PBKDF2-HMAC-SHA256 hashing + legacy migration
├── StaffUser.cs                Signed-in user model (id, name, role)
├── function.cs                 Data access layer (temporary)
├── Logger.cs                   File logger
├── Validation.cs               Shared input validation rules
├── Resources/
│   └── HotelManagment/         User controls
│       ├── UC_Rooms.cs
│       ├── UC_Customers.cs
│       ├── UC_Guests.cs        Active guests + check-out
│       ├── UC_Staff.cs
│       └── UC_Booking.cs       Dashboard
├── database/
│   ├── schema.sql              Creates the database from scratch
│   └── migrations/             Incremental scripts for existing databases
└── App.config                  Application settings (connection string)
```

---

## User Interface (redesign/ui-theme branch)

The UI redesign lives on branch `redesign/ui-theme` (not yet merged to `main`) and is built on top of `Theme.cs`, a central palette (deep slate + gold) with helpers for inputs, combos, date pickers, buttons, cards, page headings, RTL-aligned labels, and header search/filter boxes.

Highlights:

- **Unified look:** every screen has a 20pt bold title, a muted subtitle, and rounded white "card" panels with a hairline border.
- **Arabic first:** all labels, grid headers, hints, buttons, and `MessageBox` text are Arabic. Stored database values remain English (`Male`/`Female`, `Staff`/`Admin`, `Free`/`Busy`, room types), converted through `Localization.cs` when reading or writing.
- **RTL labels:** labels above fields are right-aligned and widened to match their field (`Theme.AlignFieldLabels`).
- **Search / filter:** Rooms (by number + status), Guests (by name, mobile, room), and Staff (by name, user, mobile, role) grids can be searched and filtered without reloading the page.
- **Staff screen:** the four tabs were merged into one page — a searchable Arabic grid on the left and an add/edit form card on the right. The password field doubles as the administrator-driven password reset (leave blank to keep the current password).
- **Dashboard:** kept as a dashboard interface — KPI cards (total/free/busy rooms, customers, staff, revenue), a wider recent-stays table, and RTL-aligned card titles.

---

## Prerequisites

1. **Windows 10/11**
2. **Visual Studio 2022** with the ".NET desktop development" workload
3. **.NET Framework 4.7.2 Developer Pack**
4. **SQL Server** (Express or higher) + **SSMS**

---

## Database Setup

1. Open **SQL Server Management Studio** and connect to your local server.
2. Open `database/schema.sql` and execute it (F5).
3. The script creates the `HotelDB` database and the `Rooms`, `Customers`, and `Staff` tables if they do not already exist.
4. For sample data, uncomment the `INSERT` section at the end of the script.

> The database is **not** committed to Git. `schema.sql` is the single source of truth for the schema.

### Upgrading an existing database

Databases created before Phase 3 must run `database/migrations/002_add_staff_role.sql` once. It is idempotent and:

1. adds `Staff_Role` (`Admin` / `Staff`, default `Staff`);
2. verifies that `Staff_UserName` values are unique, then adds a `UNIQUE` constraint;
3. promotes the **first** staff member to `Admin` if no administrator exists yet.

After running it, sign in with the promoted account and create a dedicated administrator from the Staff screen. To promote another account manually:

```sql
UPDATE dbo.Staff
SET Staff_Role = 'Admin'
WHERE Staff_UserName = 'your.user.name';
```

Databases created before Phase 4 must also run `database/migrations/003_rooms_and_billing.sql` once. It is idempotent and:

1. normalizes the room type `Suit` to `Suite`;
2. replaces the legacy `'No'` status default with `'Free'`, makes `Rooms.Status` `NOT NULL`, and restricts it to `Free` / `Busy`;
3. adds `Customers.Customer_Rate` (the rate captured at check-in) and `Customers.Customer_Total` (the final bill);
4. backfills `Customer_Rate` from the current room price for active guests;
5. adds a `CHECK` constraint for `Customer_IsCheckOut` and an index for active-room lookups.

Run both scripts with `sqlcmd` before starting the new build:

```bash
sqlcmd -S . -d HotelDB -E -b -i database/migrations/002_add_staff_role.sql
sqlcmd -S . -d HotelDB -E -b -i database/migrations/003_rooms_and_billing.sql
```

---

## Authentication and Roles

- **Hashing:** PBKDF2-HMAC-SHA256, 100,000 iterations, a random 16-byte salt, and a 32-byte hash.
- **Storage format:** `PBKDF2$100000$<base64 salt>$<base64 hash>` in `Staff_Password`.
- **Comparison:** constant-time, so a wrong password does not leak information through timing.
- **Unknown user names:** the app still performs a dummy hash verification and shows the same generic message, so the response does not reveal whether the account exists.
- **Legacy passwords:** rows still stored as plain text are accepted once and immediately replaced with a PBKDF2 hash after a successful login. Every staff member is upgraded the first time they sign in.
- **Password policy:** at least 8 characters, including a letter and a digit (maximum 128).
- **Roles:**
  - `Admin` — full access, including staff registration and deletion. The app also prevents deleting the last administrator.
  - `Staff` — dashboard, rooms, and customers. The Staff tab is hidden and the navigation handler rejects the request.
- **Logout:** the Logout button closes the main window and returns to the login screen without restarting the process.
- **Forgot password:** there is no self-service reset yet; the screen tells the user to contact an administrator.

> **Security note:** role checks in a WinForms client can be bypassed by anyone with direct database access. A real deployment also needs restricted database permissions, server-side authorization, and audit logging.

---

## Billing and Check-out

- The nightly rate is copied from `Rooms.Price` into `Customers.Customer_Rate` when the guest is registered, so later price changes do not alter an active stay.
- Check-out is available from the **Guests** screen. The operator chooses the check-out date; it cannot be before the check-in date or in the future.
- Billable nights = `max(1, check-out − check-in)`. The final bill = nights × `Customer_Rate`.
- Check-out writes `Customer_CheckOut`, `Customer_IsCheckOut = 'Yes'`, and `Customer_Total` in one transaction. The room returns to `Free` only when no other active guest uses it.
- The dashboard shows completed revenue, today's revenue, and recent activity. Active stays display an estimate using today as the provisional check-out date.
- There are no taxes, discounts, partial payments, refunds, or printed invoices yet.

---

## Configuration

Edit the connection string in `App.config` to match your server:

```xml
<connectionStrings>
  <add name="HotelDb"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

| Value | Meaning |
|---|---|
| `Data Source=.` | Default local server instance |
| `Data Source=.\SQLEXPRESS` | SQL Server Express instance |
| `Initial Catalog=HotelDB` | Database name |
| `Integrated Security=True` | Windows authentication |

---

## Build and Run

```bash
git clone <repository-url>
cd Hotel_Managment_System
```

1. Open `Hotel_Managment_System.sln` in Visual Studio.
2. From the menu: **Build → Restore NuGet Packages** (to restore Guna.UI2).
3. Press **F5**.

> The `packages/` folder is not committed; Visual Studio restores it automatically during the build.

---

## Known Limitations

The following issues are known and will be addressed in order (see the roadmap):

- There is no self-service password reset, account lockout, or idle-session timeout.
- Legacy plain-text passwords are upgraded lazily on first login; there is no bulk migration for accounts that never sign in.
- Role checks are enforced by the UI. Anyone with direct database access can bypass them.
- Most validation rules live in the UI; only `Staff_Role`, `Rooms.Status`, and `Customers.Customer_IsCheckOut` have database `CHECK` constraints.
- Phone numbers are validated as digits, spaces, hyphens and an optional leading `+`; there is no country-aware format.
- Billing has no taxes, discounts, partial payments, refunds, or invoice printing.
- The nightly rate is fixed at check-in; changing it mid-stay is not supported.
- Some legacy rooms are marked `Busy` without an active guest; they are not repaired automatically.
- Text columns use `VARCHAR` and do not support Unicode (e.g. Arabic).

---

## Roadmap

- [x] Repository setup and database schema script
- [x] Move the connection string to `App.config`
- [x] Secure queries (`SqlParameter`) + `using` + error handling
- [x] Transactional room allocation with a concurrency guard
- [x] File logging and a global exception handler
- [x] Per-field input validation (lengths, formats, dates, duplicate checks)
- [x] Dashboard replacing the Bookings placeholder
- [x] Real login + PBKDF2 password hashing + roles
- [x] Staff password reset by administrator (Phase 4.3, Staff screen)
- [ ] Account lockout and idle-session timeout
- [x] Complete the Rooms screen (Edit / Delete)
- [x] Customer list + check-out + billing
- [ ] Separate layers (Repositories / Services)
- [ ] Convert read operations to `async/await`
- [ ] Tests + continuous integration (CI)

---

## License

This project is currently for educational purposes. The final license will be determined later.
