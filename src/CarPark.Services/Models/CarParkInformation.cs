using System;

namespace CarPark.Services.Models
{
    public class CarParkInformation
    {
        public Guid CarParkId { get; set; }

        public string CarParkName { get; set; }

        public int Capacity { get; set; } = 200;
    }
}
