using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Reguser.Models
{
    public class User
    {
        [Required(ErrorMessage ="Enter username")]
        [Display(Name ="Enter Username")]
        [StringLength(maximumLength:7,MinimumLength =3,ErrorMessage ="Username length must be max 7 & min 3  ")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter re-password")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="select the gender")]
        [Display(Name="Gender")]
        public char Gender { get; set; }
       
        [Display(Name = "Profile image")]
        public string Img {  get; set; }

    }
}