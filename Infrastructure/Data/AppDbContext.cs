using System;
using System.Collections.Generic;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountMembership> AccountMemberships { get; set; }

    public virtual DbSet<BlogBookmark> BlogBookmarks { get; set; }

    public virtual DbSet<BlogLike> BlogLikes { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Fetus> Fetus { get; set; }

    public virtual DbSet<FetusRecord> FetusRecords { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<MembershipPlan> MembershipPlans { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Pregnancy> Pregnancies { get; set; }

    public virtual DbSet<PregnancyStandard> PregnancyStandards { get; set; }

    public virtual DbSet<ScheduleTemplate> ScheduleTemplates { get; set; }

    public virtual DbSet<ScheduleUser> ScheduleUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PrenatalCareDB;User ID=sa;Password=p@ssw0rd12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__B19D4181E6D80687");

            entity.ToTable("Account");

            entity.HasIndex(e => e.AccountEmail, "UQ__Account__B0FBAC0B76D66C43").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.AccountEmail)
                .HasMaxLength(255)
                .HasColumnName("Account_email");
            entity.Property(e => e.AccountExternalProvider)
                .HasMaxLength(255)
                .HasColumnName("Account_external_provider");
            entity.Property(e => e.AccountFullName)
                .HasMaxLength(255)
                .HasColumnName("Account_full_Name");
            entity.Property(e => e.AccountIsExternal).HasColumnName("Account_is_external");
            entity.Property(e => e.AccountPassword)
                .HasMaxLength(255)
                .HasColumnName("Account_password");
            entity.Property(e => e.AccountPhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Account_phone_Number");
            entity.Property(e => e.AccountRole)
                .HasMaxLength(50)
                .HasColumnName("Account_role");
            entity.Property(e => e.AccountStatus)
                .HasMaxLength(50)
                .HasColumnName("Account_status");
            entity.Property(e => e.AccountUserName)
                .HasMaxLength(255)
                .HasColumnName("Account_user_name");
        });

        modelBuilder.Entity<AccountMembership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Account___CAE49DDDD124E295");

            entity.ToTable("Account_membership");

            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.AccountMembershipEndDate).HasColumnName("Account_membership_end_date");
            entity.Property(e => e.AccountMembershipPaymentAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Account_membership_payment_amount");
            entity.Property(e => e.AccountMembershipPaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("Account_membership_payment_status");
            entity.Property(e => e.AccountMembershipStartDate).HasColumnName("Account_membership_start_date");
            entity.Property(e => e.MembershipPlanId).HasColumnName("Membership_plan_id");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethod_id");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountMemberships)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Account_m__Accou__3E52440B");

            entity.HasOne(d => d.MembershipPlan).WithMany(p => p.AccountMemberships)
                .HasForeignKey(d => d.MembershipPlanId)
                .HasConstraintName("FK__Account_m__Membe__3F466844");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.AccountMemberships)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Account_m__Payme__403A8C7D");
        });

        modelBuilder.Entity<BlogBookmark>(entity =>
        {
            entity.HasKey(e => e.BlogBookmarkId).HasName("PK__Blog_boo__43525A61FF49F9B7");

            entity.ToTable("Blog_bookmark");

            entity.Property(e => e.BlogBookmarkId).HasColumnName("Blog_bookmark_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.HasOne(d => d.Account).WithMany(p => p.BlogBookmarks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Blog_book__Accou__49C3F6B7");

            entity.HasOne(d => d.Post).WithMany(p => p.BlogBookmarks)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Blog_book__post___4AB81AF0");
        });

        modelBuilder.Entity<BlogLike>(entity =>
        {
            entity.HasKey(e => e.BlogLikeId).HasName("PK__Blog_lik__3AE47BBD3B5A12F5");

            entity.ToTable("Blog_like");

            entity.Property(e => e.BlogLikeId).HasColumnName("Blog_like_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.HasOne(d => d.Account).WithMany(p => p.BlogLikes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Blog_like__Accou__45F365D3");

            entity.HasOne(d => d.Post).WithMany(p => p.BlogLikes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Blog_like__post___46E78A0C");
        });

        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.HasKey(e => e.BlogPostId).HasName("PK__Blog_pos__3FD703BF2215DB12");

            entity.ToTable("Blog_post");

            entity.Property(e => e.BlogPostId).HasColumnName("Blog_post_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BlogPostDescription).HasColumnName("Blog_post_description");
            entity.Property(e => e.BlogPostPeriod).HasColumnName("Blog_post_period");
            entity.Property(e => e.BlogPostStatus)
                .HasMaxLength(50)
                .HasColumnName("Blog_post_status");
            entity.Property(e => e.BlogPostTitle)
                .HasMaxLength(255)
                .HasColumnName("Blog_post_title");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.PublishedDay).HasColumnName("published_day");

            entity.HasOne(d => d.Author).WithMany(p => p.BlogPosts)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Blog_post__autho__4316F928");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__99D3E6C3D63E3607");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("Comment_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.BlogPostId).HasColumnName("Blog_post_id");
            entity.Property(e => e.CommentContent).HasColumnName("Comment_Content");
            entity.Property(e => e.CommentStatus)
                .HasMaxLength(50)
                .HasColumnName("Comment_Status");
            entity.Property(e => e.ReplyId).HasColumnName("Reply_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Comment__Account__5EBF139D");

            entity.HasOne(d => d.BlogPost).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BlogPostId)
                .HasConstraintName("FK__Comment__Blog_po__5FB337D6");
        });

        modelBuilder.Entity<Fetus>(entity =>
        {
            entity.HasKey(e => e.FetusId).HasName("PK__Fetus__96EDA214CAE93AE6");

            entity.Property(e => e.FetusId).HasColumnName("Fetus_id");
            entity.Property(e => e.FetusGender)
                .HasMaxLength(50)
                .HasColumnName("Fetus_gender");
            entity.Property(e => e.FetusName)
                .HasMaxLength(100)
                .HasColumnName("Fetus_name");
            entity.Property(e => e.PregnancyId).HasColumnName("Pregnancy_id");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.Fetus)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fetus__Pregnancy__52593CB8");
        });

        modelBuilder.Entity<FetusRecord>(entity =>
        {
            entity.HasKey(e => e.FetusRecordId).HasName("PK__Fetus_Re__11E3575A53073C5A");

            entity.ToTable("Fetus_Record");

            entity.Property(e => e.FetusRecordId).HasColumnName("Fetus_Record_id");
            entity.Property(e => e.FetusId).HasColumnName("Fetus_id");
            entity.Property(e => e.FetusRecordBpd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fetus_Record_BPD");
            entity.Property(e => e.FetusRecordDate).HasColumnName("Fetus_Record_date");
            entity.Property(e => e.FetusRecordHc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fetus_Record_HC");
            entity.Property(e => e.FetusRecordInputPeriod).HasColumnName("Fetus_Record_Input_Period");
            entity.Property(e => e.FetusRecordLength)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fetus_Record_Length");
            entity.Property(e => e.FetusRecordPeriod).HasColumnName("Fetus_Record_period");
            entity.Property(e => e.FetusRecordWeight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fetus_Record_Weight");

            entity.HasOne(d => d.Fetus).WithMany(p => p.FetusRecords)
                .HasForeignKey(d => d.FetusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fetus_Rec__Fetus__5812160E");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__278CBDD3306DF944");

            entity.Property(e => e.MediaId).HasColumnName("Media_id");
            entity.Property(e => e.MediaType)
                .HasMaxLength(50)
                .HasColumnName("Media_Type");
            entity.Property(e => e.MediaUrl).HasColumnName("Media_Url");
        });

        modelBuilder.Entity<MembershipPlan>(entity =>
        {
            entity.HasKey(e => e.MembershipPlanId).HasName("PK__Membersh__0A7DEA252D21EF31");

            entity.ToTable("Membership_plan");

            entity.Property(e => e.MembershipPlanId).HasColumnName("Membership_plan_id");
            entity.Property(e => e.MembershipPlanDescription).HasColumnName("Membership_plan_description");
            entity.Property(e => e.MembershipPlanName)
                .HasMaxLength(255)
                .HasColumnName("Membership_plan_name");
            entity.Property(e => e.MembershipPlanPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Membership_plan_price");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__88E7F3CF02F10FFB");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethod_id");
            entity.Property(e => e.PaymentMethodDescription).HasColumnName("PaymentMethod_description");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(100)
                .HasColumnName("PaymentMethod_name");
            entity.Property(e => e.PaymentMethodVia)
                .HasMaxLength(50)
                .HasColumnName("PaymentMethod_via");
        });

        modelBuilder.Entity<Pregnancy>(entity =>
        {
            entity.HasKey(e => e.PregnancyId).HasName("PK__Pregnanc__9BB559697F079801");

            entity.ToTable("Pregnancy");

            entity.Property(e => e.PregnancyId).HasColumnName("Pregnancy_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.PregnancyEndDate).HasColumnName("Pregnancy_end_date");
            entity.Property(e => e.PregnancyStartDate).HasColumnName("Pregnancy_start_date");
            entity.Property(e => e.PregnancyStatus)
                .HasMaxLength(50)
                .HasColumnName("Pregnancy_status");
            entity.Property(e => e.PregnancyType)
                .HasMaxLength(255)
                .HasColumnName("Pregnancy_type");

            entity.HasOne(d => d.Account).WithMany(p => p.Pregnancies)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Pregnancy__Accou__4F7CD00D");
        });

        modelBuilder.Entity<PregnancyStandard>(entity =>
        {
            entity.HasKey(e => e.PregnancyStandardId).HasName("PK__Pregnanc__41CCD437465B1D33");

            entity.ToTable("Pregnancy_Standard");

            entity.Property(e => e.PregnancyStandardId).HasColumnName("Pregnancy_Standard_id");
            entity.Property(e => e.PregnancyStandardMaximum)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pregnancy_Standard_maximum");
            entity.Property(e => e.PregnancyStandardMinimum)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pregnancy_Standard_minimum");
            entity.Property(e => e.PregnancyStandardPeriod).HasColumnName("Pregnancy_Standard_period");
            entity.Property(e => e.PregnancyStandardType)
                .HasMaxLength(50)
                .HasColumnName("Pregnancy_Standard_type");
            entity.Property(e => e.PregnancyStandardUnit)
                .HasMaxLength(50)
                .HasColumnName("Pregnancy_Standard_unit");
            entity.Property(e => e.PregnancyType)
                .HasMaxLength(255)
                .HasColumnName("Pregnancy_type");
        });

        modelBuilder.Entity<ScheduleTemplate>(entity =>
        {
            entity.HasKey(e => e.ScheduleTemplateId).HasName("PK__Schedule__112A0476673B8984");

            entity.ToTable("Schedule_Template");

            entity.Property(e => e.ScheduleTemplateId).HasColumnName("Schedule_Template_id");
            entity.Property(e => e.ScheduleTemplateDescription).HasColumnName("Schedule_Template_Description");
            entity.Property(e => e.ScheduleTemplatePeriod).HasColumnName("Schedule_Template_Period");
            entity.Property(e => e.ScheduleTemplateTitle)
                .HasMaxLength(255)
                .HasColumnName("Schedule_Template_Title");
            entity.Property(e => e.ScheduleTemplateType)
                .HasMaxLength(50)
                .HasColumnName("Schedule_Template_Type");
        });

        modelBuilder.Entity<ScheduleUser>(entity =>
        {
            entity.HasKey(e => e.ScheduleUserId).HasName("PK__Schedule__CEFD2C9D4493D2A9");

            entity.ToTable("Schedule_User");

            entity.Property(e => e.ScheduleUserId).HasColumnName("Schedule_User_id");
            entity.Property(e => e.PregnancyId).HasColumnName("Pregnancy_id");
            entity.Property(e => e.ScheduleUserDate).HasColumnName("Schedule_User_date");
            entity.Property(e => e.ScheduleUserNote).HasColumnName("Schedule_User_note");
            entity.Property(e => e.ScheduleUserStatus)
                .HasMaxLength(50)
                .HasColumnName("Schedule_User_status");
            entity.Property(e => e.ScheduleUserTitle)
                .HasMaxLength(255)
                .HasColumnName("Schedule_User_title");
            entity.Property(e => e.ScheduleUserType)
                .HasMaxLength(50)
                .HasColumnName("Schedule_User_type");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.ScheduleUsers)
                .HasForeignKey(d => d.PregnancyId)
                .HasConstraintName("FK__Schedule___Pregn__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
