using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms.Helpers
{
    public class PickEventArgs : EventArgs
    {
        public PickEventArgs(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
