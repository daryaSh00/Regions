using Regions.Application.Common.Interfaces;
using Regions.Infrastructure.Data;

namespace Regions.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProvinceRepository Province { get; private set; }
        public IDistrictRepository District { get; private set; }
        public ICityRepository City { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Province = new ProvinceRepository(_db); 
            District = new DistrictRepostitory(_db); 
            City = new CityRepository(_db);         
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}