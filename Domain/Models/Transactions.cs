namespace Domain.Models
{
    public class Transactions
    {
        public int transaction_id { get; set; }
        public DateOnly dateTransaction { get; set; }
        public Client Client { get; set; }
    }
}
