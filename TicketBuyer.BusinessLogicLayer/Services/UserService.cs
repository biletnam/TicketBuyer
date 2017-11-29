using System;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly IWishEventService _wishEventService;

        public UserService(IUnitOfWork unitOfWork, IOrderService orderService, IWishEventService wishEventService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _wishEventService = wishEventService;
        }

        public UserLiteDTO GetUserLite(string email, string password)
        {
            var user = _unitOfWork.UserRepository.Find(x => x.Email == email && x.Password == password)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }
 
            return new UserLiteDTO
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };
        }

        public UserDTO GetUser(int userId)
        {
            var user = _unitOfWork.UserRepository.Find(x => x.Id == userId).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                Role = user.Role,
                Orders = _orderService.GetOrders(user.Id),
                WishEvents = _wishEventService.GetWishEvents(user.Id)
            };
        }

        public void AddUser(UserLiteDTO user)
        {
            if (_unitOfWork.UserRepository.Find(x => x.Email == user.Email).Any())
            {
                throw new Exception();
            }

            var newUser = new User
            {
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };

            _unitOfWork.UserRepository.Add(newUser);
            _unitOfWork.SaveChanges();
        }
    }
}