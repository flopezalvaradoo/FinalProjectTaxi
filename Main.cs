namespace Practice2
{
    internal class Program
    {

        static void Main()
        {
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            policeCar1.GivePoliceARadar(); // Added new
            policeCar2.GivePoliceARadar(); // Added new

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

            // New

            City city = new City("Madrid");
            Console.WriteLine(city.WriteMessage("Created"));

            PoliceStation policeStation = new PoliceStation();
            city.SetPoliceStation(policeStation);
            Console.WriteLine(policeStation.WriteMessage("Created"));

            city.GiveTaxiLicenses("0003 CCC");
            city.GiveTaxiLicenses("0004 DDD");
            city.GiveTaxiLicenses("0005 EEE");

            policeStation.AddNewPoliceCarToStation("0003 CNP");
            policeStation.AddNewPoliceCarToStation("0004 CNP");
            policeStation.AddNewPoliceCarToStation("0005 CNP");


            PoliceCar policeCar3 = policeStation.policeCarList[0];
            PoliceCar policeCar4 = policeStation.policeCarList[1];
            PoliceCar policeCar5 = policeStation.policeCarList[2];

            policeCar3.StartPatrolling();
            policeCar3.UseRadar(taxi1);

            policeCar4.GivePoliceARadar();
            policeCar5.GivePoliceARadar();
            policeCar4.StartPatrolling();
            policeCar5.StartPatrolling();

            Taxi taxi4 = city.taxiLicenseList[1];
            taxi4.StartRide();
            policeCar5.UseRadar(taxi4);
            policeStation.AllChaseCar();

            city.RemoveTaxiLicenses(taxi4);
            policeStation.AllStopChaseCar();

            //Scooter scooter1 = new Scooter();
            //Console.WriteLine(scooter1.WriteMessage("Created"));
        }
    }
}
    

