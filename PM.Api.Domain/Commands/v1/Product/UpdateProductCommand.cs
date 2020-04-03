using Entities = PM.Api.Domain.Models.Entities;

namespace PM.Api.Domain.Commands.v1.Product
{
    public class UpdateProductCommand : AbstractCommand
    {
        public Entities.Product Product { get; set; }
    }
}
