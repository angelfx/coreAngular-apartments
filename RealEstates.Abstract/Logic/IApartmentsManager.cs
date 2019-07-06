using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;
using RealEstates.Models.DTO;
using RealEstates.Models.DTO.Table;
using RealEstates.Models.DTO.Filters;

namespace RealEstates.Abstract.Logic
{
    public interface IApartmentsManager : IBaseLogic<ApartmentDTO, Apartment>
    {
        List<ApartmentDTO> GetAll();

        TableApartmentsDTO GetPaged(ApartmentFilterDTO filter);
    }
}
