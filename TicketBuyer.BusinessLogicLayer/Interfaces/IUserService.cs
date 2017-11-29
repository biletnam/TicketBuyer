using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        bool IsUserExist(string username, string email);

        void RegisterUser(string username, string email, string password);

        User GetUserForLogin(string email, string password);

        User GetUser(string username);
    }
}