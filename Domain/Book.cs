using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book: Document
    {
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        public int NbrPage { get; set; }
        public int Duration { get; set; }
        public double Rate { get; set; }

        public Book() {}

        public Book(string summary, int nbrPage, int duration, double rate)
        {
            Summary = summary;
            NbrPage = nbrPage;
            Duration = duration;
            Rate = rate;
        }

        public override string ToString()
        {
            return base.ToString() + $"Summary : {Summary} | NbrPage : {NbrPage} | Duration : {Duration} | Rate: { Rate}";
        }
    }
}
