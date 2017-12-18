using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebElectronicCashCounter.Models
{
    //[Table("UserAccountTable")]
    public class UserAccountModel
    {
        [Key]
        public int UserId { get; set; }

       // [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string LastName { get; set; }

        [Display(Name = "email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string Password { get; set; }

       
    }
}