namespace ClinicSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================");
            Console.WriteLine("   Welcome To Our Clinic System  ");
            Console.WriteLine("=================================");
            Console.ResetColor();

            bool repetition = true;
            Clinic clinic = new Clinic();

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=================================");
                Console.WriteLine("1- Add Doctor");
                Console.WriteLine("2- Show All Doctors");
                Console.WriteLine("3- Add Patient");
                Console.WriteLine("4- Show All Patients");
                Console.WriteLine("5- Book Appointment");
                Console.WriteLine("6- Cancel Appointment");
                Console.WriteLine("7- Show All Appointments");
                Console.WriteLine("8- Show Doctor Appointments");
                Console.WriteLine("9- Exit");
                Console.WriteLine("=================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Your Choice: ");
                Console.ResetColor();

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine();

                            Console.Write("Enter Doctor Id: ");
                            int doctorId;
                            if (!int.TryParse(Console.ReadLine(), out doctorId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Id");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Doctor Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Doctor Age: ");
                            int doctorAge;
                            if (!int.TryParse(Console.ReadLine(), out doctorAge))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Age");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Doctor Specialization: ");
                            string specialization = Console.ReadLine();

                            Console.Write("Enter Doctor Fees: ");
                            double fees;
                            if (!double.TryParse(Console.ReadLine(), out fees))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Fees");
                                Console.ResetColor();
                                break;
                            }

                            Doctor doctor = new Doctor(doctorId, name, doctorAge, specialization, fees);
                            clinic.AddDoctor(doctor);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Doctor added successfully.");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine();
                            clinic.ShowAllDoctors();
                            Console.WriteLine();
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine();

                            Console.Write("Enter Patient ID: ");
                            int patientId;
                            if (!int.TryParse(Console.ReadLine(), out patientId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid ID");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Patient Name: ");
                            string patientName = Console.ReadLine();

                            Console.Write("Enter Patient Age: ");
                            int patientAge;
                            if (!int.TryParse(Console.ReadLine(), out patientAge))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Age");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Disease: ");
                            string disease = Console.ReadLine();

                            Console.Write("Enter PhoneNumber: ");
                            string phoneNumber = Console.ReadLine();

                            Patient patient = new Patient(patientId, patientName, patientAge, disease, phoneNumber);
                            clinic.AddPatient(patient);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Patient added successfully.");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine();
                            clinic.ShowAllPatients();
                            Console.WriteLine();
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine();

                            Console.Write("Enter Doctor ID: ");
                            int doctorId;
                            if (!int.TryParse(Console.ReadLine(), out doctorId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Doctor ID");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Patient ID: ");
                            int patientId;
                            if (!int.TryParse(Console.ReadLine(), out patientId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Patient ID");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Enter Appointment Date (e.g. 2026-04-20 10:30): ");
                            DateTime date;
                            if (!DateTime.TryParse(Console.ReadLine(), out date))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Date");
                                Console.ResetColor();
                                break;
                            }

                            bool result = clinic.BookAppointment(doctorId, patientId, date);

                            if (!result)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Booking failed.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Appointment booked successfully.");
                                Console.ResetColor();
                            }

                            Console.WriteLine();
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine();

                            Console.Write("Enter Appointment ID: ");
                            int appointmentId;
                            if (!int.TryParse(Console.ReadLine(), out appointmentId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Appointment ID");
                                Console.ResetColor();
                                break;
                            }

                            bool result = clinic.CancelAppointment(appointmentId);

                            if (!result)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Cancel failed.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Appointment cancelled successfully.");
                                Console.ResetColor();
                            }

                            Console.WriteLine();
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine();
                            clinic.ShowAllAppointments();
                            Console.WriteLine();
                            break;
                        }

                    case 8:
                        {
                            Console.WriteLine();

                            Console.Write("Enter Doctor ID: ");
                            int doctorId;
                            if (!int.TryParse(Console.ReadLine(), out doctorId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Doctor ID");
                                Console.ResetColor();
                                break;
                            }

                            clinic.ShowDoctorAppointments(doctorId);
                            Console.WriteLine();
                            break;
                        }

                    case 9:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Thank you for using Clinic System.");
                            Console.ResetColor();
                            repetition = false;
                            break;
                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Choice, try again.");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }
                }

            } while (repetition);

        }
    }
}
