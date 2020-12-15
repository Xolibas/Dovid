using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dovid.Models
{
    public class Train
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Початкова позиція")]
        public string SPos { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 до 50 символів")]
        [Display(Name = "Кінцева позиція")]
        public string FPos { get; set; }
        [Required]
        [Display(Name = "Час прибуття")]
        public DateTime STime { get; set; }
        [Required]
        [Display(Name = "Час від’їзду")]
        public DateTime FTime { get; set; }
        [Required]
        [Range(typeof(Int32), "1", "20")]
        [Display(Name = "Кількість вагонів")]
        public int VCount { get; set; }
        [Required]
        [Display(Name = "Ціна")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Квитки")]
        public ICollection<Ticket> Tickets { get; set; }
        public Train()
        {
            Tickets = new List<Ticket>();
        }
        [Display(Name = "Станції")]
        public virtual ICollection<Station> Stations{ get; set; }
    }
    public class TrainPropertyValidator : ModelValidator
    {
        public TrainPropertyValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Train t = container as Train;
            if (t != null)
            {
                switch (Metadata.PropertyName)
                {
                    case "SPos":
                        if (string.IsNullOrEmpty(t.SPos))
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="SPos", Message="Введіть початкову позицію"}
                        };
                        }
                        break;
                    case "FPos":
                        if (string.IsNullOrEmpty(t.FPos))
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="FPos", Message="Введіть кінцеву позицію"}
                        };
                        }
                        break;
                    case "STime":
                        if (t.STime.Year<2000 || t.STime.Year>2022)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="STime", Message="Введіть час прибуття"}
                        };
                        }
                        break;
                    case "FTime":
                        if (t.FTime.Year < 2000 || t.FTime.Year > 2022 || t.STime>t.FTime)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="STime", Message="Введіть час від’їзду"}
                        };
                        }
                        break;
                    case "VCount":
                        if (t.VCount<5)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="VCount", Message="Введіть кількість вагонів"}
                        };
                        }
                        break;
                    case "Price":
                        if (t.Price > 2000 || t.Price < 50)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="Price", Message="Введіть ціну"}
                        };
                        }
                        break;
                }
            }
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
    public class MyValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(Train))
            {
                return new ModelValidator[] { new TrainPropertyValidator(metadata, context) };
            }

            if (metadata.ModelType == typeof(Train))
            {
                return new ModelValidator[] { new TrainValidator(metadata, context) };
            }

            return Enumerable.Empty<ModelValidator>();
        }
    }

    public class TrainValidator : ModelValidator
    {
        public TrainValidator(ModelMetadata metadata, ControllerContext context)
            : base(metadata, context)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Train t = (Train)Metadata.Model;

            List<ModelValidationResult> errors = new List<ModelValidationResult>();

            if (t.SPos == "Хмельницький" && t.FPos== "Київ" && t.Price == 1900)
            {
                errors.Add(new ModelValidationResult { MemberName = "", Message = "Неправильний потяг" });
            }
            return errors;
        }
    }
}