namespace AutoMerge.Standalone
{
    partial class AutoMergeControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.grpChangesets = new System.Windows.Forms.GroupBox();
      this.lstChangesets = new System.Windows.Forms.ListView();
      this.colChangesetId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colBranch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnAddById = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.grpBranches = new System.Windows.Forms.GroupBox();
      this.lstBranches = new System.Windows.Forms.ListView();
      this.colBranchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colValidation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel3 = new System.Windows.Forms.Panel();
      this.cmbMergeMode = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnMerge = new System.Windows.Forms.Button();
      this.statusStripControl = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.grpChangesets.SuspendLayout();
      this.panel2.SuspendLayout();
      this.grpBranches.SuspendLayout();
      this.panel3.SuspendLayout();
      this.statusStripControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.grpChangesets);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.grpBranches);
      this.splitContainer1.Size = new System.Drawing.Size(700, 539);
      this.splitContainer1.SplitterDistance = 232;
      this.splitContainer1.SplitterWidth = 3;
      this.splitContainer1.TabIndex = 0;
      // 
      // grpChangesets
      // 
      this.grpChangesets.Controls.Add(this.lstChangesets);
      this.grpChangesets.Controls.Add(this.panel2);
      this.grpChangesets.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpChangesets.Location = new System.Drawing.Point(0, 0);
      this.grpChangesets.Margin = new System.Windows.Forms.Padding(2);
      this.grpChangesets.Name = "grpChangesets";
      this.grpChangesets.Padding = new System.Windows.Forms.Padding(2);
      this.grpChangesets.Size = new System.Drawing.Size(700, 232);
      this.grpChangesets.TabIndex = 0;
      this.grpChangesets.TabStop = false;
      this.grpChangesets.Text = "Recent Changesets";
      // 
      // lstChangesets
      // 
      this.lstChangesets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChangesetId,
            this.colBranch,
            this.colComment});
      this.lstChangesets.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstChangesets.FullRowSelect = true;
      this.lstChangesets.HideSelection = false;
      this.lstChangesets.Location = new System.Drawing.Point(2, 51);
      this.lstChangesets.Margin = new System.Windows.Forms.Padding(2);
      this.lstChangesets.MultiSelect = false;
      this.lstChangesets.Name = "lstChangesets";
      this.lstChangesets.Size = new System.Drawing.Size(696, 179);
      this.lstChangesets.TabIndex = 0;
      this.lstChangesets.UseCompatibleStateImageBehavior = false;
      this.lstChangesets.View = System.Windows.Forms.View.Details;
      this.lstChangesets.SelectedIndexChanged += new System.EventHandler(this.lstChangesets_SelectedIndexChanged);
      // 
      // colChangesetId
      // 
      this.colChangesetId.Text = "ID";
      this.colChangesetId.Width = 80;
      // 
      // colBranch
      // 
      this.colBranch.Text = "Branch";
      this.colBranch.Width = 150;
      // 
      // colComment
      // 
      this.colComment.Text = "Comment";
      this.colComment.Width = 550;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnAddById);
      this.panel2.Controls.Add(this.btnRefresh);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(2, 18);
      this.panel2.Margin = new System.Windows.Forms.Padding(2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(696, 33);
      this.panel2.TabIndex = 1;
      // 
      // btnAddById
      // 
      this.btnAddById.Location = new System.Drawing.Point(88, 6);
      this.btnAddById.Margin = new System.Windows.Forms.Padding(2);
      this.btnAddById.Name = "btnAddById";
      this.btnAddById.Size = new System.Drawing.Size(79, 25);
      this.btnAddById.TabIndex = 1;
      this.btnAddById.Text = "Add By Id";
      this.btnAddById.UseVisualStyleBackColor = true;
      this.btnAddById.Click += new System.EventHandler(this.btnAddById_Click);
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(4, 6);
      this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(79, 25);
      this.btnRefresh.TabIndex = 0;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // grpBranches
      // 
      this.grpBranches.Controls.Add(this.lstBranches);
      this.grpBranches.Controls.Add(this.panel3);
      this.grpBranches.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpBranches.Location = new System.Drawing.Point(0, 0);
      this.grpBranches.Margin = new System.Windows.Forms.Padding(2);
      this.grpBranches.Name = "grpBranches";
      this.grpBranches.Padding = new System.Windows.Forms.Padding(2);
      this.grpBranches.Size = new System.Drawing.Size(700, 304);
      this.grpBranches.TabIndex = 0;
      this.grpBranches.TabStop = false;
      this.grpBranches.Text = "Branches";
      // 
      // lstBranches
      // 
      this.lstBranches.CheckBoxes = true;
      this.lstBranches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBranchName,
            this.colType,
            this.colValidation});
      this.lstBranches.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstBranches.FullRowSelect = true;
      this.lstBranches.HideSelection = false;
      this.lstBranches.Location = new System.Drawing.Point(2, 51);
      this.lstBranches.Margin = new System.Windows.Forms.Padding(2);
      this.lstBranches.Name = "lstBranches";
      this.lstBranches.Size = new System.Drawing.Size(696, 251);
      this.lstBranches.TabIndex = 0;
      this.lstBranches.UseCompatibleStateImageBehavior = false;
      this.lstBranches.View = System.Windows.Forms.View.Details;
      this.lstBranches.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstBranches_ItemCheck);
      this.lstBranches.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstBranches_ItemChecked);
      this.lstBranches.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstBranches_ItemSelectionChanged);
      // 
      // colBranchName
      // 
      this.colBranchName.Text = "Branch Name";
      this.colBranchName.Width = 300;
      // 
      // colType
      // 
      this.colType.Text = "Type";
      this.colType.Width = 100;
      // 
      // colValidation
      // 
      this.colValidation.Text = "Validation";
      this.colValidation.Width = 380;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.cmbMergeMode);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Controls.Add(this.btnMerge);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(2, 18);
      this.panel3.Margin = new System.Windows.Forms.Padding(2);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(696, 33);
      this.panel3.TabIndex = 1;
      // 
      // cmbMergeMode
      // 
      this.cmbMergeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMergeMode.FormattingEnabled = true;
      this.cmbMergeMode.Items.AddRange(new object[] {
            "Merge",
            "Merge and Check In"});
      this.cmbMergeMode.Location = new System.Drawing.Point(175, 7);
      this.cmbMergeMode.Margin = new System.Windows.Forms.Padding(2);
      this.cmbMergeMode.Name = "cmbMergeMode";
      this.cmbMergeMode.Size = new System.Drawing.Size(132, 23);
      this.cmbMergeMode.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(91, 10);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 15);
      this.label2.TabIndex = 1;
      this.label2.Text = "Merge Mode:";
      // 
      // btnMerge
      // 
      this.btnMerge.Enabled = false;
      this.btnMerge.Location = new System.Drawing.Point(4, 6);
      this.btnMerge.Margin = new System.Windows.Forms.Padding(2);
      this.btnMerge.Name = "btnMerge";
      this.btnMerge.Size = new System.Drawing.Size(79, 25);
      this.btnMerge.TabIndex = 0;
      this.btnMerge.Text = "Merge";
      this.btnMerge.UseVisualStyleBackColor = true;
      this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
      // 
      // statusStripControl
      // 
      this.statusStripControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatus});
      this.statusStripControl.Location = new System.Drawing.Point(0, 539);
      this.statusStripControl.Name = "statusStripControl";
      this.statusStripControl.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
      this.statusStripControl.Size = new System.Drawing.Size(700, 24);
      this.statusStripControl.TabIndex = 1;
      this.statusStripControl.Text = "statusStripControl";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 19);
      this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      // 
      // lblStatus
      // 
      this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.lblStatus.Size = new System.Drawing.Size(53, 19);
      this.lblStatus.Text = "Ready";
      // 
      // AutoMergeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.statusStripControl);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "AutoMergeControl";
      this.Size = new System.Drawing.Size(700, 563);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.grpChangesets.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.grpBranches.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.statusStripControl.ResumeLayout(false);
      this.statusStripControl.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpChangesets;
        private System.Windows.Forms.ListView lstChangesets;
        private System.Windows.Forms.ColumnHeader colChangesetId;
        private System.Windows.Forms.ColumnHeader colBranch;
        private System.Windows.Forms.ColumnHeader colComment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpBranches;
        private System.Windows.Forms.ListView lstBranches;
        private System.Windows.Forms.ColumnHeader colBranchName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colValidation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.StatusStrip statusStripControl;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnAddById;
        private System.Windows.Forms.ComboBox cmbMergeMode;
        private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
  }
}
