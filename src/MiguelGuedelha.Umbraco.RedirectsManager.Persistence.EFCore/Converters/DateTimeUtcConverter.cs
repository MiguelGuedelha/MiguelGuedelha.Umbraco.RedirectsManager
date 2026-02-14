using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Converters;

internal sealed class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
{
   public DateTimeUtcConverter() 
      : base(
         v => v.ToUniversalTime(),
         v => new(v.Ticks, DateTimeKind.Utc)
         )
   {
   }
}