namespace Clinica.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        #region Public Constructors

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        #endregion Public Constructors
    }
}