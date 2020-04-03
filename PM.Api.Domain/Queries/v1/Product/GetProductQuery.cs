namespace PM.Api.Domain.Queries.v1.Product
{
    public class GetProductQuery : AbstractQuery<GetProductResponse>
    {
        public long Id { get; private set; }

        public GetProductQuery(long id)
        {
            Id = id;
        }
    }
}
