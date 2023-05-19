using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagementSystem.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Campus> Campuses { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassRoutine> ClassRoutines { get; set; } = null!;
        public virtual DbSet<Curriculum> Curricula { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<GradingSystem> GradingSystems { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentClassRoutine> StudentClassRoutines { get; set; } = null!;
        public virtual DbSet<StudentExamRoutine> StudentExamRoutines { get; set; } = null!;
        public virtual DbSet<StudentPayment> StudentPayments { get; set; } = null!;
        public virtual DbSet<StudentPortal> StudentPortals { get; set; } = null!;
        public virtual DbSet<StudentPromotion> StudentPromotions { get; set; } = null!;
        public virtual DbSet<StudentResult> StudentResults { get; set; } = null!;
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; } = null!;
        public virtual DbSet<Stuff> Stuffs { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherClassRoutine> TeacherClassRoutines { get; set; } = null!;
        public virtual DbSet<TeacherDesignation> TeacherDesignations { get; set; } = null!;
        public virtual DbSet<TeacherExamRoutine> TeacherExamRoutines { get; set; } = null!;
        public virtual DbSet<TeacherPortal> TeacherPortals { get; set; } = null!;
        public virtual DbSet<TeacherPromotion> TeacherPromotions { get; set; } = null!;
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AISHI-TONMOY-BS;Database=SchoolDb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Password)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.Teacherid)
                    .HasConstraintName("FK__Admin__Teacherid__1DB06A4F");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("Building");

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CampusId)
                    .HasConstraintName("FK__Building__Campus__46E78A0C");
            });

            modelBuilder.Entity<Campus>(entity =>
            {
                entity.ToTable("Campus");

                entity.Property(e => e.CampusName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Campuses)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Campus__BranchId__4316F928");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Campuses)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Campus__ShiftId__440B1D61");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Curriculum)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CurriculumId)
                    .HasConstraintName("FK__Class__Curriculu__4F7CD00D");
            });

            modelBuilder.Entity<ClassRoutine>(entity =>
            {
                entity.ToTable("ClassRoutine");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeekDay)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__ClassRout__Class__5535A963");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__ClassRout__RoomI__571DF1D5");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK__ClassRout__Secti__59063A47");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.Shiftid)
                    .HasConstraintName("FK__ClassRout__Shift__5812160E");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__ClassRout__Subje__5629CD9C");
            });

            modelBuilder.Entity<Curriculum>(entity =>
            {
                entity.ToTable("Curriculum");

                entity.Property(e => e.CurriculumName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Curricula)
                    .HasForeignKey(d => d.CampusId)
                    .HasConstraintName("FK__Curriculu__Campu__4CA06362");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamDate).HasColumnType("datetime");

                entity.Property(e => e.ExamDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Exam__SubjectId__5BE2A6F2");
            });

            modelBuilder.Entity<GradingSystem>(entity =>
            {
                entity.HasKey(e => e.GradeId)
                    .HasName("PK__GradingS__54F87A577A17712F");

                entity.ToTable("GradingSystem");

                entity.Property(e => e.GradeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.GradingSystems)
                    .HasForeignKey(d => d.Classid)
                    .HasConstraintName("FK__GradingSy__Class__5EBF139D");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK__Room__BuildingId__49C3F6B7");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.Property(e => e.SectionName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.SessionName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.AdmissionDate).HasColumnType("datetime");

                entity.Property(e => e.BirthCertificate)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FatherEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatherNid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FatherNID");

                entity.Property(e => e.FatherOccupation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatherPhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("GPA");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotherEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MotherNid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MotherNID");

                entity.Property(e => e.MotherOccupation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MotherPhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PresentAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousSchool)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RollNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CampusId)
                    .HasConstraintName("FK__Student__CampusI__619B8048");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Student__ClassId__66603565");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Student__GroupId__6383C8BA");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK__Student__Section__628FA481");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK__Student__Session__6477ECF3");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Student__ShiftId__656C112C");
            });

            modelBuilder.Entity<StudentClassRoutine>(entity =>
            {
                entity.ToTable("StudentClassRoutine");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.StudentClassRoutines)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK__StudentCl__Class__693CA210");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentClassRoutines)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentCl__Stude__6A30C649");
            });

            modelBuilder.Entity<StudentExamRoutine>(entity =>
            {
                entity.ToTable("StudentExamRoutine");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentExamRoutines)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__StudentEx__ExamI__73BA3083");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentExamRoutines)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentEx__Stude__74AE54BC");
            });

            modelBuilder.Entity<StudentPayment>(entity =>
            {
                entity.ToTable("StudentPayment");

                entity.Property(e => e.PaymentAmmount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPayments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentPa__Stude__6D0D32F4");
            });

            modelBuilder.Entity<StudentPortal>(entity =>
            {
                entity.ToTable("StudentPortal");

                entity.Property(e => e.Password)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPortals)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentPo__Stude__00200768");
            });

            modelBuilder.Entity<StudentPromotion>(entity =>
            {
                entity.ToTable("StudentPromotion");

                entity.Property(e => e.PromotionApprover)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionDate).HasColumnType("datetime");

                entity.Property(e => e.PromotionReason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentPromotions)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__StudentPr__Class__787EE5A0");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPromotions)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentPr__Stude__778AC167");
            });

            modelBuilder.Entity<StudentResult>(entity =>
            {
                entity.ToTable("StudentResult");

                entity.Property(e => e.ObtainedMark).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__StudentRe__Grade__7D439ABD");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentRe__Stude__7B5B524B");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__StudentRe__Subje__7C4F7684");
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("StudentSubject");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentSu__Stude__70DDC3D8");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__StudentSu__Subje__6FE99F9F");
            });

            modelBuilder.Entity<Stuff>(entity =>
            {
                entity.ToTable("Stuff");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Subject__ClassId__52593CB8");
            });

            modelBuilder.Entity<SuperAdmin>(entity =>
            {
                entity.ToTable("SuperAdmin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeacherClassRoutine>(entity =>
            {
                entity.ToTable("TeacherClassRoutine");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.TeacherClassRoutines)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK__TeacherCl__Class__08B54D69");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherClassRoutines)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherCl__Teach__09A971A2");
            });

            modelBuilder.Entity<TeacherDesignation>(entity =>
            {
                entity.ToTable("TeacherDesignation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TeacherDesignations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__TeacherDe__Desig__10566F31");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherDesignations)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherDe__Teach__114A936A");
            });

            modelBuilder.Entity<TeacherExamRoutine>(entity =>
            {
                entity.ToTable("TeacherExamRoutine");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.TeacherExamRoutines)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__TeacherEx__ExamI__0C85DE4D");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherExamRoutines)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherEx__Teach__0D7A0286");
            });

            modelBuilder.Entity<TeacherPortal>(entity =>
            {
                entity.ToTable("TeacherPortal");

                entity.Property(e => e.Password)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherPortals)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherPo__Teach__17036CC0");
            });

            modelBuilder.Entity<TeacherPromotion>(entity =>
            {
                entity.ToTable("TeacherPromotion");

                entity.Property(e => e.PromotionApprover)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionDate).HasColumnType("datetime");

                entity.Property(e => e.PromotionReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherPromotions)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherPr__Teach__14270015");
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.ToTable("TeacherSubject");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__TeacherSu__Subje__04E4BC85");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherSu__Teach__05D8E0BE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
