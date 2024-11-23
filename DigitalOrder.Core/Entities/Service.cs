using DigitalOrder.Core.Enums;

namespace DigitalOrder.Core.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ServiceCategory Category { get; set; }
    }

}
