using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RXGroupApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public string Name { get; set; }

        public string Author { get; set; }

        public string Article { get; set; }

        public int YearCreated { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}