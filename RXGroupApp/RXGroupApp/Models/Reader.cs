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
        [StringLength(100)]
        public string Fio { get; set; }
        
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}