using DigitalPettyCashLedger.Models;

namespace DigitalPettyCashLedger.Ledger
{
    public class Ledger<T> where T : Transaction
    {
        private readonly List<T> _transactions;

        public Ledger()
        {
            _transactions = new List<T>();
        }

        public void AddEntry(T entry)
        {
            _transactions.Add(entry);
        }

        public List<T> GetTransactionsByDate(DateTime date)
        {
            return _transactions
                .Where(t => t.Date.Date == date.Date)
                .ToList();
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (var transaction in _transactions)
            {
                total += transaction.Amount;
            }

            return total;
        }

        public List<T> GetAllTransactions()
        {
            return _transactions;
        }
    }
}
