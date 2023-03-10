// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TMS1.Migrations
{
    [DbContext(typeof(TMS1Context))]
    partial class TMS1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TMS1.Models.Allocate", b =>
                {
                    b.Property<int>("AllocatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllocatId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AllocatId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RouteId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Allocate");
                });

            modelBuilder.Entity("TMS1.Models.EmployeeInfo", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("EmployeeAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("RouteId");

                    b.HasIndex("VehicleId");

                    b.ToTable("EmployeeInfo");
                });

            modelBuilder.Entity("TMS1.Models.RouteInfo", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<string>("stop1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stop2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.ToTable("RouteInfo");
                });

            modelBuilder.Entity("TMS1.Models.Transport", b =>
                {
                    b.Property<string>("EmployeeAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<string>("stop1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stop2")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Transport");
                });

            modelBuilder.Entity("TMS1.Models.VehicleInfo", b =>
                {
                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeatAvailablity")
                        .HasColumnType("int");

                    b.Property<int>("VehicleCapacity")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("VehicleInfo");
                });

            modelBuilder.Entity("TMS1.Models.Allocate", b =>
                {
                    b.HasOne("TMS1.Models.EmployeeInfo", "EmployeeInfo")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS1.Models.RouteInfo", "RouteInfo")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS1.Models.VehicleInfo", "VehicleInfo")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("EmployeeInfo");

                    b.Navigation("RouteInfo");

                    b.Navigation("VehicleInfo");
                });

            modelBuilder.Entity("TMS1.Models.EmployeeInfo", b =>
                {
                    b.HasOne("TMS1.Models.RouteInfo", "RouteInfo")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS1.Models.VehicleInfo", "VehicleInfo")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteInfo");

                    b.Navigation("VehicleInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
