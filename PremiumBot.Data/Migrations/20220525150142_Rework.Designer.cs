﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PremiumBot.Data;

#nullable disable

namespace PremiumBot.Data.Migrations
{
    [DbContext(typeof(BotDBContext))]
    [Migration("20220525150142_Rework")]
    partial class Rework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AchievmentUser", b =>
                {
                    b.Property<int>("AchievmentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("AchievmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AchievmentUser");
                });

            modelBuilder.Entity("PremiumBot.Data.Models.Achievment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUniq")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Achievments");
                });

            modelBuilder.Entity("PremiumBot.Data.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("PremiumBot.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactsCount")
                        .HasColumnType("int");

                    b.Property<int>("FilesCount")
                        .HasColumnType("int");

                    b.Property<int>("GeopositionsCount")
                        .HasColumnType("int");

                    b.Property<int>("ImagesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("MessagesCount")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoolsCount")
                        .HasColumnType("int");

                    b.Property<int>("ReactionsCount")
                        .HasColumnType("int");

                    b.Property<int>("RedirectCount")
                        .HasColumnType("int");

                    b.Property<int>("ReplyCount")
                        .HasColumnType("int");

                    b.Property<int>("StickersCount")
                        .HasColumnType("int");

                    b.Property<long>("TGID")
                        .HasColumnType("bigint");

                    b.Property<int?>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AchievmentUser", b =>
                {
                    b.HasOne("PremiumBot.Data.Models.Achievment", null)
                        .WithMany()
                        .HasForeignKey("AchievmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PremiumBot.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PremiumBot.Data.Models.User", b =>
                {
                    b.HasOne("PremiumBot.Data.Models.Title", null)
                        .WithMany("Users")
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("PremiumBot.Data.Models.Title", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
