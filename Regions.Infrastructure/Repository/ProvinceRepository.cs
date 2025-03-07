using Regions.Application.Common.Interfaces;
using Regions.Infrastructure.Data;
using Regions.Domain.Entities;
using Regions.Infrastructure.Repository;
namespace Regions.Infrastructure.Repository
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        private readonly ApplicationDbContext _db;
        public ProvinceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void CreateRandomProvinces()
        {
            for (int i = 0; i < 10; i++)
            {
                var province = new Province { Name = $"استان {Guid.NewGuid().ToString().Substring(0, 8)}" };
                _db.Provinces.Add(province);
            }
        }
        public void RenameProvince(Province province)
        {
            province.Name += "*";
            _db.Provinces.Update(province);
        }
    }
}