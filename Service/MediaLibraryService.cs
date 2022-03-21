using Domain;
using PS.Data.Infrastructure;
using ServicePattern;

namespace Service
{
    public class MediaLibraryService : Service<MediaLibrary>, IMediaLibraryService
    {
        public MediaLibraryService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
