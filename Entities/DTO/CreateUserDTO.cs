﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CreateUserDTO
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber1 { get; set; } = null!;

        public string PhoneNumber2 { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
