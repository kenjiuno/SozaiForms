using SozaiForms.Helpers;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms.Usecases
{
    public class RenderFileToBitmapUsecase
    {
        public BitmapOrNot Decide(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (false) { }
            else if ("/.ico/".Contains("/" + extension + "/"))
            {
                return new BitmapOrNot
                {
                    CanLoad = true,
                    Extension = extension,
                    Load = () => new Bitmap(new MemoryStream(File.ReadAllBytes(filePath))),
                    IsIcon = true,
                };
            }
            else if ("/.svg/".Contains("/" + extension + "/"))
            {
                return new BitmapOrNot
                {
                    CanLoad = true,
                    Extension = extension,
                    Load = () =>
                    {
                        var svgDoc = SvgDocument.Open<SvgDocument>(filePath);
                        return svgDoc.Draw(32, 32);
                    },
                    IsSvg = true,
                    RenderSvg = size =>
                    {
                        var svgDoc = SvgDocument.Open<SvgDocument>(filePath);
                        return svgDoc.Draw(size, size);
                    },
                };
            }
            else if ("/.bmp/.gif/.png/.jpg/.jpeg/.emf/.wmf/.ico/".Contains("/" + extension + "/"))
            {
                return new BitmapOrNot
                {
                    CanLoad = true,
                    Extension = extension,
                    Load = () => new Bitmap(new MemoryStream(File.ReadAllBytes(filePath))),
                };
            }
            else
            {
                return new BitmapOrNot
                {
                    Extension = extension,
                };
            }
        }
    }
}
