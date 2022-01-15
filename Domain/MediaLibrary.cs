using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MediaLibrary
    {
        [Key]
        public int Key { get; set; }
        public string Name { get; set; }
        public virtual IList<Client> Clients { get; set; }
        public virtual IList<Document> Documents { get; set; }

        public MediaLibrary() {}

        public MediaLibrary(int key, string name, IList<Client> clients, IList<Document> documents)
        {
            Key = key;
            Name = name;
            Clients = clients;
            Documents = documents;
        }

        public override string ToString()
        {
            return base.ToString() + $" :\nKey : {Key} | Name : {Name}";
        }
    }
}
