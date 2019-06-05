using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models.Interface
{
    // Source abstract class(used as interface and add BaseNotify option.
    public abstract class ISource : BaseNotify
    {
        public abstract string Read();
        public abstract void Open();
        public abstract void Close();
    }
}
