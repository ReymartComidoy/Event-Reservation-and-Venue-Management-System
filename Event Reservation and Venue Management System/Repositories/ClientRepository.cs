using Event_Reservation_and_Venue_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public class ClientRepository : IRepository<ClientModel>
    {
        public DataTable GetDataTable() => DataRepository.ClientsTable;

        public void Add(ClientModel client)
        {
            string newId = $"CLT-{1000 + DataRepository.ClientsTable.Rows.Count + 1}";
            DataRepository.ClientsTable.Rows.Add(
                newId,
                client.FullName,
                client.Email,
                client.Phone,
                client.Company,
                client.ClientType,
                client.Status
            );
        }

        public void Update(int rowIndex, ClientModel client)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.ClientsTable.Rows.Count)
            {
                DataRow row = DataRepository.ClientsTable.Rows[rowIndex];
                row["Client Name"] = client.FullName;
                row["Email Address"] = client.Email;
                row["Phone Number"] = client.Phone;
                row["Company Name"] = client.Company;
                row["Client Type"] = client.ClientType;
                row["Status"] = client.Status;
            }
        }

        public void Delete(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.ClientsTable.Rows.Count)
            {
                DataRepository.ClientsTable.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
