using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebElectronicCashCounter.Models
{
    public class Invoice
    {
        
        public int InvoiceId { get; set; }

        [Key]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

         [Display(Name = "Product Name")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string ProductName { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Per Value Product")]
        public int ValuePerProduct { get; set; }

        [Display(Name = "per Price Product")]
        public int PricePerProduct { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Expire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "Menupacture Company Name")]
        public string MenupactureCompany { get; set; }
  
     }
}