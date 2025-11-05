class Car
{
    public string CarName {  get; set; }
    public int MaxSpeed { get; set; }
    public int Turning { get; set; }


    public Car(string carName, int maxSpeed, int turning)
    {
        CarName = carName;
        MaxSpeed = maxSpeed;
        Turning = turning;
    }

}