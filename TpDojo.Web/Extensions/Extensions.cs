namespace TpDojo.Web.Extensions;

public static class Extensions
{
    public static DateTime Août(this int day, int year)
    {
        return new DateTime(day, 8, year);
    }
}
