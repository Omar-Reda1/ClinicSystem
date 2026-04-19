namespace ClinicSystem
{
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Canceled,
    }
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
