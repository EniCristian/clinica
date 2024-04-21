using Clinica.Application.Interfaces;

namespace Clinica.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
