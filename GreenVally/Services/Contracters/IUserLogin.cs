using GreenValley.Utility;

namespace GreenValley.Services.Contracters
{
    public interface IUserLogin
    {
        public  LoginResponse AddNewOne(LoginResponse loginResponse);
        public string ValidUser(LoginResponse loginResponse);
        public string CreatToken(LoginResponse login);
    }
}
