using Ex3.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Ex3.Models.SourceObjects
{
    // Read xml from local disk file.
    public class SourceFile : ISource
    {
        private XmlReader reader = null;
        // Set file name.
        public string FileName { get; set; }
        volatile Boolean _Stop = true;   // Boolean for client status.

        public Boolean Stop
        {
            get => _Stop;
            set
            {
                _Stop = value;
                if (value)
                {
                    // If server stopped, notify timeout.
                    this.NotifyPropertyChanged("Timeout");
                }
            }
        }

        // Source file init, use file name.
        public SourceFile(string FileNameSet)
        {
            // Set file name and stop arg.
            this.FileName = FileNameSet;
            this.Stop = true;
        }

        // Close connection.
        public override void Close()
        {
            if (!Stop)
            {
                // Close file and set stop to true.
                this.reader.Close();
                this.Stop = true;
            }
        }
        // Open connection.
        public override void Open()
        {
            if (Stop)
            {
                try
                {
                    // Create xdoc from file path, create reader, move to root, move to first element, announce source is on(stop = false).
                    XDocument xdoc = XDocument.Load(this.FileName);
                    this.reader = xdoc.CreateReader();
                    reader.MoveToContent();
                    reader.Read();
                    this.Stop = false;
                }
                catch (Exception) { this.Stop = true; }
            }
        }
        // Read from file.
        public override string Read()
    {
            try
            {
                // Itearate every time to next element, convert to xml node, choose Attr, convert to list, and skip id.
                // We get String = "Lon,Lat,Rudder,Throttle"
                string xElement = string.Join(",", XElement.Parse(this.reader.ReadOuterXml()).Descendants().Select(x => x.Value).ToList().Skip(1));

                // Check for last value, if so stop.
                if (reader.EOF)
                {
                    this.Stop = true;
                }

                return xElement;

            } catch (Exception)
            {
                // If problem occure stop the reading.
                this.Stop = true;
                return null;
            }
        }
    }
}