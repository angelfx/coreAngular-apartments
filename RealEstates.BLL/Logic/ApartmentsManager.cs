using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstates.Abstract;
using RealEstates.Abstract.Logic;
using RealEstates.Entities;
using RealEstates.Models.DTO;
using RealEstates.Models.DTO.Filters;
using RealEstates.Models.DTO.Table;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.BLL.Logic
{
    public class ApartmentsManager : BaseLogic<ApartmentDTO, Apartment>, IApartmentsManager
    {
        public ApartmentsManager(IDALContext ctx) : base(ctx)
        { }

        public override ApartmentDTO Get(int id)
        {
            var apartment = db.Apartments
                .Include(x => x.Building)
                .ThenInclude(x => x.District)
                .ThenInclude(x => x.Region)
                .Single(x => x.Id == id);
            ApartmentDTO apartmentDTO = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Apartment, ApartmentDTO>()
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.Building.BuildingNumber))
                .ForMember(dest => dest.DistrictTitle, opt => opt.MapFrom(src => src.Building.District.Title))
                .ForMember(dest => dest.NameRC, opt => opt.MapFrom(src => src.Building.NameRC))
                .ForMember(dest => dest.QueueNumber, opt => opt.MapFrom(src => src.Building.QueueNumber))
                .ForMember(dest => dest.RegionTitle, opt => opt.MapFrom(src => src.Building.District.Region.Title)));
            var mapper = config.CreateMapper();

            if (apartment != null)
            {
                apartmentDTO = mapper.Map<ApartmentDTO>(apartment);
            }

            return apartmentDTO;
        }

        /// <summary>
        /// Get all objects
        /// </summary>
        public List<ApartmentDTO> GetAll()
        {
            return db.Apartments.Select(x => new ApartmentDTO
            {
                Id = x.Id,
                idApartment = x.IdApartment,
                CommonArea = x.CommonArea,
                Cost = x.Cost,
                Floor = x.Floor,
                KitchenArea = x.KitchenArea,
                QuantitiesOfRooms = x.QuantitiesOfRooms
            }).ToList();
        }

        /// <summary>
        /// Get paged objects
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableApartmentsDTO GetPaged(ApartmentFilterDTO filter)
        {
            var model = new TableApartmentsDTO();
            model.Filter = filter;

            var models = db.Apartments.Select(x => new ApartmentDTO
            {
                Id = x.Id,
                idApartment = x.IdApartment,
                CommonArea = x.CommonArea,
                Cost = x.Cost,
                Floor = x.Floor,
                KitchenArea = x.KitchenArea,
                QuantitiesOfRooms = x.QuantitiesOfRooms,
                BuildingNumber = x.Building.BuildingNumber,
                NameRC = x.Building.NameRC,
                QueueNumber = x.Building.QueueNumber,
                DistrictTitle = x.Building.District.Title,
                RegionTitle = x.Building.District.Region.Title
            });

            models = Filter(filter, models);

            models = Sort(filter, models);

            models = models.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize + 1);

            model.NextPage = models.Count() > filter.PageSize;

            model.Apartments = models.Take(filter.PageSize).ToList();

            return model;
        }

        /// <summary>
        /// Filter query
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        private IQueryable<ApartmentDTO> Filter(ApartmentFilterDTO filter, IQueryable<ApartmentDTO> models)
        {
            if (filter.CommonAreaFrom > 0)
                models = models.Where(x => x.CommonArea >= filter.CommonAreaFrom);

            if (filter.CommonAreaTo > 0)
                models = models.Where(x => x.CommonArea <= filter.CommonAreaTo);

            if (filter.KitchenAreaFrom > 0)
                models = models.Where(x => x.KitchenArea >= filter.KitchenAreaFrom);

            if (filter.KitchenAreaTo > 0)
                models = models.Where(x => x.KitchenArea <= filter.KitchenAreaTo);

            if (filter.CostFrom > 0)
                models = models.Where(x => x.Cost >= filter.CostFrom);

            if (filter.CostTo > 0)
                models = models.Where(x => x.Cost <= filter.CostTo);

            return models;
        }

        /// <summary>
        /// Sort query
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        private IQueryable<ApartmentDTO> Sort(ApartmentFilterDTO filter, IQueryable<ApartmentDTO> models)
        {
            switch (filter.SortField?.ToLower())
            {
                case "commonarea":
                    if (filter.SortOrder == "asc")
                        models = models.OrderBy(x => x.CommonArea);
                    else
                        models = models.OrderByDescending(x => x.CommonArea);
                    break;
                case "kitchenarea":
                    if (filter.SortOrder == "asc")
                        models = models.OrderBy(x => x.KitchenArea);
                    else
                        models = models.OrderByDescending(x => x.KitchenArea);
                    break;
                case "cost":
                    if (filter.SortOrder == "asc")
                        models = models.OrderBy(x => x.Cost);
                    else
                        models = models.OrderByDescending(x => x.Cost);
                    break;
                case "floor":
                    if (filter.SortOrder == "asc")
                        models = models.OrderBy(x => x.Floor);
                    else
                        models = models.OrderByDescending(x => x.Floor);
                    break;
                case "districttitle":
                    if (filter.SortOrder == "asc")
                        models = models.OrderBy(x => x.Floor);
                    else
                        models = models.OrderByDescending(x => x.Floor);
                    break;
                default:
                    break;
            }

            return models;
        }
    }
}
