using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class Title
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string? Image { get; set; }

    public int Amount { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime DateEnter { get; set; }

    public int DaysToBorrow { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual ICollection<BooksArchive> BooksArchives { get; } = new List<BooksArchive>();

    public virtual ICollection<CategoryToTitle> CategoryToTitles { get; } = new List<CategoryToTitle>();
}
