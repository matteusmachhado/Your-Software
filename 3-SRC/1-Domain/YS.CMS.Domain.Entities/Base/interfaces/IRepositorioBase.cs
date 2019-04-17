﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YS.CMS.Domain.Base.interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AsNoTracking();
        IQueryable<TEntity> All { get; }
        Task<TEntity> FindAsync(int id);
        Task CreateAsync(params TEntity[] obj);
        Task UpdateAsync(params TEntity[] obj);
        Task DeleteAsync(params TEntity[] obj);
        Task<IList<TEntity>> FindAllAsync(IEnumerable<int> ids);
    }
}
