﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostManager.DAL.Contexts;

namespace PostManager.DAL.Migrations
{
    [DbContext(typeof(FeedContext))]
    [Migration("20190628090400_StartingPoint3")]
    partial class StartingPoint3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PostManager.DAL.Entities.Feed", b =>
                {
                    b.Property<int>("FeedId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RelatedToUser");

                    b.HasKey("FeedId");

                    b.HasIndex("RelatedToUser")
                        .IsUnique();

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("PostManager.DAL.Entities.FeedPost", b =>
                {
                    b.Property<int>("FeedId");

                    b.Property<int>("PostId");

                    b.HasKey("FeedId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("FeedPost");
                });

            modelBuilder.Entity("PostManager.DAL.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PostManager.DAL.Entities.FeedPost", b =>
                {
                    b.HasOne("PostManager.DAL.Entities.Feed", "Feed")
                        .WithMany("Posts")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PostManager.DAL.Entities.Post", "Post")
                        .WithMany("Feeds")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
