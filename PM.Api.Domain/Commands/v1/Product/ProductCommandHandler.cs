using PM.Api.Domain.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PM.Api.Domain.Commands.v1.Product
{
    public class ProductCommandHandler : 
        IRequestHandler<AddProductCommand, long>,
        IRequestHandler<DeleteProductCommand>,
        IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken) =>
            await _productRepository.AddAsync(request.Product);

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateAsync(request.Product);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
