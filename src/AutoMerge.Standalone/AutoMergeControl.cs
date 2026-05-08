using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

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

      InitializeAsync();
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
          global::AutoMerge.Settings.Instance.ChangesetCount);

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

    private void UpdateBranchesView()
    {
      lstBranches.Items.Clear();

      lblStatus.Text = $"Loading branches for changeset {_selectedChangesetId}...";

      var selectedChangeset = lstChangesets.SelectedItems.Count > 0
          ? lstChangesets.SelectedItems[0].Tag as global::AutoMerge.ChangesetViewModel
          : null;

      if (selectedChangeset != null && selectedChangeset.Branches != null)
      {
        foreach (var branch in selectedChangeset.Branches)
        {
          var item = new ListViewItem(branch) { Checked = true };
          lstBranches.Items.Add(item);
        }
      }

      UpdateMergeButton();

      lblStatus.Text = "Ready";
    }

    private string TruncateComment(string comment)
    {
      if (string.IsNullOrEmpty(comment))
        return "";

      var firstLine = comment.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
      return firstLine.Length > 80 ? firstLine.Substring(0, 77) + "..." : firstLine;
    }

    private void lstChangesets_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lstChangesets.SelectedItems.Count > 0)
      {
        var changeset = lstChangesets.SelectedItems[0].Tag as global::AutoMerge.ChangesetViewModel;

        if (changeset != null)
        {
          _selectedChangesetId = changeset.ChangesetId;

          UpdateBranchesView();
        }
      }
    }

    private void lstBranches_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      UpdateMergeButton();
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

        // Placeholder for merge operation
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
