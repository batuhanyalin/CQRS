using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.DAL.Context;
using CQRS.DAL.Entities;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public CreateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(CreateProductCommand createProductCommand)
        {
            _context.Products.Add(new Product
            {
                CategoryId = createProductCommand.CategoryId,
                Description = createProductCommand.Description,
                ImageUrl = createProductCommand.ImageUrl,
                Price = createProductCommand.Price,
                ProductName = createProductCommand.ProductName,
                Stock=createProductCommand.Stock,
            });
            _context.SaveChanges();
        }
    }
}
