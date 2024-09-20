using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class Book
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public DateTime DateEnter { get; set; }

    public virtual ICollection<BooksArchive> BooksArchives { get; } = new List<BooksArchive>();

    public virtual ICollection<CheckedBook> CheckedBooks { get; } = new List<CheckedBook>();

    public virtual Title Title { get; set; } = null!;
}
