using EF7;
using EF7.BaseRepository;
using EF7.Models;
using EF7.Repository;
using EF7.Repository.Dto;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static readonly BaseRepository<Customer> customerRepository = new(new ApplicationContext());
    private static readonly BaseRepository<Order> orderRepository = new(new ApplicationContext());
    private static readonly BaseRepository<OrderItem> orderItemRepository = new(new ApplicationContext());
    private static readonly BaseRepository<Product> productRepository = new(new ApplicationContext());
    private static readonly BaseRepository<Supplier> supplierRepository = new(new ApplicationContext());

    private static void Main(string[] args)
    {
        // получаем объекты из бд и выводим на консоль
        //GetSuppliers();
        //GetCustomers();
        //GetOrderItems();
        //GetProducts();
        GetCustomerOrders();
        //GetOrders(); 

        //var customer = customerRepository.GetEntity(5);
        //customerRepository.DeleteEntity();
        //customerRepository.DeleteEntity(customer);
        //Console.WriteLine(customer.FirstName);
    }

    /// <summary>
    /// Выводим всех поставщиков
    /// </summary>
    private static void GetSuppliers()
    {
        var suppliers = supplierRepository.GetEntities().ToList();
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
        var customers = customerRepository.GetEntities().ToList();
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
        var orders = orderRepository.GetEntities().ToList();
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
        var orderItems = orderItemRepository.GetEntities().ToList();
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
        var products = productRepository.GetEntities().ToList();
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
        var customers = customerRepository.GetEntities().ToList().Select(q => new { Id = q.Id, Name = q.FirstName + " " + q.LastName, Orders = q.Orders });
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.Id + " " + customer.Name + ":");
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"{order.OrderNumber}");
            }
        }
    }
}