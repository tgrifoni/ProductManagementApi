﻿namespace PM.Api.Domain.Contracts.Repositories
{
    public interface ICommandQueryRepository<T> : ICommandRepository<T>, IQueryRepository<T>
    {
    }
}
