using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Fundamentals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPaymentProcessor
    {
        void ProcessPayment(string paymentMethod, decimal amount);
    }
    public interface IInventoryService
    {
        void UpdateInventory(IReadOnlyList<string> items);
    }
    public interface INotificationService
    {
        void SendEmail(string to, string message);
    }
    public interface ILogger
    {
        void LogToDatabase(string message);
    }
    public interface IReceiptGenerator
    {
        void GenerateReceipt(Order order);
    }

    public class OrderRepository
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine($"Order {order.Id} added");
        }

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public decimal GetTotalRevenue()
        {
            return orders.Sum(o => o.TotalAmount);
        }

        public int GetTotalOrdersCount()
        {
            return orders.Count;
        }
    }

    public class OrderProcessingService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IInventoryService _inventoryService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;
        private readonly IReceiptGenerator _receiptGenerator;

        public OrderProcessingService(
            IPaymentProcessor paymentProcessor,
            IInventoryService inventoryService,
            INotificationService notificationService,
            ILogger logger,
            IReceiptGenerator receiptGenerator)
        {
            _paymentProcessor = paymentProcessor;
            _inventoryService = inventoryService;
            _notificationService = notificationService;
            _logger = logger;
            _receiptGenerator = receiptGenerator;
        }

        public void ProcessOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.TotalAmount <= 0)
                throw new Exception("Invalid order amount");

            Console.WriteLine($"Processing order {order.Id}");

            _paymentProcessor.ProcessPayment(order.PaymentMethod, order.TotalAmount);
            _inventoryService.UpdateInventory(order.Items);
            _notificationService.SendEmail(order.CustomerEmail, $"Order {order.Id} processed");
            _logger.LogToDatabase($"Order {order.Id} processed at {DateTime.Now}");
            _receiptGenerator.GenerateReceipt(order);
        }
    }

    public class ReportService
    {
        private readonly OrderRepository _orderRepository;

        public ReportService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void GenerateMonthlyReport()
        {
            decimal totalRevenue = _orderRepository.GetTotalRevenue();
            int totalOrders = _orderRepository.GetTotalOrdersCount();
            Console.WriteLine($"Monthly Report: {totalOrders} orders, Revenue: {totalRevenue:C}");
        }
    }

    public class ExportService
    {
        public void ExportToExcel(string filePath)
        {
            Console.WriteLine($"Exporting orders to {filePath}");
        }
    }
}
