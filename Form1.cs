using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SozaiForms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string fpcache { get { return Path.Combine(Application.StartupPath, "CACHE.bin"); } }

        string fpdirs { get { return Path.Combine(Application.StartupPath, "Dirs.txt"); } }

        string[] Dirs {
            get {
                return File.ReadAllLines(fpdirs);
            }
        }

        class Lic {
            internal string dir;
            internal string license;
        }

        private void bwSearch_DoWork(object sender, DoWorkEventArgs e) {
            var keywords = Regex.Split(("" + e.Argument).Trim(), "\\s+");

            var cache = "";

            var fi = new FileInfo(fpcache);
            if (fi.Exists) {
                cache = File.ReadAllText(fi.FullName);
            }
            else {
                foreach (var dir in Dirs) {
                    if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir)) {
                        cache = cache + "\n" + string.Join("\n", Directory.GetFiles(dir, "*", SearchOption.AllDirectories));
                    }
                }
                File.WriteAllText(fi.FullName, cache);
            }

            List<Lic> lics = new List<SozaiForms.Form1.Lic>();

            foreach (var dir in Dirs) {
                if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir)) {
                    foreach (string fp in Directory.GetFiles(dir, "@*")) {
                        lics.Add(new Lic {
                            dir = dir,
                            license = Path.GetFileName(fp)
                        });
                    }
                }
            }

            foreach (var fp in cache.Split('\n')) {
                if (bwSearch.CancellationPending) {
                    return;
                }
                bool any = false, all = true;
                foreach (var keyword in keywords) {
                    if (fp.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) >= 0) {
                        any = true;
                    }
                    else {
                        all = false;
                        break;
                    }
                }
                if (any && all) {
                    var ext = Path.GetExtension(fp).ToLowerInvariant();
                    if ("/.bmp/.gif/.png/.jpg/.jpeg/.emf/.wmf/.ico/".Contains("/" + ext + "/")) {
                        try {
                            bwSearch.ReportProgress(-1, new Item {
                                ext = ext,
                                fp = fp,
                                pic = new Bitmap(new MemoryStream(File.ReadAllBytes(fp))),
                                license = String.Join("\n", lics
                                    .Where(lic => fp.StartsWith(lic.dir, StringComparison.InvariantCultureIgnoreCase))
                                    .Select(lic => lic.license)
                                    )
                            });
                        }
                        catch {

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (bwSearch.IsBusy) {
                bwSearch.CancelAsync();
                return;
            }
            pictures1.ClearItems();
            bwSearch.RunWorkerAsync(textBox1.Text);
            button1.Enabled = false;
        }

        private void bwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            button1.Enabled = true;
        }

        private void bwSearch_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == -1) {
                pictures1.Add((Item)e.UserState);
                pictures1.Invalidate();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                button1_Click(sender, e);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void mDeleteCache_Click(object sender, EventArgs e) {
            if (bwSearch.IsBusy) {
                return;
            }
            var fi = new FileInfo(fpcache);
            if (fi.Exists) {
                fi.Delete();
            }
            textBox1.Select();
        }

        private void mDirs_Click(object sender, EventArgs e) {
            Process.Start(fpdirs);
        }

        private void mOpenPictures_Click(object sender, EventArgs e) {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }

        private void mShowLic_Click(object sender, EventArgs e) {
            pictures1.ShowLic = !pictures1.ShowLic;
            pictures1.ShowSize = !pictures1.ShowSize;
        }
    }
}
