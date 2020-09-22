using System;
using System.ComponentModel.DataAnnotations;

namespace RXGroupApp.Models
{
    public class IssueBook
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }

        public int CountDays { get; set; }

        public int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }

        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}