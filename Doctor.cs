namespace ClinicSystem
{
    public class Doctor : Person
    {
        public string Specializaion { get; set; }
        public double Fess { get; set; }
        public Doctor(int id, string name, int age, string specializaion, double fees) : base(id, name, age)
        {
            Specializaion = specializaion;
            Fess = fees;
        }
    }
}
