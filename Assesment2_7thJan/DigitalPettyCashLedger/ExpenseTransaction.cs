namespace DigitalPettyCashLedger.Models
{
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        public ExpenseTransaction(
            int id,
            DateTime date,
            double amount,
            string description,
            string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }

        public override string GetSummary()
        {
            return $"[EXPENSE] {Date.ToShortDateString()} | {Category} | ₹{Amount} | {Description}";
        }
    }
}
