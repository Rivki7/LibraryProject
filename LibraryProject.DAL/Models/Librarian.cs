using System;
using System.Collections.Generic;

namespace LibraryProject.DAL.Models;

public partial class Librarian
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber1 { get; set; } = null!;

    public string PhoneNumber2 { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public bool IsBlocked { get; set; }
}
