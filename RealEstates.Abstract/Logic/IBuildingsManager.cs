using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Models.DTO;
using RealEstates.Entities;

namespace RealEstates.Abstract.Logic
{
    public interface IBuildingsManager : IBaseLogic<BuildingDTO, Building>
    {
    }
}
