using System;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Base
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}
