using System.Collections.Generic;
using RealEstates.Models.ViewModel.Filters;

namespace RealEstates.Models.ViewModel.Table
{
    public class TableApartmentViewModel
    {
        public int TotalPages { get; set; }

        public int Count { get; set; }

        public bool NextPage = false;


        public List<ApartmentViewModel> Apartments;

        public ApartmentFilterViewModel Filter;

        public TableApartmentViewModel()
        {
            Filter = new ApartmentFilterViewModel();
        }

        public TableApartmentViewModel(int page, int pageSize, int count)
        {
            Filter = new ApartmentFilterViewModel();
        }

    }
}
