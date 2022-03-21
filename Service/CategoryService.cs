using Domain;
using PS.Data.Infrastructure;
using ServicePattern;

namespace Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow)
        {

        }

    }
}
