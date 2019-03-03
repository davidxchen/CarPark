using CarPark.Services.Interfaces;
using CarPark.Services.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace CarPark.Services.Services
{
    public class CarParkService : ICarParkService
    {
        private readonly IMemoryCache _cache;

        public CarParkService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<int> GetCapacity(Guid carparkId)
        {
            ThrowIfDispose();

            var capacity = GetCarParkInformation(carparkId).Result.Capacity;

            return Task.FromResult(capacity);
        }

        public Task<Guid> BuildCarPark(int capacity)
        {
            ThrowIfDispose();

            CarParkInformation carPark = new CarParkInformation
            {
                CarParkId = new Guid("487407A8-5C59-4E86-9D91-80CC65AAD5A4"),
                Capacity = capacity,
                CarParkName = "Easy Park"
            };

            _cache.Set(carPark.CarParkId.ToString(), carPark);

            return Task.FromResult(carPark.CarParkId);
        }

        public Task<CarParkInformation> GetCarParkInformation(Guid carparkId)
        {
            ThrowIfDispose();

            CarParkInformation carPark;
            if (!_cache.TryGetValue(carparkId.ToString(), out carPark))
            {
                BuildCarPark(200);

                _cache.TryGetValue(carparkId.ToString(), out carPark);
            }
            
            return Task.FromResult(carPark);
        }

        public Task<bool> HasAvailableLots(Guid carparkId)
        {
            ThrowIfDispose();

            var capacity = GetCarParkInformation(carparkId).Result.Capacity;
            var occupiedLots = 0;

            return Task.FromResult((capacity - occupiedLots) > 0);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CarParkService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);

            Console.WriteLine($"{this.GetType().Name} is disposed.");
        }

        private void ThrowIfDispose()
        {
            if (disposedValue)
            {
                throw new Exception($"{this.GetType().Name} is disposed.");
            }
        }
        #endregion
    }
}
