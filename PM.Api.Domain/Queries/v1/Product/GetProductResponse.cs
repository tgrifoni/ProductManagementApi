using Entities = PM.Api.Domain.Models.Entities;

namespace PM.Api.Domain.Queries.v1.Product
{
    public class GetProductResponse
    {
        public Entities.Product Product { get; private set; }

        public GetProductResponse(Entities.Product product)
        {
            Product = product;
        }
    }
}
