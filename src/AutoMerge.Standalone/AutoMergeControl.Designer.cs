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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpChangesets.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpBranches.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 578);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpChangesets
            // 
            this.grpChangesets.Controls.Add(this.lstChangesets);
            this.grpChangesets.Controls.Add(this.panel2);
            this.grpChangesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChangesets.Location = new System.Drawing.Point(0, 0);
            this.grpChangesets.Name = "grpChangesets";
            this.grpChangesets.Size = new System.Drawing.Size(800, 250);
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
            this.lstChangesets.Location = new System.Drawing.Point(3, 55);
            this.lstChangesets.MultiSelect = false;
            this.lstChangesets.Name = "lstChangesets";
            this.lstChangesets.Size = new System.Drawing.Size(794, 192);
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
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 36);
            this.panel2.TabIndex = 1;
            // 
            // btnAddById
            // 
            this.btnAddById.Location = new System.Drawing.Point(100, 6);
            this.btnAddById.Name = "btnAddById";
            this.btnAddById.Size = new System.Drawing.Size(90, 27);
            this.btnAddById.TabIndex = 1;
            this.btnAddById.Text = "Add By Id";
            this.btnAddById.UseVisualStyleBackColor = true;
            this.btnAddById.Click += new System.EventHandler(this.btnAddById_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(4, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 27);
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
            this.grpBranches.Name = "grpBranches";
            this.grpBranches.Size = new System.Drawing.Size(800, 324);
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
            this.lstBranches.Location = new System.Drawing.Point(3, 55);
            this.lstBranches.Name = "lstBranches";
            this.lstBranches.Size = new System.Drawing.Size(794, 266);
            this.lstBranches.TabIndex = 0;
            this.lstBranches.UseCompatibleStateImageBehavior = false;
            this.lstBranches.View = System.Windows.Forms.View.Details;
            this.lstBranches.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstBranches_ItemChecked);
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
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 36);
            this.panel3.TabIndex = 1;
            // 
            // cmbMergeMode
            // 
            this.cmbMergeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMergeMode.FormattingEnabled = true;
            this.cmbMergeMode.Items.AddRange(new object[] {
            "Merge",
            "Merge and Check In"});
            this.cmbMergeMode.Location = new System.Drawing.Point(200, 8);
            this.cmbMergeMode.Name = "cmbMergeMode";
            this.cmbMergeMode.Size = new System.Drawing.Size(150, 24);
            this.cmbMergeMode.TabIndex = 2;
            this.cmbMergeMode.SelectedIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Merge Mode:";
            // 
            // btnMerge
            // 
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(4, 6);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(90, 27);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "Ready";
            // 
            // AutoMergeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AutoMergeControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpChangesets.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpBranches.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnAddById;
        private System.Windows.Forms.ComboBox cmbMergeMode;
        private System.Windows.Forms.Label label2;
    }
}
