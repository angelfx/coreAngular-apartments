using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Abstract.Service;
using RealEstates.Models.DTO;
using RealEstates.Models.DTO.Filters;
using RealEstates.Models.ViewModel;
using RealEstates.Models.ViewModel.Filters;
using RealEstates.Models.ViewModel.Table;

namespace RealEstates.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private IRealEstateService service;

        public ApartmentsController(IRealEstateService ctx)
        {
            service = ctx;
        }

        // GET: api/Apartments
        [HttpGet("[action]")]
        public IEnumerable<ApartmentViewModel> Get()
        {
            var modelsDTO = service.ApartmentsManager.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApartmentDTO, ApartmentViewModel>());
            var mapper = config.CreateMapper();
            var models = mapper.Map<List<ApartmentViewModel>>(modelsDTO);

            return models;
        }

        [HttpGet("[action]")]
        public TableApartmentViewModel GetPaged2(
            string sortField = "",
            string sortOrder = "",
            int commonAreaFrom = 0,
            int commonAreaTo = 0,
            int kitchenAreaFrom = 0,
            int kitchenAreaTo = 0,
            int costFrom = 0,
            int costTo = 0,
            int page = 1)
        {
            ApartmentFilterViewModel filter = new ApartmentFilterViewModel();
            filter.SortField = sortField;
            filter.SortOrder = sortOrder;
            filter.CommonAreaFrom = commonAreaFrom;
            filter.CommonAreaTo = commonAreaTo;
            filter.KitchenAreaFrom = kitchenAreaFrom;
            filter.KitchenAreaTo = kitchenAreaTo;
            filter.CostFrom = costFrom;
            filter.CostTo = costTo;
            filter.Page = page;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApartmentDTO, ApartmentViewModel>();
                cfg.CreateMap<ApartmentFilterViewModel, ApartmentFilterDTO>();
            });
            var mapper = config.CreateMapper();

            var filterDTO = mapper.Map<ApartmentFilterDTO>(filter);
            var tableDTO = service.ApartmentsManager.GetPaged(filterDTO);

            var table = new TableApartmentViewModel(tableDTO.Filter.Page, tableDTO.Filter.PageSize, tableDTO.Count);
            table.Apartments = mapper.Map<List<ApartmentViewModel>>(tableDTO.Apartments);
            table.Filter = filter;
            table.NextPage = tableDTO.NextPage;

            return table;
        }

        // GET: api/Apartments/5
        [HttpGet("[action]/{id}")]
        public ApartmentViewModel Get(int id)
        {
            var modelDTO = service.ApartmentsManager.Get(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApartmentDTO, ApartmentViewModel>());
            var mapper = config.CreateMapper();
            var model = mapper.Map<ApartmentViewModel>(modelDTO);

            return model;
        }

        [HttpPut("[action]")]
        public int Update(ApartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApartmentViewModel, ApartmentDTO>());
                var mapper = config.CreateMapper();
                var modelDTO = mapper.Map<ApartmentDTO>(model);

                service.ApartmentsManager.Update(modelDTO);
            }
            else
            {
                return 400;
            }
            return 200;
        }

        // POST: api/Apartments
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Apartments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("[action]/{id}")]
        public void Delete(int id)
        {
            service.ApartmentsManager.Delete(id);
        }
    }
}