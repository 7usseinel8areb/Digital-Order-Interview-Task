namespace DigitalOrder.Core.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }

        public string Industry { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }

}
