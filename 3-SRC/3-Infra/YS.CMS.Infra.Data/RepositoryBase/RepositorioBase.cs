using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace YS.CMS.Infra.Data.RepositoryBase
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly CMSRepositoryContext _context;

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public async void Create(params TEntity[] objs)
        {
            await _context.Set<TEntity>().AddRangeAsync(objs);
            await _context.SaveChangesAsync();
        }

        public async void Delete(params TEntity[] objs)
        {
            _context.Set<TEntity>().RemoveRange(objs);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Find(int id)
        {
             return await _context.Set<TEntity>().FindAsync(id);
        }

        public async void Update(params TEntity[] objs)
        {
            _context.Set<TEntity>().UpdateRange(objs);
            await _context.SaveChangesAsync();
        }
    }
}
