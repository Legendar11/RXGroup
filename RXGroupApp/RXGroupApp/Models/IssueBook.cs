using System;
using System.ComponentModel.DataAnnotations;

namespace RXGroupApp.Models
{
    public class IssueBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата выдачи")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateIssue { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Количество дней, на которое выдана книга")]
        public int CountDays { get; set; }

        [Required]
        [Display(Name = "Читатель")]
        public int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }

        [Required]
        [Display(Name = "Книга")]
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}