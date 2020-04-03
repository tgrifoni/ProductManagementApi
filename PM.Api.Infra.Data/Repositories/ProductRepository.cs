using Dapper;
using PM.Api.Domain.Contracts.Repositories;
using PM.Api.Domain.Models.Entities;
using PM.Api.Infra.Data.Connections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Api.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string _getAllQuery =
            @"SELECT [Id],
                     [Name],
                     [Code],
                     [Category],
                     [Description],
                     [ReleaseDate],
                     [Price],
                     [Rating],
                     [ImageUrl]
                FROM [dbo].[Product]";
        private const string _getByIdQuery =
            @"SELECT [Id],
                     [Name],
                     [Code],
                     [Category],
                     [Description],
                     [ReleaseDate],
                     [Price],
                     [Rating],
                     [ImageUrl]
                FROM [dbo].[Product]
               WHERE [Id] = @Id";
        private const string _addCommand =
            @"INSERT INTO [dbo].[Product]
              (
                  [Name],
                  [Code],
                  [Category],
                  [Description],
                  [ReleaseDate],
                  [Price],
                  [Rating],
                  [ImageUrl]
              ) 
              VALUES
              (
                  @Name,
                  @Code,
                  @Category,
                  @Description,
                  @ReleaseDate,
                  @Price,
                  @Rating,
                  @ImageUrl
              );
              SELECT SCOPE_IDENTITY();";
        private const string _updateCommand =
            @"UPDATE [dbo].[Product]
                 SET [Name] = @Name,
  	                 [Code] = @Code,
  	                 [Category] = @Category,
  	                 [Description] = @Description,
  	                 [ReleaseDate] = @ReleaseDate,
  	                 [Price] = @Price,
  	                 [Rating] = @Rating,
  	                 [ImageUrl] = @ImageUrl
               WHERE [Id] = @Id";
        private const string _deleteCommand = "DELETE [dbo].[Product] WHERE [Id] = @Id";

        private readonly IConnection _connection;

        public ProductRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = _connection.CreateConnection();
            return await connection.QueryAsync<Product>(_getAllQuery);
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            using var connection = _connection.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(_getByIdQuery, new { Id = id });
        }

        public async Task<long> AddAsync(Product product)
        {
            using var connection = _connection.CreateConnection();
            return await connection.ExecuteScalarAsync<long>(_addCommand, product);
        }

        public async Task UpdateAsync(Product product)
        {
            using var connection = _connection.CreateConnection();
            await connection.ExecuteAsync(_updateCommand, product);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connection.CreateConnection();
            await connection.ExecuteAsync(_deleteCommand, new { Id = id });
        }
    }
}
