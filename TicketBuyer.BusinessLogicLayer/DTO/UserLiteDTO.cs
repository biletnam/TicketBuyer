using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class UserLiteDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public Role Role { get; set; }
    }
}