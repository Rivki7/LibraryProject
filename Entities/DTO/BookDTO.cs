using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public int TitleId { get; set; }

        public DateTime DateEnter { get; set; }


        public virtual TitleDTO Title { get; set; } = null!;


    }
}
