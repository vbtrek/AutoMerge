using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace AutoMerge.Standalone
{
  public partial class AutoMergeControl : UserControl
  {
    private const string DefaultTeamProjectName = "Intact iQ";

    private StandaloneServiceProvider _serviceProvider;
    private TfsTeamProjectCollection _tfs;
    private VersionControlServer _versionControl;
    private global::AutoMerge.ChangesetService _changesetService;
    private List<global::AutoMerge.ChangesetViewModel> _changesets;
    private int _selectedChangesetId;

    public AutoMergeControl()
    {
      InitializeComponent();
      _changesets = new List<global::AutoMerge.ChangesetViewModel>();
    }

    public void Initialize(StandaloneServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
      _tfs = serviceProvider.TfsConnection;
      _versionControl = _tfs.GetService<VersionControlServer>();
      _changesetService = new global::AutoMerge.ChangesetService(_versionControl);
      cmbMergeMode.SelectedIndex = 0;

      InitializeAsync();
    }

    public void ConnectedStatusMessage(string message)
    {
      toolStripStatusLabel1.Text = message;
    }

    private async Task InitializeAsync()
    {
      try
      {
        lblStatus.Text = "Loading changesets...";
        await LoadRecentChangesetsAsync();
        lblStatus.Text = "Ready";
      }
      catch (Exception ex)
      {
        lblStatus.Text = $"Error: {ex.Message}";
        MessageBox.Show($"Failed to initialize:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async Task LoadRecentChangesetsAsync()
    {
      var changesetProvider = new global::AutoMerge.MyChangesetChangesetProvider(
          _changesetService,
          DefaultTeamProjectName,
          global::AutoMerge.Settings.Instance.ChangesetCount,
          true);

      _changesets = await changesetProvider.GetChangesets(_versionControl.AuthorizedUser);

      UpdateChangesetsView();
    }

    private void UpdateChangesetsView()
    {
      lstChangesets.Items.Clear();

      foreach (var changeset in _changesets)
      {
        var item = new ListViewItem(changeset.ChangesetId.ToString());

        item.SubItems.Add("");

        item.SubItems.Add(TruncateComment(changeset.Comment) + (string.IsNullOrWhiteSpace(changeset.DisplayBranchName) ? string.Empty : $" [{changeset.DisplayBranchName}]"));

        item.Tag = changeset;

        lstChangesets.Items.Add(item);
      }

      if (lstChangesets.Items.Count > 0)
      {
        lstChangesets.Items[0].Selected = true;
      }
    }

    private async Task UpdateBranchesViewAsync()
    {
      try
      {
        lstBranches.Items.Clear();

        lblStatus.Text = $"Loading branches for changeset {_selectedChangesetId}...";

        var selectedChangeset = lstChangesets.SelectedItems.Count > 0
            ? lstChangesets.SelectedItems[0].Tag as global::AutoMerge.ChangesetViewModel
            : null;

        if (selectedChangeset != null)
        {
          var workspaces = _versionControl.QueryWorkspaces(null, _tfs.AuthorizedIdentity.UniqueName, Environment.MachineName);
          var workspace = workspaces.Length == 0
              ? null
              : global::AutoMerge.WorkspaceHelper.GetWorkspace(_versionControl, workspaces);

          if (workspace != null)
          {
            var branches = await Task.Run(() =>
                global::AutoMerge.BranchesViewModel.GetBranches(
                    _tfs,
                    selectedChangeset,
                    workspace,
                    _changesetService,
                    new global::AutoMerge.Prism.Events.EventAggregator()));

            foreach (var branch in branches)
            {
              var branchText = branch.DisplayBranchName;

              var type = "Target";

              if (branch.IsSourceBranch)
              {
                continue; // TODO_DS1 Skip source branches for now, as they can't be merged to
                //branchText += " (source)";
                //type = "Source";
              }

              var item = new ListViewItem(branchText) { Checked = !branch.IsSourceBranch && branch.Checked };

              item.SubItems.Add(type);

              item.SubItems.Add(branch.ValidationMessage ?? string.Empty);

              item.Tag = branch;

              if (branch.ValidationResult != BranchValidationResult.Success)
              {
                item.ForeColor = System.Drawing.Color.Gray;
              }

              lstBranches.Items.Add(item);
            }
          }
          else
          {
            lblStatus.Text = "No workspace found. Create/map a TFVC workspace and refresh.";
          }
        }

        UpdateMergeButton();

        if (lblStatus.Text != "No workspace found. Create/map a TFVC workspace and refresh.")
        {
          lblStatus.Text = "Ready";
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex);
        lblStatus.Text = "Error loading branches";
        MessageBox.Show($"Failed to load branches:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private string TruncateComment(string comment)
    {
      if (string.IsNullOrEmpty(comment))
        return "";

      var firstLine = comment.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
      return firstLine.Length > 80 ? firstLine.Substring(0, 77) + "..." : firstLine;
    }

    private async void lstChangesets_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lstChangesets.SelectedItems.Count > 0)
      {
        var changeset = lstChangesets.SelectedItems[0].Tag as global::AutoMerge.ChangesetViewModel;

        if (changeset != null)
        {
          _selectedChangesetId = changeset.ChangesetId;

          await UpdateBranchesViewAsync();
        }
      }
    }

    private void lstBranches_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      UpdateMergeButton();
    }

    private void lstBranches_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (e.Item.Tag is MergeInfoViewModel branch)
      {
        if (branch.ValidationResult != BranchValidationResult.Success)
          e.Item.Selected = false;
      }
    }

    private void lstBranches_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (lstBranches.Items[e.Index].Tag is MergeInfoViewModel branch)
      {
        if (branch.ValidationResult != BranchValidationResult.Success)
          e.NewValue = e.CurrentValue;
      }
    }

    private void UpdateMergeButton()
    {
      btnMerge.Enabled = lstBranches.CheckedItems.Count > 0;
    }

    private async void btnMerge_Click(object sender, EventArgs e)
    {
      try
      {
        btnMerge.Enabled = false;
        lblStatus.Text = "Merging...";

        // TODO_DS1 Placeholder for merge operation
        await Task.Delay(1000);

        lblStatus.Text = "Merge completed";
        MessageBox.Show("Merge operation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        lblStatus.Text = "Merge failed";
        MessageBox.Show($"Merge failed:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        btnMerge.Enabled = true;
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      InitializeAsync();
    }

    private void btnAddById_Click(object sender, EventArgs e)
    {
      using (var form = new AddChangesetByIdDialog())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          var changesetId = form.ChangesetId;
          AddChangesetByIdAsync(changesetId);
        }
      }
    }

    private async void AddChangesetByIdAsync(int changesetId)
    {
      try
      {
        lblStatus.Text = $"Loading changeset {changesetId}...";

        var changesetProvider = new global::AutoMerge.ChangesetByIdChangesetProvider(_changesetService, new[] { changesetId });
        var changesets = await changesetProvider.GetChangesets(null);
        if (changesets.Count > 0)
        {
          _changesets.Add(changesets[0]);
        }

        UpdateChangesetsView();

        var items = lstChangesets.Items.Cast<ListViewItem>()
            .Where(i => ((global::AutoMerge.ChangesetViewModel)i.Tag).ChangesetId == changesetId).ToArray();
        if (items.Length > 0)
        {
          items[0].Selected = true;
          items[0].EnsureVisible();
        }

        lblStatus.Text = "Ready";
      }
      catch (Exception ex)
      {
        lblStatus.Text = "Error loading changeset";
        MessageBox.Show($"Failed to load changeset:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
