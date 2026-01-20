using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Champ2026Client.Models;

public partial class User102Context : DbContext
{
    public User102Context()
    {
    }

    public User102Context(DbContextOptions<User102Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CriticalThresholdTemplate> CriticalThresholdTemplates { get; set; }

    public virtual DbSet<IssuesFound> IssuesFounds { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesToChart> SalesToCharts { get; set; }

    public virtual DbSet<ServicePriority> ServicePriorities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<VendingMachine> VendingMachines { get; set; }

    public virtual DbSet<WorkMode> WorkModes { get; set; }

    public virtual DbSet<WorksDescription> WorksDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.24.15; database=user102; user=user102; password=1234567890; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Company1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company");
        });

        modelBuilder.Entity<CriticalThresholdTemplate>(entity =>
        {
            entity.ToTable("critical_threshold_template");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Template)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("template");
        });

        modelBuilder.Entity<IssuesFound>(entity =>
        {
            entity.ToTable("issues_found");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IssueFound).HasColumnName("issue_found");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.ToTable("maintenance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IssuesFound).HasColumnName("issues_found");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.VendingMachineId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vending_machine_id");
            entity.Property(e => e.WorkDescription).HasColumnName("work_description");

            entity.HasOne(d => d.IssuesFoundNavigation).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.IssuesFound)
                .HasConstraintName("FK_maintenance_issues_found");

            entity.HasOne(d => d.User).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_maintenance_users");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.VendingMachineId)
                .HasConstraintName("FK_maintenance_vending_machines");

            entity.HasOne(d => d.WorkDescriptionNavigation).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.WorkDescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maintenance_works_description");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("models");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Model1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model");
        });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.ToTable("notification_templates");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Template)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("template");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.ToTable("operators");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Operator1)
                .HasMaxLength(15)
                .HasColumnName("operator");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("payment_methods");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PaymentMethod1)
                .HasMaxLength(15)
                .HasColumnName("payment_method");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.MinStock).HasColumnName("min_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QuantityAvailable).HasColumnName("quantity_available");
            entity.Property(e => e.SalesTrend)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sales_trend");
            entity.Property(e => e.VendingMachineId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vending_machine_id");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendingMachineId)
                .HasConstraintName("FK_products_vending_machines");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sales$");

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_payment_methods");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_products");
        });

        modelBuilder.Entity<SalesToChart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SalesToChart");

            entity.Property(e => e.SalesCount).HasColumnName("sales_count");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("total_price");
        });

        modelBuilder.Entity<ServicePriority>(entity =>
        {
            entity.ToTable("service_priorities");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ServicePriority1)
                .HasMaxLength(15)
                .HasColumnName("service_priority");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("statuses");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Status1)
                .HasMaxLength(15)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.IsEngineer).HasColumnName("is_engineer");
            entity.Property(e => e.IsManager).HasColumnName("is_manager");
            entity.Property(e => e.IsOperator).HasColumnName("is_operator");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.ToTable("user_logins");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_logins_users");
        });

        modelBuilder.Entity<VendingMachine>(entity =>
        {
            entity.ToTable("vending_machines");

            entity.HasIndex(e => e.InventNumber, "unique_invent_vending_machines").IsUnique();

            entity.HasIndex(e => e.SerialNumber, "unique_serial_vending_machines").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BillAcceptor).HasColumnName("bill_acceptor");
            entity.Property(e => e.CashlessPayment).HasColumnName("cashless_payment");
            entity.Property(e => e.CoinAcceptor).HasColumnName("coin_acceptor");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Coordinates)
                .IsUnicode(false)
                .HasColumnName("coordinates");
            entity.Property(e => e.CriticalTresholdTemplateId).HasColumnName("critical_treshold_template_id");
            entity.Property(e => e.EngineerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("engineer_id");
            entity.Property(e => e.InstallDate)
                .HasColumnType("datetime")
                .HasColumnName("install_date");
            entity.Property(e => e.InterverificationInterval).HasColumnName("interverification_interval");
            entity.Property(e => e.InventNumber).HasColumnName("invent_number");
            entity.Property(e => e.InventoryDate)
                .HasColumnType("datetime")
                .HasColumnName("inventory_date");
            entity.Property(e => e.KitOnlineId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("kit_online_id");
            entity.Property(e => e.LastMaintenanceDate)
                .HasColumnType("datetime")
                .HasColumnName("last_maintenance_date");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .HasColumnName("location");
            entity.Property(e => e.ManagerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("manager_id");
            entity.Property(e => e.ManufactureDate)
                .HasColumnType("datetime")
                .HasColumnName("manufacture_date");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NextMaintenanceDate)
                .HasComputedColumnSql("(case when [interverification_interval] IS NOT NULL then dateadd(month,[interverification_interval],[last_maintenance_date])  end)", false)
                .HasColumnType("datetime")
                .HasColumnName("next_maintenance_date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.NotificationTemplateId).HasColumnName("notification_template_id");
            entity.Property(e => e.OperatorId).HasColumnName("operator_id");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasColumnName("place");
            entity.Property(e => e.QrPayment).HasColumnName("QR_payment");
            entity.Property(e => e.RfidCashCollection)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("rfid_cash_collection");
            entity.Property(e => e.RfidLoading)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("rfid_loading");
            entity.Property(e => e.RfidService)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfid_service");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.ServicePriorityId).HasColumnName("service_priority_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SystemDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("system_date");
            entity.Property(e => e.TechnicianId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("technician_id");
            entity.Property(e => e.Timezone)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("timezone");
            entity.Property(e => e.TotalIncome)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_income");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.VmResource).HasColumnName("VM_resource");
            entity.Property(e => e.WorkModeId).HasColumnName("work_mode_id");
            entity.Property(e => e.WorkingHours)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("working_hours");

            entity.HasOne(d => d.Company).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_Companies");

            entity.HasOne(d => d.CriticalTresholdTemplate).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CriticalTresholdTemplateId)
                .HasConstraintName("FK_vending_machines_critical_threshold_template");

            entity.HasOne(d => d.Engineer).WithMany(p => p.VendingMachineEngineers)
                .HasForeignKey(d => d.EngineerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_users2");

            entity.HasOne(d => d.Manager).WithMany(p => p.VendingMachineManagers)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_users1");

            entity.HasOne(d => d.Model).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_models");

            entity.HasOne(d => d.NotificationTemplate).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.NotificationTemplateId)
                .HasConstraintName("FK_vending_machines_notification_templates");

            entity.HasOne(d => d.Operator).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.OperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_operators");

            entity.HasOne(d => d.ServicePriority).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ServicePriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_service_priorities");

            entity.HasOne(d => d.Status).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_statuses");

            entity.HasOne(d => d.Technician).WithMany(p => p.VendingMachineTechnicians)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_users3");

            entity.HasOne(d => d.User).WithMany(p => p.VendingMachineUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_users");

            entity.HasOne(d => d.WorkMode).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.WorkModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines_work_modes");
        });

        modelBuilder.Entity<WorkMode>(entity =>
        {
            entity.ToTable("work_modes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.WorkMode1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("work_mode");
        });

        modelBuilder.Entity<WorksDescription>(entity =>
        {
            entity.ToTable("works_description");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.WorkDescription).HasColumnName("work_description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
