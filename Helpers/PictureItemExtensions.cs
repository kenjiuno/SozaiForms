using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SozaiForms.PicturesControl;

namespace SozaiForms.Helpers
{
    internal static class PictureItemExtensions
    {
        public static BitmapOrNot GetInfo(this PictureItem it) => (BitmapOrNot)it.Tag;
    }
}
