using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebElectronicCashCounter.Models;

namespace WebElectronicCashCounter.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoice_View()
        {
            InvoiceDataRetriveFromDatabase invoiceDataRetriveFromDatabase = new InvoiceDataRetriveFromDatabase();
            List<Invoice> invoice= invoiceDataRetriveFromDatabase.Invoices.ToList();


            return View(invoice);
        }

        [HttpGet]
        public ActionResult Invoice_Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Invoice_Add(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                InvoiceDataRetriveFromDatabase invoiceDataRetriveFromDatabase = new InvoiceDataRetriveFromDatabase();
                invoiceDataRetriveFromDatabase.AddInvoice(invoice);

                return RedirectToAction("Invoice_View");
            }
            return View();
        }


          public ActionResult SeeProfitOrLoss()
         {
         SeeProfitOrLoss ob = new SeeProfitOrLoss();
         List<SeeProfitOrLossField> ProfitOrLoss = ob.Field.ToList();


          return View(ProfitOrLoss);
          }

        public ActionResult DailySale()
        {
            SeeProfitOrLoss ob = new SeeProfitOrLoss();
            List<SeeProfitOrLossField> ProfitOrLoss = ob.Field.ToList();


            return View(ProfitOrLoss);
        }
    }
}