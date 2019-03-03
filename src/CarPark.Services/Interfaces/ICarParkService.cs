using CarPark.Services.Models;
using System;
using System.Threading.Tasks;

namespace CarPark.Services.Interfaces
{
    public interface ICarParkService : IService
    {
        Task<Guid> BuildCarPark(int capacity);

        Task<CarParkInformation> GetCarParkInformation(Guid carparkId);

        Task<int> GetCapacity(Guid carparkId);

        Task<bool> HasAvailableLots(Guid carparkId);
    }
}
