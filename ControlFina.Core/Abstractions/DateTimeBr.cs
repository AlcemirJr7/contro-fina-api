namespace ControlFina.Core.Abstractions;

public static class DateTimeBr
{
    private static readonly TimeZoneInfo _brasilTimeZone = GetBrazilTimeZone();

    private static TimeZoneInfo GetBrazilTimeZone()
    {
        try
        {
            // Windows
            return TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        }
        catch (TimeZoneNotFoundException)
        {
            try
            {
                // Linux/Mac
                return TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }
            catch (TimeZoneNotFoundException)
            {
                // Fallback para UTC-3
                return TimeZoneInfo.CreateCustomTimeZone(
                    "Brazil Standard Time",
                    TimeSpan.FromHours(-3),
                    "Brazil Standard Time",
                    "Brazil Standard Time");
            }
        }
    }

    /// <summary>
    /// Retorna a data/hora atual no timezone do Brasil
    /// </summary>
    public static DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _brasilTimeZone);

    /// <summary>
    /// Retorna apenas a data atual no timezone do Brasil
    /// </summary>
    public static DateTime Today => Now.Date;

    /// <summary>
    /// Converte UTC para horário do Brasil
    /// </summary>
    public static DateTime FromUtc(DateTime utcDateTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, _brasilTimeZone);
    }

    /// <summary>
    /// Converte horário do Brasil para UTC
    /// </summary>
    public static DateTime ToUtc(DateTime brazilDateTime)
    {
        return TimeZoneInfo.ConvertTimeToUtc(brazilDateTime, _brasilTimeZone);
    }

    /// <summary>
    /// Formata data/hora no padrão brasileiro
    /// </summary>
    public static string Format(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss")
    {
        return dateTime.ToString(format);
    }

    /// <summary>
    /// Retorna o timezone do Brasil
    /// </summary>
    public static TimeZoneInfo TimeZone => _brasilTimeZone;
}
