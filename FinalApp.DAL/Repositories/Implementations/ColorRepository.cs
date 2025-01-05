using FinalApp.Core.Entities.Characteristics;
using FinalApp.DAL.Contexts;
using FinalApp.DAL.Repositories.Abstractions;

namespace FinalApp.DAL.Repositories.Implementations;

public class ColorRepository : Repository<Color>, IColorRepository
{
    public ColorRepository(FinalAppDbContext context) : base(context) { }
}