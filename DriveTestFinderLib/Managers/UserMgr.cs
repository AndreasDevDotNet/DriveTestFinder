using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.Response;
using DriveTestFinderRepository.Entities;
using DriveTestFinderRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class UserMgr
    {
        private readonly UserRepository _userRepository;

        public UserMgr(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public async Task<List<UserData>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return UserData.FromUsers(users);
        }

        public async Task<RegisterUserResponse> RegisterUser(UserData userData)
        {
            var newUser = new User
            {
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Email = userData.Email,
                LanguageId = userData.LanguageId,
                NotifyByEmail = userData.NotifyByEmail,
                NotifyByPush = userData.NotifyByPush,
                Phone = userData.Phone,
                Password = userData.Password,
                UserName = userData.UserName,
                SocialSecurityNumber = userData.SocialSecurityNumber,
                SubscriptionId = (int)userData.Subscription,
                UserRoleId = (int)userData.Role
            };

            var u = await _userRepository.AddAsync(newUser, true);

            var registerUserResp = new RegisterUserResponse
            {
                UserId = u.Entity.UserId
            };

            return registerUserResp;

        }
    }
}
