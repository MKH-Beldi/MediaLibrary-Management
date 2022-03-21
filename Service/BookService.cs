using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
namespace Service
{
    public class BookService: Service<Book>, IBookService
    {
        public BookService (IUnitOfWork uow) : base(uow)
        {

        }
    }
}
