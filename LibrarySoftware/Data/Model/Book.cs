using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Book
    {
        public Book()
        {
            this.BookCardRelations = new HashSet<BookCardRelations>();
        }

        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Category { get; set; }

        public DateTime? DateTaken { get; set; }

        public DateTime? DateReturned { get; set; }

        public ICollection<BookCardRelations> BookCardRelations { get; set; }
    }
}
