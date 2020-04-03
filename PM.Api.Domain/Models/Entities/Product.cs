using PM.Api.Domain.Models.Enums;
using System;

namespace PM.Api.Domain.Models.Entities
{
    public class Product
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public ProductCategory Category { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public decimal Price { get; private set; }
        public int Rating { get; private set; }
        public string ImageUrl { get; private set; }

        public Product() { }

        public Product(long id, string name, string code, ProductCategory category, string description, DateTime releaseDate, decimal price, int rating, string imageUrl)
        {
            Id = id;
            Name = name;
            Code = code;
            Category = category;
            Description = description;
            ReleaseDate = releaseDate;
            Price = price;
            Rating = rating;
            ImageUrl = imageUrl;
        }
    }
}
