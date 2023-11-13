using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public class BInvoice
    {

        public List<Invoice> GetInvoiceActives()
        {
            DInvoice data = new DInvoice();
            var invoices = data.GetInvoices();
            var result = invoices.Where(x => x.Active == true).ToList();
            return result;
        }

        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = GetInvoiceActives();
            foreach (var invoice in invoices)
            {
                DateTime dates = invoice.Date;
            }
            return invoices;
        }

        public void InsertInvoice(int customer_id, DateTime date, decimal total)
        {
            DInvoice data = new DInvoice();
            data.InsertInvoice(customer_id, date, total);
        }

        public void DeleteInvoice(int id)
        {
            DInvoice data = new DInvoice();
            data.DeleteInvoice(id);
        }

    }
}