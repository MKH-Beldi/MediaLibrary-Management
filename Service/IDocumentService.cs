using Domain;
using System.Collections.Generic;

namespace Service
{
    public interface IDocumentService : IService<Document>
    {
        IList<Document> SearchDocument(string title, MediaLibrary mediaLibrary);
    }
}
