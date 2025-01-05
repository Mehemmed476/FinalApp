using FinalApp.Core.Entities;
using FinalApp.DAL.Contexts;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.DAL.Repositories.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(FinalAppDbContext context) : base(context) { }
}