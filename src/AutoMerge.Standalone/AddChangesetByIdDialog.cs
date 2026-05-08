using System;
using System.Windows.Forms;

namespace AutoMerge.Standalone
{
    public partial class AddChangesetByIdDialog : Form
    {
        public int ChangesetId { get; private set; }

        public AddChangesetByIdDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtChangesetId.Text, out int id) && id > 0)
            {
                ChangesetId = id;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid changeset ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
