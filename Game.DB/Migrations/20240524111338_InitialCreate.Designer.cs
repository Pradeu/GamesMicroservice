﻿// <auto-generated />
using System;
using Game.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Game.DB.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20240524111338_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Game.DB.Entities.DbGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Developer")
                        .HasColumnType("text")
                        .HasColumnName("developer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer")
                        .HasColumnName("releaseYear");

                    b.HasKey("Id")
                        .HasName("pK_games");

                    b.ToTable("games", (string)null);
                });

            modelBuilder.Entity("Game.DB.Entities.DbGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pK_genres");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("Game.DB.Entities.DbPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pK_platforms");

                    b.ToTable("platforms", (string)null);
                });

            modelBuilder.Entity("GenreGames", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genreId");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.HasKey("GenreId", "GameId")
                        .HasName("pK_genreGames");

                    b.HasIndex("GameId")
                        .HasDatabaseName("iX_genreGames_gameId");

                    b.ToTable("genreGames", (string)null);
                });

            modelBuilder.Entity("PlatformGames", b =>
                {
                    b.Property<int>("PlatformId")
                        .HasColumnType("integer")
                        .HasColumnName("platformId");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.HasKey("PlatformId", "GameId")
                        .HasName("pK_platformGames");

                    b.HasIndex("GameId")
                        .HasDatabaseName("iX_platformGames_gameId");

                    b.ToTable("platformGames", (string)null);
                });

            modelBuilder.Entity("GenreGames", b =>
                {
                    b.HasOne("Game.DB.Entities.DbGame", "Game")
                        .WithMany("GenreGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_genreGames_games_gameId");

                    b.HasOne("Game.DB.Entities.DbGenre", "Genre")
                        .WithMany("GenreGames")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_genreGames_genres_genreId");

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PlatformGames", b =>
                {
                    b.HasOne("Game.DB.Entities.DbGame", "Game")
                        .WithMany("PlatformGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_platformGames_games_gameId");

                    b.HasOne("Game.DB.Entities.DbPlatform", "Platform")
                        .WithMany("PlatformGames")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_platformGames_platforms_platformId");

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Game.DB.Entities.DbGame", b =>
                {
                    b.Navigation("GenreGames");

                    b.Navigation("PlatformGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbGenre", b =>
                {
                    b.Navigation("GenreGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbPlatform", b =>
                {
                    b.Navigation("PlatformGames");
                });
#pragma warning restore 612, 618
        }
    }
}
