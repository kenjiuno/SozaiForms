using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms {
    class Item {
        /// <summary>
        /// lower .ext
        /// </summary>
        internal string ext;
        internal string fp;
        internal Bitmap pic;
        internal string license;

        internal bool isIco { get { return ext == ".ico"; } }
        public int width { get { return pic.Width; } }
    }
}
