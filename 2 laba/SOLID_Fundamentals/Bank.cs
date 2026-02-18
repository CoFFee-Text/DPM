namespace SOLID_Fundamentals
{
    public interface IAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
        bool TryWithdraw(decimal amount, out string message);
        decimal CalculateInterest();
    }

    public abstract class BaseAccount : IAccount
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual bool TryWithdraw(decimal amount, out string message)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                message = "Success";
                return true;
            }
            message = "Insufficient funds";
            return false;
        }

        public virtual decimal CalculateInterest() => Balance * 0.01m;
    }

    public class SavingsAccount : BaseAccount
    {
        public decimal MinimumBalance { get; } = 100m;

        public override bool TryWithdraw(decimal amount, out string message)
        {
            if (Balance - amount < MinimumBalance)
            {
                message = "Cannot go below minimum balance";
                return false;
            }
            return base.TryWithdraw(amount, out message);
        }
    }

    public class CheckingAccount : BaseAccount
    {
        public decimal OverdraftLimit { get; } = 500m;

        public override bool TryWithdraw(decimal amount, out string message)
        {
            if (Balance - amount < -OverdraftLimit)
            {
                message = "Overdraft limit exceeded";
                return false;
            }
            Balance -= amount;
            message = "Success";
            return true;
        }
    }

    public class FixedDepositAccount : BaseAccount
    {
        public DateTime MaturityDate { get; }

        public FixedDepositAccount(DateTime maturityDate)
        {
            MaturityDate = maturityDate;
        }

        public override bool TryWithdraw(decimal amount, out string message)
        {
            if (DateTime.Now < MaturityDate)
            {
                message = "Cannot withdraw before maturity date";
                return false;
            }
            return base.TryWithdraw(amount, out message);
        }

        public override decimal CalculateInterest() => Balance * 0.05m;
    }

    public class Bank
    {
        public void ProcessWithdrawal(IAccount account, decimal amount)
        {
            if (account.TryWithdraw(amount, out string message))
            {
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            else
            {
                Console.WriteLine($"Withdrawal failed: {message}");
            }
        }

        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
            if (from.TryWithdraw(amount, out string message))
            {
                to.Deposit(amount);
                Console.WriteLine($"Transfer successful: {amount} from {from.GetType().Name} to {to.GetType().Name}");
            }
            else
            {
                Console.WriteLine($"Transfer failed: {message}");
            }
        }
    }
}
