# LAb007
#CREATE PROCEDURE ListarInvoices 
#AS
#BEGIN
    SELECT
      [invoice_id],
      [customer_id],
      [date],
      [total],
      [active]
    FROM
        [dbo].[invoices]
END;

EXECUTE ListarInvoices


CREATE PROCEDURE InsertInvoice
    @customer_id INT,
    @date DATE,
    @total DECIMAL
AS
BEGIN
    INSERT INTO Invoices (customer_id, date, total)
    VALUES (@customer_id, @date, @total);
END;
