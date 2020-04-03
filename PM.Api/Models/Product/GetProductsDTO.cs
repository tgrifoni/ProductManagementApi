using System;

namespace PM.Api.Models.Product
{
    public class GetProductsDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
