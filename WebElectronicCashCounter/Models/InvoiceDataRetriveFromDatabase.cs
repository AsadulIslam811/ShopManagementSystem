using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebElectronicCashCounter.Models
{
    public class InvoiceDataRetriveFromDatabase
    {
        public IEnumerable<Invoice> Invoices
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OurDbContext"].ConnectionString;
                List<Invoice> Invoices = new List<Invoice>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT [InvoiceId]
      ,[ProductId]
      ,[ProductName]
      ,[Quantity]
      ,[ValuePerProduct]
      ,[PricePerProduct]
      ,[EntryDate]
      ,[ExpireDate]
      ,[ManupactureCompany]
  FROM [dbo].[Invoice]";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Invoice invoice = new Invoice();

                        invoice.InvoiceId = Convert.ToInt32(rdr["InvoiceId"]);
                        invoice.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        invoice.ProductName = rdr["ProductName"].ToString();
                        invoice.Quantity = Convert.ToInt32(rdr["Quantity"]);
                        invoice.ValuePerProduct = Convert.ToInt32(rdr["ValuePerProduct"]);
                        invoice.PricePerProduct = Convert.ToInt32(rdr["PricePerProduct"]);
                        invoice.EntryDate = Convert.ToDateTime(rdr["EntryDate"]);
                        invoice.ExpireDate = Convert.ToDateTime(rdr["ExpireDate"]);
                        invoice.MenupactureCompany = rdr["ManupactureCompany"].ToString();

                        Invoices.Add(invoice);

                    }
                }
                return Invoices;
            }
        }

        public void AddInvoice(Invoice Invoices)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OurDbContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [dbo].[Invoice]
           ([ProductId]
           ,[ProductName]
           ,[Quantity]
           ,[ValuePerProduct]
           ,[PricePerProduct]
           ,[EntryDate]
           ,[ExpireDate]
           ,[ManupactureCompany])
     VALUES
           (@ProductId, @ProductName ,@Quantity,@ValuePerProduct,@PricePerProduct,@EntryDate,@ExpireDate,@ManupactureCompany)";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ProductId = new SqlParameter();
                ProductId.ParameterName = "@ProductId";
                ProductId.Value = Invoices.ProductId;
                cmd.Parameters.Add(ProductId);

                SqlParameter ProductName = new SqlParameter();
                ProductName.ParameterName = "@ProductName";
                ProductName.Value = Invoices.ProductName;
                cmd.Parameters.Add(ProductName);

                SqlParameter Quantity = new SqlParameter();
                Quantity.ParameterName = "@Quantity";
                Quantity.Value = Invoices.Quantity;
                cmd.Parameters.Add(Quantity);

                SqlParameter ValuePerProduct = new SqlParameter();
                ValuePerProduct.ParameterName = "@ValuePerProduct";
                ValuePerProduct.Value = Invoices.ValuePerProduct;
                cmd.Parameters.Add(ValuePerProduct);

                SqlParameter PricePerProduct = new SqlParameter();
                PricePerProduct.ParameterName = "@PricePerProduct";
                PricePerProduct.Value = Invoices.PricePerProduct;
                cmd.Parameters.Add(PricePerProduct);

                SqlParameter EntryDate = new SqlParameter();
                EntryDate.ParameterName = "@EntryDate";
                EntryDate.Value = Invoices.EntryDate;
                cmd.Parameters.Add(EntryDate);

                SqlParameter ExpireDate = new SqlParameter();
                ExpireDate.ParameterName = "@ExpireDate";
                ExpireDate.Value = Invoices.ExpireDate;
                cmd.Parameters.Add(ExpireDate);


                SqlParameter MenupactureCompany = new SqlParameter();
                MenupactureCompany.ParameterName = "@ManupactureCompany";
                MenupactureCompany.Value = Invoices.MenupactureCompany;
                cmd.Parameters.Add(MenupactureCompany);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}