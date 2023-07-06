using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms.Helpers
{
    public class BitmapOrNot
    {
        public string Extension { get; set; }
        public bool CanLoad { get; set; }
        public Func<Bitmap> Load { get; set; }
        public bool IsIcon { get; set; }
        public bool IsSvg { get; set; }
        public Func<int, Bitmap> RenderSvg { get; set; }
    }
}
