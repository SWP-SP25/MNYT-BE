﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250217135332_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ExternalProvider")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("External_provider");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Full_Name");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsExternal")
                        .HasColumnType("bit")
                        .HasColumnName("Is_external");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("User_name");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__B19D418153C218A9");

                    b.HasIndex(new[] { "Email" }, "UQ__Account__A9D10534C1B03E34")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.AccountMembership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("membership_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("End_date");

                    b.Property<int?>("MembershipPlanId")
                        .HasColumnType("int")
                        .HasColumnName("Membership_plan_id");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Payment_amount");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Payment_method");

                    b.Property<string>("PaymentStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Payment_status");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("Start_date");

                    b.Property<string>("TransactionCode")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Transaction_code");

                    b.HasKey("MembershipId")
                        .HasName("PK__Account___CAE49DDDAE6AC4FE");

                    b.HasIndex("AccountId");

                    b.HasIndex("MembershipPlanId");

                    b.ToTable("Account_membership", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.BlogBookmark", b =>
                {
                    b.Property<int>("BlogBookmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Blog_bookmark_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogBookmarkId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.HasKey("BlogBookmarkId")
                        .HasName("PK__Blog_boo__43525A619F3E70B6");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("Blog_bookmark", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.BlogLike", b =>
                {
                    b.Property<int>("BlogLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Blog_like_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogLikeId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.HasKey("BlogLikeId")
                        .HasName("PK__Blog_lik__3AE47BBD432EF71A");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("Blog_like", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Blog_post_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogPostId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("PublishedDay")
                        .HasColumnType("date")
                        .HasColumnName("published_day");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BlogPostId")
                        .HasName("PK__Blog_pos__3FD703BF2C193ECB");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blog_post", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Comment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int")
                        .HasColumnName("Blog_post_id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReplyId")
                        .HasColumnType("int")
                        .HasColumnName("Reply_id");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CommentId")
                        .HasName("PK__Comment__99D3E6C3A6984A5C");

                    b.HasIndex("AccountId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.FetusRecord", b =>
                {
                    b.Property<int>("FetusRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Fetus_Record_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FetusRecordId"));

                    b.Property<decimal?>("Bpd")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("BPD");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("FetusId")
                        .HasColumnType("int")
                        .HasColumnName("Fetus_Id");

                    b.Property<decimal?>("Hc")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("HC");

                    b.Property<int?>("InputPeriod")
                        .HasColumnType("int")
                        .HasColumnName("Input_Period");

                    b.Property<decimal?>("Length")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<int?>("PregnancyId")
                        .HasColumnType("int")
                        .HasColumnName("Pregnancy_id");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("FetusRecordId")
                        .HasName("PK__Fetus_Re__11E3575A507B3844");

                    b.HasIndex("PregnancyId");

                    b.ToTable("Fetus_Record", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Medium", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Media_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"));

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaId")
                        .HasName("PK__Media__278CBDD334309D6C");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Infrastructure.Models.MembershipPlan", b =>
                {
                    b.Property<int>("MembershipPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Membership_plan_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipPlanId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("MembershipPlanId")
                        .HasName("PK__Membersh__0A7DEA259F8CD130");

                    b.ToTable("Membership_plan", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Payment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    b.Property<string>("Method")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransactionCode")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Transaction_code");

                    b.Property<string>("Via")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId")
                        .HasName("PK__Payment__DA638B192282CC45");

                    b.HasIndex("AccountId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Pregnancy", b =>
                {
                    b.Property<int>("PregnancyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pregnancy_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PregnancyId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_id");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("End_date");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("Start_date");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PregnancyId")
                        .HasName("PK__Pregnanc__9BB559690F4E4C0D");

                    b.HasIndex("AccountId");

                    b.ToTable("Pregnancy", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.PregnancyStandard", b =>
                {
                    b.Property<int>("PregnancyStandardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pregnancy_Standard_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PregnancyStandardId"));

                    b.Property<decimal?>("Maximum")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Minimum")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PregnancyStandardId")
                        .HasName("PK__Pregnanc__41CCD4377106EC7A");

                    b.ToTable("Pregnancy_Standard", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.ScheduleTemplate", b =>
                {
                    b.Property<int>("ScheduleTemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Schedule_Template_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleTemplateId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ScheduleTemplateId")
                        .HasName("PK__Schedule__112A047641EEFD5D");

                    b.ToTable("Schedule_Template", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.ScheduleUser", b =>
                {
                    b.Property<int>("ScheduleUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Schedule_User_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleUserId"));

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PregnancyId")
                        .HasColumnType("int")
                        .HasColumnName("Pregnancy_id");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ScheduleUserId")
                        .HasName("PK__Schedule__CEFD2C9D1F53F754");

                    b.ToTable("Schedule_User", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.AccountMembership", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("AccountMemberships")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Account_m__Accou__3C69FB99");

                    b.HasOne("Infrastructure.Models.MembershipPlan", "MembershipPlan")
                        .WithMany("AccountMemberships")
                        .HasForeignKey("MembershipPlanId")
                        .HasConstraintName("FK__Account_m__Membe__3D5E1FD2");

                    b.Navigation("Account");

                    b.Navigation("MembershipPlan");
                });

            modelBuilder.Entity("Infrastructure.Models.BlogBookmark", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("BlogBookmarks")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Blog_book__accou__49C3F6B7");

                    b.HasOne("Infrastructure.Models.BlogPost", "Post")
                        .WithMany("BlogBookmarks")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__Blog_book__post___4AB81AF0");

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Infrastructure.Models.BlogLike", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("BlogLikes")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Blog_like__Accou__45F365D3");

                    b.HasOne("Infrastructure.Models.BlogPost", "Post")
                        .WithMany("BlogLikes")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__Blog_like__post___46E78A0C");

                    b.Navigation("Account");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Infrastructure.Models.BlogPost", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Author")
                        .WithMany("BlogPosts")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK__Blog_post__autho__4316F928");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Infrastructure.Models.Comment", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("Comments")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Comment__Account__5AEE82B9");

                    b.HasOne("Infrastructure.Models.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .HasConstraintName("FK__Comment__Blog_po__5BE2A6F2");

                    b.Navigation("Account");

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("Infrastructure.Models.FetusRecord", b =>
                {
                    b.HasOne("Infrastructure.Models.Pregnancy", "Pregnancy")
                        .WithMany("FetusRecords")
                        .HasForeignKey("PregnancyId")
                        .HasConstraintName("FK__Fetus_Rec__Pregn__5441852A");

                    b.Navigation("Pregnancy");
                });

            modelBuilder.Entity("Infrastructure.Models.Payment", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("Payments")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Payment__Account__403A8C7D");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Infrastructure.Models.Pregnancy", b =>
                {
                    b.HasOne("Infrastructure.Models.Account", "Account")
                        .WithMany("Pregnancies")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Pregnancy__Accou__5165187F");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Infrastructure.Models.Account", b =>
                {
                    b.Navigation("AccountMemberships");

                    b.Navigation("BlogBookmarks");

                    b.Navigation("BlogLikes");

                    b.Navigation("BlogPosts");

                    b.Navigation("Comments");

                    b.Navigation("Payments");

                    b.Navigation("Pregnancies");
                });

            modelBuilder.Entity("Infrastructure.Models.BlogPost", b =>
                {
                    b.Navigation("BlogBookmarks");

                    b.Navigation("BlogLikes");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Infrastructure.Models.MembershipPlan", b =>
                {
                    b.Navigation("AccountMemberships");
                });

            modelBuilder.Entity("Infrastructure.Models.Pregnancy", b =>
                {
                    b.Navigation("FetusRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
