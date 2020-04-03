using AutoMapper;
using PM.Api.Domain.Commands.v1.Product;
using PM.Api.Domain.Models.Entities;
using PM.Api.Models.Product;

namespace PM.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() : base("ProductProfile")
        {
            CreateMap<Product, GetProductsDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<SaveProductRequest, AddProductCommand>();
            CreateMap<SaveProductRequest, UpdateProductCommand>();
        }
    }
}
