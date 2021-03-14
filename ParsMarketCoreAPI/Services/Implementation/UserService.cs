using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using ViewModels;
namespace ParsMarketCoreAPI
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private IPasswordHelper _passwordHelper;
        public UserService(IUnitOfWork UnitOfWork,IPasswordHelper PasswordHelper)
        {
            _passwordHelper = PasswordHelper;
            unitOfWork = UnitOfWork;
        }
        public Task AddUser(User user)
        {
            
            throw new NotImplementedException();
        }

        public Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UptateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterUserResult> RegisterUser(RegisterViewModel register)
        {
            if (IsUserExistByEmail(register.EmailAddress))
                return RegisterUserResult.EmailExist;
            var user = new Person() {

                EmailAddress = register.EmailAddress.SanitizeText(),
                Password = _passwordHelper.EncodePasswordMd5(register.Password),
                Address = null,
                Address2 = null,
                City = null,
                Countries = null,
                FirstName=null,
                LastName=null,
                IsAdmin=false,
                IsDelete=false,
                IsActive=true,
                PhoneNumber=12345,
                PostCode=12345,
               
            };
            await unitOfWork.PersonRepository.Insert(user);
            await unitOfWork.SaveAsync();
            return RegisterUserResult.Success;
        }

        public bool IsUserExistByEmail(string email)
        {
            var res = unitOfWork.PersonRepository.IsUserExistByEmail(email);
            return res;
        }

        public async Task<LoginUserResult> LoginUser(LoginViewModel login)
        {

            var password = _passwordHelper.EncodePasswordMd5(login.Password);
            var user = await unitOfWork.PersonRepository.GetPersonForLogin(login.EmailAddress,login.Password);
            if (user == null) return LoginUserResult.IncorrectData;
            if (!user.IsActive)
            {
                return LoginUserResult.NotActivated;
            }
            
            return LoginUserResult.Success;
        }

        public  async Task<Person> GetPersonByEmail(string email)
        {
            var res = await unitOfWork.PersonRepository.GetPersonByEmail(email);
            return res;
        }
    }
}
