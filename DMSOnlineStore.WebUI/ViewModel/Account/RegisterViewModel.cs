using System.ComponentModel.DataAnnotations;
using DMSOnlineStore.WebUI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DMSOnlineStore.WebUI.ViewModel.Account
{

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomain(allowedDomain: "emailname@yahoo.com",
            ErrorMessage = "Email domain must be emailname@yahoo.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
