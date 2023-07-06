using kenjiuno.AutoHourglass;
using PicSozai;
using SozaiForms.Helpers;
using SozaiForms.Properties;
using SozaiForms.Usecases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SozaiForms
{
    public partial class Form1 : Form
    {
        private readonly LicenseInfoManagerUsecase _licenseInfoManagerUsecase;
        private readonly FileListManagerUsecase _fileListManagerUsecase;
        private readonly RenderFileToBitmapUsecase _renderFileToBitmapUsecase;
        private readonly ExtractIconUsecase _extractIconUsecase;
        private readonly SplitBitmapUsecase _splitBitmapUsecase;
        private readonly string _dirsFile;
        private readonly string _defaultInstallDir;
        private Task _task = null;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1(
            SplitBitmapUsecase splitBitmapUsecase,
            ExtractIconUsecase extractIconUsecase,
            RenderFileToBitmapUsecase renderFileToBitmapUsecase,
            FileListManagerUsecase fileListManagerUsecase,
            LicenseInfoManagerUsecase licenseInfoManagerUsecase
        )
        {
            _licenseInfoManagerUsecase = licenseInfoManagerUsecase;
            _fileListManagerUsecase = fileListManagerUsecase;
            _renderFileToBitmapUsecase = renderFileToBitmapUsecase;
            _extractIconUsecase = extractIconUsecase;
            _splitBitmapUsecase = splitBitmapUsecase;
            _dirsFile = Path.Combine(Application.StartupPath, "Dirs.txt");
            _defaultInstallDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SozaiForms");
            Directory.CreateDirectory(_defaultInstallDir);

            InitializeComponent();
        }

        private void SetEnabled(bool f)
        {
            _clearCache.Enabled = f;
            _searchNow.Enabled = f;
        }

        private string[] GetValidDirs()
        {
            return new string[] { _defaultInstallDir }
                .Concat(File.ReadAllLines(_dirsFile))
                .Where(dir => !string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                .ToArray();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _cts.Cancel();
                _searchNow_Click(sender, e);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void pictures1_Split(object sender, Helpers.SplitEventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(e.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            try
            {
                int n = 1;
                foreach (var pic in _splitBitmapUsecase.Split(e.FilePath))
                {
                    pic.Save(Path.Combine(dir, n + ".png"));
                    n++;
                }

                Process.Start(dir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー\n\n" + ex);
            }
        }

        private void pictures1_Pick(object sender, Helpers.PickEventArgs e)
        {
            File.Copy(
                e.FilePath,
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Path.GetFileName(e.FilePath)
                ),
                true
            );
        }

        private void pictures1_Explode(object sender, Helpers.FileSelectedEventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(e.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            foreach (var res in _extractIconUsecase.LoadIcos(new String[] { e.FilePath }))
            {
                res.pic.Save(Path.Combine(dir, res.fn + ".png"));
            }

            Process.Start(dir);
        }

        private void pictures1_SaveAs(object sender, Helpers.FileSelectedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileName(e.FilePath);
            sfd.DefaultExt = Path.GetExtension(sfd.FileName);
            sfd.Filter = string.Format("{0}|{0}", "*" + Path.GetExtension(sfd.FileName));
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                File.Copy(e.FilePath, sfd.FileName, true);
            }
        }

        private void installMenu_DropDownOpening(object sender, EventArgs e)
        {
        }

        private void OpenInstallFolder(object sender, EventArgs e)
        {
            Process.Start(_defaultInstallDir);
        }

        private void InstallZip(object sender, EventArgs e)
        {
            var zipFile = (string)((ToolStripItem)sender).Tag;
            if (File.Exists(zipFile))
            {
                using (new AH())
                {
                    var dirSaveTo = Path.Combine(_defaultInstallDir, Path.GetFileNameWithoutExtension(zipFile));
                    Directory.CreateDirectory(dirSaveTo);
                    ZipFile.ExtractToDirectory(zipFile, dirSaveTo, Encoding.GetEncoding(932));
                    _clearCache_Click(_clearCache, e);
                    Process.Start(dirSaveTo);
                }
            }
        }

        private void pictures1_SvgRender(object sender, Helpers.SvgRenderEventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(e.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            if (e.Render != null)
            {
                foreach (var size in new int[] { 16, 32, 48, 64, 96, 128, 256, })
                {
                    e.Render(size).Save(Path.Combine(dir, $"{size}.png"));
                }
            }

            Process.Start(dir);
        }

        private void _clearCache_Click(object sender, EventArgs e)
        {
            var next = GetTask();

            async Task RunAsync()
            {
                try
                {
                    await next;
                }
                finally
                {
                    _fileListManagerUsecase.DeleteCache();
                    _licenseInfoManagerUsecase.DeleteCache();
                    textBox1.Select();
                }
            }

            SetTask(RunAsync());
        }

        private Task GetTask()
        {
            if (_task == null || _task.IsCompleted)
            {
                return Task.CompletedTask;
            }
            else
            {
                return _task;
            }
        }

        private void _editDirs_Click(object sender, EventArgs e)
        {
            Process.Start(_dirsFile);

        }

        private void _openPictures_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

        }

        private void _toggle_Click(object sender, EventArgs e)
        {
            _pictures.ShowLic = !_pictures.ShowLic;
            _pictures.ShowSize = !_pictures.ShowSize;

        }

        private void installMenu_Click(object sender, EventArgs e)
        {

        }

        private void _installMaterials_DropDownOpening(object sender, EventArgs e)
        {
            _installMaterials.DropDownItems.Clear();

            {
                var item = _installMaterials.DropDownItems.Add(
                    "インストール先を開く...",
                    null,
                    OpenInstallFolder
                );
            }

            _installMaterials.DropDownItems.Add(new ToolStripSeparator());

            using (new AH())
            {
                var zipFiles = new List<string>();
                foreach (var source in Settings.Default.InstallSources.Replace("\r\n", "\n").Split('\n'))
                {
                    if (Directory.Exists(source))
                    {
                        zipFiles.AddRange(Directory.GetFiles(source, "*.zip"));
                    }
                }

                foreach (var zipFile in zipFiles)
                {
                    var item = _installMaterials.DropDownItems.Add(
                        Path.GetFileName(zipFile),
                        null,
                        InstallZip
                    );
                    item.Tag = zipFile;
                }
            }

        }

        private void _searchNow_Click(object sender, EventArgs e)
        {
            var next = GetTask();

            async Task RunAsync()
            {
                await next;

                _pictures.ClearItems();

                SetEnabled(false);
                try
                {
                    _cts = new CancellationTokenSource();
                    await Task.Run(() => Search(textBox1.Text, _cts.Token));
                }
                finally
                {
                    SetEnabled(true);
                }
            }

            SetTask(RunAsync());
        }

        private void SetTask(Task task)
        {
            _task = task;

            _idle.Text = "実行中";

            task.GetAwaiter().OnCompleted(
                () =>
                {
                    if (ReferenceEquals(task, _task))
                    {
                        Invoke(
                            (Action)(
                                () =>
                                {
                                    _idle.Text = task.IsFaulted
                                        ? task.Exception + ""
                                        : "待機";
                                }
                            )
                        );
                    }
                }
            );
        }

        private void Search(string input, CancellationToken cancellationToken)
        {
            var keywords = Regex.Split(input.Trim(), "\\s+");

            var cache = _fileListManagerUsecase.TryToLoadFromCache()
                ?? _fileListManagerUsecase.CreateFileListFromAndSaveCache(GetValidDirs());

            var licenses = _licenseInfoManagerUsecase.TryToLoadFromCache()
                ?? _licenseInfoManagerUsecase.CreateFromAndSaveCache(GetValidDirs());

            foreach (var fp in cache.Split('\n'))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                bool any = false, all = true;
                foreach (var keyword in keywords)
                {
                    if (fp.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        any = true;
                    }
                    else
                    {
                        all = false;
                        break;
                    }
                }
                if (any && all)
                {
                    var info = _renderFileToBitmapUsecase.Decide(fp);
                    if (info.CanLoad)
                    {
                        try
                        {
                            var picture = info.Load();

                            var newItem = new Item
                            {
                                Info = info,
                                FilePath = fp,
                                Picture = picture,
                                License = string.Join(
                                    "\n",
                                    licenses
                                        .Where(lic => fp.StartsWith(lic.Dir, StringComparison.InvariantCultureIgnoreCase))
                                        .Select(lic => lic.License)
                                ),
                                WidthRepresentation = info.IsSvg ? "svg" : picture.Width.ToString(),
                            };

                            Invoke(
                                (Action)(
                                    () =>
                                    {
                                        _pictures.Add(newItem);
                                        _pictures.Invalidate();
                                    }
                                )
                            );
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
