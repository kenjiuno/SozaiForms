using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jtifedit3;
using System.Diagnostics;
using System.IO;
using PicSozai;
using SozaiForms.Usecases;
using SozaiForms.Helpers;

namespace SozaiForms
{
    public partial class PicturesControl : UserControl
    {
        public PicturesControl()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public class PictureItem
        {
            public Bitmap Picture { get; set; }
            public string License { get; set; }
            public string WidthRepresentation { get; set; }

            public object Tag { get; set; }
        }

        private readonly List<PictureItem> _items = new List<PictureItem>();

        private bool _showLic = false;
        private bool _showSize = false;
        private int _selectedIndex;

        private PictureItem SelectedItem => ((uint)_selectedIndex >= (uint)_items.Count) ? null : _items[_selectedIndex];

        private const int BLKX = 48 + 2;
        private const int BLKY = 56 + 2;

        private static readonly Font _smallFont = new Font("Arial", 5);

        private static readonly StringFormat _bottomRight = new StringFormat
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Far,
        };

        private static readonly StringFormat _bottomLeft = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Far,
        };

        private class PictureLayouter
        {
            public int cx;
            public int cy;
            public int maxy;
            public int count;

            public Rectangle GetRect(int t)
            {
                return new Rectangle((t % cx) * BLKX, (t / cx) * BLKY, BLKX, BLKY);
            }

            public int GetPos(Point point)
            {
                int x = point.X / BLKX;
                int y = point.Y / BLKY;
                int t = x + cx * y;
                if (point.X < 0 || point.Y < 0 || BLKX * cx < point.X || t >= count)
                {
                    return -1;
                }
                return t;
            }
        }

        private PictureLayouter GetPictureLayouter()
        {
            var size = ClientSize;
            int cx = Math.Max(1, size.Width / BLKX);
            int cy = size.Height / BLKY;

            return new PictureLayouter
            {
                cx = cx,
                cy = cy,
                maxy = (_items.Count + cx - 1) / cx,
                count = _items.Count,
            };
        }

        public event EventHandler<FillBackgroundEventArgs> FillBackground;

        private void Pictures_Paint(object sender, PaintEventArgs e)
        {
            var pictureLayouter = GetPictureLayouter();
            var cv = e.Graphics;
            for (int t = 0; t < _items.Count; t++)
            {
                var item = _items[t];
                Rectangle rcMax = pictureLayouter.GetRect(t);
                rcMax.Offset(0, AutoScrollPosition.Y);

                if (e.ClipRectangle.IntersectsWith(rcMax))
                {
                    FillBackground?.Invoke(this, new FillBackgroundEventArgs(cv, rcMax, item));
                    var newRect = FitRect3.Fit(rcMax, item.Picture.Size);
                    cv.DrawImage(item.Picture, newRect);
                    cv.DrawLines(Pens.Gray, new Point[] {
                        new Point(rcMax.X, rcMax.Bottom - 1),
                        new Point(rcMax.Right - 1, rcMax.Bottom - 1),
                        new Point(rcMax.Right - 1, rcMax.Y)
                    });
                    var rcMaxM1 = rcMax;
                    rcMaxM1.Width--;
                    rcMaxM1.Height--;
                    if (ShowSize)
                    {
                        cv.DrawString(item.WidthRepresentation, _smallFont, Brushes.Green, rcMaxM1, _bottomRight);
                    }
                    if (_showLic)
                    {
                        cv.DrawString(item.License, _smallFont, Brushes.Green, rcMaxM1);
                    }
                }
            }
        }

        internal void Add(PictureItem item)
        {
            int t = _items.Count;

            _items.Add(item);

            Invalidate(GetPictureLayouter().GetRect(t));

            RecalcBox();
        }

        internal void ClearItems()
        {
            _items.Clear();
            Invalidate();
        }

        private void Pictures_Resize(object sender, EventArgs e)
        {
            RecalcBox();
        }

        private void RecalcBox()
        {
            AutoScrollMinSize = new Size(BLKX + 16, BLKY * GetPictureLayouter().maxy);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowLic { get { return _showLic; } set { _showLic = value; Invalidate(); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowSize { get { return _showSize; } set { _showSize = value; Invalidate(); } }

        public PictureItem FindItemAt(Point location)
        {
            _selectedIndex = GetPictureLayouter().GetPos(location - new Size(AutoScrollPosition));
            if (_selectedIndex < 0)
            {
                return null;
            }
            else
            {
                return _items[_selectedIndex];
            }
        }
    }
}
