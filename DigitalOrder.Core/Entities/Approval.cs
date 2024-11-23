namespace DigitalOrder.Core.Entities
{
    public class Approval : BaseEntity
    {
        public string Name { get; set; }

        public string Authority { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }

}
