namespace DigitalOrder.Core.Entities
{
    public class CompanyProfile : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Mission { get; set; }

        public string Vision { get; set; }

        public virtual ICollection<CoreValue> CoreValues { get; set; }
    }

}
