using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Event_Reservation_and_Venue_Management_System.Models;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public class ReservationRepository : IRepository<ReservationModel>
    {
        public DataTable GetDataTable() => DataRepository.ReservationsTable;

        public void Add(ReservationModel reservation)
        {
            string newId = $"RES-{2000 + DataRepository.ReservationsTable.Rows.Count + 1}";
            DataRepository.ReservationsTable.Rows.Add(
                newId,
                reservation.Client,
                reservation.Event,
                reservation.Venue,
                reservation.Date,
                reservation.Status
            );
        }

        public void Update(int rowIndex, ReservationModel reservation)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.ReservationsTable.Rows.Count)
            {
                DataRow row = DataRepository.ReservationsTable.Rows[rowIndex];
                row["Client Name"] = reservation.ClientName;
                row["Event Name"] = reservation.EventName;
                row["Venue"] = reservation.Venue;
                row["Reservation Date"] = reservation.ReservationDate;
                row["Status"] = reservation.Status;
            }
        }

        public void Delete(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.ReservationsTable.Rows.Count)
            {
                DataRepository.ReservationsTable.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
