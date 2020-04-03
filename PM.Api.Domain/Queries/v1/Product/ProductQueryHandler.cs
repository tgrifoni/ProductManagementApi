using PM.Api.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PM.Api.Domain.Queries.v1.Product
{
    public class ProductQueryHandler : 
        IRequestHandler<GetProductsQuery, GetProductsResponse>, 
        IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken) =>
            new GetProductResponse(product: await _productRepository.GetByIdAsync(request.Id));

        public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken) =>
            new GetProductsResponse(products: await _productRepository.GetAllAsync());
    }
}
