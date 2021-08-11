using System;
using System.Collections.Generic;

#nullable disable

namespace AspApp.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public decimal Price { get; set; }
        public string Vendor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
