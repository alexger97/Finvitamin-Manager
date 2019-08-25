﻿// <auto-generated />
using System;
using FinVitamin_Manager.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinVitamin_Manager.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinVitamin_Manager.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.Courer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime>("DateOfBirdth");

                    b.Property<bool>("HaveCar");

                    b.Property<int>("Metro");

                    b.Property<string>("Name");

                    b.Property<string>("Vk");

                    b.HasKey("Id");

                    b.ToTable("Courers");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.CourerTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourerId");

                    b.Property<int?>("InvoiceForCourerId");

                    b.Property<int>("OrderSpbId");

                    b.HasKey("Id");

                    b.HasIndex("CourerId");

                    b.HasIndex("InvoiceForCourerId");

                    b.HasIndex("OrderSpbId")
                        .IsUnique();

                    b.ToTable("CourerTasks");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.InvoiceForCourer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataForInvoice");

                    b.Property<int?>("WorkCourerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkCourerId");

                    b.ToTable("InvoiceForCourers");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.OrderProdust", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("OldCount");

                    b.Property<int?>("OrderRegionId");

                    b.Property<int?>("OrderSpbId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderRegionId");

                    b.HasIndex("OrderSpbId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProdusts");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.OrderRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdressDilivery");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<string>("Comment");

                    b.Property<string>("CustomerAdress");

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhone");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("PaymentStatus");

                    b.Property<int>("ProccessingStatus");

                    b.Property<string>("RecipientFullName");

                    b.Property<string>("RecipientTelephone");

                    b.Property<int>("SendVariant");

                    b.Property<double>("SendingCost");

                    b.Property<DateTime>("StartExecute");

                    b.Property<int>("TypeOfPacking");

                    b.Property<int>("TypeOfPayment");

                    b.HasKey("Id");

                    b.ToTable("OrdersRegion");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.OrderSpb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdressDilivery");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<string>("Comment");

                    b.Property<string>("CustomerAdress");

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhone");

                    b.Property<DateTime>("DateDilivery");

                    b.Property<double>("DelivetyCost");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("MetroStation");

                    b.Property<int>("PaymentStatus");

                    b.Property<int>("ProccessingStatus");

                    b.Property<string>("RecipientFullName");

                    b.Property<string>("RecipientTelephone");

                    b.Property<DateTime>("StartExecute");

                    b.Property<string>("TimeDilivery");

                    b.Property<int>("TypeOfDelivery");

                    b.Property<int>("TypeOfOffice");

                    b.Property<int>("TypeOfPayment");

                    b.HasKey("Id");

                    b.ToTable("OrdersSpb");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.PresenceOrderRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangeTime");

                    b.Property<int>("Count");

                    b.Property<int?>("OrderRegionId");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderRegionId");

                    b.HasIndex("ProductId");

                    b.ToTable("PresenceOrderRegion");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.PresenceOrderSpb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangeTime");

                    b.Property<int>("Count");

                    b.Property<int?>("OrderSpbId");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderSpbId");

                    b.HasIndex("ProductId");

                    b.ToTable("PresenceOrderSpb");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentBalance");

                    b.Property<string>("Decsription");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("ProviderType");

                    b.Property<double>("PurchasePrice");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.CourerTask", b =>
                {
                    b.HasOne("FinVitamin_Manager.Models.Courer", "Courer")
                        .WithMany("DiliveryOrders")
                        .HasForeignKey("CourerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinVitamin_Manager.Models.InvoiceForCourer", "InvoiceForCourer")
                        .WithMany("CourerTasks")
                        .HasForeignKey("InvoiceForCourerId");

                    b.HasOne("FinVitamin_Manager.Models.OrderSpb", "OrderSpb")
                        .WithOne("CourerTask")
                        .HasForeignKey("FinVitamin_Manager.Models.CourerTask", "OrderSpbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.InvoiceForCourer", b =>
                {
                    b.HasOne("FinVitamin_Manager.Models.Courer", "WorkCourer")
                        .WithMany()
                        .HasForeignKey("WorkCourerId");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.OrderProdust", b =>
                {
                    b.HasOne("FinVitamin_Manager.Models.OrderRegion")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderRegionId");

                    b.HasOne("FinVitamin_Manager.Models.OrderSpb")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderSpbId");

                    b.HasOne("FinVitamin_Manager.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.PresenceOrderRegion", b =>
                {
                    b.HasOne("FinVitamin_Manager.Models.OrderRegion", "OrderRegion")
                        .WithMany()
                        .HasForeignKey("OrderRegionId");

                    b.HasOne("FinVitamin_Manager.Models.Product")
                        .WithMany("PresenceOrderRegions")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("FinVitamin_Manager.Models.PresenceOrderSpb", b =>
                {
                    b.HasOne("FinVitamin_Manager.Models.OrderSpb", "OrderSpb")
                        .WithMany()
                        .HasForeignKey("OrderSpbId");

                    b.HasOne("FinVitamin_Manager.Models.Product")
                        .WithMany("PresenceOrderSpbs")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}