using Regions.Domain.Entities;

namespace Regions.Application.Common.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City city);
    }
}
