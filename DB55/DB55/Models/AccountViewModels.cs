using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DB55.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
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
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [Display(Name = "Discriminator")]
        public string Discriminator { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public static IEnumerable<SelectListItem> CountryList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "ملک", Value = "ملک" },
                new  SelectListItem{Text = "Afghanistan", Value = "Afghanistan" },
                new  SelectListItem{Text = "Åland Islands", Value = "Åland Islands" },
                new  SelectListItem{Text = "Albania", Value = "Albania" },
                new  SelectListItem{Text = "Algeria", Value = "Algeria" },
                new  SelectListItem{Text = "American Samoa", Value = "American Samoa" },
                new  SelectListItem{Text = "Andorra", Value = "Andorra" },
                new  SelectListItem{Text = "Angola", Value = "Angola" },
                new  SelectListItem{Text = "Anguilla", Value = "Anguilla" },
            };
            return items;
        }
        public static IEnumerable<SelectListItem> GenderList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "صنف", Value = "صنف" },
                new  SelectListItem{Text = "مرد", Value = "مرد" },
                new  SelectListItem{Text = "عورت", Value = "عورت" },
            };
            return items;
        }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class DoctorRegisterViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName1 { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string LastName1 { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country1 { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender1 { get; set; }

        [Required]
        [Display(Name = "LiscenceNumber")]
        public int LiscenceNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email1 { get; set; }



        [Display(Name = "Discriminator")]
        public string Discriminator1 { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact1 { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password1 { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password1", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword1 { get; set; }

        public static IEnumerable<SelectListItem> CountryList1()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "ملک", Value = "ملک" },
                new  SelectListItem{Text = "Afghanistan", Value = "Afghanistan" },
                new  SelectListItem{Text = "Åland Islands", Value = "Åland Islands" },
                new  SelectListItem{Text = "Albania", Value = "Albania" },
                new  SelectListItem{Text = "Algeria", Value = "Algeria" },
                new  SelectListItem{Text = "American Samoa", Value = "American Samoa" },
                new  SelectListItem{Text = "Andorra", Value = "Andorra" },
                new  SelectListItem{Text = "Angola", Value = "Angola" },
                new  SelectListItem{Text = "Anguilla", Value = "Anguilla" },
            };
            return items;
        }
        public static IEnumerable<SelectListItem> GenderList1()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "صنف", Value = "صنف" },
                new  SelectListItem{Text = "مرد", Value = "مرد" },
                new  SelectListItem{Text = "عورت", Value = "عورت" },
            };
            return items;
        }

    }
}
