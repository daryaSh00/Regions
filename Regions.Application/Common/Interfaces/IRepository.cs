using System.Linq.Expressions;

namespace Regions.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T GetById(Expression<Func<T, bool>> filter, string? includeProperties = null);
    }
}
