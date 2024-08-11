using CQRS.CQRSDesignPattern.Commands.CategoryCommands;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
       private readonly CQRSContext _context;

        public RemoveCategoryCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(RemoveCategoryCommand removeCategoryCommand)
        {
            var value=_context.Categories.Find(removeCategoryCommand.CategoryId);
            _context.Categories.Remove(value);
            _context.SaveChanges();
        }
    }
}
