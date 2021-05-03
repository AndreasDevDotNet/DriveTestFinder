using DriveTestFinderLib.Model.DTO;
using DriveTestFinderRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var user = _userRepository.FindOne(x => x.Login.UserName == userName && x.Login.Password == decodedPassword);

            if(user != null)
            {
                return UserData.FromUser(user);
            }

            return null;
        }
    }
}
