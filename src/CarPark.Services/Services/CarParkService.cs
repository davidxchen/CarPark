using CarPark.Services.Interfaces;
using CarPark.Services.Models;
using System;
using System.Threading.Tasks;

namespace CarPark.Services.Services
{
    public class CarParkService : ICarParkService
    {
        public CarParkService()
        {

        }

        public Task<int> GetCapacity(Guid carparkId)
        {
            throw new NotImplementedException();
        }

        public async Task<CarParkInformation> GetCarParkInformation(Guid carparkId)
        {
            ThrowIfDispose();

            var parkInfo = new CarParkInformation()
            {

            };

            return parkInfo;
        }

        public Task<bool> HasAvailableLots(Guid carparkId)
        {
            throw new NotImplementedException();
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
