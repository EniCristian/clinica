namespace Clinica.Application.Common.Services;
public interface IDateTimeService
{
    DateTime NowUtc { get; }
}
internal class DateTimeService: IDateTimeService
{
    public DateTime NowUtc { get; }
}