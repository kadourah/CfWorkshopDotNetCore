using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CfWorkshopDotNetCore.Models;

namespace CfWorkshopDotNetCore.Migrations
{
    [DbContext(typeof(CfWorkshopContext))]
    [Migration("20170903202808_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("CfWorkshopDotNetCore.Models.Note", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Note");
                });
        }
    }
}
