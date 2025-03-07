namespace Regions.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IProvinceRepository Province { get; }
        IDistrictRepository District { get; }
        ICityRepository City { get; }
        void Save();
    }
}
