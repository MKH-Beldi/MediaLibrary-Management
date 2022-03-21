using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;

namespace Service
{
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
