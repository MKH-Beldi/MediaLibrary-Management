using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Service;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientService clientService = new ClientService();
            IList<Client> clients = clientService.GetMany().ToList();
            DocumentService documentService = new DocumentService();
            IList<Document> documents = documentService.GetMany().ToList();
            MediaLibraryService mediaLibraryService = new MediaLibraryService();
            IList<MediaLibrary> mediaLibraries = mediaLibraryService.GetMany().ToList();
            BorrowService borrowService = new BorrowService();
            /*borrowService.Add(borrow01);
            borrowService.Commit();*/
            /*if (borrowService.Borrowable(documents[3]))
                 System.Console.WriteLine("Le Document "+documents[3].Title+" a été emprunté");
            else
                 System.Console.WriteLine("Le Document " + documents[3].Title + " n'a pas  été emprunté");*/
            /*foreach (var document in borrowService.GetBorrowables(mediaLibraries[2]))
            {
                System.Console.WriteLine(document.ToString());
            }*/
            /*Document document = new Document();
            document.Key = 8;
            borrowService.Return(document);
            borrowService.Commit();*/

            /*borrowService.Borrow(documents[4], clients[2]);
            borrowService.Commit();*/
            /*MediaLibrary mediaLibrary = new MediaLibrary();
            mediaLibrary.Name= "Cloud Computing";
            foreach (var item in documentService.SearchDocument("Install", mediaLibrary))
            {
                System.Console.WriteLine(item);
            }*/
            System.Console.WriteLine(borrowService.NbrBorrowsDepositedByClient(clients[1]));

        }
    }
}
