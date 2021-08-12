using System;
using System.Text.RegularExpressions;

namespace CheckFields
{
    public class CheckFields
    {
        #region Private methods
        private bool CheckPassword(string password)
        {
            bool isValid = true;
            int minLength = 8;

            if (password.Length < minLength || !Regex.Match(password, @"/\d+/",
                RegexOptions.ECMAScript).Success ||
                !(Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
                Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success) ||
                !Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
            {
                isValid = false;
            }
            return isValid;
        }
        private bool CheckUsername(string user)
        {
            bool isValid = true;
            int minLength = 4;
            if (String.IsNullOrWhiteSpace(user) || user.Length <= minLength)
            {
                isValid = !isValid;
            }
            return isValid;
        }
        #endregion
        #region Public Method
        public bool IsValid(string user, string password)
        {
            bool isValidPassword = CheckPassword(password);
            bool isValidUser = CheckUsername(user);
            if (isValidPassword && isValidUser)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
