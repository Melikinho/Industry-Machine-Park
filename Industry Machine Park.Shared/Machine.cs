using System.Data.Common;

namespace Industry_Machine_Park.Shared
{
    public class Machine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("");
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(Random.Shared.Next(50));
        public string Location { get; set; } = String.Empty;
        public bool IsActive { get; set; } = false;
    }
}