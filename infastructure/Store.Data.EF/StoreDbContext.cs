using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF
{
    public class StoreDbContext : DbContext
    {
        public DbSet<BookDto> Books { get; set; }

        public DbSet<OrderDto> Orders { get; set; }

        public DbSet<OrderItemDto> OrderItems { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildBooks(modelBuilder);
            BuildOrders(modelBuilder);
            BuildOrderItems(modelBuilder);
        }



        private void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }




        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDto>(action =>
            {
                action.Property(dto => dto.CellPhone)
                      .HasMaxLength(20);

                action.Property(dto => dto.DeliveryUniqueCode)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryPrice)
                      .HasColumnType("money");


                //.HasMaxLength(40);
                action.Property(dto => dto.PaymentServiceName)
                      .HasColumnType("nvarchar(1000)");

                action.Property(dto => dto.DeliveryParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

                action.Property(dto => dto.PaymentParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);
            });
        }




        private static readonly ValueComparer DictionaryComparer =
                    new ValueComparer<Dictionary<string, string>>(
                        (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
                        dictionary => dictionary.Aggregate(
                            0,
                            (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
                        )
                    );



        private static void BuildBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDto>(action =>
            {
                action.Property(dto => dto.Isbn)
                .HasMaxLength(17).IsRequired();

                action.Property(dto => dto.Title).IsRequired();

                action.Property(dto => dto.Price).HasColumnType("money");


                action.HasData(
                    new BookDto
                    {
                        ID = 1,
                        Isbn = "ISBN0201029090",
                        Author = "Даниэль Куссвюрм",
                        Title = "ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ НА АССЕМБЛЕРЕ X64" +
                    "С РАСШИРЕНИЯМИ AVX, AVX2 И AVX-512",
                        Description = "Изучите язык ассемблера x64, сосредоточившись на обновлениях набора команд x86," +
                    " наиболее актуальных для разработки прикладных программ.",
                        Price = 1900,
                    },
                    new BookDto
                    {
                        ID = 2,
                        Isbn = "ISBN0321029090",
                        Author = "Роберт Нистрем",
                        Title = "ПАТТЕРНЫ ПРОГРАММИРОВАНИЯ ИГР",
                        Description = "Самый большой вызов для программиста видеоигр - закончить игру. " +
                        "Громоздкий и запутанный код часто становится неразрешимой проблемой, которая тянет проект на дно и деморализует всю команду. Об этом, как никто другой, " +
                        "знает Роберт Нистрем, восемь лет проработавший в Electronic Arts.",
                        Price = 879,
                    },
                      new BookDto
                      {
                          ID = 3,
                          Isbn = "ISBN0451029090",
                          Author = "Дэвид Флэнаган",
                          Title = "JAVASCRIPT. ПОДРОБНОЕ РУКОВОДСТВО. 6-Е ИЗД",
                          Description = "егулярно ищете в интернете сведения по Java? Разработчикам приложений " +
                          "для Web 2.0 иногда приходится несладко, ведь их профессия – одна из самых передовых",
                          Price = 1004,
                      },
                      new BookDto
                      {
                          ID = 4,
                          Isbn = "ISBN0561029090",
                          Author = "Роберт Сикорд",
                          Title = "ЭФФЕКТИВНЫЙ C. ПРОФЕССИОНАЛЬНОЕ ПРОГРАММИРОВАНИЕ",
                          Description = "Мир работает на коде, написанном на C, но в большинстве учебных заведений программированию учат на Python или Java. Книга «Эффективный " +
                          "С для профессионалов» восполняет этот пробел и предлагает современный взгляд на C. ",
                          Price = 1039,
                      },
                      new BookDto
                      {
                          ID = 5,
                          Isbn = "ISBN0661029090",
                          Author = "Билл Любанович",
                          Title = "ПРОСТОЙ PYTHON.",
                          Description = "«Простой Python» познакомит вас с одним из самых популярных языков программирования. Книга идеально подойдет как начинающим, " +
                       "так и опытным программистам, желающим добавить Python к списку освоенных языков. ",
                          Price = 1139,
                      }
                    );
            });
        }
    }
}
