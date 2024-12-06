﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hacaton.DataAccess;

#nullable disable

namespace hacaton.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hacaton.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OverTimeHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<int>("VacationLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("attendances");
                });

            modelBuilder.Entity("hacaton.Models.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("BonusPercentage")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HorkyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MonthlyMaxHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("hacaton.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("hacaton.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AttendanceId")
                        .HasColumnType("int");

                    b.Property<double>("Bonus")
                        .HasColumnType("float");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId1")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Paswword")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId");

                    b.HasIndex("DepartmentId1");

                    b.ToTable("employess");
                });

            modelBuilder.Entity("hacaton.Models.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Bonus")
                        .HasColumnType("float");

                    b.Property<int>("Deductions")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("months")
                        .HasColumnType("int");

                    b.Property<DateTime>("year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("payrolls");
                });

            modelBuilder.Entity("hacaton.Models.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("vacationRequests");
                });

            modelBuilder.Entity("hacaton.Models.Attendance", b =>
                {
                    b.HasOne("hacaton.Models.Employees", null)
                        .WithMany("attendances")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("hacaton.Models.Contracts", b =>
                {
                    b.HasOne("hacaton.Models.Employees", null)
                        .WithMany("contracts")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("hacaton.Models.Employees", b =>
                {
                    b.HasOne("hacaton.Models.Attendance", "Attendance")
                        .WithMany()
                        .HasForeignKey("AttendanceId");

                    b.HasOne("hacaton.Models.Department", "Department")
                        .WithMany("employees")
                        .HasForeignKey("DepartmentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendance");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("hacaton.Models.Payroll", b =>
                {
                    b.HasOne("hacaton.Models.Employees", null)
                        .WithMany("Payrolls")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("hacaton.Models.VacationRequest", b =>
                {
                    b.HasOne("hacaton.Models.Employees", null)
                        .WithMany("VacationRequests")
                        .HasForeignKey("EmployeesId");
                });

            modelBuilder.Entity("hacaton.Models.Department", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("hacaton.Models.Employees", b =>
                {
                    b.Navigation("Payrolls");

                    b.Navigation("VacationRequests");

                    b.Navigation("attendances");

                    b.Navigation("contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
