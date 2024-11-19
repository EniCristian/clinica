using Clinica.Domain.Common;

namespace Clinica.Domain.Entities
{
    public class Token : BaseEntity
    {
        public DateTime Expiration { get; set; }

        public TokenType Type { get; set; }

        public ApplicationUser User { get; set; }

        public string Value { get; set; }
    }

    public enum TokenType
    {
        RefreshToken = 1
    }
}