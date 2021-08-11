using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.Models
{
    public class ProductsPageViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

    }
}
