namespace SozaiForms.Forms
{
    partial class InstallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _message
            // 
            this._message.Dock = System.Windows.Forms.DockStyle.Fill;
            this._message.Location = new System.Drawing.Point(0, 0);
            this._message.Name = "_message";
            this._message.Size = new System.Drawing.Size(558, 81);
            this._message.TabIndex = 0;
            this._message.Text = "...";
            this._message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstallForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(558, 81);
            this.Controls.Add(this._message);
            this.Name = "InstallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "お待ちください";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label _message;
    }
}