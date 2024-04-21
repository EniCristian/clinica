namespace Clinica.Common.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        #region Public Constructors

        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message) : base(message)
        {
        }

        #endregion Public Constructors
    }
}