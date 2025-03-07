using System;
using System.Collections.Generic;


namespace Regions.Domain.Entities
{

    public partial class District
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? CityId { get; set; }

        public virtual City? City { get; set; }
    }

}