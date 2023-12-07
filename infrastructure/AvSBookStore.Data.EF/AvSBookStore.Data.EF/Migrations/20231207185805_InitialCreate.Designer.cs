﻿// <auto-generated />
using AvSBookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvSBookStore.Data.EF.Migrations
{
    [DbContext(typeof(AvSBookStoreDbContext))]
    [Migration("20231207185805_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AvSBookStore.Data.BookDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "D. Knuth",
                            Description = "This volume begins with basic programming concepts and techniques,then focuses more particularly on information structures-the representation of information inside a computer, the structural relationships between data elements and how to deal with them efficiently.",
                            Isbn = "ISBN0201038013",
                            Price = 7.19m,
                            Title = "Art Of Programming, Vol. 1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "M. Fowler",
                            Description = "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community.",
                            Isbn = "ISBN0201485672",
                            Price = 12.45m,
                            Title = "Refactoring"
                        },
                        new
                        {
                            Id = 3,
                            Author = "B. W. Kernighan, D. M. Ritchie",
                            Description = "Known as the bible of C, this classic bestseller introduces the C programming language and illustrates algorithms, data structures, and programming techniques.",
                            Isbn = "ISBN0131101633",
                            Price = 14.98m,
                            Title = "C Programming Language"
                        });
                });

            modelBuilder.Entity("AvSBookStore.Data.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("DeliveryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("money");

                    b.Property<string>("DeliveryUniqueCode")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentServiceName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AvSBookStore.Data.OrderItemDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("AvSBookStore.Data.OrderItemDto", b =>
                {
                    b.HasOne("AvSBookStore.Data.OrderDto", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
