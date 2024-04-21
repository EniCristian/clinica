namespace Clinica.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        #region Public Constructors

        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}