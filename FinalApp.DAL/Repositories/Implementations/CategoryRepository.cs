using FinalApp.Core.Entities;
using FinalApp.DAL.Contexts;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.DAL.Repositories.Implementations;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(FinalAppDbContext context) : base(context) { }
}