using System.Collections.Generic;

namespace DriveTestFinderLib.Model.Response
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public bool LoginSuccessful { get; set; }
        public string SecurityToken { get; set; }
        public List<string> Errors { get; set; }
    }
}
