using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class Message
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual User User { get; set; } = null!;
}
