using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static void ToString(this User user) { }

        public static void ValidateCredentials(this UserData user, string name, string password)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("The name cannot be empty");
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("The password cannot be empty");
            }

            //TODO: Invoke ValidateUser(string name, string password); from UserData
        }

        public static void GetUser(this UserData user)
        {
            user.GetUser();
        }
    }
}
