using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebElectronicCashCounter.Models
{
    public class SeeProfitOrLoss
    {
        public IEnumerable<SeeProfitOrLossField> Field
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OurDbContext"].ConnectionString;
                List<SeeProfitOrLossField> Field = new List<SeeProfitOrLossField>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT [InvoiceId]
      ,[ProductId]
      ,[ProductName]
      ,[Quantity]
      ,[ValuePerProduct]
      ,[PricePerProduct]
  FROM [dbo].[Invoice]";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        SeeProfitOrLossField invoice = new SeeProfitOrLossField();

                        int x = Convert.ToInt32(rdr["PricePerProduct"]) - Convert.ToInt32(rdr["ValuePerProduct"]);
                        int y= Convert.ToInt32(rdr["Quantity"]);


                        invoice.SerialNo = Convert.ToInt32(rdr["InvoiceId"]);
                        invoice.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        invoice.ProductName = rdr["ProductName"].ToString();
                        invoice.Quantity = y;
                        invoice.ValuePerProduct = Convert.ToInt32(rdr["ValuePerProduct"]);
                        invoice.PricePerProduct = Convert.ToInt32(rdr["PricePerProduct"]);
                        if (x > 0)
                        {
                            invoice.ProfitOrLoss = "Profit";
                        }
                        else
                        {
                            invoice.ProfitOrLoss = "Loss";
                        }
                        // invoice.ProfitOrLoss = Convert.ToDateTime(rdr["EntryDate"]);
                         invoice.How_ProfitOrLoss = x;
                        // invoice.MenupactureCompany = rdr["ManupactureCompany"].ToString();
                        invoice.Total_ProfitOrLoss = x*y ;

                        Field.Add(invoice);

                    }
                }
                return Field;
            }
        }
    }
}