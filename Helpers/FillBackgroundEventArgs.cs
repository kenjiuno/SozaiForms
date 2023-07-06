using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SozaiForms.PicturesControl;

namespace SozaiForms.Helpers
{
    public class FillBackgroundEventArgs : EventArgs
    {
        public FillBackgroundEventArgs(Graphics graphics, Rectangle rectangle, PictureItem pictureItem)
        {
            Graphics = graphics;
            Rectangle = rectangle;
            PictureItem = pictureItem;
        }

        public Graphics Graphics { get; }
        public Rectangle Rectangle { get; }
        public PictureItem PictureItem { get; }
    }
}
