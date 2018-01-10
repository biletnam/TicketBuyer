using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IAuthService
    {
        bool IsUserExist(string username, string email);

        void RegisterUser(string username, string email, string password);

        User GetUserForLogin(string email, string password);
    }
}