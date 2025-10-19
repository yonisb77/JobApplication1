namespace JobAPPTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            JobManager manager = new JobManager();

            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("Job Application Tracker");
                Console.WriteLine("1. Lägg till ny ansökan");
                Console.WriteLine("2. Visa alla ansökningar");
                Console.WriteLine("3. Visa statistik: Totalt antal ansökningar");
                Console.WriteLine("4. Uppdatera status på en ansökan");
                Console.WriteLine("5. ta bort en ansökan");
                Console.WriteLine("6. Avsluta programmet");
                Console.Write("ange ditt val 1-6: ");

                string choice = Console.ReadLine();
                Console.Clear();


                switch (choice)
                {
                    case "1":
                        manager.AddJob();
                        break;
                    case "2":
                        manager.ShowAll();
                        break;
                    case "3":
                        manager.ShowStatistics();
                        break;
                    case "4":
                        manager.UpdateStatus();
                        break;
                    case "5":
                        manager.RemoveApplication();
                        break;
                    case "6":
                        Console.WriteLine("Avslutar programmet.....");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }
    }
}
