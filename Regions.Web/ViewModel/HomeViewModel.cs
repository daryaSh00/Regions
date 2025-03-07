using Regions.Domain.Entities;

namespace Regions.Web.ViewModel
{
    public class HomeViewModel
    {
        public int ProvinceCount { get; set; }
        public int CityCount { get; set; }
        public int DistrictCount { get; set; }
        public List<Province> RecentProvinces { get; set; }
    }
}
