﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250720160158_SeedDemoData")]
    partial class SeedDemoData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Policy", b =>
                {
                    b.Property<string>("PolicyId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PolicyType")
                        .HasColumnType("int");

                    b.HasKey("PolicyId");

                    b.ToTable("PolicyTable");

                    b.HasData(
                        new
                        {
                            PolicyId = "P1",
                            CreatedDateTime = new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDefault = true,
                            IsEnabled = true,
                            PolicyName = "DefaultPolicy",
                            PolicyType = 0
                        },
                        new
                        {
                            PolicyId = "P2",
                            CreatedDateTime = new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDefault = false,
                            IsEnabled = false,
                            PolicyName = "StrictPolicy",
                            PolicyType = 1
                        });
                });

            modelBuilder.Entity("DAL.Models.PolicyUserGroup", b =>
                {
                    b.Property<string>("PolicyId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PolicyId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("PolicyUserGroups");

                    b.HasData(
                        new
                        {
                            PolicyId = "P1",
                            GroupId = "admins"
                        },
                        new
                        {
                            PolicyId = "P2",
                            GroupId = "reviewers"
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            UserId = "qais",
                            CreatedDateTime = new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = true,
                            Username = "Qais"
                        },
                        new
                        {
                            UserId = "ali",
                            CreatedDateTime = new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = true,
                            Username = "Ali"
                        },
                        new
                        {
                            UserId = "mehdi",
                            CreatedDateTime = new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = true,
                            Username = "Mehdi"
                        },
                        new
                        {
                            UserId = "farah",
                            CreatedDateTime = new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = false,
                            Username = "Farah"
                        },
                        new
                        {
                            UserId = "sara",
                            CreatedDateTime = new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = true,
                            Username = "Sara"
                        },
                        new
                        {
                            UserId = "ahmad",
                            CreatedDateTime = new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = true,
                            Username = "Ahmad"
                        },
                        new
                        {
                            UserId = "sulaiman",
                            CreatedDateTime = new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEnabled = false,
                            Username = "Sulaiman"
                        });
                });

            modelBuilder.Entity("DAL.Models.UserGroup", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("GroupId");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            GroupId = "admins",
                            Description = "Administrators"
                        },
                        new
                        {
                            GroupId = "reviewers",
                            Description = "Request Reviewers"
                        });
                });

            modelBuilder.Entity("DAL.Models.UserRequest", b =>
                {
                    b.Property<long>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RequestId"));

                    b.Property<DateTime?>("CompletionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RequestCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("RequestedBy");

                    b.ToTable("UserRequests");

                    b.HasData(
                        new
                        {
                            RequestId = 1L,
                            CompletionDateTime = new DateTime(2025, 7, 8, 9, 5, 0, 0, DateTimeKind.Unspecified),
                            Description = "Initial system setup",
                            RequestCode = 100,
                            RequestDateTime = new DateTime(2025, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "qais",
                            Status = 2
                        },
                        new
                        {
                            RequestId = 2L,
                            Description = "Documentation review",
                            RequestCode = 101,
                            RequestDateTime = new DateTime(2025, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "ali",
                            Status = 1
                        },
                        new
                        {
                            RequestId = 3L,
                            Description = "Feature design",
                            RequestCode = 102,
                            RequestDateTime = new DateTime(2025, 7, 9, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "mehdi",
                            Status = 0
                        },
                        new
                        {
                            RequestId = 4L,
                            CompletionDateTime = new DateTime(2025, 7, 9, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            Description = "Performance audit",
                            RequestCode = 103,
                            RequestDateTime = new DateTime(2025, 7, 9, 10, 15, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "farah",
                            Status = 3
                        },
                        new
                        {
                            RequestId = 5L,
                            Description = "Security scan",
                            RequestCode = 104,
                            RequestDateTime = new DateTime(2025, 7, 10, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "sara",
                            Status = 4
                        },
                        new
                        {
                            RequestId = 6L,
                            CompletionDateTime = new DateTime(2025, 7, 10, 11, 10, 0, 0, DateTimeKind.Unspecified),
                            Description = "User training",
                            RequestCode = 105,
                            RequestDateTime = new DateTime(2025, 7, 10, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "ahmad",
                            Status = 2
                        },
                        new
                        {
                            RequestId = 7L,
                            Description = "Final review",
                            RequestCode = 106,
                            RequestDateTime = new DateTime(2025, 7, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            RequestedBy = "sulaiman",
                            Status = 1
                        });
                });

            modelBuilder.Entity("DAL.Models.UserUserGroup", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserUserGroups");

                    b.HasData(
                        new
                        {
                            UserId = "qais",
                            GroupId = "admins"
                        },
                        new
                        {
                            UserId = "ali",
                            GroupId = "reviewers"
                        },
                        new
                        {
                            UserId = "mehdi",
                            GroupId = "reviewers"
                        },
                        new
                        {
                            UserId = "farah",
                            GroupId = "admins"
                        },
                        new
                        {
                            UserId = "sara",
                            GroupId = "reviewers"
                        },
                        new
                        {
                            UserId = "ahmad",
                            GroupId = "admins"
                        },
                        new
                        {
                            UserId = "sulaiman",
                            GroupId = "reviewers"
                        });
                });

            modelBuilder.Entity("DAL.Models.PolicyUserGroup", b =>
                {
                    b.HasOne("DAL.Models.UserGroup", "Group")
                        .WithMany("Policies")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Policy", "Policy")
                        .WithMany("Groups")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("DAL.Models.UserRequest", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserRequests")
                        .HasForeignKey("RequestedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserUserGroup", b =>
                {
                    b.HasOne("DAL.Models.UserGroup", "Group")
                        .WithMany("UserUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Policy", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("UserGroups");

                    b.Navigation("UserRequests");
                });

            modelBuilder.Entity("DAL.Models.UserGroup", b =>
                {
                    b.Navigation("Policies");

                    b.Navigation("UserUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
