using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DInvoice
    {
        public static string connectionString = "Data Source=LAB1504-26\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=Tecsup;Password=123456";

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string procedure = "ListarInvoices";

                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Invoice listinvoice = new Invoice
                                {
                                    invoice_id = reader.GetInt32(reader.GetOrdinal("invoice_id")),
                                    customer_id = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                    date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    total = reader.GetDecimal(reader.GetOrdinal("total")),
                                    active = reader.GetBoolean(reader.GetOrdinal("active"))
                                };
                                invoices.Add(listinvoice);
                                Console.WriteLine($"invoice_id: {listinvoice.invoice_id}");
                                Console.WriteLine($"customer_id: {listinvoice.customer_id}");
                                Console.WriteLine($"date: {listinvoice.date}");
                                Console.WriteLine($"total: {listinvoice.total}");
                                Console.WriteLine($"active: {listinvoice.active}");
                            }
                        }
                    }
                    connection.Close();
                }

                return invoices;
            }
        }
    }
}