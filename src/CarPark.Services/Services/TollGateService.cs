using CarPark.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CarPark.Services.Services
{
    public class TollGateService : ITollGateService
    {
        private readonly ICarParkService _carpark;

        public TollGateService(ICarParkService carpark)
        {
            _carpark = carpark;
        }

        public Task<bool> Enter(string carPlate)
        {
            ThrowIfDispose();

            return Task.FromResult(!string.IsNullOrEmpty(carPlate));
        }

        public Task<bool> Leave(string carPlate)
        {
            ThrowIfDispose();

            return Task.FromResult(!string.IsNullOrEmpty(carPlate));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            Console.WriteLine($"{this.GetType().Name} is disposed.");
        }

        private void ThrowIfDispose()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException($"{this.GetType().Name} is disposed.");
            }
        }
        #endregion
    }
}
