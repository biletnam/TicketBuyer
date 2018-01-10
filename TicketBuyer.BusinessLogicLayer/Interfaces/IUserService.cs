using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {


        User GetUser(string username);
    }
}