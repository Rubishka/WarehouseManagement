using System.Data.Entity.Spatial;
using System.Data.Entity.Spatial;
using System.Globalization;

namespace WarehouseManagement.Models
{
    public class Structure
    {
        public int ID { get; set; }

        public string Address { get; set; }


        public DbGeography Location { get; set; }

    }
}