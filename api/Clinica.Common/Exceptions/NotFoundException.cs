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
        
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        #endregion Public Constructors
    }
}