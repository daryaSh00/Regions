using System;
using System.Collections.Generic;


namespace Regions.Domain.Entities
{

    public partial class City
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ProvinceId { get; set; }

        public virtual ICollection<District> Districts { get; set; } = new List<District>();

        public virtual Province? Province { get; set; }
    }
}
