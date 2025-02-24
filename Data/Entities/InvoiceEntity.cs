namespace Data.Entities;

public class InvoiceEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime InvoiceDate { get; set; }
}