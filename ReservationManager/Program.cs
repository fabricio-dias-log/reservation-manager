using ReservationManager.Entities;

namespace ReservationManager;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Room number: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Console.Write("Check-in date (dd/MM/yyyy): ");
        DateTime checkInDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Check-out date (dd/MM/yyyy): ");
        DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

        if (checkOutDate <= checkInDate)
        {
            Console.WriteLine("Error in reservation: Check-out date must be after check-in date!");
        }
        else
        {
            Reservation reservation = new Reservation(roomNumber, checkInDate, checkOutDate);
            Console.WriteLine(reservation);
            Console.WriteLine();

            Console.WriteLine("Enter data to update the reservation: ");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOutDate = DateTime.Parse(Console.ReadLine());

            string error = reservation.UpdateDates(checkInDate, checkOutDate);

            if (error != null)
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine(reservation);
            }

        }


    }
}