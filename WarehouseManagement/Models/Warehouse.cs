using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class Warehouse :Structure
    {

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }



        public int FreeSpace { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}