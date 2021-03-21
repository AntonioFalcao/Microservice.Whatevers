﻿using System;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microservice.Whatevers.Repositories.Migrations
{
    [DbContext(typeof(WhateverContext))]
    internal class WhateverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
               .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Things.Thing", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("TEXT");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("TEXT");

                b.Property<string>("Type")
                   .HasColumnType("TEXT");

                b.Property<double>("Value")
                   .HasColumnType("REAL");

                b.Property<Guid?>("WhateverId")
                   .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("WhateverId");

                b.ToTable("Thing");
            });

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Whatevers.Whatever", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("TEXT");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasColumnType("TEXT");

                b.Property<DateTime>("Time")
                   .HasColumnType("TEXT");

                b.Property<string>("Type")
                   .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Whatever");

                b.HasData(new
                    {
                        Id = new Guid("b1732550-2b45-4eee-af19-bbf34e403ed1"),
                        Name = "Whatever",
                        Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Type = "Some type"
                    },
                    new
                    {
                        Id = new Guid("34ec1b0c-e8fc-4394-8496-8a2ee0f6e6f4"),
                        Name = "Whatever",
                        Time = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                        Type = "Another type"
                    },
                    new
                    {
                        Id = new Guid("0ede8633-b422-4c46-b064-810f5b10f21e"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 5, 9, 9, 19, 2, 166, DateTimeKind.Local).AddTicks(3060),
                        Type = "More another type"
                    },
                    new
                    {
                        Id = new Guid("d002fd42-0a70-4dab-a12f-9119c643e37c"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Local),
                        Type = "Once more another type"
                    });
            });

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Things.Thing", b =>
            {
                b.HasOne("Microservice.Whatevers.Domain.Entities.Whatevers.Whatever", null)
                   .WithMany("Things")
                   .HasForeignKey("WhateverId");
            });
#pragma warning restore 612, 618
        }
    }
}