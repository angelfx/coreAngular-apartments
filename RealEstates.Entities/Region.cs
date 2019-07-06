using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Entities
{
    public class Region
    {
        public int Id { get; set; }

        public int IdRegion { get; set; }

        public string Title { get; set; }

        public virtual List<District> Districts { get; set; }
    }
}
