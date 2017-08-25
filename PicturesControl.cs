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

namespace SozaiForms {
    public partial class PicturesControl : UserControl {
        public PicturesControl() {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        StringFormat sfBR = new StringFormat {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Far,
        };
        StringFormat sfBL = new StringFormat {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Far,
        };

        const int BLKX = 48 + 2;
        const int BLKY = 56 + 2;

        class PictureLayouter {
            public int cx;
            public int cy;
            public int maxy;
            public int count;

            public Rectangle getRect(int t) {
                return new Rectangle((t % cx) * BLKX, (t / cx) * BLKY, BLKX, BLKY);
            }

            public int getPos(Point point) {
                int x = point.X / BLKX;
                int y = point.Y / BLKY;
                int t = x + cx * y;
                if (point.X < 0 || point.Y < 0 || BLKX * cx < point.X || t >= count) {
                    return -1;
                }
                return t;
            }
        }

        PictureLayouter getPictureLayouter() {
            var size = ClientSize;
            int cx = Math.Max(1, size.Width / BLKX);
            int cy = size.Height / BLKY;

            return new PictureLayouter {
                cx = cx,
                cy = cy,
                maxy = (items.Count + cx - 1) / cx,
                count = items.Count,
            };
        }

        private void Pictures_Load(object sender, EventArgs e) {

        }

        List<Item> items = new List<Item>();

        static Brush backIco = new SolidBrush(Color.FromArgb(222, 255, 255));
        static Font smallFont = new Font("Arial", 5);

        private void Pictures_Paint(object sender, PaintEventArgs e) {
            var pictureLayouter = getPictureLayouter();
            var cv = e.Graphics;
            for (int t = 0; t < items.Count; t++) {
                var item = items[t];
                Rectangle rcMax = pictureLayouter.getRect(t);
                rcMax.Offset(0, AutoScrollPosition.Y);

                if (e.ClipRectangle.IntersectsWith(rcMax)) {
                    if (item.isIco) {
                        cv.FillRectangle(backIco, rcMax);
                    }
                    var newRect = FitRect3.Fit(rcMax, item.pic.Size);
                    cv.DrawImage(item.pic, newRect);
                    cv.DrawLines(Pens.Gray, new Point[] {
                        new Point(rcMax.X, rcMax.Bottom - 1),
                        new Point(rcMax.Right - 1, rcMax.Bottom - 1),
                        new Point(rcMax.Right - 1, rcMax.Y)
                    });
                    var rcMaxM1 = rcMax;
                    rcMaxM1.Width--;
                    rcMaxM1.Height--;
                    if (ShowSize) {
                        cv.DrawString(item.width + "", smallFont, Brushes.Green, rcMaxM1, sfBR);
                    }
                    if (showLic) {
                        cv.DrawString(item.license, smallFont, Brushes.Green, rcMaxM1);
                    }
                }
            }
        }

        internal void Add(Item item) {
            int t = items.Count;

            items.Add(item);

            Invalidate(getPictureLayouter().getRect(t));

            rebox();
        }

        internal void ClearItems() {
            items.Clear();
            Invalidate();
        }

        private void Pictures_Resize(object sender, EventArgs e) {
            rebox();
        }

        void rebox() {
            AutoScrollMinSize = new Size(BLKX + 16, BLKY * getPictureLayouter().maxy);
        }

        int selectedIndex;

        Item selectedItem { get { return ((uint)selectedIndex >= (uint)items.Count) ? null : items[selectedIndex]; } }

        private void PicturesControl_MouseDown(object sender, MouseEventArgs e) {
            selectedIndex = getPictureLayouter().getPos(e.Location - new Size(AutoScrollPosition));
            if (selectedIndex < 0) {
                return;
            }
            if (e.Button == MouseButtons.Left) {
                DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { selectedItem.fp }), DragDropEffects.Copy | DragDropEffects.Link);
            }
            else if (e.Button == MouseButtons.Right) {
                mExplode.Enabled = selectedItem.isIco;
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
        }

        private void mOpen_Click(object sender, EventArgs e) {
            Process.Start(selectedItem.fp);
        }

        private void mFolder_Click(object sender, EventArgs e) {
            Process.Start("explorer.exe", "/select,\"" + (selectedItem.fp) + "\"");
        }

        private void mSaveAs_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileName(selectedItem.fp);
            sfd.DefaultExt = Path.GetExtension(sfd.FileName);
            sfd.Filter = string.Format("{0}|{0}", "*" + Path.GetExtension(sfd.FileName));
            if (sfd.ShowDialog(this) == DialogResult.OK) {
                File.Copy(selectedItem.fp, sfd.FileName, true);
            }
        }

        private void mExplode_Click(object sender, EventArgs e) {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(selectedItem.fp) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            foreach (var res in EIUt.LoadIcos(new String[] { selectedItem.fp })) {
                res.pic.Save(Path.Combine(dir, res.fn + ".png"));
            }

            Process.Start(dir);
        }

        private void mSplit_Click(object sender, EventArgs e) {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(selectedItem.fp) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            int n = 1;
            foreach (var pic in UtSplit.Split(selectedItem.fp)) {
                pic.Save(Path.Combine(dir, n + ".png"));
                n++;
            }

            Process.Start(dir);
        }

        private void mPick_Click(object sender, EventArgs e) {
            File.Copy(selectedItem.fp, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), Path.GetFileName(selectedItem.fp)), true);
        }

        bool showLic = false;
        bool showSize = false;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Visible)]
        public bool ShowLic { get { return showLic; } set { showLic = value; Invalidate(); } }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Visible)]
        public bool ShowSize { get { return showSize; } set { showSize = value; Invalidate(); } }
    }
}
