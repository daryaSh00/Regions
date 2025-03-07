using Regions.Application.Common.Interfaces;
using Regions.Infrastructure.Data;
using Regions.Domain.Entities;
namespace Regions.Infrastructure.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(City city)
        {
            _db.Update(city);
        }
    }
}
