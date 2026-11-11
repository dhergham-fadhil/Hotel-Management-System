# Hotel Management System

نظام إدارة فندق لسطح المكتب، مبني بـ **C# / WinForms** مع قاعدة بيانات **SQL Server** عبر **ADO.NET**.

> **الحالة:** المشروع تحت التطوير. هذه نسخة أولية (Prototype) يتم تحسينها تدريجياً — راجع قسم [خارطة التطوير](#خارطة-التطوير).

---

## الميزات الحالية

| الوحدة | الحالة |
|---|---|
| إدارة الغرف (إضافة + عرض) | ✅ |
| تخصيص غرفة لعميل (تسجيل + تحويل الحالة إلى Busy) | ✅ |
| تسجيل الموظفين + عرضهم + حذفهم | ✅ |
| تسجيل الدخول | ⚠️ واجهة فقط (غير موصولة) |
| الحجوزات | ❌ قيد التطوير |

---

## التقنيات

- **C# 7** — .NET Framework **4.7.2**
- **Windows Forms** مع مكتبة [Guna.UI2](https://www.nuget.org/packages/Guna.UI2.WinForms)
- **SQL Server** (محرك البيانات)
- **ADO.NET** (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)

---

## هيكل المشروع

```
Hotel_Managment_System/
├── Program.cs                  نقطة الدخول
├── MainHotelMenu.cs            النافذة الرئيسية + التنقل
├── Login.cs                    شاشة تسجيل الدخول (غير موصولة بعد)
├── function.cs                 طبقة الوصول إلى البيانات (مؤقتة)
├── Resources/
│   └── HotelManagment/         شاشات المستخدم (User Controls)
│       ├── UC_Rooms.cs
│       ├── UC_Customers.cs
│       ├── UC_Staff.cs
│       └── UC_Booking.cs
├── database/
│   └── schema.sql              إنشاء قاعدة البيانات من الصفر
└── App.config                  إعدادات التطبيق (سلسلة الاتصال)
```

---

## المتطلبات

1. **Windows 10/11**
2. **Visual Studio 2022** مع حزمة عمل «تطوير سطح المكتب باستخدام .NET»
3. **.NET Framework 4.7.2 Developer Pack**
4. **SQL Server** (Express أو أعلى) + **SSMS**

---

## إعداد قاعدة البيانات

1. افتح **SQL Server Management Studio** واتصل بالسيرفر المحلي.
2. افتح الملف `database/schema.sql` ونفّذه (F5).
3. سيُنشئ قاعدة `HotelDB` والجداول `Rooms` و`Customers` و`Staff` إن لم تكن موجودة.
4. لإضافة بيانات تجريبية، أزل التعليق عن قسم `INSERT` في نهاية الملف.

> قاعدة البيانات **لا تُرفع** على Git. الملف `schema.sql` هو المصدر الرسمي للبنية.

---

## الإعداد

عدّل سلسلة الاتصال في `App.config` لتطابق سيرفرك:

```xml
<connectionStrings>
  <add name="HotelDb"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

| القيمة | المعنى |
|---|---|
| `Data Source=.` | السيرفر المحلي الافتراضي |
| `Data Source=.\SQLEXPRESS` | نسخة SQL Server Express |
| `Initial Catalog=HotelDB` | اسم قاعدة البيانات |
| `Integrated Security=True` | مصادقة Windows |

---

## التشغيل

```bash
git clone <repository-url>
cd Hotel_Managment_System
```

1. افتح `Hotel_Managment_System.sln` في Visual Studio.
2. من القائمة: **Build → Restore NuGet Packages** (لاستعادة Guna.UI2).
3. اضغط **F5**.

> حزمة `packages/` غير مرفوعة؛ Visual Studio يعيد تنزيلها تلقائياً عند البناء.

---

## ملاحظات معروفة (Known Limitations)

هذه المشاكل معروفة وستُعالج بالترتيب في خارطة التطوير:

- استعلامات SQL تُبنى بدمج النصوص → **قابلة للحقن (SQL Injection)**.
- شاشة تسجيل الدخول غير موصولة بالتطبيق → لا توجد مصادقة حالياً.
- كلمات مرور الموظفين تُخزَّن كنص صريح.
- معالجة الأخطاء والتحقق من المدخلات محدودان.
- عملية «تخصيص الغرفة» غير محمية بـ Transaction.
- زرّا **Edit / Delete** في شاشة الغرف غير مفعّلين.
- لا يوجد تسجيل خروج (Check-out) للعميل.
- الأعمدة النصية `VARCHAR` لا تدعم العربية.

---

## خارطة التطوير

- [x] إعداد المستودع وسكربت قاعدة البيانات
- [x] نقل سلسلة الاتصال إلى `App.config`
- [ ] تأمين الاستعلامات (`SqlParameter`) + `using` + معالجة أخطاء
- [ ] التحقق من المدخلات (`TryParse` + رسائل لكل حقل)
- [ ] معاملات (Transactions) لعمليات الحجز
- [ ] تسجيل دخول فعلي + تشفير كلمات المرور (PBKDF2/BCrypt) + صلاحيات
- [ ] إكمال شاشة الغرف (Edit / Delete)
- [ ] قائمة العملاء + Check-out + الفوترة
- [ ] تنفيذ وحدة الحجوزات
- [ ] فصل الطبقات (Repositories / Services)
- [ ] تحويل عمليات القراءة إلى `async/await`
- [ ] اختبارات + نشر تلقائي (CI)

---

## الترخيص

هذا المشروع تعليمي حالياً. الترخيص النهائي سيُحدَّد لاحقاً.
