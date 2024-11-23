namespace DigitalOrder.Application.Features.User.Query.Results
{
    public class GetUserResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
