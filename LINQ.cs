namespace JobAPPTracker
{
    public class LINQ
    {

        List<JobApplication> ApplicationList = new List<JobApplication>();

        public void ShowStatistics()
        {
            Console.WriteLine($"Totalt antal ansökningar {ApplicationList.Count}");

            var antal = ApplicationList
                .GroupBy(a => a.AnsökningsStatus)
                .Select(g => new { Status = g.Key, Count = g.Count() });

            Console.WriteLine("Antal ansökningar per status:");
            foreach (var s in antal)
            {
                Console.WriteLine($"{s.Status}: {s.Count}");
            }

        }


        public void UpdateStatus()
        {
            Console.Write("Ange företagsnamn att uppdatera: ");
            string namn = Console.ReadLine();

            var application = ApplicationList.FirstOrDefault(a => a.FöretagsNamn.Equals(namn, StringComparison.OrdinalIgnoreCase));

            if (application != null)
            {
                Console.WriteLine($"Nuvarande status: {application.AnsökningsStatus}");
                Console.Write("Ny status : Ansökt, Intervju, Erbjudande, Nekad ");
                string Update = Console.ReadLine();

                if (Enum.TryParse<JobApplication.Status>(Update, true, out var newStatus))
                {
                    application.AnsökningsStatus = newStatus;

                    if (newStatus == JobApplication.Status.Erbjudande || newStatus == JobApplication.Status.Nekad)
                    {
                        application.SvarsTid = DateTime.Today;
                    }

                    Console.WriteLine("Statusen har uppdateras.");
                }
                else
                {
                    Console.WriteLine("status är ej giltig. Uppdatering har  misslyckakats.");
                }

            }
        }


        public void RemoveApplication()
        {
            Console.Write("Ange företagsnamn att ta bort: ");
            string CompanyName = Console.ReadLine();

            var RemoveApp = ApplicationList.FirstOrDefault(a => a.FöretagsNamn.Equals(CompanyName, StringComparison.OrdinalIgnoreCase));

            if (RemoveApp != null)
            {
                ApplicationList.Remove(RemoveApp);
                Console.WriteLine("Ansökan borttagen.");
            }
            else
            {
                Console.WriteLine("Ansökan hittades inte.");
            }




        }
    }
}
