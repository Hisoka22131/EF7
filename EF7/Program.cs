using EF7;
using EF7.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static readonly CustomerRepository customerRepository = new(new ApplicationContext());
    private static readonly ApplicationContext context = new ApplicationContext();

    private static void Main(string[] args)
    {
        // получаем объекты из бд и выводим на консоль
        //GetSuppliers();
        //GetCustomers();
        //GetOrders();
        //GetOrderItems();
        //GetProducts();
        //GetCustomerOrders();
        var customer = customerRepository.GetEntity(5);
        Console.WriteLine(customer.FirstName);
        foreach (var order in customerRepository.GetAll().Where(q => q.Id == customer.Id).SelectMany(q => q.Orders))
            Console.WriteLine(order.OrderNumber);

    }

    /// <summary>
    /// Выводим всех поставщиков
    /// </summary>
    private static void GetSuppliers()
    {
        var suppliers = context.Supplier.ToList();
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
        var customers = context.Customer.ToList();
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
        var orders = context.Order.ToList();
        Console.WriteLine("Orders list:");
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Id} {order.OrderNumber} {order.Customer?.Id}");
        }
    }

    /// <summary>
    /// Выводим все позиции заказов
    /// </summary>
    private static void GetOrderItems()
    {
        var orderItems = context.OrderItem.ToList();
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
        var products = context.Product.ToList();
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
        var customers = customerRepository.GetAll().ToList().Select(q => new { Id = q.Id, Name = q.FirstName + " " + q.LastName, Orders = q.Orders });
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.Id + " " + customer.Name + ":");
            var orders = customer.Orders;
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderNumber}");
            }
        }
    }
}