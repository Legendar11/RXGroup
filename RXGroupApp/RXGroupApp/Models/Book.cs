using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RXGroupApp.Models
{
    // TODO: разграничить модели, перенести их на Data-слой и на UI-слой
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [Display(Name = "Наименование")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        [StringLength(100)]
        public string Author { get; set; }

        [Display(Name = "Артикль")]
        [StringLength(20)]
        public string Article { get; set; }

        // TODO: хардкод текущего года, решение: создать свой атрибут
        [Required]
        [Range(1, 2021)]
        [Display(Name = "Год издания")]
        public int YearCreated { get; set; }

        public ICollection<IssueBook> IssueBooks { get; set; } = new List<IssueBook>();
    }
}