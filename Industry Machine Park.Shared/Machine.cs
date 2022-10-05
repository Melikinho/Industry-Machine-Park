namespace Industry_Machine_Park.Shared
{
    public class Machine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("");
        public string Name { get; set; } = String.Empty;
        public DateTime LastUpdated { get; set; } = default;
        public MachineType? machinetype { get; set; } = default;
    }
}