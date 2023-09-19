﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesListApi.Data;

#nullable disable

namespace MoviesListApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230918231147_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("MoviesListApi.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PreferencesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PreferencesId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAvailableUntil")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Released")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Preferences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Theme")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MoviesListApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Category", b =>
                {
                    b.HasOne("MoviesListApi.Entities.Preferences", null)
                        .WithMany("FavoriteCategories")
                        .HasForeignKey("PreferencesId");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Metadata", b =>
                {
                    b.HasOne("MoviesListApi.Entities.Movie", "Movie")
                        .WithMany("Metadata")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Movie", b =>
                {
                    b.HasOne("MoviesListApi.Entities.User", null)
                        .WithMany("FavoritesMovies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Preferences", b =>
                {
                    b.HasOne("MoviesListApi.Entities.User", "User")
                        .WithOne("Preferences")
                        .HasForeignKey("MoviesListApi.Entities.Preferences", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Tag", b =>
                {
                    b.HasOne("MoviesListApi.Entities.Movie", "Movie")
                        .WithMany("Tags")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Movie", b =>
                {
                    b.Navigation("Metadata");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MoviesListApi.Entities.Preferences", b =>
                {
                    b.Navigation("FavoriteCategories");
                });

            modelBuilder.Entity("MoviesListApi.Entities.User", b =>
                {
                    b.Navigation("FavoritesMovies");

                    b.Navigation("Preferences");
                });
#pragma warning restore 612, 618
        }
    }
}
