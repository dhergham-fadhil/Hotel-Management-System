# Hotel Management System

A desktop hotel management application built with **C# / WinForms** and **SQL Server** using **ADO.NET**.

> **Status:** Under active development. This is an early prototype that is being improved step by step — see the [Roadmap](#roadmap).

---

## Features

| Module | Status |
|---|---|
| Room management (add + list) | ✅ |
| Room allocation to a customer (register + set status to Busy) | ✅ |
| Staff registration, listing, and deletion | ✅ |
| Login screen | ⚠️ UI only (not wired yet) |
| Bookings | ❌ In progress |

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
├── Program.cs                  Application entry point
├── MainHotelMenu.cs            Main window + navigation
├── Login.cs                    Login screen (not wired yet)
├── function.cs                 Data access layer (temporary)
├── Resources/
│   └── HotelManagment/         User controls
│       ├── UC_Rooms.cs
│       ├── UC_Customers.cs
│       ├── UC_Staff.cs
│       └── UC_Booking.cs
├── database/
│   └── schema.sql              Creates the database from scratch
└── App.config                  Application settings (connection string)
```

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

- SQL queries are built with string concatenation and are **vulnerable to SQL injection**.
- The login screen is not connected to the application — there is currently no authentication.
- Staff passwords are stored in plain text.
- Error handling and input validation are limited.
- The room allocation operation is not protected by a transaction.
- The **Edit / Delete** buttons on the Rooms screen are not implemented.
- There is no customer check-out flow.
- Text columns use `VARCHAR` and do not support Unicode (e.g. Arabic).

---

## Roadmap

- [x] Repository setup and database schema script
- [x] Move the connection string to `App.config`
- [ ] Secure queries (`SqlParameter`) + `using` + error handling
- [ ] Input validation (`TryParse` + per-field messages)
- [ ] Transactions for booking operations
- [ ] Real login + password hashing (PBKDF2/BCrypt) + roles
- [ ] Complete the Rooms screen (Edit / Delete)
- [ ] Customer list + check-out + billing
- [ ] Implement the Bookings module
- [ ] Separate layers (Repositories / Services)
- [ ] Convert read operations to `async/await`
- [ ] Tests + continuous integration (CI)

---

## License

This project is currently for educational purposes. The final license will be determined later.
