using Industry_Machine_Park.Shared;

namespace Industry_Machine_Park.Services
{
    public interface IMachineClient
    {
        Task<IEnumerable<Machine>> GetAsync();
    }
}
