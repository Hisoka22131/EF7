using EF7;

public class Program
{
    private static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            // получаем объекты из бд и выводим на консоль
            //GetSuppliers();
            //GetCustomers();
            //GetOrders();
            //GetOrderItems();
            //GetProducts();
            GetCustomerOrders();
        }
    }
    /// <summary>
    /// Выводим всех поставщиков
    /// </summary>
    private static void GetSuppliers()
    {
        ApplicationContext db = new();
        var suppliers = db.Supplier.ToList();
        Console.WriteLine("Suppliers list:");
        foreach (var supplier in suppliers)
        {
            Console.WriteLine($"{supplier.Id}.{supplier.ContactName}");
        }
    }

    /// <summary>
    /// Выводи всех заказчиков
    /// </summary>
    private static void GetCustomers()
    {
        ApplicationContext db = new();
        var customers = db.Customer.ToList();
        Console.WriteLine("Customers list:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.FirstName}");
        }
    }

    /// <summary>
    /// Выводим все заказы
    /// </summary>
    private static void GetOrders()
    {
        ApplicationContext db = new();
        var orders = db.Order.ToList();
        Console.WriteLine("Orders list:");
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Id} {order.OrderNumber}");
        }
    }

    /// <summary>
    /// Выводим все позиции заказов
    /// </summary>
    private static void GetOrderItems()
    {
        ApplicationContext db = new();
        var orderItems = db.OrderItem.ToList();
        Console.WriteLine("OrderItems list:");
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine($"{orderItem.Id} {orderItem.UnitPrice}");
        }
    }

    /// <summary>
    /// Выводим все продукты
    /// </summary>
    private static void GetProducts()
    {
        ApplicationContext db = new();
        var products = db.Product.ToList();
        Console.WriteLine("Products list:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id} {product.ProductName}");
        }
    }

    /// <summary>
    /// Выводим все заказы заказчика
    /// </summary>
    private static void GetCustomerOrders()
    {
        ApplicationContext db = new();
        var customers = db.Customer.ToList().Select(q => new { Id = q.Id, Name = q.FirstName + " " + q.LastName });
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.Name + ":");
            var orders = db.Order.Where(q => q.CustomerId == customer.Id).ToList();
            int i = 0;
            foreach (var order in orders)
            {
                i++;
                Console.WriteLine($"{i,5}. {order.OrderNumber}");
            }
        }
    }
}