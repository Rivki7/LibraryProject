using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class CategoryToTitle
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int TitleId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
