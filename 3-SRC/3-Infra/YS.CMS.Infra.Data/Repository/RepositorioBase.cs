using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Interfaces;

namespace YS.CMS.Infra.Data.Repository
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly CMSRepositoryContext _context;

        public RepositorioBase(CMSRepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();
        
        public async Task CreateAsync(params TEntity[] objs)
        {
            await _context.Set<TEntity>().AddRangeAsync(objs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params TEntity[] objs)
        {
            _context.Set<TEntity>().RemoveRange(objs);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> AsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking().AsQueryable();
        }
        
        public async Task<TEntity> FindAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(params TEntity[] objs)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(objs);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<IList<TEntity>> FindAllAsync(IEnumerable<Guid> ids)
        {
            var listTEntity = new List<TEntity>();
            
            foreach (var id in ids)
            {
                var entity = await FindAsync(id);
                if (entity != null)
                {
                    listTEntity.Add(entity);
                }
                else
                {
                    // logar ids não encontrados...
                }

            }
            return listTEntity;
        }
    }
}
