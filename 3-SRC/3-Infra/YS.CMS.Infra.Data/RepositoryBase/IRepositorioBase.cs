
using System.Linq;
using System.Threading.Tasks;

namespace YS.CMS.Infra.Data.RepositoryBase
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        Task<TEntity> Find(int id);
        void Create(params TEntity[] obj);
        void Update(params TEntity[] obj);
        void Delete(params TEntity[] obj);
    }
}
