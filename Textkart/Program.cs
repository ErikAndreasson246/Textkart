using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class program
{
    public static void Main(string[] args)
    {
        //Loop för att kunna starta om programmet när det är klart

        bool programRunnning = true;

        while (programRunnning)
        {

            //Intro och variabler

            List<Car> cars = new List<Car>();

            bool creatingCar = true;
            bool isTrue = true;
            Console.WriteLine("Welcome to Textcart! This game works as follows: You can create as many cars as you want and customize them however you want. You will be using a total of 100 stat points to spread across the different stats. You have to use atleast 1 point on every stat. The stats you have are maxspeed, acceleration and turning.");
            Console.WriteLine();

            // While loop för hela bilskapar processen

            while (creatingCar)
            {

                // Här skapas några boolians och vi får också våran totala poäng som vi får spendera
                creatingCar = true;
                isTrue = true;

                double statPoints = 100;

                // Här anger användaren alla attribut som bilen ska ha

                Console.WriteLine("What do you want to call you car?");
                string carName = Console.ReadLine();


                double speedPoints;
                double maxSpeed;

                while (true)
                {

                    speedPoints = GetValue("How many points do you want to spend on speed? 1 point = 5km/h");

                    if (speedPoints < 99)
                    {
                        maxSpeed = speedPoints * 5;
                        statPoints -= speedPoints;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't spend more points than you have, you also need to have atleast 1 point left for the last stat");                
                    }
                    


                }
                

                Console.Clear();
                Console.WriteLine("You have " + statPoints + " points left");

                double accelerationPoints;
                double acceleration;

                while (true)
                {
                accelerationPoints = GetValue("How many points do you want to spend on acceleration? 1 point = 0.5km/h^2, 2 points = 1km/h^2");

                if (accelerationPoints < statPoints)
                    {
                        acceleration = accelerationPoints * 0.5;
                        statPoints -= accelerationPoints;
                        break;
                    } else
                    {
                        Console.WriteLine("You can't spend more points than you have, you also need to have atleast 1 point left for the last stat");
                    }
                
                }
                
                
                
                    
                Console.Clear();
                Console.WriteLine("You have " + statPoints + " points left");

                double turningPoints;
                double turning;

                while (true)
                {
                    turningPoints = GetValue("How many points do you want to spend on turning?");

                    if (turningPoints <= statPoints)
                    {
                        turning = turningPoints;
                        statPoints -= turningPoints;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't spend more points than you have");
                    }

                }
                

                // Här skapas bilen utefter vad användaren har angett för stats

                Car a = new Car(carName, maxSpeed, turning, acceleration);
                Console.Clear();

                cars.Add(a);

                //detta skriver ut en lista på alla dina bilar du hittils har och sen frågar den dig om du vill skapa fler bilar eller inte

                Console.WriteLine("This is a list of your current cars:");
                for (int i = 0; i < cars.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Name:" + cars[i].CarName + ", Max Speed:" + cars[i].MaxSpeed + "km/h, " + " Turning:" + cars[i].Turning + " Acceleration:" + cars[i].Acceleration + "km/h^2");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();

                Console.WriteLine("Do you want to create another car? yes/no");

                // While loop som kontrollerar ifall du vill skapa fler billar eller inte

                while (isTrue)
                {

                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.Clear();
                        isTrue = false;
                        creatingCar = true;
                    }
                    else if (answer == "no")
                    {
                        Console.Clear();
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

            //Loop för att kunna köra igen med samma bilar

            bool IsPlaying = true;
            while (IsPlaying)
            {

                // Lista på alla banor
                List<string> courses = ["Curvy Curves", "Straight Speed", "Pacy Pivots", "Custom Course (This one might not work as intended since I made some changes to the calculation but it's still usable)"];

                // Skriver ut alla bilar och visar upp en lista av banalternativen

                Console.WriteLine("This is all your cars");
                for (int i = 0; i < cars.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Name:" + cars[i].CarName + ", Max Speed:" + cars[i].MaxSpeed + "km/h, " + " Turning:" + cars[i].Turning + " Acceleration:" + cars[i].Acceleration + "km/h^2");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.WriteLine("it's time to choose what course you want them to race on");
                Console.WriteLine();
                Console.WriteLine("These are the courses you can choose from (Type the number next to the coursename in order to choose it):");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + courses[i]);
                }

                isTrue = true;

                // Här skapas separata listor för varje värde på varje bil så att jag kan jämföra de värdena med värdena på banan (Mitt sätt att räkna ut vilken bil som vann)
                List<double> turningList = new List<double>();
                List<double> accelerationList = new List<double>();
                List<double> maxSpeedList = new List<double>();

                Course course = GetCourse();
                Console.Clear();
                
                double maxTurning = 98;
                double maxAcceleration = 98 * 0.5;
                double maxMaxSpeed = 98 * 5;





                List<Car> fixedCars = new List<Car>();

                for (int i = 0; i < cars.Count; i++)
                {
                    fixedCars.Add(cars[i]);

                    double fixedTurning = cars[i].Turning / maxTurning;
                    
                    double fixedAcceleration = cars[i].Acceleration / maxAcceleration;
                    
                    double fixedMaxSpeed = cars[i].MaxSpeed / maxMaxSpeed;
                    
                    Car a = new Car(cars[i].CarName, fixedMaxSpeed, fixedTurning, fixedAcceleration);
                }


                double turningDegrees = course.TurnDegrees;
                double distanceBetweenTurns = course.DistanceBetweenTurns;
                double courseLength = course.CourseLenght;



                for (int i = 0; i < cars.Count; i++)
                {
                    double a = turningDegrees / fixedCars[i].Turning;
                    turningList.Add(a);
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    double a = distanceBetweenTurns / fixedCars[i].Acceleration ;
                    accelerationList.Add(a);
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    double a = courseLength / fixedCars[i].MaxSpeed;
                    maxSpeedList.Add(a);
                }



                

                List<double> carValues = new List<double>();


                for (int i = 0; i < cars.Count; i++)
                {
                    double a = turningList[i] + accelerationList[i] + maxSpeedList[i];
                    carValues.Add(a);
                }

                string name = "namn";
                double time = 0;

                List<CarResult> carResult = new List<CarResult>();


                for (int i = 0; i < cars.Count; i++)
                {
                    CarResult a = new CarResult(cars[i].CarName, carValues[i]);
                    carResult.Add(a);
                }

                carResult = carResult.OrderBy(carResult => carResult.Time).ToList();


                for (int i = 0; i < carResult.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine((i + 1) + ". " + carResult[i].Car + ": " + carResult[i].Time + " seconds");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(These times are not realistic, they're only for the calculations of who should win)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Play again:");
                Console.WriteLine("1. Same cars");
                Console.WriteLine("2. New cars");
                
                bool wrongAnswer = true;
                while (wrongAnswer)
                {
                    string input = Console.ReadLine();
                    Console.Clear();

                    if (input == "1")
                    {
                        IsPlaying = true;
                        wrongAnswer = false;

                    }
                    else if (input == "2")
                    {
                        IsPlaying = false;
                        wrongAnswer = false;
                    }
                    else
                    {
                        wrongAnswer = true;
                        Console.WriteLine("You can only write 1 or 2");
                        Console.WriteLine();
                        
                    }
                }

            }
        }
            // Detta är en funktion som sköter statpoint processen

            int GetValue(string question)
            {
                bool isTrue = true;
                Console.WriteLine(question);
                while (isTrue)
                {
                    string input = Console.ReadLine();

                //Här är en try som ser till att du endast kan skriva siffror
                try
                { 
                    int points = Convert.ToInt32(input);
                    if (points > 0 && points < 99)
                    {
                        isTrue = false;
                        return points;
                    }
                    else
                    {
                        Console.WriteLine("You can only enter a number between 1 - 98 since you need to use atleast 1 point on each stat");
                        isTrue = true;
                    }

                } catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to enter a number");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                    
                }
                return 0;
            }

        //Detta är en funktion som ger ett värde till custom course. Den kollar så att värdet är större än 0 och inte är en bokstav.
        int GetCourseValue(string question)
        {
            bool isTrue = true;
            Console.WriteLine(question);
            while (isTrue)
            {
                string input = Console.ReadLine();

                //Här är en try som ser till att du endast kan skriva siffror
                try
                {
                    int points = Convert.ToInt32(input);
                    if (points > 0)
                    {
                        isTrue = false;
                        return points;
                    }
                    else
                    {
                        Console.WriteLine("Your number can't be 0 or lower");
                        isTrue = true;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to enter a number");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            return 0;
        }

        //En funktion som skapar den bana som användaren väljer
        Course GetCourse()
            {
                Course course = null;
                bool isChoosing = true;

                while (isChoosing)
                {
                string courseChoice = Console.ReadLine();

                    switch (courseChoice)
                    {
                        case "1":
                            course = new Course("Curvy Curves", 90, 4, 3);
                            isChoosing = false;
                            break;
                        case "2":
                            course = new Course("Straight Speed", 0, 0, 10);
                            isChoosing = false;
                            break;
                        case "3":
                            course = new Course("Pacy Pivots", 30, 8, 7);
                            isChoosing = false;
                            break;
                        case "4":
                            
                            //Här skapas custom banan
                            course = new Course("Custom", 1, 1, 1);
                            Console.WriteLine("You chose to create a custom course");
                            Console.WriteLine();

                            course.DistanceBetweenTurns = GetCourseValue("How many Degrees do you want on your turns?");
                            course.DistanceBetweenTurns = GetCourseValue("How long distance do you want in beetween your turns?");
                            course.CourseLenght = GetCourseValue("How long do you want your course to be?");
                            isChoosing = false;
                            break;
                        default:
                            Console.WriteLine("You can only choose between the courses that exists");
                            break;
                    }         
                }
                return course;
            }   
        }
    }