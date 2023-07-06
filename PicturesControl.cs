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

        private readonly List<Item> _items = new List<Item>();

        private bool _showLic = false;
        private bool _showSize = false;
        private int _selectedIndex;

        private Item SelectedItem => ((uint)_selectedIndex >= (uint)_items.Count) ? null : _items[_selectedIndex];

        private const int BLKX = 48 + 2;
        private const int BLKY = 56 + 2;

        private static readonly Brush _iconBack = new SolidBrush(Color.FromArgb(222, 255, 255));
        private static readonly Brush _svgBack = new SolidBrush(Color.FromArgb(255, 255, 222));

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

        private void Pictures_Load(object sender, EventArgs e)
        {

        }

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
                    if (false) { }
                    else if (item.Info.IsIcon)
                    {
                        cv.FillRectangle(_iconBack, rcMax);
                    }
                    else if (item.Info.IsSvg)
                    {
                        cv.FillRectangle(_svgBack, rcMax);
                    }
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

        internal void Add(Item item)
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

        private void PicturesControl_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedIndex = GetPictureLayouter().GetPos(e.Location - new Size(AutoScrollPosition));
            if (_selectedIndex < 0)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { SelectedItem.FilePath }), DragDropEffects.Copy | DragDropEffects.Link);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _explode.Enabled = SelectedItem.Info.IsIcon;
                _svgRender.Enabled = SelectedItem.Info.IsSvg;
                _split.Enabled = !SelectedItem.Info.IsSvg;
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
        }

        private void mOpen_Click(object sender, EventArgs e)
        {
            Process.Start(SelectedItem.FilePath);
        }

        private void mFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select,\"" + (SelectedItem.FilePath) + "\"");
        }

        public event EventHandler<FileSelectedEventArgs> SaveAs;

        private void mSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs?.Invoke(this, new FileSelectedEventArgs(SelectedItem.FilePath));
        }

        public event EventHandler<FileSelectedEventArgs> Explode;

        private void mExplode_Click(object sender, EventArgs e)
        {
            Explode?.Invoke(this, new FileSelectedEventArgs(SelectedItem.FilePath));
        }

        public event EventHandler<SplitEventArgs> Split;

        private void mSplit_Click(object sender, EventArgs e)
        {
            Split?.Invoke(this, new SplitEventArgs(SelectedItem.FilePath));
        }

        public event EventHandler<PickEventArgs> Pick;

        private void mPick_Click(object sender, EventArgs e)
        {
            Pick?.Invoke(this, new PickEventArgs(SelectedItem.FilePath));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowLic { get { return _showLic; } set { _showLic = value; Invalidate(); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowSize { get { return _showSize; } set { _showSize = value; Invalidate(); } }

        public event EventHandler<SvgRenderEventArgs> SvgRender;

        private void _svgRender_Click(object sender, EventArgs e)
        {
            SvgRender?.Invoke(this, new SvgRenderEventArgs(SelectedItem.FilePath, SelectedItem.Info?.RenderSvg));
        }
    }
}
