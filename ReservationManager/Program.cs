using ReservationManager.Entities;
using ReservationManager.Entities.Exceptions;

namespace ReservationManager;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Room number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(roomNumber, checkInDate, checkOutDate);
            Console.WriteLine(reservation);
            Console.WriteLine();

            Console.WriteLine("Enter data to update the reservation: ");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOutDate = DateTime.Parse(Console.ReadLine());

            reservation.UpdateDates(checkInDate, checkOutDate);

            Console.WriteLine(reservation);
        }
        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Format error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}