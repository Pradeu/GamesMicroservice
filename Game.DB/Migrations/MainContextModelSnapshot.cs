﻿// <auto-generated />
using System;
using Game.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Game.DB.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeveloperGames", b =>
                {
                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer")
                        .HasColumnName("developerId");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.HasKey("DeveloperId", "GameId")
                        .HasName("pK_developerGames");

                    b.HasIndex("GameId")
                        .HasDatabaseName("iX_developerGames_gameId");

                    b.ToTable("developerGames", (string)null);
                });

            modelBuilder.Entity("EngineGames", b =>
                {
                    b.Property<int>("EngineId")
                        .HasColumnType("integer")
                        .HasColumnName("engineId");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.HasKey("EngineId", "GameId")
                        .HasName("pK_engineGames");

                    b.HasIndex("GameId")
                        .HasDatabaseName("iX_engineGames_gameId");

                    b.ToTable("engineGames", (string)null);
                });

            modelBuilder.Entity("Game.DB.Entities.DbDeveloper", b =>
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
                        .HasName("pK_developers");

                    b.ToTable("developers", (string)null);
                });

            modelBuilder.Entity("Game.DB.Entities.DbEngine", b =>
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
                        .HasName("pK_engines");

                    b.ToTable("engines", (string)null);
                });

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer")
                        .HasColumnName("releaseYear");

                    b.Property<float>("Score")
                        .HasColumnType("real")
                        .HasColumnName("score");

                    b.Property<int>("ScoresCount")
                        .HasColumnType("integer")
                        .HasColumnName("scoresCount");

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

            modelBuilder.Entity("Game.DB.Entities.DbUserList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("statusId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.Property<int>("UserScore")
                        .HasColumnType("integer")
                        .HasColumnName("userScore");

                    b.HasKey("Id")
                        .HasName("pK_userLists");

                    b.HasIndex("GameId")
                        .HasDatabaseName("iX_userLists_gameId");

                    b.HasIndex("StatusId")
                        .HasDatabaseName("iX_userLists_statusId");

                    b.ToTable("userLists", (string)null);
                });

            modelBuilder.Entity("Game.DB.Entities.DbUserStatus", b =>
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
                        .HasName("pK_gameStatuses");

                    b.ToTable("gameStatuses", (string)null);
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

            modelBuilder.Entity("DeveloperGames", b =>
                {
                    b.HasOne("Game.DB.Entities.DbDeveloper", "Developer")
                        .WithMany("DeveloperGames")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_developerGames_developers_developerId");

                    b.HasOne("Game.DB.Entities.DbGame", "Game")
                        .WithMany("DeveloperGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_developerGames_games_gameId");

                    b.Navigation("Developer");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("EngineGames", b =>
                {
                    b.HasOne("Game.DB.Entities.DbEngine", "Engine")
                        .WithMany("EngineGames")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_engineGames_engines_engineId");

                    b.HasOne("Game.DB.Entities.DbGame", "Game")
                        .WithMany("EngineGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_engineGames_games_gameId");

                    b.Navigation("Engine");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Game.DB.Entities.DbUserList", b =>
                {
                    b.HasOne("Game.DB.Entities.DbGame", "Game")
                        .WithMany("UserLists")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_userLists_games_gameId");

                    b.HasOne("Game.DB.Entities.DbUserStatus", "UserStatus")
                        .WithMany("UserLists")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_userLists_gameStatuses_userStatusId");

                    b.Navigation("Game");

                    b.Navigation("UserStatus");
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

            modelBuilder.Entity("Game.DB.Entities.DbDeveloper", b =>
                {
                    b.Navigation("DeveloperGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbEngine", b =>
                {
                    b.Navigation("EngineGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbGame", b =>
                {
                    b.Navigation("DeveloperGames");

                    b.Navigation("EngineGames");

                    b.Navigation("GenreGames");

                    b.Navigation("PlatformGames");

                    b.Navigation("UserLists");
                });

            modelBuilder.Entity("Game.DB.Entities.DbGenre", b =>
                {
                    b.Navigation("GenreGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbPlatform", b =>
                {
                    b.Navigation("PlatformGames");
                });

            modelBuilder.Entity("Game.DB.Entities.DbUserStatus", b =>
                {
                    b.Navigation("UserLists");
                });
#pragma warning restore 612, 618
        }
    }
}
