using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Models
{
    public class Store: Structure
    {


        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Store name")]
        public string Name { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Store purpose")]
        public string Purpose { get; set; }

  
        public decimal Budget { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}