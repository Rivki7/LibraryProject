using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class UsersLevel
{
    public int LevelId { get; set; }

    public string? LevelDesc { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
