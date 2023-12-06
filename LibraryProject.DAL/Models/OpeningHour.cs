using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class OpeningHour
{
    public int Id { get; set; }

    public DateTime Day { get; set; }

    public TimeSpan? OpeningHour1 { get; set; }

    public TimeSpan? ClosingHour1 { get; set; }

    public TimeSpan? OpeningHour2 { get; set; }

    public TimeSpan? ClosingHour2 { get; set; }
}
