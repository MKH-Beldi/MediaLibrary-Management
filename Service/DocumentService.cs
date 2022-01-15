using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class DocumentService : Service<Document>, IDocumentService
    {
        public IList<Document> SearchDocument(string title, MediaLibrary mediaLibrary)
        {
            return this.GetMany(d => d.MediaLibrary.Name == mediaLibrary.Name && d.Title.Contains(title)).ToList();
        }
    }
}
