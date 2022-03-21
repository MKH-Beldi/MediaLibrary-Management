using Domain;
using System.Collections.Generic;
using System.Linq;
using ServicePattern;
using PS.Data.Infrastructure;

namespace Service
{
    public class DocumentService : Service<Document>, IDocumentService
    {
        public DocumentService(IUnitOfWork uow) : base(uow)
        {

        }
        public IList<Document> SearchDocument(string title, MediaLibrary mediaLibrary)
        {
            return this.GetMany(d => d.MediaLibrary.Name == mediaLibrary.Name && d.Title.Contains(title)).ToList();
        }
    }
}
