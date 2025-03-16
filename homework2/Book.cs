using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubjectId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

       
        public Subject Subject { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }

}
