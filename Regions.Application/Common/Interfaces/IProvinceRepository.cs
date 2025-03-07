using Regions.Domain.Entities;

namespace Regions.Application.Common.Interfaces
{
    public interface IProvinceRepository : IRepository<Province>
    {
        void CreateRandomProvinces();
        void RenameProvince(Province province);
    }
}
