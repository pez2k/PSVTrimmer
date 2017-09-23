namespace PSVTrimmer
{
    partial class PSVTrimmer
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
            this.btnTrim = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.fdInput = new System.Windows.Forms.OpenFileDialog();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTrim
            // 
            this.btnTrim.Location = new System.Drawing.Point(241, 39);
            this.btnTrim.Name = "btnTrim";
            this.btnTrim.Size = new System.Drawing.Size(75, 23);
            this.btnTrim.TabIndex = 0;
            this.btnTrim.Text = "Trim";
            this.btnTrim.UseVisualStyleBackColor = true;
            this.btnTrim.Click += new System.EventHandler(this.btnTrim_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 97);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(563, 160);
            this.lbLog.TabIndex = 1;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 13);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(530, 20);
            this.txtInput.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(549, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // PSVTrimmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 262);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnTrim);
            this.Name = "PSVTrimmer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrim;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.OpenFileDialog fdInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowse;
    }
}

