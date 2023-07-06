namespace SozaiForms
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._top = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._searchNow = new System.Windows.Forms.Button();
            this._root = new System.Windows.Forms.ToolStripContainer();
            this._bottom = new System.Windows.Forms.StatusStrip();
            this._idle = new System.Windows.Forms.ToolStripStatusLabel();
            this._pictures = new SozaiForms.PicturesControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._clearCache = new System.Windows.Forms.ToolStripButton();
            this._editDirs = new System.Windows.Forms.ToolStripButton();
            this._openPictures = new System.Windows.Forms.ToolStripButton();
            this._toggle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._installMaterials = new System.Windows.Forms.ToolStripDropDownButton();
            this._sozaiMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._openSozai = new System.Windows.Forms.ToolStripMenuItem();
            this._openSozaiParent = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._pick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._explode = new System.Windows.Forms.ToolStripMenuItem();
            this._svgRender = new System.Windows.Forms.ToolStripMenuItem();
            this._split = new System.Windows.Forms.ToolStripMenuItem();
            this._top.SuspendLayout();
            this._root.BottomToolStripPanel.SuspendLayout();
            this._root.ContentPanel.SuspendLayout();
            this._root.TopToolStripPanel.SuspendLayout();
            this._root.SuspendLayout();
            this._bottom.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this._sozaiMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _top
            // 
            this._top.AutoSize = true;
            this._top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._top.ColumnCount = 3;
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._top.Controls.Add(this.label1, 0, 0);
            this._top.Controls.Add(this.textBox1, 1, 0);
            this._top.Controls.Add(this._searchNow, 2, 0);
            this._top.Dock = System.Windows.Forms.DockStyle.Top;
            this._top.Location = new System.Drawing.Point(0, 0);
            this._top.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._top.Name = "_top";
            this._top.RowCount = 1;
            this._top.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._top.Size = new System.Drawing.Size(957, 33);
            this._top.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "キーワード:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(61, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(846, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // _searchNow
            // 
            this._searchNow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._searchNow.AutoSize = true;
            this._searchNow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._searchNow.Location = new System.Drawing.Point(913, 4);
            this._searchNow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._searchNow.Name = "_searchNow";
            this._searchNow.Size = new System.Drawing.Size(41, 25);
            this._searchNow.TabIndex = 2;
            this._searchNow.Text = "検索";
            this._searchNow.UseVisualStyleBackColor = true;
            this._searchNow.Click += new System.EventHandler(this._searchNow_Click);
            // 
            // _root
            // 
            // 
            // _root.BottomToolStripPanel
            // 
            this._root.BottomToolStripPanel.Controls.Add(this._bottom);
            // 
            // _root.ContentPanel
            // 
            this._root.ContentPanel.Controls.Add(this._pictures);
            this._root.ContentPanel.Controls.Add(this._top);
            this._root.ContentPanel.Size = new System.Drawing.Size(957, 303);
            this._root.Dock = System.Windows.Forms.DockStyle.Fill;
            this._root.Location = new System.Drawing.Point(0, 0);
            this._root.Name = "_root";
            this._root.Size = new System.Drawing.Size(957, 350);
            this._root.TabIndex = 3;
            this._root.Text = "toolStripContainer1";
            // 
            // _root.TopToolStripPanel
            // 
            this._root.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // _bottom
            // 
            this._bottom.Dock = System.Windows.Forms.DockStyle.None;
            this._bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._idle});
            this._bottom.Location = new System.Drawing.Point(0, 0);
            this._bottom.Name = "_bottom";
            this._bottom.Size = new System.Drawing.Size(957, 22);
            this._bottom.TabIndex = 0;
            // 
            // _idle
            // 
            this._idle.Name = "_idle";
            this._idle.Size = new System.Drawing.Size(16, 17);
            this._idle.Text = "...";
            // 
            // _pictures
            // 
            this._pictures.AutoScroll = true;
            this._pictures.AutoScrollMinSize = new System.Drawing.Size(66, 0);
            this._pictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictures.Location = new System.Drawing.Point(0, 33);
            this._pictures.Margin = new System.Windows.Forms.Padding(12, 46006, 12, 46006);
            this._pictures.Name = "_pictures";
            this._pictures.ShowLic = false;
            this._pictures.ShowSize = true;
            this._pictures.Size = new System.Drawing.Size(957, 270);
            this._pictures.TabIndex = 1;
            this._pictures.FillBackground += new System.EventHandler<SozaiForms.Helpers.FillBackgroundEventArgs>(this._pictures_FillBackground);
            this._pictures.MouseDown += new System.Windows.Forms.MouseEventHandler(this._pictures_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._clearCache,
            this._editDirs,
            this._openPictures,
            this._toggle,
            this.toolStripSeparator1,
            this._installMaterials});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(686, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // _clearCache
            // 
            this._clearCache.Image = ((System.Drawing.Image)(resources.GetObject("_clearCache.Image")));
            this._clearCache.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._clearCache.Name = "_clearCache";
            this._clearCache.Size = new System.Drawing.Size(109, 22);
            this._clearCache.Text = "キャッシュ削除(&X)";
            this._clearCache.Click += new System.EventHandler(this._clearCache_Click);
            // 
            // _editDirs
            // 
            this._editDirs.Image = ((System.Drawing.Image)(resources.GetObject("_editDirs.Image")));
            this._editDirs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._editDirs.Name = "_editDirs";
            this._editDirs.Size = new System.Drawing.Size(114, 22);
            this._editDirs.Text = "Dirs.txt を編集(&E)";
            this._editDirs.Click += new System.EventHandler(this._editDirs_Click);
            // 
            // _openPictures
            // 
            this._openPictures.Image = ((System.Drawing.Image)(resources.GetObject("_openPictures.Image")));
            this._openPictures.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._openPictures.Name = "_openPictures";
            this._openPictures.Size = new System.Drawing.Size(107, 22);
            this._openPictures.Text = "ピクチャを開く(&O)";
            this._openPictures.Click += new System.EventHandler(this._openPictures_Click);
            // 
            // _toggle
            // 
            this._toggle.Image = ((System.Drawing.Image)(resources.GetObject("_toggle.Image")));
            this._toggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toggle.Name = "_toggle";
            this._toggle.Size = new System.Drawing.Size(216, 22);
            this._toggle.Text = "ライセンスと画像サイズの表示オンオフ(&L)";
            this._toggle.Click += new System.EventHandler(this._toggle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _installMaterials
            // 
            this._installMaterials.Image = ((System.Drawing.Image)(resources.GetObject("_installMaterials.Image")));
            this._installMaterials.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._installMaterials.Name = "_installMaterials";
            this._installMaterials.Size = new System.Drawing.Size(122, 22);
            this._installMaterials.Text = "素材をインストール";
            this._installMaterials.DropDownOpening += new System.EventHandler(this._installMaterials_DropDownOpening);
            // 
            // _sozaiMenu
            // 
            this._sozaiMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._sozaiMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openSozai,
            this._openSozaiParent,
            this._saveAs,
            this.toolStripSeparator2,
            this._pick,
            this.toolStripSeparator3,
            this._explode,
            this._svgRender,
            this._split});
            this._sozaiMenu.Name = "contextMenuStrip1";
            this._sozaiMenu.Size = new System.Drawing.Size(231, 170);
            // 
            // _openSozai
            // 
            this._openSozai.Name = "_openSozai";
            this._openSozai.Size = new System.Drawing.Size(230, 22);
            this._openSozai.Text = "ひらく";
            this._openSozai.Click += new System.EventHandler(this._openSozai_Click);
            // 
            // _openSozaiParent
            // 
            this._openSozaiParent.Name = "_openSozaiParent";
            this._openSozaiParent.Size = new System.Drawing.Size(230, 22);
            this._openSozaiParent.Text = "親フォルダ";
            this._openSozaiParent.Click += new System.EventHandler(this._openSozaiParent_Click);
            // 
            // _saveAs
            // 
            this._saveAs.Name = "_saveAs";
            this._saveAs.Size = new System.Drawing.Size(230, 22);
            this._saveAs.Text = "名前をつけて保存";
            this._saveAs.Click += new System.EventHandler(this._saveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // _pick
            // 
            this._pick.Name = "_pick";
            this._pick.Size = new System.Drawing.Size(230, 22);
            this._pick.Text = "ピクチャへコピー";
            this._pick.Click += new System.EventHandler(this._pick_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(227, 6);
            // 
            // _explode
            // 
            this._explode.Name = "_explode";
            this._explode.Size = new System.Drawing.Size(230, 22);
            this._explode.Text = "アイコンファイルを解体(&E)";
            this._explode.Click += new System.EventHandler(this._explode_Click);
            // 
            // _svgRender
            // 
            this._svgRender.Name = "_svgRender";
            this._svgRender.Size = new System.Drawing.Size(230, 22);
            this._svgRender.Text = "S&VG を複数解像度でレンダリング";
            this._svgRender.Click += new System.EventHandler(this._svgRender_Click);
            // 
            // _split
            // 
            this._split.Name = "_split";
            this._split.Size = new System.Drawing.Size(230, 22);
            this._split.Text = "スプライト画像を分割(&S)";
            this._split.Click += new System.EventHandler(this._split_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(957, 350);
            this.Controls.Add(this._root);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "素材";
            this._top.ResumeLayout(false);
            this._top.PerformLayout();
            this._root.BottomToolStripPanel.ResumeLayout(false);
            this._root.BottomToolStripPanel.PerformLayout();
            this._root.ContentPanel.ResumeLayout(false);
            this._root.ContentPanel.PerformLayout();
            this._root.TopToolStripPanel.ResumeLayout(false);
            this._root.TopToolStripPanel.PerformLayout();
            this._root.ResumeLayout(false);
            this._root.PerformLayout();
            this._bottom.ResumeLayout(false);
            this._bottom.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._sozaiMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button _searchNow;
        private PicturesControl _pictures;
        private System.Windows.Forms.ToolStripContainer _root;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _clearCache;
        private System.Windows.Forms.ToolStripButton _editDirs;
        private System.Windows.Forms.ToolStripButton _openPictures;
        private System.Windows.Forms.ToolStripButton _toggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton _installMaterials;
        private System.Windows.Forms.StatusStrip _bottom;
        private System.Windows.Forms.ToolStripStatusLabel _idle;
        private System.Windows.Forms.ContextMenuStrip _sozaiMenu;
        private System.Windows.Forms.ToolStripMenuItem _openSozai;
        private System.Windows.Forms.ToolStripMenuItem _openSozaiParent;
        private System.Windows.Forms.ToolStripMenuItem _saveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _pick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _explode;
        private System.Windows.Forms.ToolStripMenuItem _svgRender;
        private System.Windows.Forms.ToolStripMenuItem _split;
    }
}

