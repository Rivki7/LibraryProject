using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class TitleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Desc { get; set; } = null!;

        public string? Image { get; set; }

        public int Amount { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime DateEnter { get; set; }

        public int DaysToBorrow { get; set; }

    }
}
