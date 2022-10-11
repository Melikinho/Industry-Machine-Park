using Industry_Machine_Park.Shared;
using Microsoft.AspNetCore.Components.Routing;

namespace Industry_Machine_Park.Services
{
    public class MachineClient : IMachineClient
    {
        private readonly HttpClient httpClient;

        public MachineClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Device>> GetAsync()
        {
            DateTime StartDate = DateTime.Now.AddDays(Random.Shared.Next(100)).Date;

            return new List<Device>()
        {
            new Device()
            {
                Name = "Machine Eikido",
                Type = "Waterpump sensor",
                Location = "Stockholm, Sweden",
                IsActive = true
            },
            new Device()
            {
                Name = "Machine Zabaleta",
                Type = "Humidity Sensor",
                Location = "Malmö, Sweden",
                IsActive = true
            },
            new Device()
            {
                Name = "Machine Charmander",
                Type = "Fire Sensor",
                Location = "Gälve, Sweden",
                IsActive = false
            },
            new Device()
            {
                Name = "Machine Turtle",
                Type = "Leak Sensor",
                Location = "Luleå, Sweden",
                IsActive = true
            },
             new Device()
            {
                Name = "Machine Snorlax",
                Type = "Grass Sensor",
                Location = "Kiruna, Sweden",
                IsActive = false
            },
            new Device()
            {
                Name = "Machine Vulpix",
                Type = "Rain Sensor",
                Location = "Helsingborg, Sweden",
                IsActive = true
            }
        };
        }
    }


}
