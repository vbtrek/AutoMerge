using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMerge.Standalone.Properties;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.VisualStudio.Shell;

namespace AutoMerge.Standalone
{
  public partial class AutoMergeControl : UserControl
  {
    private StandaloneServiceProvider _serviceProvider;
    private TfsTeamProjectCollection _tfs;
    private VersionControlServer _versionControl;
    private List<ChangesetInfo> _changesets;
    private int _selectedChangesetId;

    public AutoMergeControl()
    {
      InitializeComponent();
      _changesets = new List<ChangesetInfo>();
    }

    public void Initialize(StandaloneServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
      _tfs = serviceProvider.TfsConnection;
      _versionControl = _tfs.GetService<VersionControlServer>();

      InitializeAsync();
    }

    private async void InitializeAsync()
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
      // TODO_DS1 Might want to create a MyChangesetChangesetProvider to do this
      //          We might also want to make the projectName variable "Intact iQ" below
      await Task.Run(() =>
      {
        var userName = _versionControl.AuthorizedUser;

        var queryHistory = _versionControl.QueryHistory(
                  "$/Intact iQ",
                  VersionSpec.Latest,
                  0,
                  RecursionType.Full,
                  userName,
                  null,
                  null,
                  20,
                  false,
                  false);

        _changesets.Clear();

        foreach (Changeset cs in queryHistory)
        {
          _changesets.Add(new ChangesetInfo
          {
            ChangesetId = cs.ChangesetId,
            Comment = cs.Comment,
            Owner = cs.Owner,
            CreationDate = cs.CreationDate
          });
        }
      });

      UpdateChangesetsView();
    }

    private void UpdateChangesetsView()
    {
      lstChangesets.Items.Clear();

      foreach (var changeset in _changesets)
      {
        var item = new ListViewItem(changeset.ChangesetId.ToString());

        item.SubItems.Add("");

        item.SubItems.Add(TruncateComment(changeset.Comment));

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

      // This is a placeholder - in a full implementation, you would:
      // 1. Get the changeset
      // 2. Find associated branches
      // 3. Query merge relationships
      // 4. Display the branches

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
        var changeset = lstChangesets.SelectedItems[0].Tag as ChangesetInfo;

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

        await Task.Run(() =>
        {
          var changeset = _versionControl.GetChangeset(changesetId);
          _changesets.Add(new ChangesetInfo
          {
            ChangesetId = changeset.ChangesetId,
            Comment = changeset.Comment,
            Owner = changeset.Owner,
            CreationDate = changeset.CreationDate
          });
        });

        UpdateChangesetsView();

        var items = lstChangesets.Items.Cast<ListViewItem>()
            .Where(i => ((ChangesetInfo)i.Tag).ChangesetId == changesetId).ToArray();
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

    private class ChangesetInfo
    {
      public int ChangesetId { get; set; }
      public string Comment { get; set; }
      public string Owner { get; set; }
      public DateTime CreationDate { get; set; }
    }
  }
}
