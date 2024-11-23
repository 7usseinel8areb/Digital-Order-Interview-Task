using DigitalOrder.Core.Enums;

namespace DigitalOrder.Core.Entities
{
    public class Partner : BaseEntity
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public PartnerType Type { get; set; }
    }

}
