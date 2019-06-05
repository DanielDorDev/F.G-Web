using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
    public class Ex3Context : DbContext
    {
    
        // DBcontext for sql server, define the connection to the server.
        public Ex3Context() : base("name=Ex3Context")
        {
        }
        public System.Data.Entity.DbSet<Ex3.Models.FlightData> FlightDatas { get; set; }
    }
}
