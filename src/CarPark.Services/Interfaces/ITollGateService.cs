using System.Threading.Tasks;

namespace CarPark.Services.Interfaces
{
    public interface ITollGateService : IService
    {
        Task<bool> Enter(string carPlate);

        Task<bool> Leave(string carPlate);
    }
}
