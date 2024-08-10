using CQRS.CQRSDesignPattern.Results.ProductResults;
using CQRS.DAL.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly CQRSContext _context;

        public GetProductQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ImageUrl = x.ImageUrl,
            });
            return values.ToList();
        }
    }
}
