using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RXGroupApp.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public string Fio { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}