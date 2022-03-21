using Domain;
using PS.Data.Infrastructure;
using ServicePattern;

namespace Service
{
    public class AudioService : Service<Audio>, IAudioService
    {
        public AudioService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
