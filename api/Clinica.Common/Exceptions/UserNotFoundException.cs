using Clinica.Common.Resources;

namespace Clinica.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        #region Constructors

        public UserNotFoundException(string user)
            : base(string.Format(User.not_found_template, user))
        {
        }

        public UserNotFoundException()
            : base(User.not_found)
        {
        }

        #endregion
    }
}