namespace MessyDeliveryOffice.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly EstimatedDispatchDate { get; set; }
    public OrderStatus Status { get; set; }
    public OrderItems Items { get; set; } = new();
}