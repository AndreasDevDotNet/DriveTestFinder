using DriveTestFinderLib.Model.DTO;
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

        public List<UserData> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return UserData.FromUsers(users);
        }
    }
}
