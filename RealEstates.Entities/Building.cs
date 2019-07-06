using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstates.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public int IdBuilding { get; set; }

        public int QueueNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string NameRC { get; set; }

        public virtual List<Apartment> Apartments { get; set; }

        public virtual District District { get; set; }
    }
}