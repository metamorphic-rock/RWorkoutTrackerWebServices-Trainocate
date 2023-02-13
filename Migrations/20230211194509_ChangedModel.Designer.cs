﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using workoutTrackerServices.Data;

#nullable disable

namespace workoutTrackerServices.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230211194509_ChangedModel")]
    partial class ChangedModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("workoutTrackerServices.Models.ExerciseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseItems");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.SetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("SetItems");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.WorkoutItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkoutTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutItems");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.ExerciseItem", b =>
                {
                    b.HasOne("workoutTrackerServices.Models.WorkoutItem", "Workout")
                        .WithMany("ExerciseItems")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.SetItem", b =>
                {
                    b.HasOne("workoutTrackerServices.Models.ExerciseItem", "Exercise")
                        .WithMany("SetItems")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("workoutTrackerServices.Models.WorkoutItem", "workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("workout");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.ExerciseItem", b =>
                {
                    b.Navigation("SetItems");
                });

            modelBuilder.Entity("workoutTrackerServices.Models.WorkoutItem", b =>
                {
                    b.Navigation("ExerciseItems");
                });
#pragma warning restore 612, 618
        }
    }
}