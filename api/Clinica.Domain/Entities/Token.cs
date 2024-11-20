using Clinica.Domain.Common;

namespace Clinica.Domain.Entities
{
    public class Token : BaseEntity
    {
        public DateTime Expiration { get; set; }

        public required string Username { get; set; }

        public required string RefreshToken { get; set; }
    }
}