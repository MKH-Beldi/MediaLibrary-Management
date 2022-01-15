using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }
        public int ReductionCode { get; set; }
        [ForeignKey("Category")]
        public int? CategoryFK { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Document> Documents { get; set; }
        public virtual IList<Borrow> Borrows { get; set; }
        [ForeignKey("MediaLibrary")]
        public int? MediaLibraryFK { get; set; }
        public virtual MediaLibrary MediaLibrary { get; set; }

        public Client() {}

        public Client(int clientId, string firstName, string lastName, string address, string login, string password, DateTime registerDate, 
            int reductionCode, Category category, IList<Document> documents, MediaLibrary mediaLibrary)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Login = login;
            Password = password;
            RegisterDate = registerDate;
            ReductionCode = reductionCode;
            Category = category;
            Documents = documents;
            MediaLibrary = mediaLibrary;
        }

        public override string ToString()
        {
            return base.ToString() + $" :\nClientId : {ClientId} | FirstName : {FirstName} | LastName : {LastName} | Address : {Address} " +
                $"| Login : {Login} | Password : {Password} | RegisterDate : {RegisterDate} | ReductionCode : {ReductionCode}";
        }
    }
}
