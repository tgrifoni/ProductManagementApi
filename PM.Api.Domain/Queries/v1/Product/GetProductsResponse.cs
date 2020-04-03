using Entities = PM.Api.Domain.Models.Entities;
using System.Collections.Generic;

namespace PM.Api.Domain.Queries.v1.Product
{
    public class GetProductsResponse
    {
        public IEnumerable<Entities.Product> Products { get; private set; }

        public GetProductsResponse(IEnumerable<Entities.Product> products)
        {
            Products = products;
        }
    }
}
