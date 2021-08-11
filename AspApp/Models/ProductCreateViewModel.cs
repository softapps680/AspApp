using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspApp.Models
{
    [Keyless]
    public class ProductCreateViewModel
    {
       //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }

        public int CategoryId { get; set; }
      //  public Category Category { get; set; }

        //public List<Category> Categories { get; set; }

        // public List<Category> Categories { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
