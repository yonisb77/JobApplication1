namespace JobAPPTracker
{

    public class JobManager
    {
        List<JobApplication> ApplicationList = new List<JobApplication>();


        public void AddJob()
        {

            Console.Write("Företagsnamn: ");
            string företagsnamn = Console.ReadLine();

            Console.Write("Tjänst/Position: ");
            string position = Console.ReadLine();


            Console.Write("Förväntad lön: ");
            string salary = Console.ReadLine();
            int lön = Convert.ToInt32(salary);

            Console.Write("Status: Ansökt, Intervju, Erbjudande, Nekad: ");
            string AnsökningsStatus = Console.ReadLine();



            Jobapplication(företagsnamn, position, AnsökningsStatus, lön);

            void Jobapplication(string företagsNamn, string position, string ansökningsStatus, int lön)
            {
                JobApplication application = new JobApplication
                {
                    FöretagsNamn = företagsNamn,
                    Position = position,
                    Lön = lön,
                    AnsökningsStatus = Enum.TryParse<JobApplication.Status>(ansökningsStatus, true, out var status) ? status : JobApplication.Status.Ansökt,
                    AnsökningsDatum = DateTime.Today,

                };

                ApplicationList.Add(application);
                Console.WriteLine("Ansökan tillagd.");
            }





        }


        public void ShowAll()
        {

            if (!ApplicationList.Any())
            {
                Console.WriteLine("Inga ansökningar hittades.");
                return;
            }

            foreach (var app in ApplicationList)
            {
                Console.WriteLine($"Företag: {app.FöretagsNamn}");
                Console.WriteLine($"Position: {app.Position}");
                Console.WriteLine($"Lön: {(app.Lön > 0 ? app.Lön + " kr" : "Ej angiven")}");
                Console.WriteLine($"Ansökningsdatum: {app.AnsökningsDatum.ToShortDateString()}");
                Console.WriteLine($"Svarstid: {(app.SvarsTid.HasValue ? app.SvarsTid.Value.ToShortDateString() : "Inget svar ännu")}");
                Console.WriteLine($"Status: {app.AnsökningsStatus}");
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Totalt antal ansökningar: {ApplicationList.Count}");

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

            if (application != null)  //anvander tryparse
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

                    Console.WriteLine("Status uppdaterad.");
                }
                else
                {
                    Console.WriteLine("Ogiltig status. Uppdatering misslyckades.");
                }

            }
        }


        public void RemoveApplication()
        {
            Console.Write("Ange företagsnamn att ta bort: ");
            string namn = Console.ReadLine();

            var tabort = ApplicationList.FirstOrDefault(a => a.FöretagsNamn.Equals(namn, StringComparison.OrdinalIgnoreCase));

            if (tabort != null)
            {
                ApplicationList.Remove(tabort);
                Console.WriteLine("Ansökan borttagen.");
            }
            else
            {
                Console.WriteLine("Ansökan hittades inte.");
            }


        }


    }

}
