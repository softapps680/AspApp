using AspApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace AspApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int id)
        {
           
            var categories = _context.Categories.ToList();
            var categorizedList = _context.Products.Where(x => x.CategoryId == id).ToList();

            if (id != 0)
            {
               var model = new ProductsPageViewModel
                {
                    Products = categorizedList,
                    Categories = categories
                };
                return View(model);
            }
            else
            {
               var model = new ProductsPageViewModel
                {
                    Categories = categories
                };
                return View(model);
            }

           
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = _context.Products.Find(id);

            return View(model);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
           
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("Index", new { id = product.CategoryId });
        
        }
        
        [HttpGet]
        [Authorize]
        public  IActionResult Create()
        {

           var categories = _context.Categories.ToList();

            ViewData["Categories"] = new SelectList(categories, "Id", "CategoryName");

            List<SelectListItem> selectItems = new List<SelectListItem>();
           
            foreach(var item in categories)
            {
                selectItems.Add(new SelectListItem { Text = item.CategoryName, Value = item.Id.ToString() }); ;
            }
            var createProduct = new ProductCreateViewModel {
                
                Categories = selectItems 
          
            };
          
         //   return View(createProduct);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var p = new Product { 

               Name=product.Name,
               Description=product.Description,
               Imageurl=product.Imageurl,
               CategoryId=product.CategoryId

            };

             _context.Add(p);
            await _context.SaveChangesAsync();
            TempData["Confirm"] = "Product saved!";
            return View(product);
        }
       
     
        
       
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Product product)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return View(product);
        }


    }
}