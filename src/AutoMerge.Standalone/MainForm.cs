using System;
using System.Windows.Forms;

namespace AutoMerge.Standalone
{
  public partial class MainForm : Form
  {
    private StandaloneServiceProvider _serviceProvider;
    private AutoMergeControl _autoMergeControl;

    public MainForm()
    {
      InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      try
      {
        btnConnect.Enabled = false;
        toolStripStatusLabel1.Text = "Connecting...";
        Application.DoEvents();

        // Create service provider with TFS connection
        _serviceProvider = new StandaloneServiceProvider(txtTfsUrl.Text);

        // Create the AutoMerge WinForms control
        _autoMergeControl = new AutoMergeControl();
        _autoMergeControl.Dock = DockStyle.Fill;

        // Add it to the panel
        panelContent.Controls.Clear();
        panelContent.Controls.Add(_autoMergeControl);

        // Initialize the control
        _autoMergeControl.Initialize(_serviceProvider);

        toolStripStatusLabel1.Text = $"Connected to {txtTfsUrl.Text}";
        txtTfsUrl.Enabled = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            $"Failed to connect to TFS:\n\n{ex.Message}",
            "Connection Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        toolStripStatusLabel1.Text = "Connection failed";
        btnConnect.Enabled = true;
      }
    }
  }
}
