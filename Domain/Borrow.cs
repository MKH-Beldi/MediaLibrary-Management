using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Borrow
    {
       
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LimitDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReminderDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double Rate { get; set; }
        [ForeignKey("Client")]
        public int ClientFK { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("Document")]
        public int DocumentFK { get; set; }
        public virtual Document Document { get; set; }

        public Borrow(){}

        public Borrow(Client client, Document document, DateTime borrowDate, DateTime limitDate, DateTime? reminderDate, DateTime? returnDate, double rate)
        {
            Client = client;
            Document = document;
            BorrowDate = borrowDate;
            LimitDate = limitDate;
            ReminderDate = reminderDate;
            ReturnDate = returnDate;
            Rate = rate;
        }

        public override string ToString()
        {
            return base.ToString() + $" :\nBorrowDate : {BorrowDate} | LimitDate : {LimitDate} | ReminderDate : {ReminderDate} | ReturnDate : {ReturnDate} " +
                $"| Rate : {Rate}";
        }
    }

}
