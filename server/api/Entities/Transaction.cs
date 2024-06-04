namespace api.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
