using System;
using System.Windows.Forms;

namespace AutoMerge.Standalone
{
  public partial class MainForm : Form
  {
    private StandaloneServiceProvider _serviceProvider;
    //TODO_DS1 private AutoMergeControl _autoMergeControl;

    public MainForm()
    {
      InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      try
      {
        btnConnect.Enabled = false;
        autoMergeControl1.ConnectedStatusMessage("Connecting...");
        //TODO_DS1 toolStripStatusLabel1.Text = "Connecting...";
        Application.DoEvents();

        // Create service provider with TFS connection
        _serviceProvider = new StandaloneServiceProvider(txtTfsUrl.Text);

        //// TODO_DS1 Create the AutoMerge WinForms control
        //_autoMergeControl = new AutoMergeControl();
        //_autoMergeControl.Dock = DockStyle.Fill;

        //// TODO_DS1 Add it to the panel
        //panelContent.Controls.Clear();
        //panelContent.Controls.Add(_autoMergeControl);

        // Initialize the control
        autoMergeControl1.Initialize(_serviceProvider);

        autoMergeControl1.ConnectedStatusMessage($"Connected to {txtTfsUrl.Text}");

        //TODO_DS1 toolStripStatusLabel1.Text = $"Connected to {txtTfsUrl.Text}";
        txtTfsUrl.Enabled = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            $"Failed to connect to TFS:\n\n{ex.Message}",
            "Connection Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        autoMergeControl1.ConnectedStatusMessage("Connection failed");
        //TODO_DS1 toolStripStatusLabel1.Text = "Connection failed";
        btnConnect.Enabled = true;
      }
    }

    // TODO_DS1 Change this to be an auto connect, no need for the button and txtbox
    private void MainForm_Load(object sender, EventArgs e)
    {
      btnConnect_Click(null, EventArgs.Empty);
    }
  }
}
