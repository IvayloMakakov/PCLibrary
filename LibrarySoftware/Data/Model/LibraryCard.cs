using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LibraryCard
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string EGN { get; set; }

        public string Email { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<BookCardRelations> BookCardRelations { get; set; }
    }
}
