using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Atlanta", Arrival = new DateTime(2016,08,07), Latitude = -65.4353, Longitude = 24.345, Order = 0 },
                        new Stop() { Name = "Denver", Arrival = new DateTime(2016,08,08), Latitude = 56.4353, Longitude = -64.345, Order = 1 }
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Budapest", Arrival = new DateTime(2016,08,10), Latitude = -35.4353, Longitude = 24.345, Order = 0 },
                        new Stop() { Name = "Paris", Arrival = new DateTime(2016,08,11), Latitude = 86.4353, Longitude = 14.345, Order = 1 },
                        new Stop() { Name = "Budapest", Arrival = new DateTime(2016,08,12), Latitude = -35.4353, Longitude = 24.345, Order = 2 }

                    }
                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                _context.SaveChanges();
            }
        }
    }
}
