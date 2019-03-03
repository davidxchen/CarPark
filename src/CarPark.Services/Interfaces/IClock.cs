using System;
using System.Threading.Tasks;

namespace CarPark.Services.Interfaces
{
    public interface IClock
    {
        Task ShowTime(DateTime currentTime);
    }
}
