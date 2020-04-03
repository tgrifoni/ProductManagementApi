namespace PM.Api.Domain.Commands.v1.Product
{
    public class DeleteProductCommand : AbstractCommand
    {
        public long Id { get; private set; }

        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}
