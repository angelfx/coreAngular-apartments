using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Abstract.Logic;

namespace RealEstates.Abstract.Service
{
    public interface IRealEstateService
    {
        IApartmentsManager ApartmentsManager { get; }
        IBuildingsManager BuildingsManager { get; }
        IDistrictsManager DistrictssManager { get; }
        IRegionsManager RegionsManager { get; }
    }
}
