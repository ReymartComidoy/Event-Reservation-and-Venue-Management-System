using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public interface IRepository<T> where T : class
    {
        DataTable GetDataTable();
        void Add(T entity);
        void Update(int rowIndex, T entity);
        void Delete(int rowIndex);
    }
}
