namespace Industry_Machine_Park.Shared
{
    public class Machine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("");
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public DateTime LastUpdated { get; set; } = default;
        public string Location { get; set; } = String.Empty;
        public bool IsActive { get; set; } = default;
    }
}