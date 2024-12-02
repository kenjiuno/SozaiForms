using kenjiuno.AutoHourglass;
using PicSozai;
using SozaiForms.Forms;
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
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SozaiForms.PicturesControl;

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
        private readonly Brush _iconBack = new SolidBrush(Color.FromArgb(222, 255, 255));
        private readonly Brush _svgBack = new SolidBrush(Color.FromArgb(255, 255, 222));
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private BitmapOrNot _selectedItem = null;
        private AppendableTaskWorker _appendableTaskWorker;
        private readonly char[] _pathSeparators = new char[] { '/', '\\' };

        public Form1(
            SplitBitmapUsecase splitBitmapUsecase,
            ExtractIconUsecase extractIconUsecase,
            RenderFileToBitmapUsecase renderFileToBitmapUsecase,
            FileListManagerUsecase fileListManagerUsecase,
            LicenseInfoManagerUsecase licenseInfoManagerUsecase,
            AppendableTaskWorker appendableTaskWorker
        )
        {
            _licenseInfoManagerUsecase = licenseInfoManagerUsecase;
            _fileListManagerUsecase = fileListManagerUsecase;
            _renderFileToBitmapUsecase = renderFileToBitmapUsecase;
            _extractIconUsecase = extractIconUsecase;
            _splitBitmapUsecase = splitBitmapUsecase;
            _dirsFile = Path.Combine(Application.StartupPath, "Dirs.txt");
            File.Open(_dirsFile, FileMode.OpenOrCreate).Close();
            _defaultInstallDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SozaiForms");
            Directory.CreateDirectory(_defaultInstallDir);

            InitializeComponent();

            _appendableTaskWorker = appendableTaskWorker;
            _appendableTaskWorker.OnStarted += () =>
            {
                _idle.Text = "実行中";
            };
            _appendableTaskWorker.OnCompleted += task =>
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
            };
        }

        private void SetEnabled(bool f)
        {
            _clearCache.Enabled = f;
            _searchNow.Enabled = f;
            _installMaterials.Enabled = f;
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

        private void OpenInstallFolder(object sender, EventArgs e)
        {
            Process.Start(_defaultInstallDir);
        }

        private void InstallZip(object sender, EventArgs e)
        {
            var zipFile = (string)((ToolStripItem)sender).Tag;
            if (File.Exists(zipFile))
            {
                if (MessageBox.Show(this, $"{zipFile} を直ちにインストールしますか", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var form = new InstallForm();
                    form._message.Text = $"{Path.GetFileName(zipFile)} をインストールしています。";
                    form.Show(this);

                    _appendableTaskWorker.Run(
                        async previous =>
                        {
                            await previous;

                            SetEnabled(false);
                            try
                            {
                                try
                                {
                                    var dirSaveTo = Path.Combine(_defaultInstallDir, Path.GetFileNameWithoutExtension(zipFile));

                                    await Task.Run(
                                        () =>
                                        {
                                            Directory.CreateDirectory(dirSaveTo);
                                            ZipFile.ExtractToDirectory(zipFile, dirSaveTo, Encoding.GetEncoding(932));
                                        }
                                    );

                                    _clearCache_Click(_clearCache, e);
                                    Process.Start(dirSaveTo);
                                    form.Dispose();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("エラー\n\n" + ex);
                                    ExceptionDispatchInfo.Capture(ex).Throw();
                                    throw;
                                }
                            }
                            finally
                            {
                                SetEnabled(true);
                            }
                        }
                    );
                }
            }
        }

        private void _clearCache_Click(object sender, EventArgs e)
        {
            _appendableTaskWorker.Run(
                async previous =>
                {
                    try
                    {
                        await previous;
                    }
                    finally
                    {
                        _fileListManagerUsecase.DeleteCache();
                        _licenseInfoManagerUsecase.DeleteCache();
                        textBox1.Select();
                    }
                }
            );
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
            _appendableTaskWorker.Run(
            async previous =>
                {
                    await previous;

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
                var name = GetNameOnly(fp);
                bool any = false, all = true;
                foreach (var keyword in keywords)
                {
                    if (name.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) >= 0)
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

                            var newItem = new PictureItem
                            {
                                Tag = info,
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

        private string GetNameOnly(string filePath)
        {
            var yenAt = filePath.LastIndexOfAny(_pathSeparators);
            var fileName = yenAt < 0 ? filePath : filePath.Substring(yenAt + 1);
            var periodAt = fileName.IndexOf('.');
            return periodAt < 0 ? fileName : fileName.Substring(0, periodAt);
        }

        private void _openSozai_Click(object sender, EventArgs e)
        {
            Process.Start(_selectedItem.FilePath);
        }

        private void _pictures_MouseDown(object sender, MouseEventArgs e)
        {
            if (true
                && _pictures.FindItemAt(e.Location) is PictureItem pictureItem
                && pictureItem.GetInfo() is BitmapOrNot info
            )
            {
                if (e.Button == MouseButtons.Left)
                {
                    DoDragDrop(
                        new DataObject(
                            DataFormats.FileDrop,
                            new string[] { info.FilePath }
                        ),
                        DragDropEffects.Copy | DragDropEffects.Link
                    );
                }
                else if (e.Button == MouseButtons.Right)
                {
                    _selectedItem = info;
                    _explode.Enabled = info.IsIcon;
                    _svgRender.Enabled = info.IsSvg;
                    _split.Enabled = !info.IsSvg;
                    _sozaiMenu.Show(_pictures.PointToScreen(e.Location));
                }
            }
        }

        private void _openSozaiParent_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"/select,\"{_selectedItem.FilePath}\"");

        }

        private void _saveAs_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileName(_selectedItem.FilePath);
            sfd.DefaultExt = Path.GetExtension(sfd.FileName);
            sfd.Filter = string.Format("{0}|{0}", "*" + Path.GetExtension(sfd.FileName));
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                File.Copy(_selectedItem.FilePath, sfd.FileName, true);
            }
        }

        private void _pick_Click(object sender, EventArgs e)
        {
            File.Copy(
                _selectedItem.FilePath,
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Path.GetFileName(_selectedItem.FilePath)
                ),
                true
            );
        }

        private void _explode_Click(object sender, EventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(_selectedItem.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            foreach (var res in _extractIconUsecase.LoadIcos(new String[] { _selectedItem.FilePath }))
            {
                res.pic.Save(Path.Combine(dir, res.fn + ".png"));
            }

            Process.Start(dir);
        }

        private void _svgRender_Click(object sender, EventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(_selectedItem.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            if (_selectedItem.RenderSvg != null)
            {
                foreach (var size in new int[] { 16, 32, 48, 64, 96, 128, 256, })
                {
                    _selectedItem.RenderSvg(size).Save(Path.Combine(dir, $"{size}.png"));
                }
            }

            Process.Start(dir);
        }

        private void _split_Click(object sender, EventArgs e)
        {
            var dir = Path.Combine(Path.GetTempPath(), Path.GetFileName(_selectedItem.FilePath) + "_" + DateTime.Now.Ticks);
            Directory.CreateDirectory(dir);

            try
            {
                int n = 1;
                foreach (var pic in _splitBitmapUsecase.Split(_selectedItem.FilePath))
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

        private void _pictures_FillBackground(object sender, FillBackgroundEventArgs e)
        {
            var cv = e.Graphics;
            var info = e.PictureItem.GetInfo();

            if (false) { }
            else if (info.IsIcon)
            {
                cv.FillRectangle(_iconBack, e.Rectangle);
            }
            else if (info.IsSvg)
            {
                cv.FillRectangle(_svgBack, e.Rectangle);
            }
        }
    }
}
