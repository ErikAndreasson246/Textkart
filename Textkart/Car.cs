class Car
{
    public string CarName {  get; set; }
    public double MaxSpeed { get; set; }
    public double Turning { get; set; }
    public double Acceleration { get; set; }


    public Car(string carName, double maxSpeed, double turning, double acceleration)
    {
        CarName = carName;
        MaxSpeed = maxSpeed;
        Turning = turning;
        Acceleration = acceleration;
    }

}