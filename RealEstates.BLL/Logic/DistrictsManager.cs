using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;
using RealEstates.Abstract;
using RealEstates.Abstract.Logic;
using RealEstates.Models.DTO;

namespace RealEstates.BLL.Logic
{
    public class DistrictsManager : BaseLogic<DistrictDTO,District>, IDistrictsManager
    {
        public DistrictsManager(IDALContext ctx) : base(ctx)
        { }
    }
}
