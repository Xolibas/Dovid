using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dovid.Models
{
    public class Ticket
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public int? TrainId { get; set; }
        [Required]
        [Display(Name = "Потяг")]
        public Train Train { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Ім’я")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Прізвище")]
        public string Sname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Адреса")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
    }
}