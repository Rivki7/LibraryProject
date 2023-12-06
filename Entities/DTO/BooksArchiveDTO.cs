using System;
using System.Collections.Generic;


namespace Entities.DTO
{

    public class BooksArchiveDTO
    {
        public int Id { get; set; }

        public int TitleId { get; set; }

        public int BookId { get; set; }

        public string Reason { get; set; } = null!;

        public virtual BookDTO Book { get; set; } = null!;

        public virtual TitleDTO Title { get; set; } = null!;
    }
}
