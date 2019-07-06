using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Models.ViewModel
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }

        public int idApartment { get; set; }

        public int QuantitiesOfRooms { get; set; }

        public float CommonArea { get; set; }

        public float KitchenArea { get; set; }

        public int Floor { get; set; }

        public float Cost { get; set; }

        public string NameRC { get; set; }

        public int QueueNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string RegionTitle { get; set; }

        public string DistrictTitle { get; set; }
    }
}
