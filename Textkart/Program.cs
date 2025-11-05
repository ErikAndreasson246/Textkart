using System.Runtime.CompilerServices;

class program
{ 
    public static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        bool creatingCar = true;
        bool isTrue = true;


        while (creatingCar)
        {


            int statPoints = 150;



            Console.WriteLine("Enter the name of the car");
            string carName = Console.ReadLine();


            int speedPoints = GetValue("How many points do you want to spend on speed? 1 point = 5km/h. You can");
            int maxSpeed = speedPoints * 5;
            statPoints -= speedPoints;

            int turningPoints = GetValue("How many points do you want to spend on turning?");
            int turning = turningPoints;
            statPoints -= speedPoints;

            Car a = new Car(carName, maxSpeed, turning);
            Console.Clear();

            Console.WriteLine("Name:" + a.CarName + ", Max Speed:" + a.MaxSpeed + "km/h, " + "Turning:" + a.Turning);

            cars.Add(a);

            Console.WriteLine("Do you want to create another car? yes/no");

            while (isTrue)
            {

                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    isTrue = false;
                    creatingCar = true;
                }
                else if (answer == "no")
                {
                    isTrue = false;
                    creatingCar = false;
                }
                else
                {
                    Console.WriteLine("You can only answer yes or no");
                    isTrue = true;
                }
            }
        }


        for (int i = 0; i < cars.Count; i ++)
        {
            Console.WriteLine("Name:" + cars[i].CarName + ", Max Speed:" + cars[i].MaxSpeed + "km/h, " + "Turning:" + cars[i].Turning);
        }

        int GetValue(string question)
        {
            Console.WriteLine(question);
            string input = Console.ReadLine();
            int maxSpeed = Convert.ToInt32(input);

            return maxSpeed;
        }
    } 
}
        
        
 
