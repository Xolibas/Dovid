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
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "SPos")]
        [Display(Name = "SPos", ResourceType = typeof(Resources.Resource))]
        public string SPos { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "FPos")]
        [Display(Name = "FPos", ResourceType = typeof(Resources.Resource))]
        public string FPos { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "STime")]
        [Display(Name = "STime", ResourceType = typeof(Resources.Resource))]
        public DateTime STime { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "FTime")]
        [Display(Name = "FTime", ResourceType = typeof(Resources.Resource))]
        public DateTime FTime { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "VCount")]
        [Range(typeof(Int32), "1", "20")]
        [Display(Name = "VCount", ResourceType = typeof(Resources.Resource))]
        public int VCount { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Price")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public int Price { get; set; }
        [Required]
        public ICollection<Ticket> Tickets { get; set; }
        public Train()
        {
            Tickets = new List<Ticket>();
        }
        [Display(Name = "Stations", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<Station> Stations { get; set; }
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
                        if (string.IsNullOrEmpty(t.SPos) || t.SPos.Length < 5 || t.SPos.Length > 50)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="SPos", Message=Resources.Resource.ESpos}
                        };
                        }
                        break;
                    case "FPos":
                        if (string.IsNullOrEmpty(t.FPos) || t.SPos.Length < 5 || t.SPos.Length > 50)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="FPos", Message=Resources.Resource.EFpos}
                        };
                        }
                        break;
                    case "STime":
                        if (t.STime.Year < 2000 || t.STime.Year > 2022)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="STime", Message=Resources.Resource.EStime}
                        };
                        }
                        break;
                    case "FTime":
                        if (t.FTime.Year < 2000 || t.FTime.Year > 2022 || t.STime > t.FTime)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="STime", Message=Resources.Resource.EFtime}
                        };
                        }
                        break;
                    case "VCount":
                        if (t.VCount < 5)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="VCount", Message=Resources.Resource.EVcount}
                        };
                        }
                        break;
                    case "Price":
                        if (t.Price > 2000 || t.Price < 50)
                        {
                            return new ModelValidationResult[]{
                            new ModelValidationResult { MemberName="Price", Message=Resources.Resource.EPrice}
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

            if (t.SPos == "Хмельницький" && t.FPos == "Київ" && t.Price == 1900)
            {
                errors.Add(new ModelValidationResult { MemberName = "", Message = Resources.Resource.WrongTrain });
            }
            return errors;
        }
    }
}