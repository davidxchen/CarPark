using CarPark.Services.Models;
using Newtonsoft.Json;

namespace CarPark.Services.Extensions
{
    public static class  CarParkInfoExtension
    {
        public static string ToJsonString(this CarParkInformation carpark)
        {
            return JsonConvert.SerializeObject(carpark);
        }
    }
}