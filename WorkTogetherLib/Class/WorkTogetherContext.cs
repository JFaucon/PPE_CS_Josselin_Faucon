using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkTogetherLib.Class;

public partial class WorkTogetherContext : DbContext
{
    public WorkTogetherContext()
    {
    }

    public WorkTogetherContext(DbContextOptions<WorkTogetherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baie> Baies { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<Forfait> Forfaits { get; set; }

    public virtual DbSet<MessengerMessage> MessengerMessages { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Unite> Unites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.193.50.3;User Id=sa;Password=sql2022;Database=Worktogether;Integrated Security=False;Trusted_Connection=False;TrustServerCertificate=True;");
    //Server=localhost;Database=WorkTogether;Trusted_Connection=True;TrustServerCertificate=True;
    //Server=10.193.50.3;User Id=sa;Password=sql2022;Database=Worktogether;Integrated Security=False;Trusted_Connection=False;TrustServerCertificate=True;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__baie__3213E83F29F72D68");

            entity.ToTable("baie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.NbSpot).HasColumnName("nb_spot");
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK__doctrine__79B5C94CDDD76F01");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasPrecision(6)
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
        });

        modelBuilder.Entity<Forfait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__forfait__3213E83FF1D8C313");

            entity.ToTable("forfait");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(255)
                .HasColumnName("img_path");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NbMonth).HasColumnName("nb_month");
            entity.Property(e => e.NbSlot).HasColumnName("nb_slot");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<MessengerMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__messenge__3213E83F0E171044");

            entity.ToTable("messenger_messages");

            entity.HasIndex(e => e.DeliveredAt, "IDX_75EA56E016BA31DB");

            entity.HasIndex(e => e.AvailableAt, "IDX_75EA56E0E3BD61CE");

            entity.HasIndex(e => e.QueueName, "IDX_75EA56E0FB7336F0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("available_at");
            entity.Property(e => e.Body)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("created_at");
            entity.Property(e => e.DeliveredAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("delivered_at");
            entity.Property(e => e.Headers)
                .IsUnicode(false)
                .HasColumnName("headers");
            entity.Property(e => e.QueueName)
                .HasMaxLength(190)
                .HasColumnName("queue_name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__report__3213E83FA0E7658E");

            entity.ToTable("report");

            entity.HasIndex(e => e.UserrId, "IDX_C42F7784DF0FD358");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Object)
                .HasMaxLength(2048)
                .HasColumnName("object");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.UserrId).HasColumnName("userr_id");

            entity.HasOne(d => d.Userr).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C42F7784DF0FD358");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83FFFD10B64");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.ForfaitId, "IDX_42C84955906D5F2C");

            entity.HasIndex(e => e.UserrId, "IDX_42C84955DF0FD358");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginDate).HasColumnName("begin_date");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.ForfaitId).HasColumnName("forfait_id");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .HasColumnName("number");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Renewable).HasColumnName("renewable");
            entity.Property(e => e.UserrId).HasColumnName("userr_id");

            entity.HasOne(d => d.Forfait).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ForfaitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_42C84955906D5F2C");

            entity.HasOne(d => d.Userr).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_42C84955DF0FD358");
        });

        modelBuilder.Entity<Unite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unite__3213E83F9DE86E93");

            entity.ToTable("unite");

            entity.HasIndex(e => e.BaieId, "IDX_1D64C11843375062");

            entity.HasIndex(e => e.ReservationId, "IDX_1D64C118B83297E7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.BaieId).HasColumnName("baie_id");
            entity.Property(e => e.NumSpot)
                .HasMaxLength(255)
                .HasColumnName("num_spot");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

            entity.HasOne(d => d.Baie).WithMany(p => p.Unites)
                .HasForeignKey(d => d.BaieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_1D64C11843375062");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Unites)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_1D64C118B83297E7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FFAC4D625");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discr)
                .HasMaxLength(255)
                .HasColumnName("discr");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .HasColumnName("profile_image");
            entity.Property(e => e.Roles)
                .IsUnicode(false)
                .HasComment("(DC2Type:json)")
                .HasColumnName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
