using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;
using RealEstates.Models.DTO;
using RealEstates.Abstract;
using RealEstates.Abstract.Logic;

namespace RealEstates.BLL.Logic
{
    public class BuildingsManager : BaseLogic<BuildingDTO, Building>, IBuildingsManager
    {
        public BuildingsManager(IDALContext ctx) : base(ctx)
        { }
    }
}
