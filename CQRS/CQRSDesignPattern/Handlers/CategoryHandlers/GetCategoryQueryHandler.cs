using CQRS.CQRSDesignPattern.Results.CategoryResults;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {private readonly CQRSContext _context;

        public GetCategoryQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public List<GetCategoryQueryResult> Handle()
        {
            var values = _context.Categories.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
            });
            return values.ToList();
        }
    }
}
