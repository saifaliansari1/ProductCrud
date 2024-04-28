using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using ProductCrud.Repository;

namespace ProductCrud.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(_productRepo.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productRepo.Find(id.GetValueOrDefault());

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepo.Find(id.GetValueOrDefault());
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _productRepo.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productRepo.Find(id.GetValueOrDefault());


            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            if(id == null)
                return NotFound();

            _productRepo.Remove(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
