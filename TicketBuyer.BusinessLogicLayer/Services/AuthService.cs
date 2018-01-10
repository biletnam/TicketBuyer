using System;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserExist(string username, string email)
        {
            return _unitOfWork.AuthRepository.Find(x => x.Email == email).Any() || _unitOfWork.UserRepository.Find(x => x.Username == username).Any();
        }

        public User GetUser(string username)
        {
            var user = _unitOfWork.UserRepository.Find(x => x.Username == username).FirstOrDefault();

            if (user == null)
            {
                throw new Exception();
            }

            return user;
        }

        public User GetUserForLogin(string email, string password)
        {
            return _unitOfWork.AuthRepository.Find(x => x.Email == email && x.Password == password)
                .FirstOrDefault()?.User;
        }

        public void RegisterUser(string username, string email, string password)
        {

            var newAuth = new Auth
            {
                Email = email,
                Password = password
            };

            _unitOfWork.AuthRepository.Add(newAuth);

            var newUser = new User
            {
                //Id = newAuth.Id,
                Username = username,
                RoleId = 1,
                AuthId = newAuth.Id
            };

            _unitOfWork.UserRepository.Add(newUser);

            _unitOfWork.SaveChanges();
        }
    }
}