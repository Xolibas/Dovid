using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Sdk;

namespace Dovid.Models
{
    public class Station
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Districts(new string[] { "Хмельницька обл.", "Київська обл.", "Херсонська обл.", "Тернопільська обл.", "АР Крим", "Донецька обл.", "Луганська обл.", "Закарпаття" }, ErrorMessage = "Неприпустима область")]
        [Required]
        [Display(Name = "Область")]
        public string Oblast { get; set; }
        public virtual ICollection<Train> Trains { get; set; }

    }
    public class DistrictsAttribute : ValidationAttribute
    {
        private static string[] Districts;
        public DistrictsAttribute(string[] MeDiscticts)
        {
            Districts = MeDiscticts;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < Districts.Length; i++)
                {
                    if (strval == Districts[i])
                        return true;
                }
            }
            return false;
        }
    }

}