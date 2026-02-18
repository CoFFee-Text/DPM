namespace SOLID_Fundamentals
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string PaymentMethod { get; private set; }
        public IReadOnlyList<string> Items { get; private set; }
        public string CustomerEmail { get; private set; }
        public string CustomerPhone { get; private set; }

        public Order(int id, decimal totalAmount, string paymentMethod, List<string> items, string customerEmail, string customerPhone)
        {
            Id = id;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
            Items = items ?? new List<string>();
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
        }
    }
}
