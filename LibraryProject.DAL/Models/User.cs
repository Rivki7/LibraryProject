using System;
using System.Collections.Generic;

namespace LibraryProjectRepository.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber1 { get; set; } = null!;

    public string? PhoneNumber2 { get; set; }

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime SignDate { get; set; }

    public string Password { get; set; } = null!;

    public bool IsBlocked { get; set; }

    public int? LevelId { get; set; }

    public virtual ICollection<CheckedBook> CheckedBooks { get; } = new List<CheckedBook>();

    public virtual UsersLevel? Level { get; set; }

    public virtual ICollection<Message> Messages { get; } = new List<Message>();
}
