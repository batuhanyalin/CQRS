using CQRS.CQRSDesignPattern.Queries.CategoryQueries;
using CQRS.CQRSDesignPattern.Results.CategoryResults;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly CQRSContext _context;

        public GetCategoryByIdQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public GetCategoryByIdQueryResult Handle(GetCategoryByIdQuery query)
        {
            var value = _context.Categories.Find(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName,
            };
        }
    }
}
