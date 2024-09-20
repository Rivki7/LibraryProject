using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Desc { get; set; } = null!;
}
