namespace MessyDeliveryOffice.Models;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    TimeSpan LeadTime { get; set; }
}