using DriveTestFinderRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DriveTestFinderLib.Model.DTO.Enums;

namespace DriveTestFinderLib.Model.DTO
{
    public class UserData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool NotifyByPush { get; set; }
        public bool NotifyByEmail { get; set; }
        public int LanguageId { get; set; }
        public SubscriptionEnum Subscription { get; set; }
        public RoleEnum Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static UserData FromUser(User user)
        {
            var ud = new UserData
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                LanguageId = user.LanguageId,
                NotifyByEmail = user.NotifyByEmail,
                NotifyByPush = user.NotifyByPush,
                UserName = user.Login.UserName,
                Password = user.Login.Password,
                Phone = user.Phone,
                Role = (RoleEnum)user.Login.Role.LoginRoleId,
                SocialSecurityNumber = user.SocialSecurityNumber,
                Subscription = (SubscriptionEnum)user.Subscription.SubscriptionId
            };

            return ud;
        }
    }
}
