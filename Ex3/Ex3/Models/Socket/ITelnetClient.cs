using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models.Socket
{
    public interface ITelnetClient // Interface connect as client
    {
        string Ip { get; } // Return ip adress.
        int Port { get; } // Return port number.
        void Connect(); // Connect to client.
        void Write(string command); // Write to client msg.
        string Read(); // Read from client.
        void Disconnect(); // Disconnect from client.
    }
}
