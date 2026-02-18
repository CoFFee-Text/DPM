namespace SOLID_Fundamentals
{
    public interface IDiscountPlan
    {
        decimal CalculateDiscount(decimal orderAmount);
    }
    public interface IShippingPlan
    {
        decimal CalculateShippingCost(decimal weight, string destination);
    }

    public class RegularDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.05m; }
    public class PremiumDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.10m; }
    public class VipDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.15m; }
    public class StudentDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.08m; }
    public class SeniorDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.07m; }
    public class NoDiscount : IDiscountPlan { public decimal CalculateDiscount(decimal orderAmount) => 0; }

    public class StandardShipping : IShippingPlan { public decimal CalculateShippingCost(decimal weight, string destination) => 5.00m + (weight * 0.5m); }
    public class ExpressShipping : IShippingPlan { public decimal CalculateShippingCost(decimal weight, string destination) => 15.00m + (weight * 1.0m); }
    public class OvernightShipping : IShippingPlan { public decimal CalculateShippingCost(decimal weight, string destination) => 25.00m + (weight * 2.0m); }
    public class InternationalShipping : IShippingPlan
    {
        public decimal CalculateShippingCost(decimal weight, string destination)
        {
            return destination switch
            {
                "USA" => 30.00m,
                "Europe" => 35.00m,
                "Asia" => 40.00m,
                _ => 50.00m
            };
        }
    }
}
