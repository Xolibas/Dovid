using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dovid.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(Resources.Resource))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Rembrow", ResourceType = typeof(Resources.Resource))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "Remme", ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значенння {0} має містити не менше {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passconf", ResourceType = typeof(Resources.Resource))]
        [Compare("Password", ErrorMessage = "Пароль и і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значення {0} повинно містити не менше {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passconf", ResourceType = typeof(Resources.Resource))]
        [Compare("Password", ErrorMessage = "Пароль і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adrel", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
    }
}
