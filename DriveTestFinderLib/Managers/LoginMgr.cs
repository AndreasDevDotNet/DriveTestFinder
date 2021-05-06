using DriveTestFinderLib.Model.DTO;
using DriveTestFinderRepository.Repositories;
using System;
using System.Text;

namespace DriveTestFinderLib.Managers
{
    public class LoginMgr
    {
        private readonly UserRepository _userRepository;

        public LoginMgr(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public UserData LoginUser(string userName, string passWord)
        {
            var decodedPassword = Encoding.UTF8.GetString(Convert.FromBase64String(passWord));

            var user = _userRepository.FindOne(x => x.UserName == userName && x.Password == decodedPassword);
                                        
            if(user != null)
            {
                return UserData.FromUser(user);
            }

            return null;
        }
    }
}
