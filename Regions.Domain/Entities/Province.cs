namespace Regions.Domain.Entities
{
    public partial class Province
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }

}

