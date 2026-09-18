using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Event_Reservation_and_Venue_Management_System.Models;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public class VenueRepository : IRepository<VenueModel>
    {
        public DataTable GetDataTable() => DataRepository.VenuesTable;

        public void Add(VenueModel venue)
        {
            DataRepository.VenuesTable.Rows.Add(
                venue.VenueName,
                venue.Capacity,
                venue.Location,
                venue.PricePerHour,
                venue.Status
            );
        }

        public void Update(int rowIndex, VenueModel venue)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.VenuesTable.Rows.Count)
            {
                DataRow row = DataRepository.VenuesTable.Rows[rowIndex];
                row["Venue Name"] = venue.VenueName;
                row["Capacity"] = venue.Capacity;
                row["Location"] = venue.Location;
                row["Price Per Hour"] = venue.PricePerHour;
                row["Status"] = venue.Status;
            }
        }

        public void Delete(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.VenuesTable.Rows.Count)
            {
                DataRepository.VenuesTable.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
