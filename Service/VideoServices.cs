using Domain;
using PS.Data.Infrastructure;
using ServicePattern;

namespace Service
{
    public class VideoService : Service<Video>, IVideoService
    {
        public VideoService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
