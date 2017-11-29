using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        UserLiteDTO GetUserLite(string email, string password);

        UserDTO GetUser(int userId);

        void AddUser(UserLiteDTO user);
    }
}