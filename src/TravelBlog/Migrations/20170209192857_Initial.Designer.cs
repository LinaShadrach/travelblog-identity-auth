using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelBlog.Models;

namespace TravelBlog.Migrations
{
    [DbContext(typeof(TravelBlogContext))]
    [Migration("20170209192857_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExperienceDescription");

                    b.Property<string>("ExperienceImage");

                    b.Property<string>("ExperienceName");

                    b.Property<int>("LocationId");

                    b.Property<int>("PersonId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocationDescription");

                    b.Property<string>("LocationImage");

                    b.Property<string>("LocationName");

                    b.Property<int>("PersonId");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExperienceId");

                    b.Property<int?>("LocationId");

                    b.Property<string>("PersonDescription");

                    b.Property<string>("PersonImage");

                    b.Property<string>("PersonName");

                    b.HasKey("PersonId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.HasOne("TravelBlog.Models.Location", "Location")
                        .WithMany("Experiences")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience", "Experience")
                        .WithMany("People")
                        .HasForeignKey("ExperienceId");

                    b.HasOne("TravelBlog.Models.Location", "Location")
                        .WithMany("People")
                        .HasForeignKey("LocationId");
                });
        }
    }
}
