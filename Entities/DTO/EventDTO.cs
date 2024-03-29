﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Desc { get; set; } = null!;
    }
}
