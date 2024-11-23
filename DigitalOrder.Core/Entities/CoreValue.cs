namespace DigitalOrder.Core.Entities
{
    public class CoreValue : BaseEntity
    {
        public string Value { get; set; }

        public int CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
    }

}
