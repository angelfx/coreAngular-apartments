using System.Collections.Generic;
using RealEstates.Models.DTO.Filters;

namespace RealEstates.Models.DTO.Table
{
    /// <summary>
    /// Model for table view with paginating
    /// </summary>
    public class TableApartmentsDTO
    {
        public int Count = 0;

        public bool NextPage = false;

        public List<ApartmentDTO> Apartments;

        public ApartmentFilterDTO Filter;

        public TableApartmentsDTO()
        {
            Filter = new ApartmentFilterDTO();
        }
    }
}
