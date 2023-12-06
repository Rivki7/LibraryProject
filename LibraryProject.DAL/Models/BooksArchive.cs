using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class BooksArchive
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public int BookId { get; set; }

    public string Reason { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
