using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryToTitle> CategoryToTitles { get; } = new List<CategoryToTitle>();
}
