using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public int NbrBorrowsMax { get; set; }
        public string Contribution { get; set; }
        public double RateCoef { get; set; }
        public double DurationCoef { get; set; }
        public bool ReductionCodeEnable { get; set; }
        public virtual IList<Client> Clients { get; set; }

        public Category() {}

        public Category(int id, int nbrBorrowsMax, string contribution, double rateCoef, double durationCoef, bool reductionCodeEnable, IList<Client> clients)
        {
            Id = id;
            NbrBorrowsMax = nbrBorrowsMax;
            Contribution = contribution;
            RateCoef = rateCoef;
            DurationCoef = durationCoef;
            ReductionCodeEnable = reductionCodeEnable;
            Clients = clients;
        }

        public override string ToString()
        {
            return base.ToString() + $" :\nId : {Id} | NbrBorrowsMax : {NbrBorrowsMax} | Contribution : {Contribution} | RateCoef : {RateCoef} " +
                $"| DurationCoef : {DurationCoef} | ReductionCodeEnable : {ReductionCodeEnable}";
        }
    }

}
