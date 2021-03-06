// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Borrow", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<int>("DocumentFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LimitDate")
                        .HasColumnType("datetime");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<DateTime?>("ReminderDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime");

                    b.HasKey("ClientFK", "DocumentFK", "BorrowDate");

                    b.HasIndex("DocumentFK");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contribution")
                        .HasColumnType("text");

                    b.Property<double>("DurationCoef")
                        .HasColumnType("double");

                    b.Property<int>("NbrBorrowsMax")
                        .HasColumnType("int");

                    b.Property<double>("RateCoef")
                        .HasColumnType("double");

                    b.Property<bool>("ReductionCodeEnable")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("CategoryFK")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("MediaLibraryFK")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReductionCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.HasKey("ClientId");

                    b.HasIndex("CategoryFK");

                    b.HasIndex("MediaLibraryFK");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Domain.Document", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<int?>("MediaLibraryKey")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.HasIndex("MediaLibraryKey");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Domain.MediaLibrary", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("MediaLibraries");
                });

            modelBuilder.Entity("Domain.Audio", b =>
                {
                    b.HasBaseType("Domain.Document");

                    b.Property<string>("Classification")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.HasBaseType("Domain.Document");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("NbrPage")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Video", b =>
                {
                    b.HasBaseType("Domain.Document");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("LegalNotice")
                        .HasColumnType("text");

                    b.Property<int>("MovieDuration")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Domain.Borrow", b =>
                {
                    b.HasOne("Domain.Client", "Client")
                        .WithMany("Borrows")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Document", "Document")
                        .WithMany("Borrows")
                        .HasForeignKey("DocumentFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Clients")
                        .HasForeignKey("CategoryFK")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.MediaLibrary", "MediaLibrary")
                        .WithMany("Clients")
                        .HasForeignKey("MediaLibraryFK");

                    b.Navigation("Category");

                    b.Navigation("MediaLibrary");
                });

            modelBuilder.Entity("Domain.Document", b =>
                {
                    b.HasOne("Domain.MediaLibrary", "MediaLibrary")
                        .WithMany("Documents")
                        .HasForeignKey("MediaLibraryKey");

                    b.Navigation("MediaLibrary");
                });

            modelBuilder.Entity("Domain.Audio", b =>
                {
                    b.HasOne("Domain.Document", null)
                        .WithOne()
                        .HasForeignKey("Domain.Audio", "Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.HasOne("Domain.Document", null)
                        .WithOne()
                        .HasForeignKey("Domain.Book", "Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Video", b =>
                {
                    b.HasOne("Domain.Document", null)
                        .WithOne()
                        .HasForeignKey("Domain.Video", "Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("Domain.Document", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("Domain.MediaLibrary", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
