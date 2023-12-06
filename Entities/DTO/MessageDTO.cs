using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public  class MessageDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; } = null!;

        public string Desc { get; set; } = null!;

        public DateTime Date { get; set; }

        public virtual UserDTO User { get; set; } = null!;
    }
}
