using FinalApp.Core.Entities.Characteristics;
using FinalApp.DAL.Contexts;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.DAL.Repositories.Implementations;

public class SizeRepository : Repository<Size>, ISizeRepository
{
    public SizeRepository(FinalAppDbContext context) : base(context) { }
}