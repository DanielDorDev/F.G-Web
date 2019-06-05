using Ex3.Models;
using Ex3.Models.SourceObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using System.Xml;



namespace Ex3.Controllers
{
    // Controllre for display flight route.
    public class DisplayController : Controller
    {
        // Default.
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        // Display server with connection to server, uses ip, port and request rate(=time).
        [HttpGet]
        public ActionResult DisplayServer(string ip, int port, int time)
        {
            // Create map model and inject source server(source interface).
            MapModel mapModel = new MapModel(new SourceServer(ip, port), time);
            ViewBag.AlertFinishedReading = false;
            // Register listener of event timeout(for map model use).
            mapModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == "EventTimeout")
                {
                    mapModel.Stop();
                }
            };

            // If time = 0 , default request created (update once), register event for first read.
            if (time == 0)
            {
                mapModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
                {
                    if
                      (e.PropertyName == "EventRead")
                    {
                        mapModel.Stop();
                    }
                };
            }
            // Configure client side refresh rate(in seconds), start model and return display.
            return StartDisplay(mapModel);
        }

        [HttpGet]

        // Display file action, uses file name, rate(=time).
        public ActionResult DisplayFile(string name, int time)
        {
            try
            {
                // Create source file(interface) from type source file.
                MapModel mapModel = new MapModel(new SourceFile(Server.MapPath(@"\" + name + ".xml")), time);
                // Configure client side refresh rate(in seconds), start model and return display.
                ViewBag.AlertFinishedReading = true;


                return StartDisplay(mapModel);
            }
            catch (Exception)
            {
                return View("Home");
            };

        }
        [HttpGet]
        public ActionResult Save(string ip, int port, int rate, int time, string name)
        {

            // If time reading = 0 , return default view.
            if (time <= 0)
            {
                return View("Home");
            }
            // Create model, for data reading.
            MapModel mapModel = new MapModel(new SourceServer(ip, port), rate);
            ViewBag.AlertFinishedReading = false;

            // Add at timeout event, export dbo.flightdatas to xml file.
            mapModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == "EventTimeout")
                {
                    try
                    {
                        // Create connection to the sql Server.
                        using (SqlConnection connection = new SqlConnection(new Ex3Context().Database.Connection.ConnectionString))
                        {
                            // Return the data to dataset object, select all rows in xml auto mode (xml fit).
                            DataSet dataset = new DataSet();
                            SqlDataAdapter adapter = new SqlDataAdapter
                            {
                                SelectCommand = new SqlCommand("SELECT * FROM dbo.FlightDatas", connection)
                            };

                            // Fill dataset and use the attr writexml to create xml file.
                            adapter.Fill(dataset);
                            dataset.WriteXml(Server.MapPath(@"\" + name + ".xml"), XmlWriteMode.IgnoreSchema);
                        }
                    }
                    catch (Exception) { }
                }
            };

            // Create timer, when executed create timeout event.
            System.Timers.Timer aTimer = new System.Timers.Timer
            {
                Interval = time * 1000
            };
            aTimer.Elapsed += (sender, e) =>
            {
                // Stop the server reading first, notify the listeners about the event.
                mapModel.Stop();
                mapModel.NotifyPropertyChanged("EventTimeout");
            };

            // Prevent from restart, start the timer and execute display.
            aTimer.AutoReset = false;
            aTimer.Start();
            return StartDisplay(mapModel);
        }

        // Common action of model start, time refresh init and view return.
        public ActionResult StartDisplay(MapModel mapModel)
        {
            Session["time"] = 4;
            mapModel.Start();
            return View("display");
        }
    }
}