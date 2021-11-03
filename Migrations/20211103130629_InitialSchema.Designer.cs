﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using todo_rest_api;

namespace todo_rest_api.Migrations
{
    [DbContext(typeof(TaskListContext))]
    [Migration("20211103130629_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("todo_rest_api.Model.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("task_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool?>("Done")
                        .HasColumnType("boolean")
                        .HasColumnName("done");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("due_date");

                    b.Property<int>("TaskListId")
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("TaskId")
                        .HasName("pk_tasks");

                    b.HasIndex("TaskListId")
                        .HasDatabaseName("ix_tasks_task_list_id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("todo_rest_api.Model.TaskList", b =>
                {
                    b.Property<int>("TaskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("TaskListId")
                        .HasName("pk_task_lists");

                    b.ToTable("task_lists");
                });

            modelBuilder.Entity("todo_rest_api.Model.Task", b =>
                {
                    b.HasOne("todo_rest_api.Model.TaskList", null)
                        .WithMany("Tasks")
                        .HasForeignKey("TaskListId")
                        .HasConstraintName("fk_tasks_task_lists_task_list_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("todo_rest_api.Model.TaskList", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
