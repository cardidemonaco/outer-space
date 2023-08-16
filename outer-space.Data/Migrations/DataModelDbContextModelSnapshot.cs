﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using outer_space.Data;

#nullable disable

namespace outer_space.Data.Migrations
{
    [DbContext(typeof(DataModelDbContext))]
    partial class DataModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("outer_space.Data.Tables.Galaxy", b =>
                {
                    b.Property<int>("GalaxyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalaxyID"));

                    b.Property<string>("GalaxyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GalaxyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalaxyID");

                    b.ToTable("Galaxies");
                });
#pragma warning restore 612, 618
        }
    }
}
