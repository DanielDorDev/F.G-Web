using Ex3.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Web;

namespace Ex3.Models
{
    // Main class for model, used as gate between data reading from sources, and requests from controller.
    public class MapModel : BaseNotify
    {

        // Create timer for model rate read.
        private System.Timers.Timer aTimer = null;

        // Create map source.
        private ISource MapSource { get; set; }

        // Init map model, get source type and read rate.
        public MapModel(ISource MapSourceSet, int TimeSet)
        {
            // Delete table if exist.
            using (var db = new Ex3Context())
            {
                db.Database.Delete();
           //     db.Database.ExecuteSqlCommand("TRUNCATE TABLE [FlightDatas]");
                db.SaveChanges();
            }

            // Set the map source, add listener, define timer(with default 4 times second reading rate).
            this.MapSource = MapSourceSet;
            this.MapSource.PropertyChanged += MapSource_PropertyChanged;
            double rate = TimeSet > 0 ? (1000 / TimeSet) : 1000;

            // Init timer, add listener for event read(bind to server response).
            aTimer = new System.Timers.Timer
            {
                Interval = rate
            };

            this.aTimer.Elapsed += (sender, e) => EventRead(this, null, MapSource);
        }

        // Stop request from server(give the option for later reconnection).
        public void Stop()
        {
            if (aTimer != null)
            {
                aTimer.Close();
            }
        }
        // Start reading from server, open connection and start reading.
        public void Start()
        {
            MapSource.Open();
            this.aTimer.Start();
        }

        // Event read, create request to flightgear, get responce, and update sql.
        public void EventRead(object source, ElapsedEventArgs e, ISource sourceRead)
        {
            try
            {
                // Convert the data returned, use ex3context connection, init dbset and insert, save changed.
                double[] arr = Array.ConvertAll(sourceRead.Read().Split(','), Double.Parse);
                using (var db = new Ex3Context())
                {
                    db.FlightDatas.Add(new FlightData
                    {
                        Id = db.FlightDatas.Count(),
                        Lon = arr[0],
                        Lat = arr[1],
                        Rudder = arr[2],
                        Throttle = arr[3]
                    });
                    db.SaveChanges();
                }
                // Notify event happened.
                this.NotifyPropertyChanged("EventRead");
            }
            catch (Exception) { };
        }

        // Read notify as listener.
        private void MapSource_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // If timeout notify happened, stop timer, notify to controller.
            if (e.PropertyName == "Timeout")
            {
                if (aTimer != null)
                {
                    this.Stop();
                }
            }
        }
    }
}
