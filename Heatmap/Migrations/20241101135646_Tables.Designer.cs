﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Heatmap.Data;

#nullable disable

namespace Heatmap.Migrations
{
    [DbContext(typeof(HeatmapDbContext))]
    [Migration("20241101135646_Tables")]
    partial class Tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Position_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<int>("Height")
                        .HasColumnType("int")
                        .HasColumnName("Height");

                    b.Property<int>("SectionId")
                        .HasColumnType("int")
                        .HasColumnName("Section_id");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Section_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<int>("ElementType")
                        .HasColumnType("int")
                        .HasColumnName("Element_type");

                    b.Property<string>("HtmlElement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Html_element");

                    b.Property<int>("SiteId")
                        .HasColumnType("int")
                        .HasColumnName("Site_id");

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Site_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteId"));

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Site_url");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("Subject_id");

                    b.HasKey("SiteId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Subject_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subject_name");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("VisibilityInfo", b =>
                {
                    b.Property<int>("VisibilityInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Visibility_info_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisibilityInfoId"));

                    b.Property<decimal>("LastVisibleTime")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("Last_visible_time");

                    b.Property<int>("SectionId")
                        .HasColumnType("int")
                        .HasColumnName("Section_id");

                    b.Property<decimal>("TotalVisibleTime")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("Total_visible_time");

                    b.HasKey("VisibilityInfoId");

                    b.ToTable("VisibilityInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
