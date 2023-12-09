using Healthcare.API.Entities;
using Healthcare.API.Entities.Procedures;
using Healthcare.API.Entities.Views;
using HealthCareAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.API.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<MedicalVideo> MedicalVideos { get; set; }

    public DbSet<PatientWithAppointmentModel> PatientWithAppointmentModels { get; set; }

    public DbSet<MedicinesSuppliedByModel> MedicinesSupplieds { get; set; }

    public DbSet<PateintsByFullNameModel> PateintsByFullNames { get; set; }

    public DbSet<GetPatientPrescriptionModel> PatientPrescriptions { get; set; }

    public DbSet<PatientWithCheckupCostByFullNameModel> PatientWithCheckupCosts { get; set; }

    public DbSet<PatientCareAgendaModel> PatientCareAgendas { get; set; }

    public DbSet<EmployeeModel> EmployeeModels { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BirthdayCelebration> BirthdayCelebrations { get; set; }

    public virtual DbSet<CurrentAppointment> CurrentAppointments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeLoginInfo> EmployeeLoginInfos { get; set; }

    public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

    public virtual DbSet<ExpiringMedicine> ExpiringMedicines { get; set; }

    public virtual DbSet<GetAgesForHiredEmployee> GetAgesForHiredEmployees { get; set; }

    public virtual DbSet<GetEmployeesWithDepartment> GetEmployeesWithDepartments { get; set; }

    public virtual DbSet<GetMedicinesWithDosage> GetMedicinesWithDosages { get; set; }

    public virtual DbSet<GetMedicinesWithDosagesAndSupplier> GetMedicinesWithDosagesAndSuppliers { get; set; }

    public virtual DbSet<GetMinAndMaxQuantityForMedicine> GetMinAndMaxQuantityForMedicines { get; set; }

    public virtual DbSet<GetMinAndMaxUnitPriceForMedicine> GetMinAndMaxUnitPriceForMedicines { get; set; }

    public virtual DbSet<GetPaidAppointment> GetPaidAppointments { get; set; }

    public virtual DbSet<GetPateint> GetPateints { get; set; }

    public virtual DbSet<GetPatientsWithAppointment> GetPatientsWithAppointments { get; set; }

    public virtual DbSet<GetSuppliersWithMedicinesProvided> GetSuppliersWithMedicinesProvideds { get; set; }

    public virtual DbSet<GetVipsuppliersWithMedicinesProvided> GetVipsuppliersWithMedicinesProvideds { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<LowStockMedicine> LowStockMedicines { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineDosage> MedicineDosages { get; set; }

    public virtual DbSet<MedicineInfo> MedicineInfos { get; set; }

    public virtual DbSet<MedicineStock> MedicineStocks { get; set; }

    public virtual DbSet<OutOfStockMedicine> OutOfStockMedicines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientsPrescription> PatientsPrescriptions { get; set; }

    public virtual DbSet<PatientsWithCheckupCost> PatientsWithCheckupCosts { get; set; }

    public virtual DbSet<PharmacyTransaction> PharmacyTransactions { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<ReorderMedicine> ReorderMedicines { get; set; }

    public virtual DbSet<ShowPatientPrescription> ShowPatientPrescriptions { get; set; }

    public virtual DbSet<ShowSchedule> ShowSchedules { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierPerformance> SupplierPerformances { get; set; }

    public virtual DbSet<TopSalaryEmployee> TopSalaryEmployees { get; set; }

    public virtual DbSet<UpcomingAppointment> UpcomingAppointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC228E5D0AF");

            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("UNPAID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Appointme__Emplo__5070F446");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Patie__52593CB8");
        });

        modelBuilder.Entity<BirthdayCelebration>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BirthdayCelebrations");

            entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CurrentAppointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CurrentAppointments");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDA4AD119B");

            entity.Property(e => e.DepartmentCost).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11191FE1B4");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Depar__4D94879B");
        });

        modelBuilder.Entity<EmployeeLoginInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeeLoginInfo");

            entity.Property(e => e.AuthCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeePerformanceSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeePerformanceSummary");

            entity.Property(e => e.Employee)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeSchedule>(entity =>
        {
            entity.HasKey(e => e.SchedualId).HasName("PK__Employee__CDE6B9A8748C3EA4");

            entity.ToTable("EmployeeSchedule");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSchedules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeS__Emplo__5812160E");
        });

        modelBuilder.Entity<ExpiringMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExpiringMedicines");

            entity.Property(e => e.ExpiryStatus)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.MedicineId).ValueGeneratedOnAdd();
            entity.Property(e => e.MedicineName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetAgesForHiredEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetAgesForHiredEmployees");

            entity.Property(e => e.Employee)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetEmployeesWithDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetEmployeesWithDepartments");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Employee)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetMedicinesWithDosage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetMedicinesWithDosages");

            entity.Property(e => e.Dosage)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<GetMedicinesWithDosagesAndSupplier>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetMedicinesWithDosagesAndSuppliers");

            entity.Property(e => e.Dosage)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<GetMedicinesWithUnitPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetMedicinesWithUnitPrices");

            entity.Property(e => e.Medicine)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<GetMinAndMaxQuantityForMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetMinAndMaxQuantityForMedicine");

            entity.Property(e => e.Medicine)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetMinAndMaxUnitPriceForMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetMinAndMaxUnitPriceForMedicine");

            entity.Property(e => e.Medicine)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<GetPaidAppointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetPaidAppointments");

            entity.Property(e => e.DepartmentCost).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Doctor)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Patient)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetPateint>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetPateints");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetPatientsWithAppointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetPatientsWithAppointments");

            entity.Property(e => e.DepartmentCost).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Doctor)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Patient)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetSuppliersWithMedicinesProvided>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetSuppliersWithMedicinesProvided");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetTotalAppointmentsForDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetTotalAppointmentsForDepartments");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetTotalCheckupCostForDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetTotalCheckupCostForDepartments");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalCost).HasColumnType("money");
        });

        modelBuilder.Entity<GetVipsuppliersWithMedicinesProvided>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetVIPSuppliersWithMedicinesProvided");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logins__3214EC07A0AA5376");

            entity.Property(e => e.AuthCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Logins)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Logins__Employee__5535A963");
        });

        modelBuilder.Entity<LowStockMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LowStockMedicines");

            entity.Property(e => e.MedicineName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StockStatus)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedicalVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalV__3214EC07A7C802AB");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.MedicalVideos)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__MedicalVi__Depar__6ABAD62E")
                .IsRequired(false);
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PK__Medicine__4F21289038354E59");

            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<MedicineDosage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Dosage)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Medicine).WithMany()
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__MedicineD__Medic__619B8048");
        });

        modelBuilder.Entity<MedicineInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MedicineInfo");

            entity.Property(e => e.MedicineInfo1)
                .HasMaxLength(97)
                .IsUnicode(false)
                .HasColumnName("MedicineInfo");
        });

        modelBuilder.Entity<MedicineStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MedicineStock");

            entity.Property(e => e.MedicineName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<MonthlyRevenueAnalysis>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MonthlyRevenueAnalysis");

            entity.Property(e => e.MonthlyRevenue).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<OutOfStockMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OutOfStockMedicines");

            entity.Property(e => e.MedicineName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3661468F9EE");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientAppointmentHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientAppointmentHistory");

            entity.Property(e => e.PatientName)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientPrescriptionHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientPrescriptionHistory");

            entity.Property(e => e.Diagnosis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.PrescribedMedicines)
                .HasMaxLength(8000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientsPrescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC2741211F63");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dosage)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MedicineName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Times)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Prescription).WithMany(p => p.PatientsPrescriptions)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK__PatientsP__Presc__5DCAEF64");
        });

        modelBuilder.Entity<PatientsWithCheckupCost>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PatientsWithCheckupCosts");

            entity.Property(e => e.CostOfDiagnosis).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Doctor)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Patient)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PharmacyTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Pharmacy__55433A6BE6ACA721");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();

            entity.HasOne(d => d.Medicine).WithMany(p => p.PharmacyTransactions)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__PharmacyT__Medic__6E01572D");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PharmacyTransactions)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK__PharmacyT__Presc__6D0D32F4");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__4013083216D4672B");

            entity.Property(e => e.Diagnosis)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Prescript__Patie__5AEE82B9");
        });

        modelBuilder.Entity<ReorderMedicine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReorderMedicines");

            entity.Property(e => e.MedicineName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ReorderStatus)
                .HasMaxLength(19)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShowEmployeeSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ShowEmployeeSchedule");

            entity.Property(e => e.Days)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("DAYS");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Schedule)
                .HasMaxLength(8000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShowPatientPrescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ShowPatientPrescriptions");

            entity.Property(e => e.Diagnosis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Doctor)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Dosage)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MedicineName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Patient)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Times)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShowSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ShowSchedule");

            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Employee)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Stocks__2C83A9C2E8B12AE2");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__Stocks__Medicine__6477ECF3");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4FD25ADC6");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasMany(d => d.Medicines).WithMany(p => p.Suppliers)
                .UsingEntity<Dictionary<string, object>>(
                    "SuppliersMedicine",
                    r => r.HasOne<Medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Suppliers__Medic__6A30C649"),
                    l => l.HasOne<Supplier>().WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Suppliers__Suppl__693CA210"),
                    j =>
                    {
                        j.HasKey("SupplierId", "MedicineId").HasName("PK__Supplier__5F14743D3E133EE8");
                        j.ToTable("SuppliersMedicines");
                    });
        });

        modelBuilder.Entity<SupplierPerformance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SupplierPerformance");

            entity.Property(e => e.SupplierName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TopSalaryEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TopSalaryEmployees");

            entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<UpcomingAppointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UpcomingAppointments");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Paid)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(101)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public async Task<int> ExecuteAddAppointmentAsync(int employeeId, string? firstName,
        string? lastName,
        string? gender,
        string? phone,
        string? email
    )
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddAppointment @employeeId, @firstName, @lastName, @gender, @phone, @email",
            new SqlParameter("@employeeId", employeeId),
            new SqlParameter("@firstName", firstName),
            new SqlParameter("@lastName", lastName),
            new SqlParameter("@gender", gender),
            new SqlParameter("@phone", phone),
            new SqlParameter("@email", email));
    }


    public async Task<int> ExecuteAddDepartmentAsync(string? departmentName,
        decimal departmentCost)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddDepartment @DepartmentName, @DepartmentCost",
            new SqlParameter("@DepartmentName", departmentName),
            new SqlParameter("@DepartmentCost", departmentCost)
        );
    }

    public async Task<int> ExecuteAddEmployeeToDepartmentAsync(int departmentId,
        string? firstName,
        string? lastName,
        string? gender,
        string? jobTitle,
        string? phone,
        decimal salary,
        DateTime dateOfBirth)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddEmployeeToDepartment @DepartmentId," +
            " @FirstName, @LastName, @Gender, @JobTitle, @HireDate, @Salary, @Phone, @DateOfBirth",
                new SqlParameter("@DepartmentId", departmentId),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Gender", gender),
                new SqlParameter("@JobTitle", jobTitle),
                new SqlParameter("@HireDate", DateTime.Now),
                new SqlParameter("@Salary", salary),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@DateOfBirth", dateOfBirth)
        );
    }

    // New
    public async Task<int> ExecuteAddNewMedicineAsync(string? name,
        DateTime expireDate, int stockQuantity, decimal unitPrice, int currentQuantity)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddNewMedicine @Name, @ExpireDate, " +
            "@StockQuantity, @UnitPrice, @CurrentQuantity",
                new SqlParameter("@Name", name),
                new SqlParameter("@ExpireDate", expireDate),
                new SqlParameter("@StockQuantity", stockQuantity),
                new SqlParameter("@UnitPrice", unitPrice),
                new SqlParameter("@CurrentQuantity", currentQuantity)
         );
    }


    public async Task<int> ExecuteAddEmployeeToScheduleAsync(int dayOfWeek,
           TimeOnly startTime,
           TimeOnly endTime,
           string firstName,
           string lastName,
           string gender,
           string jobTitle,
           decimal salary,
           string phone,
           DateTime dateOfBirth,
       int departmentId)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddEmployeeToSchedual @DayOfWeek, " +
            "@StartTime, @EndTime, @FirstName, @LastName, @Gender, @JobTitle, @Salary, " +
            "@Phone, @DateOfBirth, @DepartmentId",
                new SqlParameter("@DayOfWeek", dayOfWeek),
                new SqlParameter("@StartTime", startTime),
                new SqlParameter("@EndTime", endTime),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Gender", gender),
                new SqlParameter("@JobTitle", jobTitle),
                new SqlParameter("@Salary", salary),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@DepartmentId", departmentId)
         );
    }


    public async Task<int> ExecuteAddPatientAsync(string? firstName, string? lastName,
       string? gender, string? phone, string? email)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.AddPateint @FirstName, @LastName, " +
            "@Gender, @Phone, @Email",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Gender", gender),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Email", email)
         );
    }

    public async Task<int> ExecuteGenerateAuthCodeAsync(string? authCodeOut)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.GenerateAuthCode @AuthCodeOut OUTPUT",
                new SqlParameter("@AuthCodeOut", authCodeOut)
         );
    }

    public Task<IQueryable<PatientWithAppointmentModel>> ExecuteGetAppointmentFor(string? fullName)
    {
        var data = PatientWithAppointmentModels.FromSqlRaw($"EXEC dbo.GetAppointmentFor @FullName",
            new SqlParameter("@FullName", fullName));

        return Task.FromResult(data);

    }

    public Task<IQueryable<MedicinesSuppliedByModel>> ExecuteGetMedicinesSuppliedBy(int supplierId)
    {
        var data = MedicinesSupplieds.FromSqlRaw("EXEC dbo.GetMedicinesSuppliedBy @SupplierId",
            new SqlParameter("@SupplierId", supplierId));

        return Task.FromResult(data);
    }

    public Task<IQueryable<PateintsByFullNameModel>> ExecuteGetPateintsByFullName(string fullName)
    {
        var data = PateintsByFullNames.FromSqlRaw("EXEC dbo.GetPateintsByFullName @FullName",
                new SqlParameter("@FullName", fullName));

        return Task.FromResult(data);
    }

    public Task<IQueryable<GetPatientPrescriptionModel>> ExecuteGetPatientPrescription(int prescriptionId)
    {
        var data = PatientPrescriptions.FromSqlRaw("EXEC dbo.GetPatientPrescription @PrescriptionId",
                new SqlParameter("@PrescriptionId", prescriptionId));

        return Task.FromResult(data);

    }

    public Task<IQueryable<PatientWithCheckupCostByFullNameModel>> ExecuteGetPatientWithCheckupCostByFullName(string? fullName)
    {
        var data = PatientWithCheckupCosts.FromSqlRaw("EXEC dbo.GetPatientWithCheckupCostByFullName @FullName",
                new SqlParameter("@FullName", fullName));

        return Task.FromResult(data);

    }

    public Task<IQueryable<PatientCareAgendaModel>> ExecutePatientCareAgenda(int employeeId)
    {
        var data = PatientCareAgendas.FromSqlRaw("EXEC dbo.PatientCareAgenda @EmployeeId",
                new SqlParameter("@EmployeeId", employeeId));

        return Task.FromResult(data);

    }

    // edit
    public async Task<int> ExecuteRecordMedicineSaleAsync(
        int prescriptionId,
        int medicineId,
        int quantitySold,
        DateTime trasactionDate)
    {
        return await Database.ExecuteSqlRawAsync("EXEC dbo.RecordMedicineSale @PrescriptionId " +
            " ,@MedicineId, @QuantitySold, @TransactionDate",
                new SqlParameter("@EmployeeId", prescriptionId),
                new SqlParameter("@MedicineId", medicineId),
                new SqlParameter("@QuantitySold", quantitySold),
                new SqlParameter("@TransactionDate", trasactionDate)
        );
    }


    public Task<IQueryable<EmployeeModel>> ExecuteSearchDoctorBy(string doctorName)
    {
        var data = EmployeeModels.FromSqlRaw("EXEC dbo.SearchDoctorBy @DoctorName ",
                new SqlParameter("@DoctorName", doctorName));

        return Task.FromResult(data);

    }

    public Task<IQueryable<EmployeeModel>> ExecuteSearchEmployeeBy(string employeeName)
    {
        var data = EmployeeModels.FromSqlRaw("EXEC dbo.SearchEmployeeBy @EmployeeName ",
                new SqlParameter("@EmployeeName", employeeName));
        return Task.FromResult(data);
    }

    public Task<int> ExecuteUpdateEmployeeSalaryAsync(int employeeId,
        decimal newSalary)
    {
        var result = Database.ExecuteSqlRaw("EXEC dbo.UpdateEmployeeSalary @EmployeeId, @NewSalary",
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@NewSalary", newSalary));

        return Task.FromResult(result);

    }

    public Task<int> ExecuteUpdatePaymentStatusForPatientAsync(int appointmentId)
    {
        var result = Database.ExecuteSqlRaw("EXEC dbo.UpdatePaymentStatusForPatient @AppointmentId",
                new SqlParameter("@AppointmentId", appointmentId)
        );

        return Task.FromResult(result);
    }
}
