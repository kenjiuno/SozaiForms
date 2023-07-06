using SozaiForms.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms
{
    class Item
    {
        public string FilePath { get; set; }
        public Bitmap Picture { get; set; }
        public string License { get; set; }

        public string WidthRepresentation { get; set; }

        public BitmapOrNot Info { get; set; }
    }
}
