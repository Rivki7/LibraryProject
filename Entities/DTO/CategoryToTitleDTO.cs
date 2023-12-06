using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public  class CategoryToTitleDTO
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int TitleId { get; set; }

        public virtual CategoryDTO Category { get; set; } = null!;

        public virtual TitleDTO Title { get; set; } = null!;
    }
}
