namespace AutoMerge.Standalone
{
    partial class MainForm
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
      this.panelContent = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtTfsUrl = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContent
      // 
      this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelContent.Location = new System.Drawing.Point(0, 49);
      this.panelContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.panelContent.Name = "panelContent";
      this.panelContent.Size = new System.Drawing.Size(750, 483);
      this.panelContent.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnConnect);
      this.panel1.Controls.Add(this.txtTfsUrl);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(750, 49);
      this.panel1.TabIndex = 1;
      // 
      // btnConnect
      // 
      this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnConnect.Location = new System.Drawing.Point(675, 15);
      this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(66, 22);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // txtTfsUrl
      // 
      this.txtTfsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTfsUrl.Location = new System.Drawing.Point(68, 16);
      this.txtTfsUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.txtTfsUrl.Name = "txtTfsUrl";
      this.txtTfsUrl.Size = new System.Drawing.Size(601, 20);
      this.txtTfsUrl.TabIndex = 1;
      this.txtTfsUrl.Text = "https://devops.intactsoftware.com/tfs";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 19);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "TFS URL:";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 532);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
      this.statusStrip1.Size = new System.Drawing.Size(750, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 17);
      this.toolStripStatusLabel1.Text = "Not Connected";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(750, 554);
      this.Controls.Add(this.panelContent);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.statusStrip1);
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "MainForm";
      this.Text = "AutoMerge - Standalone";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtTfsUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
