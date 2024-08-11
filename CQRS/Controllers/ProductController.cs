using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.CQRSDesignPattern.Handlers.CategoryHandlers;
using CQRS.CQRSDesignPattern.Handlers.ProductHandlers;
using CQRS.CQRSDesignPattern.Queries.ProductQueries;
using CQRS.CQRSDesignPattern.Results.CategoryResults;
using CQRS.CQRSDesignPattern.Results.ProductResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS.Controllers
{

    public class ProductController : Controller
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        public ProductController(CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductQueryHandler getProductQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductQueryHandler = getProductQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories=_getCategoryQueryHandler.Handle();
            List<SelectListItem> cat= (from x in categories.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.CategoryName,
                                           Value=x.CategoryId.ToString()
                                       }).ToList();
            ViewBag.categories=cat;
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductCommand createProductCommand)
        {
            _createProductCommandHandler.Handle(createProductCommand);
            return RedirectToAction("ProductList");
        }
        public IActionResult RemoveProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            var categories = _getCategoryQueryHandler.Handle();
            List<SelectListItem> cat = (from x in categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.categories= cat;
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            _updateProductCommandHandler.Handle(updateProductCommand);
            return RedirectToAction("ProductList");
        }
    }
}

