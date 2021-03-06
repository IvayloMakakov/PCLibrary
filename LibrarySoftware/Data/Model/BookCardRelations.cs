using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class BookCardRelations
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        public int LibraryCardId { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
    }
}
