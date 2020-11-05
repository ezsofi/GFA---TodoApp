﻿// <auto-generated />
using System;
using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201105134257_postgre")]
    partial class postgre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("EntityFramework.Model.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("AssigneeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("DueAtet")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("EntityFramework.Models.Assignee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("EntityFramework.Model.Todo", b =>
                {
                    b.HasOne("EntityFramework.Models.Assignee", "Assignee")
                        .WithMany("Todos")
                        .HasForeignKey("AssigneeId");

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("EntityFramework.Models.Assignee", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}