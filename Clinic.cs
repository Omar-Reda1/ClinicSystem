namespace ClinicSystem
{
    public class Clinic
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public void ShowAllDoctors()
        {
            Console.WriteLine("All Doctors:");

            if (Doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
                return;
            }

            foreach (var item in Doctors)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Age: {item.Age}, Specialization: {item.Specializaion}, Fees: {item.Fess}");
            }
        }

        public void ShowAllPatients()
        {
            Console.WriteLine("All Patients:");

            if (Patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var item in Patients)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Age: {item.Age}, Phone Number: {item.PhoneNumber}, Disease: {item.Disease}");
            }
        }

        public void ShowAllAppointments()
        {
            Console.WriteLine("All Appointments:");

            if (Appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var item in Appointments)
            {
                Console.WriteLine($"Id: {item.Id}, Status: {item.Status}, Date: {item.AppointmentDate}, Doctor Name: {item.Doctor.Name}, Patient Name: {item.Patient.Name}");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public Doctor GetDoctorById(int id)
        {
            foreach (var item in Doctors)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public Patient GetPatientById(int id)
        {
            foreach (var item in Patients)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public Appointment GetAppointmentById(int id)
        {
            foreach (var item in Appointments)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public bool BookAppointment(int doctorId, int patientId, DateTime date)
        {
            var doctor = GetDoctorById(doctorId);
            if (doctor is null)
                return false;

            var patient = GetPatientById(patientId);
            if (patient is null)
                return false;

            if (date < DateTime.Now)
                return false;

            foreach (var item in Appointments)
            {
                if (item.Doctor.Id == doctorId &&item.AppointmentDate == date &&item.Status != AppointmentStatus.Canceled)
                {
                    return false;
                }
            }

            var appointment = new Appointment
            {
                Id = Appointments.Count + 1,
                Doctor = doctor,
                Patient = patient,
                AppointmentDate = date,
                Status = AppointmentStatus.Pending
            };

            Appointments.Add(appointment);
            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            var appointment = GetAppointmentById(appointmentId);

            if (appointment is null)
                return false;

            if (appointment.Status == AppointmentStatus.Canceled)
                return false;

            appointment.Status = AppointmentStatus.Canceled;
            return true;
        }

        public void ShowDoctorAppointments(int doctorId)
        {
            var doctor = GetDoctorById(doctorId);

            if (doctor is null)
            {
                Console.WriteLine("Doctor does not exist.");
                return;
            }

            Console.WriteLine($"Appointments for Dr. {doctor.Name}:");

            bool found = false;

            foreach (var item in Appointments)
            {
                if (item.Doctor.Id == doctorId)
                {
                    Console.WriteLine($"Id: {item.Id}, Patient Name: {item.Patient.Name}, Status: {item.Status}, Date: {item.AppointmentDate}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No appointments for this doctor.");
            }
        }
    }
}