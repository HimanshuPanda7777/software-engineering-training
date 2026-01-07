using DigitalPettyCashLedger.Interfaces;

namespace DigitalPettyCashLedger.Models
{
    public abstract class Transaction : InterfaceReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        protected Transaction(int id, DateTime date, double amount, string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description=description;
        }

        public abstract string GetSummary();
    }
}
