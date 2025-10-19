
namespace JobAPPTracker
{
    public class JobApplication
    {
        public enum Status { Ansökt, Intervju, Erbjudande, Nekad }

        public string FöretagsNamn { get; set; }
        public string Position { get; set; }
        public int Lön { get; set; }
        public Status AnsökningsStatus { get; set; }
        public DateTime AnsökningsDatum { get; set; }
        public DateTime? SvarsTid { get; set; }




        public void GetDaysSinceApplied()
        {
            TimeSpan dagar = DateTime.Now - AnsökningsDatum;
            Console.WriteLine($" Det har gått {dagar} dagar sedan ansökan skickades till {FöretagsNamn}. ");
        }

        public void GetSummary()
        {
            Console.WriteLine($"FöretagsNamn: {FöretagsNamn}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Lön: {Lön} kr");
            Console.WriteLine($"AnsökningsStatus: {AnsökningsStatus}");
            Console.WriteLine($"Ansökningsdatum: {AnsökningsDatum}");


            if (SvarsTid != null)
                Console.WriteLine($"Svar mottaget: {SvarsTid.Value}");
            else
                Console.WriteLine("Svar: Ej mottaget");
            return;
        }
    }
}
