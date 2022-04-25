using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Studio
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
        public Studio()
        {
            Games = new List<Game>();
        }
    }

    public class StudioMap
    {
        public StudioMap(EntityTypeBuilder<Studio> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
        }
    }
}
