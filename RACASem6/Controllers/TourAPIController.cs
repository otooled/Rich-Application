using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RACASem6.DAL;
using RACASem6.Models;

namespace RACASem6.Controllers
{
    public class TourAPIController : ApiController
    {
        private ITourRepository _repo;

        public TourAPIController(ITourRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Trip>GetAllTrips() 
        {
            return _repo.GetAllTrips();
        }

        public Trip GetLeg(int id)
        {
            var trip = _repo.GetTripById(id);
            if (trip == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return trip;
        }

        public HttpResponseMessage PostProduct(Trip trp)
        {
            trp = _repo.AddTrip(trp);
            var response = Request.CreateResponse<Trip>(HttpStatusCode.Created, trp);

            string uri = Url.Link("DefaultApi", new { id = trp.TripId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

    }
}
