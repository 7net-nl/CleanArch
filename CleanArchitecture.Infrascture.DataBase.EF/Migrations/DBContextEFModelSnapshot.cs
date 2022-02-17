﻿// <auto-generated />
using CleanArchitecture.Infrascture.DataBase.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrascture.DataBase.EF.Migrations
{
    [DbContext(typeof(DBContextEF))]
    partial class DBContextEFModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.TodoItem", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<long>("TodoList_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TodoList_ID");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.TodoList", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.TodoList", null)
                        .WithMany("TodoItems")
                        .HasForeignKey("TodoList_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.TodoList", b =>
                {
                    b.Navigation("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
