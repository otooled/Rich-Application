using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RACASem6.Models;

namespace RACASem6.DAL
{
    public interface ITourRepository : IDisposable
    {
        IQueryable<Trip> GetAllTrips();
    }
}
