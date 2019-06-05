using Ex3.Models.Interface;
using Ex3.Models.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Ex3.Models.SourceObjects
{
    // Read directly from flightgear.
    public class SourceServer : ISource
    {
        readonly BaseClient serverConnection;

        volatile Boolean _StopClient = true;   // Boolean for client status.
        public Boolean StopClient
        {
            get => _StopClient;
            set
            {
                _StopClient = value;
                if (value)
                {
                    // If server stopped, notify timeout.
                    this.NotifyPropertyChanged("Timeout");
                }
            }
        }

        // Init Source server, use ip and port, add event and listen to connect, disconnect operation.
        public SourceServer(string ipSet, int portSet)
        {
            this.serverConnection = new ConnectToServer(ipSet, portSet);
            this.serverConnection.NotifyDisconnected += delegate () { this.StopClient = true; };
            this.serverConnection.NotifyConnected += delegate () { this.StopClient = false; };
        }

        // Disconnect action if server is running.
        public override void Close()
        {
            if (!StopClient)
            {
                serverConnection.Disconnect();
            }
        }
        // Open connection if server is disconnected.
        public override void Open()
        {
            if (this.StopClient)
            {
                serverConnection.Connect();
            }
        }

        // Reading opeartion, because only one read of one type needed.
        // Use simple write opeartion(no need for complex for this ex).
        public override string Read()
        {

            if (this.StopClient)
            {
                return null;
            }

            this.serverConnection.Write(
                "get /position/longitude-deg\r\n " +
                "get /position/latitude-deg\r\n " +
                "get /controls/flight/rudder\r\n " +
                "get /controls/engines/current-engine/throttle\r\n");

            string recvData = this.serverConnection.Read();

            // Use regex to get all the double response( 'number' ).
            return recvData != null ? string.Join(",", Regex.Matches(recvData,
                    @"'(.*?)'").Cast<Match>()).Replace("'", "") : null;
        }
    }
}