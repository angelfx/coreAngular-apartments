using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Entities
{
    public class District
    {

        public int Id { get; set; }

        public int IdDistrict { get; set; }

        public string Title { get; set; }

        public virtual List<Building> Buildings { get; set; }

        public virtual Region Region { get; set; }
    }
}
