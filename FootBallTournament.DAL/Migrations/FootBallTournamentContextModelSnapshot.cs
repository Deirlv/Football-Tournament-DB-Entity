﻿// <auto-generated />
using System;
using FootBallTournament.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootBallTournament.DAL.Migrations
{
    [DbContext(typeof(FootBallTournamentContext))]
    partial class FootBallTournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StandingId")
                        .HasColumnType("int");

                    b.Property<int>("Team1Goals")
                        .HasColumnType("int");

                    b.Property<int>("Team1Id")
                        .HasColumnType("int");

                    b.Property<int>("Team2Goals")
                        .HasColumnType("int");

                    b.Property<int>("Team2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StandingId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Standing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DrawGamesCount")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("GoalsMissed")
                        .HasColumnType("int");

                    b.Property<int>("LosesCount")
                        .HasColumnType("int");

                    b.Property<string>("TeamCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VictoriesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Standings");
                });

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Match", b =>
                {
                    b.HasOne("FootBallTournament.DAL.Entities.Standing", null)
                        .WithMany("Matches")
                        .HasForeignKey("StandingId");

                    b.HasOne("FootBallTournament.DAL.Entities.Standing", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FootBallTournament.DAL.Entities.Standing", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Player", b =>
                {
                    b.HasOne("FootBallTournament.DAL.Entities.Standing", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootBallTournament.DAL.Entities.Standing", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
