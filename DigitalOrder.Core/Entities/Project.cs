using DigitalOrder.Core.Enums;

namespace DigitalOrder.Core.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ClientName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ProjectStatus Status { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }

}
