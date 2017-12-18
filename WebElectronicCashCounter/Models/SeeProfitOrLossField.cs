using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebElectronicCashCounter.Models
{
    //[Table("UserAccountTable")]
    public class SeeProfitOrLossField
    {
        [key]
        public int SerialNo { get; set; }


        public int ProductId { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ValuePerProduct { get; set; }
        public int PricePerProduct { get; set; }
        public string ProfitOrLoss { get; set; }
        public int How_ProfitOrLoss { get; set; }
        public int Total_ProfitOrLoss { get; set; }
       // public object Field { get; internal set; }
    }
}