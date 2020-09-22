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
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Артикль")]
        public string Article { get; set; }

        // TODO: хардкод текущего года, решение: создать свой атрибут
        [Required]
        [Range(1, 2021)]
        [Display(Name = "Год издания")]
        public int YearCreated { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}