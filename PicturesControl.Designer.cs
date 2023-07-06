namespace SozaiForms {
    partial class PicturesControl {
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mPick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._explode = new System.Windows.Forms.ToolStripMenuItem();
            this._svgRender = new System.Windows.Forms.ToolStripMenuItem();
            this._split = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpen,
            this.mFolder,
            this.mSaveAs,
            this.toolStripSeparator2,
            this.mPick,
            this.toolStripSeparator1,
            this._explode,
            this._svgRender,
            this._split});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 192);
            // 
            // mOpen
            // 
            this.mOpen.Name = "mOpen";
            this.mOpen.Size = new System.Drawing.Size(230, 22);
            this.mOpen.Text = "ひらく";
            this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
            // 
            // mFolder
            // 
            this.mFolder.Name = "mFolder";
            this.mFolder.Size = new System.Drawing.Size(230, 22);
            this.mFolder.Text = "親フォルダ";
            this.mFolder.Click += new System.EventHandler(this.mFolder_Click);
            // 
            // mSaveAs
            // 
            this.mSaveAs.Name = "mSaveAs";
            this.mSaveAs.Size = new System.Drawing.Size(230, 22);
            this.mSaveAs.Text = "名前をつけて保存";
            this.mSaveAs.Click += new System.EventHandler(this.mSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // mPick
            // 
            this.mPick.Name = "mPick";
            this.mPick.Size = new System.Drawing.Size(230, 22);
            this.mPick.Text = "ピクチャへコピー";
            this.mPick.Click += new System.EventHandler(this.mPick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // _explode
            // 
            this._explode.Name = "_explode";
            this._explode.Size = new System.Drawing.Size(230, 22);
            this._explode.Text = "アイコンファイルを解体(&E)";
            this._explode.Click += new System.EventHandler(this.mExplode_Click);
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
            this._split.Click += new System.EventHandler(this.mSplit_Click);
            // 
            // PicturesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PicturesControl";
            this.Size = new System.Drawing.Size(90, 100);
            this.Load += new System.EventHandler(this.Pictures_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Pictures_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicturesControl_MouseDown);
            this.Resize += new System.EventHandler(this.Pictures_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mOpen;
        private System.Windows.Forms.ToolStripMenuItem mFolder;
        private System.Windows.Forms.ToolStripMenuItem mSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _explode;
        private System.Windows.Forms.ToolStripMenuItem _split;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mPick;
        private System.Windows.Forms.ToolStripMenuItem _svgRender;
    }
}
