using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public UpdateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(UpdateProductCommand updateProductCommand)
        {
            var value = _context.Products.Find(updateProductCommand.ProductId);
            value.ProductName = updateProductCommand.ProductName;
            value.ImageUrl = updateProductCommand.ImageUrl;
            value.Description = updateProductCommand.Description;
            value.Price = updateProductCommand.Price;
            value.Stock = updateProductCommand.Stock;
            value.CategoryId = updateProductCommand.CategoryId;
            _context.SaveChanges();

        }
    }
}
