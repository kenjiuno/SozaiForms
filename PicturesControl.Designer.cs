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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mExplode = new System.Windows.Forms.ToolStripMenuItem();
            this.mSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mPick = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mExplode,
            this.mSplit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 229);
            // 
            // mOpen
            // 
            this.mOpen.Name = "mOpen";
            this.mOpen.Size = new System.Drawing.Size(211, 30);
            this.mOpen.Text = "ひらく";
            this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
            // 
            // mFolder
            // 
            this.mFolder.Name = "mFolder";
            this.mFolder.Size = new System.Drawing.Size(211, 30);
            this.mFolder.Text = "親フォルダ";
            this.mFolder.Click += new System.EventHandler(this.mFolder_Click);
            // 
            // mSaveAs
            // 
            this.mSaveAs.Name = "mSaveAs";
            this.mSaveAs.Size = new System.Drawing.Size(211, 30);
            this.mSaveAs.Text = "名前をつけて保存";
            this.mSaveAs.Click += new System.EventHandler(this.mSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // mExplode
            // 
            this.mExplode.Name = "mExplode";
            this.mExplode.Size = new System.Drawing.Size(211, 30);
            this.mExplode.Text = "&Explode";
            this.mExplode.Click += new System.EventHandler(this.mExplode_Click);
            // 
            // mSplit
            // 
            this.mSplit.Name = "mSplit";
            this.mSplit.Size = new System.Drawing.Size(211, 30);
            this.mSplit.Text = "&Split";
            this.mSplit.Click += new System.EventHandler(this.mSplit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // mPick
            // 
            this.mPick.Name = "mPick";
            this.mPick.Size = new System.Drawing.Size(211, 30);
            this.mPick.Text = "Pick to Pictures";
            this.mPick.Click += new System.EventHandler(this.mPick_Click);
            // 
            // PicturesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "PicturesControl";
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
        private System.Windows.Forms.ToolStripMenuItem mExplode;
        private System.Windows.Forms.ToolStripMenuItem mSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mPick;
    }
}
