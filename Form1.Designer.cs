namespace SozaiForms {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bwSearch = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mDeleteCache = new System.Windows.Forms.ToolStripMenuItem();
            this.mDirs = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenPictures = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowLic = new System.Windows.Forms.ToolStripMenuItem();
            this.pictures1 = new SozaiForms.PicturesControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "キーワード:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(89, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(801, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(896, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bwSearch
            // 
            this.bwSearch.WorkerReportsProgress = true;
            this.bwSearch.WorkerSupportsCancellation = true;
            this.bwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSearch_DoWork);
            this.bwSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSearch_ProgressChanged);
            this.bwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSearch_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDeleteCache,
            this.mDirs,
            this.mOpenPictures,
            this.mShowLic});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mDeleteCache
            // 
            this.mDeleteCache.Name = "mDeleteCache";
            this.mDeleteCache.Size = new System.Drawing.Size(145, 29);
            this.mDeleteCache.Text = "キャッシュ削除(&X)";
            this.mDeleteCache.Click += new System.EventHandler(this.mDeleteCache_Click);
            // 
            // mDirs
            // 
            this.mDirs.Name = "mDirs";
            this.mDirs.Size = new System.Drawing.Size(114, 29);
            this.mDirs.Text = "&Edit Dirs.txt";
            this.mDirs.Click += new System.EventHandler(this.mDirs_Click);
            // 
            // mOpenPictures
            // 
            this.mOpenPictures.Name = "mOpenPictures";
            this.mOpenPictures.Size = new System.Drawing.Size(134, 29);
            this.mOpenPictures.Text = "&Open Pictures";
            this.mOpenPictures.Click += new System.EventHandler(this.mOpenPictures_Click);
            // 
            // mShowLic
            // 
            this.mShowLic.Name = "mShowLic";
            this.mShowLic.Size = new System.Drawing.Size(93, 29);
            this.mShowLic.Text = "Show &Lic";
            this.mShowLic.Click += new System.EventHandler(this.mShowLic_Click);
            // 
            // pictures1
            // 
            this.pictures1.AutoScroll = true;
            this.pictures1.AutoScrollMinSize = new System.Drawing.Size(66, 0);
            this.pictures1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictures1.Location = new System.Drawing.Point(0, 76);
            this.pictures1.Margin = new System.Windows.Forms.Padding(3, 7718, 3, 7718);
            this.pictures1.Name = "pictures1";
            this.pictures1.ShowLic = false;
            this.pictures1.ShowSize = true;
            this.pictures1.Size = new System.Drawing.Size(957, 274);
            this.pictures1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(957, 350);
            this.Controls.Add(this.pictures1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "素材";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bwSearch;
        private PicturesControl pictures1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mDeleteCache;
        private System.Windows.Forms.ToolStripMenuItem mDirs;
        private System.Windows.Forms.ToolStripMenuItem mOpenPictures;
        private System.Windows.Forms.ToolStripMenuItem mShowLic;
    }
}

