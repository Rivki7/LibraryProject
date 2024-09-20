using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class OpeningHour
{
    public int Id { get; set; }

    public string Day { get; set; } = null!;

    public string? OpeningHour1 { get; set; }

    public string? ClosingHour1 { get; set; }

    public string? OpeningHour2 { get; set; }

    public string? ClosingHour2 { get; set; }
}
