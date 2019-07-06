using System;

namespace RealEstates.Entities
{
    public class Apartment
    {
        public int Id { get; set; }

        public int IdApartment { get; set; }

        public int QuantitiesOfRooms { get; set; }

        public float CommonArea { get; set; }

        public float KitchenArea { get; set; }

        public int Floor { get; set; }

        public float Cost { get; set; }

        public virtual Building Building { get; set; }
    }
}
