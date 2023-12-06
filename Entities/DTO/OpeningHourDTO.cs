using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OpeningHourDTO
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public TimeSpan? OpeningHour1 { get; set; }

        public TimeSpan? ClosingHour1 { get; set; }

        public TimeSpan? OpeningHour2 { get; set; }

        public TimeSpan? ClosingHour2 { get; set; }
    }
}
