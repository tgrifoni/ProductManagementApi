using System;

namespace PM.Api.Models.Product
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ProductCategoryDTO Category { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}
