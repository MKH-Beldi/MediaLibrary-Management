using Domain;
using System.Collections.Generic;
using ServicePattern;

namespace Service
{
    public interface IBorrowService : IService<Borrow>
    {
        bool Borrowable(Document document);
        IList<Document> GetBorrowables(MediaLibrary mediaLibrary);
        bool Borrow(Document document, Client client);
        void Return(Document document);
        int NbrBorrowsByClient(Client c);
        int NbrBorrowsInProgressByClient(Client c);
        int NbrBorrowsDepositedByClient(Client c);
        int NbrBorrowsByDocument(Document c);
        bool Borrowed(Document document);
    }
}
