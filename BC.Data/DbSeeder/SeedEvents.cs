using BC.Data.Entities;
using BC.Data.JsonManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BC.Data.DbSeeder
{
    public static class SeedEvents
    {
        private const string eventsDirectory = @"..\BC.Data\JsonRaw\Events.json";

        public static void SeedDatabaseEvents(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _context = serviceScope.ServiceProvider.GetService<BettingContext>();
                var _jsonManager = serviceScope.ServiceProvider.GetService<IJsonManager>();

                if (!_context.Events.Any())
                {
                    _context.Database.Migrate();

                    var events = _jsonManager.ExtractTypesFromJson<Event>(eventsDirectory);

                    _context.Events.AddRange(events);
                    _context.SaveChanges();
                }
            }
        }
    }
}
