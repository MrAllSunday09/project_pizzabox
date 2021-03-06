// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    [Migration("20210428041017_second migration")]
    partial class secondmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CrustEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SizeEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("CrustEntityId");

                    b.HasIndex("SizeEntityId");

                    b.ToTable("Pizzas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("APizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Stores");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AStore");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.ToTable("Crust");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Thin",
                            Price = 3m
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Original",
                            Price = 5m
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Brooklyn",
                            Price = 7m
                        },
                        new
                        {
                            EntityId = 7L,
                            Name = "Stuffed",
                            Price = 10m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Daniel Henderson"
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Fred Belotte"
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Azhya Knox"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CustomersEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PizzaEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("StoreEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("CustomersEntityId");

                    b.HasIndex("PizzaEntityId");

                    b.HasIndex("StoreEntityId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Small",
                            Price = 3m
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Medium",
                            Price = 5m
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Large",
                            Price = 7m
                        },
                        new
                        {
                            EntityId = 7L,
                            Name = "X-Large",
                            Price = 12m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Toppings", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("APizzaEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("APizzaEntityId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.HasIndex("APizzaEntityId");

                    b.HasIndex("APizzaEntityId1");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Bacon",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Sausage",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Chicken",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 4L,
                            Name = "Spinach",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 5L,
                            Name = "Peppers",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 6L,
                            Name = "Pepperoni",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 7L,
                            Name = "Ham",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 8L,
                            Name = "Pineapple",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 9L,
                            Name = "Mushrooms",
                            Price = 1m
                        },
                        new
                        {
                            EntityId = 10L,
                            Name = "Onion",
                            Price = 1m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza.BuildYourOwn", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("BuildYourOwn");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            CrustEntityId = 1L,
                            SizeEntityId = 1L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza.MeatLovers", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("MeatLovers");

                    b.HasData(
                        new
                        {
                            EntityId = 2L,
                            CrustEntityId = 2L,
                            SizeEntityId = 2L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza.VeggiePizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("VeggiePizza");

                    b.HasData(
                        new
                        {
                            EntityId = 3L,
                            CrustEntityId = 3L,
                            SizeEntityId = 3L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Stores.Dominos", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("Dominos");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Chitown Main Street"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Stores.PizzaHut", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("PizzaHut");

                    b.HasData(
                        new
                        {
                            EntityId = 2L,
                            Name = "Big Apple"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersEntityId");

                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaEntityId");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Pizza");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Toppings", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("APizzaEntityId");

                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany()
                        .HasForeignKey("APizzaEntityId1");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
