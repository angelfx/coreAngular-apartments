using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;

namespace RealEstates.BLL.Helpers
{
    public static class EntityParser
    {
        public static Apartment ParseApartment(string[] array)
        {
            if (array == null || array.Length < 14)
                return null;

            Apartment apartment = new Apartment
            {
                IdApartment = int.Parse(array[0]),
                CommonArea = float.Parse(array[10].Replace('.',',')),
                Cost = float.Parse(array[13].Replace('.', ',')),
                Floor = int.Parse(array[12]),
                KitchenArea = float.Parse(array[11].Replace('.', ',')),
                QuantitiesOfRooms = int.Parse(array[9])
            };
            return apartment;
        }

        public static Building ParseBuilding(string[] array)
        {
            if (array == null || array.Length < 14)
                return null;

            Building building = new Building
            {
                IdBuilding = int.Parse(array[1]),
                BuildingNumber = array[4],
                NameRC = array[2],
                QueueNumber = int.Parse(array[3])
            };
            return building;
        }

        public static District ParseDistrict(string[] array)
        {
            if (array == null || array.Length < 14)
                return null;

            District district = new District
            {
                IdDistrict = int.Parse(array[7]),
                Title = array[8]
            };
            return district;
        }

        public static Region ParseRegion(string[] array)
        {
            if (array == null || array.Length < 14)
                return null;

            Region region = new Region
            {
                IdRegion = int.Parse(array[5]),
                Title = array[6]
            };
            return region;
        }
    }
}
