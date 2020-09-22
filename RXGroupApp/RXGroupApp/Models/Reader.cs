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
        [Display(Name = "ФИО")]
        public string Fio { get; set; }

        [Range(1, 2021)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}