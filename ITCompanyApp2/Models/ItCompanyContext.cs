using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITCompanyApp2.Models;

public partial class ItCompanyContext : DbContext
{
    public ItCompanyContext()
    {
    }

    public ItCompanyContext(DbContextOptions<ItCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignmentInProject> AssignmentInProjects { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusesTask> StatusesTasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=it_company;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentInProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assignment_in_projects_pkey");

            entity.ToTable("assignment_in_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.Project).WithMany(p => p.AssignmentInProjects)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_assigm_in_project_to_projects");

            entity.HasOne(d => d.Role).WithMany(p => p.AssignmentInProjects)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_assigm_in_project_to_roles");

            entity.HasOne(d => d.User).WithMany(p => p.AssignmentInProjects)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_assigm_in_project_to_users");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_position_id");

            entity.ToTable("positions");

            entity.HasIndex(e => e.PositionName, "uq_positions_position_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PositionName).HasColumnName("position_name");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_priority_id");

            entity.ToTable("priorities");

            entity.HasIndex(e => e.PriorityName, "uq_priorities_priority_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PriorityName).HasColumnName("priority_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_projects_id");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdManager).HasColumnName("id_manager");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.NameProject).HasColumnName("name_project");

            entity.HasOne(d => d.User).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdManager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projects_to_users");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projects_to_statuses");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_roles_id");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "uq_roles_role_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_status_id");

            entity.ToTable("statuses");

            entity.HasIndex(e => e.StatusesName, "uq_statuses_sstatus_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusesName).HasColumnName("statuses_name");
        });

        modelBuilder.Entity<StatusesTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_status_tasks_id");

            entity.ToTable("statuses_tasks");

            entity.HasIndex(e => e.StatusTasksName, "uq_status_tasks_status_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('status_tasks_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.StatusTasksName).HasColumnName("status_tasks_name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tasks_id");

            entity.ToTable("tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateComplete).HasColumnName("date_complete");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdPriority).HasColumnName("id_priority");
            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.IdStatusTask).HasColumnName("id_status_task");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.NameTasks).HasColumnName("name_tasks");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdPriority)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_to_priority");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_to_projects");

            entity.HasOne(d => d.StatusesTask).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdStatusTask)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_to_status_tasks");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_to_users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users_id");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fio).HasColumnName("FIO");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_to_positions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
