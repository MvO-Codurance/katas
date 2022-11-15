namespace MessyDeliveryOffice.Models;

public enum OrderStatus
{
    New = 0,
    Received = 1,
    AllItemsSentToSuppliers = 2,
    AllItemsReceivedFromSuppliers = 3,
    DispatchedToCustomer = 4
}