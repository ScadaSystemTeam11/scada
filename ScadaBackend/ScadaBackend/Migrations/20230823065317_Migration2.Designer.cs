﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScadaBackend.Data;

#nullable disable

namespace ScadaBackend.Migrations
{
    [DbContext(typeof(ScadaContext))]
    [Migration("20230823065317_Migration2")]
    partial class Migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScadaBackend.Models.Alarm", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AnalogInputID")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<Guid>("TagID")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("ValueLimit")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("AnalogInputID");

                    b.ToTable("Alarms", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.AlarmAlert", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AlarmID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("AlarmID");

                    b.ToTable("AlarmAlerts", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.AnalogInput", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("CurrentValue")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("HighLimit")
                        .HasColumnType("real");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<float>("LowLimit")
                        .HasColumnType("real");

                    b.Property<bool>("OnOffScan")
                        .HasColumnType("boolean");

                    b.Property<float>("ScanTime")
                        .HasColumnType("real");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AnalogInput", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.AnalogOutput", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("CurrentValue")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("HighLimit")
                        .HasColumnType("real");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("InitialValue")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<float>("LowLimit")
                        .HasColumnType("real");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AnalogOutput", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.DigitalInput", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("CurrentValue")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("OnOffScan")
                        .HasColumnType("boolean");

                    b.Property<float>("ScanTime")
                        .HasColumnType("real");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("DigitalInput", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.DigitalOutput", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("CurrentValue")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("InitialValue")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("DigitalOutput", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.TagChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TagChange", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ScadaBackend.Models.Alarm", b =>
                {
                    b.HasOne("ScadaBackend.Models.AnalogInput", null)
                        .WithMany("Alarms")
                        .HasForeignKey("AnalogInputID");
                });

            modelBuilder.Entity("ScadaBackend.Models.AlarmAlert", b =>
                {
                    b.HasOne("ScadaBackend.Models.Alarm", "Alarm")
                        .WithMany()
                        .HasForeignKey("AlarmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alarm");
                });

            modelBuilder.Entity("ScadaBackend.Models.AnalogInput", b =>
                {
                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
