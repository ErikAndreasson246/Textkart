    class Course
    {
        public string Name { get; set; }
        public double TurnDegrees { get; set; }
        public double DistanceBetweenTurns { get; set; }
        public double CourseLenght { get; set; }



        public Course(string name, double turnDegrees, double distanceBetweenTurns, double courseLength)
        {
            Name = name;
            TurnDegrees = turnDegrees;
            DistanceBetweenTurns = distanceBetweenTurns;
            CourseLenght = courseLength;
        }
}