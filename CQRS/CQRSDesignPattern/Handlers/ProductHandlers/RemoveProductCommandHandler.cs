using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly CQRSContext _context;

        public RemoveProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(RemoveProductCommand removeProductCommand)
        {
           var value= _context.Products.Find(removeProductCommand.ProductId);
            _context.Products.Remove(value);
            _context.SaveChanges();
        }
    }
}
