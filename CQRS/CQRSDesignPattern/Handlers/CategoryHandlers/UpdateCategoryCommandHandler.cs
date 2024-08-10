using CQRS.CQRSDesignPattern.Commands.CategoryCommands;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly CQRSContext _context;

        public UpdateCategoryCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = _context.Categories.Find(updateCategoryCommand.CategoryId);
            value.CategoryName = updateCategoryCommand.CategoryName; //Burada da atama yapılarak alınan değer entitye yazılıyopr.
            _context.SaveChanges();
        }
    }
}
