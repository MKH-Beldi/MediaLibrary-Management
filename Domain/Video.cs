namespace Domain
{
    public class Video: Document
    {
        public int MovieDuration { get; set; }
        public string LegalNotice { get; set; }
        public int Duration { get; set; }
        public double Rate { get; set; }

        public Video() { }

        public Video(int movieDuration, string legalNotice, int duration, double rate)
        {
            MovieDuration = movieDuration;
            LegalNotice = legalNotice;
            Duration = duration;
            Rate = rate;
        }

        public override string ToString()
        {
            return base.ToString() + $"MovieDuration : {MovieDuration} | LegalNotice : {LegalNotice} | Duration : {Duration} | " +
                $"Rate : {Rate}";
        }
    }
}
