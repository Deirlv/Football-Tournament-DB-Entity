﻿// <auto-generated />
using FootBallTournament.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootBallTournament.DAL.Migrations
{
    [DbContext(typeof(FootBallTournamentContext))]
    [Migration("20240207173034_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootBallTournament.DAL.Standing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DrawGamesCount")
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
#pragma warning restore 612, 618
        }
    }
}