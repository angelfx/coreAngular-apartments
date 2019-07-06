namespace RealEstates.Models.DTO.Filters
{
    /// <summary>
    /// Model for fluter apartments
    /// </summary>
    public class ApartmentFilterDTO
    {
        public ApartmentFilterDTO()
        {
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
