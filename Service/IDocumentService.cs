using Domain;
using System.Collections.Generic;
using ServicePattern;

namespace Service
{
    public interface IDocumentService : IService<Document>
    {
        IList<Document> SearchDocument(string title, MediaLibrary mediaLibrary);
    }
}
