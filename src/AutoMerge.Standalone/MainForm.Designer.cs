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
      this.autoMergeControl1 = new AutoMerge.Standalone.AutoMergeControl();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtTfsUrl = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panelContent.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContent
      // 
      this.panelContent.Controls.Add(this.autoMergeControl1);
      this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelContent.Location = new System.Drawing.Point(0, 57);
      this.panelContent.Margin = new System.Windows.Forms.Padding(2);
      this.panelContent.Name = "panelContent";
      this.panelContent.Size = new System.Drawing.Size(1469, 625);
      this.panelContent.TabIndex = 0;
      // 
      // autoMergeControl1
      // 
      this.autoMergeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.autoMergeControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.autoMergeControl1.Location = new System.Drawing.Point(0, 0);
      this.autoMergeControl1.Margin = new System.Windows.Forms.Padding(2);
      this.autoMergeControl1.Name = "autoMergeControl1";
      this.autoMergeControl1.Size = new System.Drawing.Size(1469, 625);
      this.autoMergeControl1.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnConnect);
      this.panel1.Controls.Add(this.txtTfsUrl);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1469, 57);
      this.panel1.TabIndex = 1;
      // 
      // btnConnect
      // 
      this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnConnect.Location = new System.Drawing.Point(1381, 17);
      this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(77, 25);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // txtTfsUrl
      // 
      this.txtTfsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTfsUrl.Location = new System.Drawing.Point(79, 18);
      this.txtTfsUrl.Margin = new System.Windows.Forms.Padding(2);
      this.txtTfsUrl.Name = "txtTfsUrl";
      this.txtTfsUrl.Size = new System.Drawing.Size(1294, 23);
      this.txtTfsUrl.TabIndex = 1;
      this.txtTfsUrl.Text = "https://devops.intactsoftware.com/tfs";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 22);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "TFS URL:";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1469, 682);
      this.Controls.Add(this.panelContent);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "MainForm";
      this.Text = "AutoMerge - Standalone";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.panelContent.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtTfsUrl;
        private System.Windows.Forms.Label label1;
    private AutoMergeControl autoMergeControl1;
  }
}
