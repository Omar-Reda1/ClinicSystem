namespace ClinicSystem
{
    public class Patient : Person
    {
        public string Disease{ get; set; }
        public string PhoneNumber{ get; set; }
        public Patient(int id, string name, int age, string disease, string phoneNumber) : base(id, name, age)
        {
            Disease = disease;
            PhoneNumber = phoneNumber;
        }
    }
}
