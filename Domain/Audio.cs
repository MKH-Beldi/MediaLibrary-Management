namespace Domain
{
    public class Audio: Document
    {
        public string Classification { get; set; }
        public int Duration { get; set; }
        public double Rate { get; set; }
        public Audio() {}

        public Audio(string classification, int duration, double rate)
        {
            Classification = classification;
            Duration = duration;
            Rate = rate;
        }

        public override string ToString()
        {
            return base.ToString() + $"Classification : {Classification} | Duration : {Duration} | Rate : {Rate}";
        }
    }
}
