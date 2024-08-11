using CQRS.CQRSDesignPattern.Commands.CategoryCommands;
using CQRS.CQRSDesignPattern.Handlers.CategoryHandlers;
using CQRS.CQRSDesignPattern.Queries.CategoryQueries;
using CQRS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryQueryHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryQueryHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        }

        public IActionResult CategoryList()
        {
            var values = _getCategoryQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            _createCategoryCommandHandler.Handle(createCategoryCommand);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
           var value= _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id)); 
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return RedirectToAction("CategoryList");
        }
        public IActionResult RemoveCategory(int id)
        {
            _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id)); //Burada Handle içine Command içine yazılan yapıcı metot kullanılarak bir nesne örneği çağrılıyor.
            return RedirectToAction("CategoryList");
        }
    }
}
