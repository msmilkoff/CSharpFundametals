namespace _07.Google
{
    public class Car
    {
        public Car(string model, double speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model { get; set; }

        public double Speed { get; set; }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}";
        }
    }
}