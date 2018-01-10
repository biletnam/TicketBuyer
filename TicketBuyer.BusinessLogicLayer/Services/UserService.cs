using System;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserExist(string username, string email)
        {
            return _unitOfWork.AuthRepository.Find(x => x.Email == email).Any();
        }

        public User GetUser(string username)
        {
            return _unitOfWork.UserRepository.Find(x => x.Username == username).FirstOrDefault();
            
        }

        public User GetUserForLogin(string email, string password)
        {
            var auth = _unitOfWork.AuthRepository.Find(x => x.Email == email && x.Password == password)
                .FirstOrDefault();
            return _unitOfWork.AuthRepository.Find(x => x.Email == email && x.Password == password)
                .FirstOrDefault().User;
        }

        public void RegisterUser(string username, string email, string password)
        {
            //if (_unitOfWork.UserRepository.Find(x => x.Username == username && x.Email == email).Any())
            //{
            //    throw new Exception();
            //}

            //var newUser = new User
            //{
            //    Email = email,
            //    Password = password,
            //    Username = username
            //};

            //_unitOfWork.UserRepository.Add(newUser);
            _unitOfWork.SaveChanges();
        }
    }
}