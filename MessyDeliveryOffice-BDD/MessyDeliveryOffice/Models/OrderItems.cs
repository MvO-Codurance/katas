using System.Collections;

namespace MessyDeliveryOffice.Models;

public class OrderItems : IEnumerable<OrderItem>
{
    private List<OrderItem> _items = new List<OrderItem>();

    public IEnumerator<OrderItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}