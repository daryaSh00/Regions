using Regions.Application.Common.Interfaces;
using Regions.Infrastructure.Data;
using Regions.Domain.Entities;
namespace Regions.Infrastructure.Repository
{
    public class DistrictRepostitory : Repository<District>, IDistrictRepository
    {
        private readonly ApplicationDbContext _db;
        public DistrictRepostitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
