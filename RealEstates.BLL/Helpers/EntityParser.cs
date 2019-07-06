using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;

namespace RealEstates.BLL.Helpers
{
    public static class EntityParser
    {
        private static string[] _array;

        public static string[] array
        {
            get { return _array; }
            set
            {
                if (value.Length != 14)
                    throw new ArgumentException("Длина массива не равна 14");
                _array = value;
            }
        }

        public static Apartment ParseApartment()
        {
            if (_array == null || _array.Length < 14)
                return null;

            Apartment apartment = new Apartment
            {
                IdApartment = int.Parse(_array[0]),
                CommonArea = float.Parse(_array[10].Replace('.',',')),
                Cost = float.Parse(_array[13].Replace('.', ',')),
                Floor = int.Parse(_array[12]),
                KitchenArea = float.Parse(_array[11].Replace('.', ',')),
                QuantitiesOfRooms = int.Parse(_array[9])
            };
            return apartment;
        }

        public static Building ParseBuilding()
        {
            if (_array == null || _array.Length < 14)
                return null;

            Building building = new Building
            {
                IdBuilding = int.Parse(_array[1]),
                BuildingNumber = _array[4],
                NameRC = _array[2],
                QueueNumber = int.Parse(_array[3])
            };
            return building;
        }

        public static District ParseDistrict()
        {
            if (_array == null || _array.Length < 14)
                return null;

            District district = new District
            {
                IdDistrict = int.Parse(_array[7]),
                Title = _array[8]
            };
            return district;
        }

        public static Region ParseRegion()
        {
            if (_array == null || _array.Length < 14)
                return null;

            Region region = new Region
            {
                IdRegion = int.Parse(_array[5]),
                Title = _array[6]
            };
            return region;
        }
    }
}
