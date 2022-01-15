using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BorrowService: Service<Borrow>, IBorrowService
    {

        public bool Borrowable(Document document)
        {
            if (this.GetMany(b => b.Document.Key == document.Key).Count() != 0)
                return true;
            else
                return false;
        }

        public IList<Document> GetBorrowables(MediaLibrary mediaLibrary)
        {
            return this.GetMany(b => b.Document.MediaLibrary.Key == mediaLibrary.Key).Select(br => br.Document).ToList();

        }

        public void Borrow(Document document, Client client)
        {
            bool borrowed = true;
            if (this.GetMany(b => b.DocumentFK == document.Key) == null)
                borrowed = false;
            else if (this.GetMany(b => b.DocumentFK == document.Key).Where(b => b.ReturnDate == null).Count() == 1)
                borrowed = true;
            else if (this.GetMany(b => b.DocumentFK == document.Key).Where(b => b.ReturnDate == null).Count() == 0)
                borrowed = false;

            if (!borrowed)
            {
                Borrow borrow = new Borrow();
                borrow.DocumentFK = document.Key;
                borrow.ClientFK = client.ClientId;
                borrow.BorrowDate = System.DateTime.Now;
                borrow.LimitDate = System.DateTime.Now.AddMonths(3);
                borrow.ReminderDate = System.DateTime.Now.AddMonths(2).AddDays(25);
                this.Add(borrow);
            }
            else
            {
                System.Console.WriteLine("Document already borrowed");
            }
               
        }

        public void Return(Document document)
        {
            Borrow borrow = this.GetMany(b => (b.DocumentFK == document.Key && b.ReturnDate == null)).Single();
            borrow.ReturnDate = System.DateTime.Now;
            this.Update(borrow);

        }

        public int NbrBorrowsByClient(Client c)
        {
            return this.GetMany(b => b.ClientFK == c.ClientId).Count();
        }

        public int NbrBorrowsInProgressByClient(Client c)
        {
            return this.GetMany(b => b.ClientFK == c.ClientId).Where(b => b.ReturnDate == null).Count();
        }

        public int NbrBorrowsDepositedByClient(Client c)
        {
            return this.GetMany(b => b.ClientFK == c.ClientId).Where(b => b.ReturnDate != null).Count();
        }

        public int NbrBorrowsByDocument(Document d)
        {
            return this.GetMany(b => b.DocumentFK == d.Key).Count();
        }
    }
}
