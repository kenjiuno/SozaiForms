using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms.Helpers
{
    public class SvgRenderEventArgs : EventArgs
    {
        public SvgRenderEventArgs(string filePath, Func<int, Bitmap> render)
        {
            FilePath = filePath;
            Render = render;
        }

        public string FilePath { get; }
        public Func<int, Bitmap> Render { get; }
    }
}
