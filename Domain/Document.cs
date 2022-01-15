using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Document
    {
        [Key]
        public int Key { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        [NotMapped]
        public bool Borrowable { get; set; }
        [NotMapped]
        public bool Borrowed { get; set; }
        [NotMapped]
        public int NbrBorrows { get; set; }
        public virtual IList<Client> Clients { get; set; }
        public virtual MediaLibrary MediaLibrary { get; set; }
        public virtual IList<Borrow> Borrows { get; set; }

        public Document() { }

        public Document(int key, string title, string author, string year, bool borrowable, bool borrowed, int nbrBorrows, IList<Client> clients, 
            MediaLibrary mediaLibrary)
        {
            Key = key;
            Title = title;
            Author = author;
            Year = year;
            Borrowable = borrowable;
            Borrowed = borrowed;
            NbrBorrows = nbrBorrows;
            Clients = clients;
            MediaLibrary = mediaLibrary;
        }

        public override string ToString()
        {
            return base.ToString() + $" :\nKey : {Key} | Title : {Title} | Author : {Author} | Year : {Year} | Borrowable : {Borrowable} " +
                $"| Borrowed : {Borrowed} | NbrBorrows : {NbrBorrows}";
        }
    }
}
