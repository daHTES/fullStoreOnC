﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.EF;

namespace Store.Data.EF.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220202182452_FullTextSearch")]
    partial class FullTextSearch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Data.BookDto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "Даниэль Куссвюрм",
                            Description = "Изучите язык ассемблера x64, сосредоточившись на обновлениях набора команд x86, наиболее актуальных для разработки прикладных программ.",
                            Isbn = "ISBN0201029090",
                            Price = 1900m,
                            Title = "ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ НА АССЕМБЛЕРЕ X64С РАСШИРЕНИЯМИ AVX, AVX2 И AVX-512"
                        },
                        new
                        {
                            ID = 2,
                            Author = "Роберт Нистрем",
                            Description = "Самый большой вызов для программиста видеоигр - закончить игру. Громоздкий и запутанный код часто становится неразрешимой проблемой, которая тянет проект на дно и деморализует всю команду. Об этом, как никто другой, знает Роберт Нистрем, восемь лет проработавший в Electronic Arts.",
                            Isbn = "ISBN0321029090",
                            Price = 879m,
                            Title = "ПАТТЕРНЫ ПРОГРАММИРОВАНИЯ ИГР"
                        },
                        new
                        {
                            ID = 3,
                            Author = "Дэвид Флэнаган",
                            Description = "егулярно ищете в интернете сведения по Java? Разработчикам приложений для Web 2.0 иногда приходится несладко, ведь их профессия – одна из самых передовых",
                            Isbn = "ISBN0451029090",
                            Price = 1004m,
                            Title = "JAVASCRIPT. ПОДРОБНОЕ РУКОВОДСТВО. 6-Е ИЗД"
                        },
                        new
                        {
                            ID = 4,
                            Author = "Роберт Сикорд",
                            Description = "Мир работает на коде, написанном на C, но в большинстве учебных заведений программированию учат на Python или Java. Книга «Эффективный С для профессионалов» восполняет этот пробел и предлагает современный взгляд на C. ",
                            Isbn = "ISBN0561029090",
                            Price = 1039m,
                            Title = "ЭФФЕКТИВНЫЙ C. ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ"
                        },
                        new
                        {
                            ID = 5,
                            Author = "Билл Любанович",
                            Description = "«Простой Python» познакомит вас с одним из самых популярных языков программирования. Книга идеально подойдет как начинающим, так и опытным программистам, желающим добавить Python к списку освоенных языков. ",
                            Isbn = "ISBN0661029090",
                            Price = 1139m,
                            Title = "ПРОСТОЙ PYTHON."
                        });
                });

            modelBuilder.Entity("Store.Data.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DeliveryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("money");

                    b.Property<string>("DeliveryUniqueCode")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentServiceName")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store.Data.OrderItemDto", b =>
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

            modelBuilder.Entity("Store.Data.OrderItemDto", b =>
                {
                    b.HasOne("Store.Data.OrderDto", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store.Data.OrderDto", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
