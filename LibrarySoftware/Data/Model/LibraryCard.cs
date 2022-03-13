using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class LibraryCard
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<BookCardRelations> BookCardRelations { get; set; }
    }
}
