using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Models.ViewModel.Filters
{
    public class ApartmentFilterViewModel
    {
        public ApartmentFilterViewModel()
        {
            CommonAreaFrom = 0;
            CommonAreaTo = 0;
            KitchenAreaFrom = 0;
            KitchenAreaTo = 0;
            CostFrom = 0;
            CostTo = 0;
            Page = 1;
            PageSize = 20;
        }

        public string SortField { get; set; }

        public string SortOrder { get; set; }

        public float CommonAreaFrom { get; set; }

        public float CommonAreaTo { get; set; }

        public float KitchenAreaFrom { get; set; }

        public float KitchenAreaTo { set; get; }

        public float CostFrom { get; set; }

        public float CostTo { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
