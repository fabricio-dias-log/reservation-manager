﻿namespace ReservationManager.Entities;
using ReservationManager.Entities.Exceptions;

public class Reservation
{
    public int RoomNumber { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public Reservation()
    {
    }

    public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
    {
        if (checkOut <= checkIn)
        {
            throw new DomainException("Error in reservation: Check-out date must be after check-in date!");
        }

        RoomNumber = roomNumber;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public override string ToString()
    {
        return $"Reservation: Room {RoomNumber}, " +
               $"check-in: {CheckIn.ToString("dd/MM/yyyy")}, " +
               $"check-out: {CheckOut.ToString("dd/MM/yyyy")}, " +
               $"{Duration()} nights";
    }

    public int Duration()
    {
        TimeSpan duration = CheckOut.Subtract(CheckIn);

        return (int)duration.TotalDays;
    }

    public void UpdateDates(DateTime checkIn, DateTime checkOut)
    {
        DateTime now = DateTime.Now;
        if (checkIn < now || checkOut < now)
        {
            throw new DomainException("Error in reservation: Reservation dates for update must be future dates");
        }

        if (checkOut <= checkIn)
        {
            throw new DomainException("Error in reservation: Check-out date must be after check-in date!");
        }

        CheckIn = checkIn;
        CheckOut = checkOut;
    }
}