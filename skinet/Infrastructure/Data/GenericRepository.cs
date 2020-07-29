using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private readonly StoreContext _context;

    public GenericRepository(StoreContext context)
    {
      _context = context ?? throw new System.ArgumentNullException(nameof(context));
    }


    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
      return await ApplaySpecification(spec).FirstOrDefaultAsync();
    }


    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
      return await ApplaySpecification(spec).ToListAsync();
    }


    private IQueryable<T> ApplaySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
  }
}