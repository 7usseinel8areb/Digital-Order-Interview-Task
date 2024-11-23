using DigitalOrder.Core.Enums;

namespace DigitalOrder.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public ProductType Type { get; set; }

        public string Details { get; set; }

        public decimal Price { get; set; }
    }

}
