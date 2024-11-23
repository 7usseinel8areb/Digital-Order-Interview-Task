namespace DigitalOrder.Core.Entities
{
    public class TeamMember : BaseEntity
    {
        public string Name { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Expertise { get; set; }
    }

}
