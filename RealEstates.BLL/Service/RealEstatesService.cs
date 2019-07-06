using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Abstract;
using RealEstates.Abstract.Service;
using RealEstates.Abstract.Logic;
using RealEstates.BLL.Logic;

namespace RealEstates.BLL.Service
{
    public class RealEstatesService : IRealEstateService
    {
        private IDALContext db;

        public RealEstatesService(IDALContext ctx)
        {
            db = ctx;
        }

        private IApartmentsManager _apartmentsManager;

        public IApartmentsManager ApartmentsManager
        {
            get
            {
                if (_apartmentsManager == null)
                    _apartmentsManager = new ApartmentsManager(db);
                return _apartmentsManager;
            }
        }

        private IBuildingsManager _buildingsManager;

        public IBuildingsManager BuildingsManager
        {
            get
            {
                if (_buildingsManager == null)
                    _buildingsManager = new BuildingsManager(db);
                return _buildingsManager;
            }
        }

        private IDistrictsManager _districtssManager;

        public IDistrictsManager DistrictssManager
        {
            get
            {
                if (_districtssManager == null)
                    _districtssManager = new DistrictsManager(db);
                return _districtssManager;
            }
        }

        private IRegionsManager _regionsManager;

        public IRegionsManager RegionsManager
        {
            get
            {
                if (_regionsManager == null)
                    _regionsManager = new RegionsManager(db);
                return _regionsManager;
            }
        }

        
    }
}
