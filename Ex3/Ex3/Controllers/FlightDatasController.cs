using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ex3.Models;

namespace Ex3.Controllers
{
    public class FlightDatasController : ApiController
    {
        private Ex3Context db = new Ex3Context();

        // GET: api/FlightDatas
        public IQueryable<FlightData> GetFlightDatas()
        {
            // SQL server request for table, returned by order(id define the flight route order).
            return db.FlightDatas.OrderBy(m => m.Id);
        }

        // GET: api/FlightDatas?from=&to=
        public async Task<List<FlightData>> GetFlightDatas(int from, int to)
        {
            // SQL server request for table, return list by order in range[from => to].
            return await this.GetFlightDatas().Skip(from).Take(to - from).ToListAsync();
        }


        // GET: api/FlightDatas/5
        [ResponseType(typeof(FlightData))]
        public async Task<IHttpActionResult> GetFlightData(int id)
        {
            // SQL request once, search by id.
            FlightData flightData = await db.FlightDatas.FindAsync(id);
            if (flightData == null)
            {
                return NotFound();
            }

            return Ok(flightData);
        }


        // DELETE: api/FlightDatas/5
        [ResponseType(typeof(FlightData))]
        public async Task<IHttpActionResult> DeleteFlightData(int id)
        {
            // Delete row, search by id.
            FlightData flightData = await db.FlightDatas.FindAsync(id);
            if (flightData == null)
            {
                return NotFound();
            }

            db.FlightDatas.Remove(flightData);
            await db.SaveChangesAsync();

            return Ok(flightData);
        }

        protected override void Dispose(bool disposing)
        {
            // SQL dispose.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightDataExists(int id)
        {
            // Check if row exist.
            return db.FlightDatas.Count(e => e.Id == id) > 0;
        }
    }
}