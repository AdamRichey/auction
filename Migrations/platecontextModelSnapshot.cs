﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Plate.Models;
using System;

namespace plate2.Migrations
{
    [DbContext(typeof(platecontext))]
    partial class platecontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Plate.Models.Auctions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bid");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<string>("Name");

                    b.Property<int?>("Personid");

                    b.Property<DateTime>("Start");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Plate.Models.Bids", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Auctionid");

                    b.Property<int?>("Personid");

                    b.Property<int>("Value");

                    b.HasKey("id");

                    b.HasIndex("Auctionid");

                    b.HasIndex("Personid");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Plate.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("First");

                    b.Property<string>("Last");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.Property<int>("Wallet");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Plate.Models.Auctions", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Auctions")
                        .HasForeignKey("Personid");
                });

            modelBuilder.Entity("Plate.Models.Bids", b =>
                {
                    b.HasOne("Plate.Models.Auctions", "Auction")
                        .WithMany("Bids")
                        .HasForeignKey("Auctionid");

                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Bids")
                        .HasForeignKey("Personid");
                });
#pragma warning restore 612, 618
        }
    }
}
