using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.DAL.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksArchive> BooksArchives { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryToTitle> CategoryToTitles { get; set; }

    public virtual DbSet<CheckedBook> CheckedBooks { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<OpeningHour> OpeningHours { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-91NE6I1B;Database=Library;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC2714DC6BA1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateEnter)
                .HasColumnType("date")
                .HasColumnName("DATE_ENTER");
            entity.Property(e => e.TitleId).HasColumnName("TITLE_ID");

            entity.HasOne(d => d.Title).WithMany(p => p.Books)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__TITLE_ID__2C3393D0");
        });

        modelBuilder.Entity<BooksArchive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books_Ar__3214EC279621A64A");

            entity.ToTable("Books_Archive");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BOOK_ID");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .HasColumnName("REASON");
            entity.Property(e => e.TitleId).HasColumnName("TITLE_ID");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksArchives)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books_Arc__BOOK___300424B4");

            entity.HasOne(d => d.Title).WithMany(p => p.BooksArchives)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books_Arc__TITLE__2F10007B");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC276C7E36A1");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<CategoryToTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC275408913B");

            entity.ToTable("Category_to_Title");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.TitleId).HasColumnName("TITLE_ID");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryToTitles)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Category___CATEG__286302EC");

            entity.HasOne(d => d.Title).WithMany(p => p.CategoryToTitles)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Category___TITLE__29572725");
        });

        modelBuilder.Entity<CheckedBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Checked___3214EC27282A27D6");

            entity.ToTable("Checked_Books");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BOOK_ID");
            entity.Property(e => e.BorrowDate)
                .HasColumnType("date")
                .HasColumnName("BORROW_DATE");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("RETURN_DATE");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Book).WithMany(p => p.CheckedBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checked_B__BOOK___37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.CheckedBooks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Checked_B__USER___36B12243");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC27C82FF21D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.Desc).HasColumnName("DESC");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libraria__3214EC2714D8EDD7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("CITY");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.IsBlocked).HasColumnName("IS_BLOCKED");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER_1");
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER_2");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC2774E1EF1D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.Desc).HasColumnName("DESC");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("TITLE");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__USER_I__3A81B327");
        });

        modelBuilder.Entity<OpeningHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Opening___3214EC2727F1056C");

            entity.ToTable("Opening_Hours");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClosingHour1).HasColumnName("CLOSING_HOUR1");
            entity.Property(e => e.ClosingHour2).HasColumnName("CLOSING_HOUR2");
            entity.Property(e => e.Day)
                .HasColumnType("date")
                .HasColumnName("DAY");
            entity.Property(e => e.OpeningHour1).HasColumnName("OPENING_HOUR1");
            entity.Property(e => e.OpeningHour2).HasColumnName("OPENING_HOUR2");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Titles__3214EC27B413B321");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("AUTHOR");
            entity.Property(e => e.DateEnter)
                .HasColumnType("date")
                .HasColumnName("DATE_ENTER");
            entity.Property(e => e.DaysToBorrow).HasColumnName("DAYS_TO_BORROW");
            entity.Property(e => e.Desc).HasColumnName("DESC");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.PublishDate)
                .HasColumnType("date")
                .HasColumnName("PUBLISH_DATE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27A9C34E3D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("CITY");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.IsBlocked).HasColumnName("IS_BLOCKED");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER_1");
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER_2");
            entity.Property(e => e.SignDate)
                .HasColumnType("date")
                .HasColumnName("SIGN_DATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
